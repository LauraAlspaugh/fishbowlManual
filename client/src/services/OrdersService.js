import { AppState } from "../AppState.js"
import { Order } from "../models/Order.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class OrdersService{
async createOrder(orderData){
    const res = await api.post('api/orders', orderData)
    logger.log("creating an order!", res.data)
}
async getOrders(){
    const res = await api.get('api/orders')
    logger.log("getting orders!", res.data)
    AppState.orders = res.data.map(pojo => new Order(pojo))
}
}
export const ordersService = new OrdersService()