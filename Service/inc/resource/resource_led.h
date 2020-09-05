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

#ifndef __RESOURCE_LED_H__
#define __RESOURCE_LED_H__

/**
 * @brief Writes value of gpio connected led light
 * @param[in] pin_num The gpio pin number for the led light
 * @param[out] out_value The value of turniing the led light on/off
 * @return 0 on success, otherwise a negative error value
 * @see If the gpio pin is not open, create gpio handle before writing the value
 */
extern int resource_write_led(int pin_num, int write_value);

/**
 * @brief Releases the gpio handle
 */
extern void resource_close_led(void);

#endif /* __RESOURCE_LED_H__ */
