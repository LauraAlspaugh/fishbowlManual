<template>
    <div class="modal fade" id="EditOrderModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title text-center text-light" id="exampleModalLabel">Edit Your Order</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="editOrder(order)">
                        <div class="mb-3">
                            <label for="description" class="form-label">Description</label>
                            <input v-model="editable.description" type="text" class="form-control" id="description"
                                aria-describedby="emailHelp" maxlength="150" required
                                placeholder="Description of Order...">
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
import { computed, reactive, onMounted, ref } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { ordersService } from '../services/OrdersService.js';
export default {
    setup() {
        const editable = ref({
            description: ''
        })
        return {
            editable,
            order: computed(() => AppState.activeOrder),
            async editOrder(order) {
                try {
                    const orderData = editable.value;
                    const orderId = AppState.activeOrder.id
                    await ordersService.editOrder(orderData, orderId)
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