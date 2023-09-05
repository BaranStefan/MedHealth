<template>
    <nav class="navbar">
        <router-link to="/" exact class="nav-item">Home</router-link>
        <router-link to="/Doctors" class="nav-item">Doctors</router-link>
        <router-link to="/list-appointments" class="nav-item">Appointments</router-link>
        <router-link v-if="!state.user" to="/Register" class="nav-item">Register</router-link>
        <router-link v-if="!state.user" to="/Login" class="nav-item">Login</router-link>
        <span v-if="state.user" class="nav-item">Welcome, {{state.user.username}}</span>
        <span v-if="state.user" @click="logout" class="nav-item">Logout</span>
    </nav>
</template>

<script>
import { inject } from 'vue';  
import { useRouter } from 'vue-router';

export default {
    setup() {
        const state = inject('appState');
        const router = useRouter();  

        const logout = () => {
            state.user = null;
            router.push('/Login');   
        };

        return { state, logout };
    }
};
</script>



<style scoped>
    .navbar {
        background-color: #333;
        padding: 10px 20px;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    .nav-item {
        color: #fff;
        text-decoration: none;
        margin: 0 15px;
        padding: 5px 10px;
        border-radius: 5px;
        transition: background-color 0.3s ease;
    }

        .nav-item:hover {
            background-color: #555;
        }

    .router-link-exact-active {
        background-color: #555;
    }
</style>
