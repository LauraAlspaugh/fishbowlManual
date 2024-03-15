import { AppState } from "../AppState.js"
import { Order } from "../models/Order.js"
import { Part } from "../models/Part.js"
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
async createPart(partData){
    const res = await api.post('api/parts', partData)
    logger.log('creating part!', res.data)
    AppState.parts.push(new Part(res.data))
}
async setActiveOrder(order) {
    const res = await api.get(`api/orders/${order.id}`)
    logger.log('getting order by id', res.data)

    AppState.activeOrder = order
}
}
export const ordersService = new OrdersService()