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
async editPart(partData) {
    const res = await api.put('api/parts/' + partData.id, partData)
    logger.log('editing part!', res.data)
    const partIndex = AppState.parts.findIndex(part => part.id == partData.id)
    if (partIndex == -1) { throw new Error('No part found with this id') }
    AppState.parts.splice(partIndex, 1, partData)

}
async setActiveOrder(orderProp) {
    AppState.activeOrder = orderProp
}
async getPartsByOrderId(orderId){
    const res = await api.get(`api/orders/${orderId}/parts`)
       logger.log('getting parts', res.data)
       AppState.parts = res.data.map(pojo => new Part(pojo))
}
async destroyPart(partId){
    const res = await api.delete(`api/parts/${partId}`)
        logger.log('destroying part', res.data)
        const partIndex = AppState.parts.findIndex(part => part.id == partId)
        if (partIndex == -1) { throw new Error('No part found with this id') }
        AppState.parts.splice(partIndex, 1)
}
}
export const ordersService = new OrdersService()