import { Request, Response, Router } from 'express';
import { BAD_REQUEST, CREATED, OK } from 'http-status-codes';
import { ParamsDictionary } from 'express-serve-static-core';

import { paramMissingError } from '@shared/constants';

import { IDevice } from "@entities/Device"

// Init shared
const router = Router();
const devices : IDevice[] = [{
    battery: 100,
    productName: "손소독제A",
    location: "1층 현관 앞",
    registerDate: "2020-09-05",
    lastDate: "2020-09-05",
    predictionDate: "1주일",
    count: 0
}];


/******************************************************************************
 *                      Get All Users - "GET /api/users/all"
 ******************************************************************************/

router.get('/all', async (req: Request, res: Response) => {
    return res.status(OK).json({devices});
});


router.get('/cost', async (req: Request, res: Response) => {
    devices[0].battery--;
    devices[0].count++;
    return res.status(OK).json({devices});
});


/******************************************************************************
 *                                     Export
 ******************************************************************************/

export default router;
