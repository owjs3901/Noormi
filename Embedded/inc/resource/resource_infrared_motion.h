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

#ifndef __RESOURCE_INFRARED_MOTION_H__
#define __RESOURCE_INFRARED_MOTION_H__

typedef void (*resource_infrared_motion_interrupted_cb) (uint32_t motion_value, void *user_data);

/**
 * @brief Reads value of gpio connected infrared motion sensor (HC-SR501)
 * @param[in] pin_num The gpio pin number for the infrared motion sensor
 * @param[out] out_value The value of the gpio (zero or non-zero)
 * @return 0 on success, otherwise a negative error value
 * @see If the gpio pin is not open, create gpio handle before reading the value
 */
extern int resource_read_infrared_motion(int pin_num, uint32_t *out_value);

/**
 * @brief Releases the gpio handle
 */
extern void resource_close_infrared_motion(void);

/**
 * @brief Sets an interrupted callback to be invoked when interrupt is triggered on motion sensor
 * @param[in] pin_num The gpio pin number for the infrared motion sensor
 * @param[in] interrupted_cb interrupted user callback to be invoked
 * @return 0 on success, otherwise a negative error value
 * @see If the gpio pin is not open, create gpio handle before reading the value
 */
extern int resource_set_interrupted_cb_infrared_motion(int pin_num, resource_infrared_motion_interrupted_cb interrupted_cb, void *user_data);

/**
 * @brief Unsets the interrupted callback for motion sensor
 * @param[in] pin_num The gpio pin number for the infrared motion sensor
 */
extern int resource_unset_interrupted_cb_infrared_motion(int pin_num);

#endif /* __RESOURCE_INFRARED_MOTION_H__ */
