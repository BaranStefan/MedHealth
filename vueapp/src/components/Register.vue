<template>
    <div class="register-container">
        <h2>Register</h2>
        <form @submit.prevent="submitForm">
            <div>
                <label for="username">Username:</label>
                <input type="text" id="username" v-model="username" required />
            </div>
            <div>
                <label for="email">Email:</label>
                <input type="email" id="email" v-model="email" required />
            </div>
            <div>
                <label for="password">Password:</label>
                <input type="password" id="password" v-model="password" required />
            </div>
            <div>
                <label for="confirmPassword">Confirm Password:</label>
                <input type="password" id="confirmPassword" v-model="confirmPassword" required />
            </div>
            <button type="submit">Register</button>
        </form>
        <p>Already have an account? <router-link to="/login">Login</router-link></p>
    </div>
</template>
<script>
    import axios from 'axios'; 

    export default {
        data() {
            return {
                username: '',
                email: '',
                password: '',
                confirmPassword: ''
            };
        },
        methods: {
            async submitForm() {
                if (this.password !== this.confirmPassword) {
                    alert('Passwords do not match.');
                    return;
                }

                try {
                    const response = await axios.post('/api/user/register', {
                        Username: this.username,
                        Email: this.email,
                        Password: this.password,
                        ConfirmPassword: this.confirmPassword
                    });

                    if (response.status === 200) {
                        alert(response.data.message);
                        this.$router.push('/login');
                    }
                } catch (error) {
                    // Handle error response from the server
                    if (error.response && error.response.data) {
                        alert(error.response.data);
                    } else {
                        alert('An error occurred during registration.');
                    }
                }
            }
        }
    };
</script>


<style scoped>
    .register-container {
        background-color: #f7f7f7;
        max-width: 300px;
        margin: 0 auto;
        padding: 20px;
        border: 1px solid #ccc;
        border-radius: 5px;
    }

    label {
        display: block;
        margin-bottom: 10px;
    }

    input {
        width: 100%;
        padding: 10px;
        margin-bottom: 20px;
        border: 1px solid #ccc;
        border-radius: 4px;
    }

    button {
        padding: 10px 15px;
        background-color: #007bff;
        color: white;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

        button:hover {
            background-color: #0056b3;
        }
</style>
