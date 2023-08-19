<template>
    <div>
        <h2>Book Your Appointment</h2>
        <form @submit.prevent="submitForm">
            <!-- Your form fields... -->
        </form>
        <p>Already have an account? <router-link to="/login">Login</router-link></p>
        <p>  <router-link to="/register">Register</router-link></p>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                // Your data properties...
            };
        },
        methods: {
            // Your methods...
        }
    };
</script>

<style scoped>
    /* Your styles... */
</style>
