import { Router } from 'express';
import DeviceRouter from './Devices';

// Init router and path
const router = Router();

// Add sub-routes
router.use('/devices', DeviceRouter);

// Export the base-router
export default router;
