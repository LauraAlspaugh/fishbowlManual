<template>
    <div class="modal fade" id="OrderModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title text-center text-light" id="exampleModalLabel">Create Your Order</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="createOrder()">
                        <div class="mb-3">
                            <label for="description" class="form-label">Description</label>
                            <input v-model="editable.description" type="text" class="form-control" id="description"
                                aria-describedby="emailHelp" maxlength="150" required
                                placeholder="Description of Order...">

                        </div>
                        <!-- <div class="mb-3">
                            <label for="partNumber" class="form-label">Part Number</label>
                            <input type="text" class="form-control" id="partNumber" aria-describedby="emailHelp"
                                maxlength="1000" required placeholder="Part Number...">

                        </div>

                        <div class="mb-3">
                            <label for="partDescription" class="form-label">Part Description</label>
                            <textarea type="text" class="form-control" id="partDescription" rows="5" maxlength="700"
                                placeholder="Part Description..."></textarea>
                        </div>
                        <div class="mb-3">
                            <label for="quantity" class="form-label">Quantity</label>
                            <input type="text" class="form-control" id="quantity" aria-describedby="emailHelp"
                                maxlength="1000" required placeholder="Quantity...">

                        </div>
                        <div class="mb-3">
                            <label for="uom" class="form-label">UOM</label>
                            <input type="text" class="form-control" id="uom" aria-describedby="emailHelp"
                                maxlength="1000" required placeholder="UOM...">

                        </div>  -->

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
import { computed, ref } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { ordersService } from '../services/OrdersService.js';
import { Modal } from 'bootstrap';
export default {
    setup() {
        const editable = ref({
            description: ''
        })
        return {
            orders: computed(() => AppState.orders),
            editable,
            async createOrder() {
                try {
                    const orderData = editable.value
                    await ordersService.createOrder(orderData)
                    Pop.success('Order created!')
                    Modal.getOrCreateInstance('#OrderModal').hide()
                    // editable.value = {}
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