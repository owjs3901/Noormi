/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#include <tizen.h>
#include <service_app.h>
#include <string.h>
#include <stdlib.h>
#include <stdint.h>
#include <time.h>
#include <Ecore.h>
#include "log.h"
#include "resource/resource_infrared_motion.h"
#include "resource/resource_led.h"
#include "network.h"

// Motion sensor information
#define SENSOR_MOTION_GPIO_NUMBER (18)

// LED sensor information
#define SENSOR_LED_GPIO_NUMBER (24)

time_t preTime;

int count = 0;

static int _change_led_state(int state) {


	int ret = 0;

	// Write state to LED light
	ret = resource_write_led(SENSOR_LED_GPIO_NUMBER, state);
	if (ret != 0) {
		_E("cannot write led data");
		return -1;
	}

//	_I("LED State : %s", state ? "ON":"OFF");

	return 0;
}

/*
 * 타이머 콜백 함수
 */
Eina_Bool timer_cb(void *data)
{
	time_t now;

	time(&now);

	_I("now : %d\npreTime : %d\nValue : %d",now, preTime, now - preTime); //디버깅용 코드

	/* 거리센서에서 인식이 될 경우 1~2초 동안 인식될때만 모터 동작.
	 * 그 이후에도 계속 손을 대고 있을경우에는 모터가 동작되지 않아 손소독제가 계속해서 나오는것을 방지.
	 */
	if(now - preTime > 1 && now - preTime <= 2){
		_change_led_state(1);
		_I("Work!");
		if(now - preTime == 2)
			connect_server();
	}
	else{
		_change_led_state(0);
		_I("NoT Work!");
	}

	return ECORE_CALLBACK_RENEW;
}


static void motion_interrupted_cb(uint32_t motion_value, void *user_data)
{
	//time 시작
	time(&preTime);

	return;
}


static bool service_app_create(void *user_data)
{
	ecore_timer_add(1, timer_cb, NULL);

	ecore_main_loop_begin();
	return true;
}

static void service_app_control(app_control_h app_control, void *user_data)
{
	int ret = 0;
	// Set an interrupted user callback to be invoked when interrupt is triggered on motion sensor
	ret = resource_set_interrupted_cb_infrared_motion(SENSOR_MOTION_GPIO_NUMBER, motion_interrupted_cb, NULL);
	if (ret != 0) {
		_E("cannot set interrupted callback for motion sensor");
		return;
	}
}

static void service_app_terminate(void *user_data)
{
	resource_unset_interrupted_cb_infrared_motion(SENSOR_MOTION_GPIO_NUMBER);

	// Turn off LED light with __set_led()
	_change_led_state(0);

	// Close Motion and LED resources
	resource_close_infrared_motion();
	resource_close_led();

	FN_END;
}


int main(int argc, char *argv[])
{

	_I("main func!!"); //디버깅용 코드

	service_app_lifecycle_callback_s event_callback;

	event_callback.create = service_app_create;
	event_callback.terminate = service_app_terminate;
	event_callback.app_control = service_app_control;


	return service_app_main(argc, argv, &event_callback, NULL);
}
