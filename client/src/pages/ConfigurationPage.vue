<template>
    <div class="container-fluid">
        <section class="row main-row">
            <div class="col-6 d-flex mt-3  justify-content-evenly nav-bar ">
                <router-link class="navbar-brand d-flex" :to="{ name: 'General' }">
                    <p>General</p>
                </router-link>
                <router-link class="navbar-brand d-flex" :to="{ name: 'Details' }">
                    <p>Details</p>
                </router-link>
                <router-link class="navbar-brand d-flex" :to="{ name: 'Configuration' }">
                    <p>Configuration</p>
                </router-link>
                <router-link class="navbar-brand d-flex" :to="{ name: 'WO Details' }">
                    <p>WO Details</p>
                </router-link>
                <router-link class="navbar-brand d-flex" :to="{ name: 'Memo' }">
                    <p>Memo( )</p>
                </router-link>
                <router-link class="navbar-brand d-flex" :to="{ name: 'Custom' }">
                    <p>Custom</p>
                </router-link>
            </div>
            <div class="col-4 p-2 text-end mt-1">
                <i role="button" title="start an order" data-bs-toggle="modal" data-bs-target="#OrderModal"
                    class="mdi mdi-plus p-2 fs-5"></i>
                <i class="mdi mdi-arrow-up p-2 fs-5"></i>
                <i class="mdi mdi-arrow-down p-2 fs-5"></i>
                <i class="mdi mdi-cog-outline p-2 fs-5"></i>
            </div>
        </section>
        <section class="row d-flex justify-content-evenly main-headings ">
            <div class="col-4 second-row">
                <p class="first-heading d-flex">Description</p>
            </div>
            <div class="col-2 second-row">
                <p class="first-heading">Part Number</p>
            </div>
            <div class="col-2 second-row">
                <p class="first-heading">Part Description</p>
            </div>
            <div class="col-2 second-row">
                <p class="first-heading">Quantity</p>
            </div>
            <div class="col-2 second-row">
                <p class="first-heading">UOM</p>
            </div>
        </section>
        <section class="row">
            <div v-for="order, index in orders" :key="order.id" class="col-12 order-row " :class="{
                    'light-gray': index % 2 == 0,
                    'bg-light': index % 2 == 1
                }">

                <OrderCard :orderProp="order" />
                <!-- <OrderCard :orderProp="order" v-else /> -->

            </div>

        </section>
    </div>
    <OrderModal />
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import OrderModal from '../components/OrderModal.vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { ordersService } from '../services/OrdersService.js';
import OrderCard from '../components/OrderCard.vue';

export default {
    setup() {
        onMounted(() => {
            getOrders()
        })
        async function getOrders() {
            try {
                await ordersService.getOrders()
            } catch (error) {
                logger.error(error)
                Pop.error(error)

            }
        }

        return {
            activeOrder: computed(() => AppState.activeOrder),
            parts: computed(() => AppState.parts),
            orders: computed(() => AppState.orders),
            // parts: computed(() => AppState.parts.filter(part => part.orderId == AppState.activeOrder.id)),
            setActiveOrder(order) {

                ordersService.setActiveOrder(order)
                const orderId = order.id
                ordersService.getPartsByOrderId(orderId)


            },

        }
    },
    components: { OrderModal, OrderCard }
};
</script>


<style lang="scss" scoped>
.main-row {
    background-color: lightgray;
}

.light-gray {
    background-color: lightblue;
}

a:focus {
    color: rgb(18, 143, 215);
}

.order-row {
    align-items: center;
}

.second-row {
    background-color: lightgray;
    border: 1px solid black;
}

.first-heading {
    align-items: center;
    padding-top: 7px;
}
</style>