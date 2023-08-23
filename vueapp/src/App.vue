
<template>
    <div id="app">
        <router-view />
    </div>
</template>


<script>
    import HomePage from './components/HomePage.vue';

    export default {
        name: 'App',
        components: {
            HomePage
        }
    };
</script>

<style scoped>
    /* Your styles here... */
</style>
