<template>
    <div id="app">
        <router-view />
    </div>
</template>


<script>
    import AppointmentForm from './components/AppointmentForm.vue';

    export default {
        name: 'App',
        components: {
            AppointmentForm
        }
    };
</script>

<style scoped>
    /* Your styles here... */
</style>
