<template>
    <div>
        <div class="order-row d-flex justify-content-between">
            <div class="col-6">


                <p v-if="!order" role="button" @click="setActiveOrder(orderProp)" class="order-name"> <i
                        class="mdi mdi-menu-right fs-2 "></i>
                    {{ orderProp.description }}</p>
                <p v-else role="button" @click="setActiveOrder(orderProp)" class="order-name"> <i
                        class="mdi mdi-menu-down fs-2 "></i>
                    {{ orderProp.description }}</p>
            </div>
            <div class="col-6 text-end">

                <i role="button" title="add a part to order" data-bs-toggle="modal" data-bs-target="#PartModal"
                    class="mdi mdi-plus p-2 fs-5"></i>
                <i role="button" title="delete this order" @click="destroyOrder(orderProp)"
                    class="mdi mdi-delete-forever p-2"></i>
                <i data-bs-toggle="modal" data-bs-target="#EditOrderModal" role="button" title="edit this order"
                    class="mdi mdi-pencil p-2"></i>
            </div>

        </div>
        <div v-if="order">
            <div class=" part-line d-flex justify-content-evenly  p-0 " v-for="part, index in parts" :key="part.id"
                :class="{
                    'light-gray': index % 2 == 0,
                    'bg-light': index % 2 == 1
                }">
                <div class="col-4 m-3">
                    <i class="mdi mdi-cog-outline"></i> {{ part.description }}
                </div>
                <div class="col-2 part-number">
                    {{ part.partNumber }}
                </div>
                <div class="col-2">
                    {{ part.partDescription }}
                </div>
                <div class="col-2">
                    {{ part.quantity }}
                </div>
                <div class="col-1">
                    {{ part.uom }}
                    <i @click="destroyPart(part.id)" class="mdi mdi-delete-forever p-2" type="button"
                        title="delete this part"></i>
                    <i @click="setActivePart(part)" class="mdi mdi-pencil  btn" type="button" title="edit this part"
                        data-bs-toggle="modal" data-bs-target="#EditPartModal"></i>
                </div>
            </div>
        </div>
    </div>
    <PartModal />
    <EditPartModal />
    <EditOrderModal />
</template>


<script>
import { AppState } from '../AppState';
import { Order } from '../models/Order.js';
import { computed } from 'vue';
import { ordersService } from '../services/OrdersService.js';
import PartModal from './PartModal.vue';
import EditPartModal from './EditPartModal.vue';
import EditOrderModal from './EditOrderModal.vue';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';

export default {
    props: { orderProp: { type: Order, required: true } },
    setup(props) {
        return {
            part: computed(() => AppState.activePart),
            order: computed(() => AppState.activeOrder),
            orders: computed(() => AppState.orders),
            parts: computed(() => AppState.parts.filter(p => p.orderId == props.orderProp.id)),
            setActiveOrder(orderProp) {

                ordersService.setActiveOrder(orderProp)
                const orderId = orderProp.id
                ordersService.getPartsByOrderId(orderId)


            },
            setActivePart(part) {
                ordersService.setActivePart(part)
                logger.log('setting active part!')
            },
            async destroyOrder(orderProp) {
                try {
                    if (await Pop.confirm('Are you sure you want to destroy this Order? ')) {
                        const orderId = orderProp.id
                        await ordersService.destroyOrder(orderId)
                    }
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)

                }
            },
            async destroyPart(partId) {
                try {
                    if (await Pop.confirm('Are you sure you want to destroy this Part? ')) {

                        logger.log('deleting part with following id ? ', partId);
                        await ordersService.destroyPart(partId);
                    }
                }
                catch (error) {
                    logger.error(error);
                    Pop.error(error);
                }
            },
        }
    },
    components: { PartModal, EditPartModal, EditOrderModal }
};
</script>


<style lang="scss" scoped>
.part-line {
    align-items: center;
}

.order-row {
    align-items: center;
}

.light-gray {
    background-color: #E5E7E9;
}

.part-number {
    color: #3498DB;
}
</style>