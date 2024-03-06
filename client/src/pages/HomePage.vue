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
  </div>
</template>

<script>
export default {
  setup() {
    return {

    }
  }
}
</script>

<style scoped lang="scss">
.main-row {
  background-color: lightgray;
}
</style>
