
<template>
    <div id="app">
        <NavBar />
        <router-view />
    </div>
</template>


<script>
    import HomePage from './components/HomePage.vue';
    import NavBar from './components/NavBar.vue'

    export default {
        name: 'App',
        components: {
            HomePage,
            NavBar
        }
    };
</script>

<style scoped>
    
</style>
