export class Part{
    constructor(data){
        this.id = data.id
        this.description = data.description
        this.partDescription = data.partDescription
        this.partNumber = data.partNumber
        this.quantity = data.quantity
        this.uom = data.uom
        this.creator = data.creator
        this.creatorId = data.creatorId
        this.orderId = data.orderId
        this.createdAt = new Date(data.createdAt).toLocaleTimeString()
        this.updatedAt = new Date(data.updatedAt).toLocaleTimeString()
    }
}