<template>
    <div class="login-container">
        <h3>Login</h3>
        <form @submit.prevent="submitForm">
            <div>
                <label for="email">Email:</label>
                <input type="text" id="email" v-model="email" required />
            </div>
            <div>
                <label for="password">Password:</label>
                <input type="password" id="password" v-model="password" required />
            </div>
            <button type="submit">Login</button>
        </form>
    </div>
</template>

<script>
    import axios from 'axios';  
    import { useRouter } from 'vue-router';
    import { ref, inject } from 'vue';

    export default {
        setup() {
            const email = ref('');
            const password = ref('');
            const state = inject('appState');
            const router = useRouter();


            const submitForm = async () => {
                try {
                    const response = await axios.post('/api/user/login', {
                        Email: email.value,
                        Password: password.value
                    });

                    if (response.status === 200) {
                        alert(response.data.message); 
                        state.user = response.data.user; 
                        router.push('/');
                    }

                } catch (error) {
                    // Handle error response from the server
                    if (error.response && error.response.data) {
                        alert(error.response.data); 
                    } else {
                        alert('An error occurred during login.');
                    }

                }
            }
            return { email, password, state, submitForm };
        }
    };
</script>

<style scoped>
    .login-container {
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
