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
                <i role="button" title="edit this order" class="mdi mdi-pencil p-2"></i>
            </div>

        </div>
        <div v-if="order">
            <div class=" part-line d-flex justify-content-evenly m-3 " v-for="part in parts" :key="part.id">
                <div class="col-4">
                    {{ part.description }}
                </div>
                <div class="col-2">
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
</template>


<script>
import { AppState } from '../AppState';
import { Order } from '../models/Order.js';
import { computed } from 'vue';
import { ordersService } from '../services/OrdersService.js';
import PartModal from './PartModal.vue';
import EditPartModal from './EditPartModal.vue';
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
            // parts: computed(() => AppState.parts),
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
            // enableEdit(part) {
            //     editable1.value = part
            // },
        }
    },
    components: { PartModal, EditPartModal }
};
</script>


<style lang="scss" scoped>
.part-line {
    align-items: center;
    border-bottom: 1px solid black;
    border-top: 1px solid black;
}

.order-row {
    align-items: center;
}
</style>