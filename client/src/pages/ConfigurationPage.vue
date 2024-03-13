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
                <i role="button" data-bs-toggle="modal" data-bs-target="#OrderModal" class="mdi mdi-plus p-2 fs-5"></i>
                <i class="mdi mdi-delete-outline p-2 fs-5"></i>
                <i class="mdi mdi-arrow-up p-2 fs-5"></i>
                <i class="mdi mdi-arrow-down p-2 fs-5"></i>
                <i class="mdi mdi-cog-outline p-2 fs-5"></i>
            </div>
        </section>
        <section class="row d-flex justify-content-evenly ">
            <div class="col-4 second-row d-flex align-items-center ">
                <p class="first-heading">Description</p>
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
            <div v-for="order, index in orders" :key="order.id" class="col-12 order-row" :class="{
                    'light-gray': index % 2 == 0,
                    'bg-light': index % 2 == 1
                }">
                <p class="order-name"> <i class="mdi mdi-menu-down fs-2 "></i> {{ order.description }}</p>
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
            orders: computed(() => AppState.orders)

        }
    },
    components: { OrderModal }
};
</script>


<style lang="scss" scoped>
.main-row {
    background-color: lightgray;
}

.light-gray {
    background-color: lightblue;
}

.active,
.navbar-brand:hover {
    color: #5DADE2;
}

.second-row {
    background-color: lightgray;
    border: 1px solid black;
}

.first-heading {

    display: flex;
    align-items: center;
}
</style>