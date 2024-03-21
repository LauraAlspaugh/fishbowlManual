<template>
    <div>
        <p role="button" @click="setActiveOrder(orderProp)" class="order-name"> <i class="mdi mdi-menu-down fs-2 "></i>
            {{ orderProp.description }}</p>

        <i role="button" data-bs-toggle="modal" data-bs-target="#PartModal" class="mdi mdi-plus p-2 fs-5"></i>
        <p v-for="part in parts" :key="part.id">
            {{ part.description }}
        </p>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { Order } from '../models/Order.js';
import { computed } from 'vue';
import { ordersService } from '../services/OrdersService.js';
export default {
    props: { orderProp: { type: Order, required: true } },
    setup() {
        return {
            orders: computed(() => AppState.orders),
            parts: computed(() => AppState.parts),
            setActiveOrder(orderProp) {

                ordersService.setActiveOrder(orderProp)
                const orderId = orderProp.id
                ordersService.getPartsByOrderId(orderId)


            },
        }
    }
};
</script>


<style lang="scss" scoped></style>