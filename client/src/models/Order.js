export class Order{
    constructor(data){
        this.id = data.id
        this.createdAt = new Date(data.createdAt).toLocaleTimeString()
        this.updatedAt = new Date(data.updatedAt).toLocaleTimeString()
        this.description = data.description
        this.creator = data.creator
        this.creatorId = data.creatorId
    }
}