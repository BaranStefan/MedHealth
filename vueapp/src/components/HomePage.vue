<template>
    <div>
        <h2>Wellcome to our Medical cabinet</h2>
        <p>Already have an account? <router-link to="/login">Login</router-link></p>
        <p>Don't have an account?  <router-link to="/register">Register</router-link></p>
        <p>  <router-link to="/doctors">Add Doctor</router-link></p>
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