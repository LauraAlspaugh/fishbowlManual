import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class OrdersService{
async createOrder(orderData){
    const res = await api.post('api/orders', orderData)
    logger.log("creating an order!", res.data)
}
}
export const ordersService = new OrdersService()