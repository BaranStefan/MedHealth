import { createApp } from 'vue';
import App from './App.vue';
import { createRouter, createWebHistory } from 'vue-router';
import HomePage from './components/HomePage.vue';
import Login from './components/Login.vue';
import Register from './components/Register.vue';
import ListDoctors from '@/components/ListDoctors.vue';
import AddDoctor from '@/components/AddDoctor.vue';
import EditDoctor from '@/components/EditDoctor.vue';  // Import the EditDoctor component
import Appointments from '@/components/Appointments.vue';
import axios from 'axios';

axios.defaults.baseURL = 'https://localhost:7053';

const routes = [
    { path: '/', component: HomePage },
    { path: '/login', component: Login },
    { path: '/register', component: Register },
    { path: '/doctors', component: ListDoctors },
    { path: '/add-doctor', component: AddDoctor },
    { path: '/edit-doctor/:id', component: EditDoctor },  // New route for EditDoctor component
    { path: '/appointments', component: Appointments },
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

const app = createApp(App);
app.use(router);
app.mount('#app');
