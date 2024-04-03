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
async editOrder(orderData, orderId){
    const res = await api.put(`api/orders/${orderId}`, orderData)
    logger.log('editing order!', res.data)
    const orderIndex = AppState.orders.findIndex(order => order.id == orderData.id)
    AppState.orders.splice(orderIndex, 1, orderData)
}
async editPart(partData, partId) {
     const res = await api.put(`api/parts/${partId}`, partData)
    logger.log('editing part!', res.data)
    const partIndex = AppState.parts.findIndex(part => part.id == partData.id)
    // if (partIndex == -1) { throw new Error('No part found with this id') }
    AppState.parts.splice(partIndex, 1, partData)

}
async setActiveOrder(orderProp) {
    AppState.activeOrder = orderProp
}
async setActivePart(part){
    AppState.activePart = part
    logger.log(part.id)
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
async destroyOrder(orderId){
    const res = await api.delete(`api/orders/${orderId}`)
    logger.log('deleting this order!', res.data)
    const orderIndex = AppState.orders.findIndex(order => order.id == orderId)
    if (orderIndex == -1) { throw new Error('No order found with this id') }
    AppState.orders.splice(orderIndex, 1)
}
}
export const ordersService = new OrdersService()