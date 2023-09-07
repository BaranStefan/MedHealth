<template>
    <div class="container">
        <h2>Welcome to our Medical Cabinet</h2>
        <p>Already have an account? <router-link to="/login">Login</router-link></p>
        <p>Don't have an account?  <router-link to="/register">Register</router-link></p>
        <p><router-link to="/doctors">See Doctors</router-link></p>
        <p><router-link to="/list-appointments">Book an Appointment</router-link></p>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                
            };
        },
        methods: {
            
        }
    };
</script>

<style scoped>
    
    .container {
        width: 100%;
        max-width: 600px; 
        margin: 50px auto; 
        text-align: center; 
        font-family: 'Arial', sans-serif;
    }

    
    h2 {
        font-size: 2em;
        margin-bottom: 20px; 
        color: #333; 
    }

    
    p {
        font-size: 1.2em;
        margin: 10px 0; 
    }

   
    router-link {
        color: #007BFF; 
        text-decoration: none;
    }

        router-link:hover {
            text-decoration: underline;
        }
</style>
