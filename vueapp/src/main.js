import { createApp } from 'vue';
import App from './App.vue';
import { createRouter, createWebHistory } from 'vue-router';
import HomePage from './components/HomePage.vue';
import Login from './components/Login.vue';
import Register from './components/Register.vue';
import ListDoctors from '@/components/ListDoctors.vue';  // import the ListDoctors component
import AddDoctor from '@/components/AddDoctor.vue';  // import the AddDoctor component
import Appointments from '@/components/Appointments.vue';  // import the Appointments component
import axios from 'axios';

axios.defaults.baseURL = 'https://localhost:7053';

const routes = [
    { path: '/', component: HomePage },
    { path: '/login', component: Login },
    { path: '/register', component: Register },
    { path: '/doctors', component: ListDoctors },  // Path for ListDoctors component
    { path: '/add-doctor', component: AddDoctor },  // Path for AddDoctor component
    { path: '/appointments', component: Appointments },  // New path for Appointments component
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

const app = createApp(App);
app.use(router);
app.mount('#app');
