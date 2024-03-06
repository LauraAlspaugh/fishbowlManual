<template>
    <div class="container-fluid">
        <section class="row main-row">
            <div class="col-6 d-flex mt-3  justify-content-evenly ">
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
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
    setup() {
        return {}
    }
};
</script>


<style lang="scss" scoped>
.main-row {
    background-color: lightgray;
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