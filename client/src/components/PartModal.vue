<template>
    <div class="modal fade" id="PartModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title text-center text-light" id="exampleModalLabel">Create a Part</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="createPart()">
                        <div class="mb-3">
                            <label for="description" class="form-label">Description</label>
                            <input v-model="editable1.description" type="text" class="form-control" id="description"
                                aria-describedby="emailHelp" maxlength="150" required
                                placeholder="Description of Order...">

                        </div>
                        <div class="mb-3">
                            <label for="partNumber" class="form-label">Part Number</label>
                            <input v-model="editable1.partNumber" type="text" class="form-control" id="partNumber"
                                aria-describedby="emailHelp" maxlength="1000" required placeholder="Part Number...">

                        </div>

                        <div class="mb-3">
                            <label for="partDescription" class="form-label">Part Description</label>
                            <textarea v-model="editable1.partDescription" type="text" class="form-control"
                                id="partDescription" rows="5" maxlength="700"
                                placeholder="Part Description..."></textarea>
                        </div>
                        <div class="mb-3">
                            <label for="quantity" class="form-label">Quantity</label>
                            <input v-model="editable1.quantity" type="number" class="form-control" id="quantity"
                                aria-describedby="emailHelp" maxlength="1000" required placeholder="Quantity...">

                        </div>
                        <div class="mb-3">
                            <label for="uom" class="form-label">UOM</label>
                            <input v-model="editable1.uom" type="text" class="form-control" id="uom"
                                aria-describedby="emailHelp" maxlength="1000" required placeholder="UOM...">

                        </div>

                        <button type="submit" class="btn btn-outline-dark">Submit</button>
                    </form>
                </div>
                <div class="modal-footer">

                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { ordersService } from '../services/OrdersService.js';
import { Modal } from 'bootstrap';
export default {
    setup() {

        const editable1 = ref({
            description: '',
            partNumber: '',
            partDescription: '',
            quantity: 0,
            uom: '',
            orderId: '',
        })
        return {
            editable1,
            account: computed(() => AppState.account),
            order: computed(() => AppState.activeOrder),
            parts: computed(() => AppState.parts),
            async createPart() {
                try {
                    const partData = editable1.value
                    partData.orderId = AppState.activeOrder.id
                    await ordersService.createPart(partData)

                    Pop.success('Part created!')
                    Modal.getOrCreateInstance('#PartModal').hide()
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)

                }
            }
        }
    }
};
</script>


<style lang="scss" scoped>
.modal-header {
    background-color: #5DADE2;

}

.modal-footer {
    background-color: #5DADE2;
}
</style>