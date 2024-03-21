<template>
    <div>
        <div class="d-flex justify-content-between">
            <p role="button" @click="setActiveOrder(orderProp)" class="order-name"> <i
                    class="mdi mdi-menu-down fs-2 "></i>
                {{ orderProp.description }}</p>

            <i role="button" data-bs-toggle="modal" data-bs-target="#PartModal" class="mdi mdi-plus p-2 fs-5"></i>
        </div>
        <div v-if="order">
            <p v-for="part in parts" :key="part.id">
                {{ part.partDescription }}
            </p>
        </div>
    </div>
    <PartModal />

</template>


<script>
import { AppState } from '../AppState';
import { Order } from '../models/Order.js';
import { computed } from 'vue';
import { ordersService } from '../services/OrdersService.js';
import PartModal from './PartModal.vue';

export default {
    props: { orderProp: { type: Order, required: true } },
    setup(props) {
        return {
            order: computed(() => AppState.activeOrder),
            orders: computed(() => AppState.orders),
            parts: computed(() => AppState.parts.filter(p => p.orderId == props.orderProp.id)),
            // parts: computed(() => AppState.parts),
            setActiveOrder(orderProp) {

                ordersService.setActiveOrder(orderProp)
                const orderId = orderProp.id
                ordersService.getPartsByOrderId(orderId)


            },
        }
    },
    components: { PartModal }
};
</script>


<style lang="scss" scoped></style>