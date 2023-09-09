
<template>
    <div id="app">
        <NavBar />
        <router-view :key="$route.fullPath"></router-view>

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
    #app {
        background-image: url(assets/medical.jpg);
        background-size: cover; 
        background-position: center; 
        background-repeat: no-repeat; 
        min-height: 100vh; 
    }
</style>