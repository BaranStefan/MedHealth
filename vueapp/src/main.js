// main.js

import { createApp } from 'vue';
import App from './App.vue';
import { createRouter, createWebHistory } from 'vue-router';
import HomePage from './components/HomePage.vue';
import Login from './components/Login.vue';
import Register from './components/Register.vue';
import Doctors from '@/components/Doctors.vue';
import Appointment from '@/components/Appointment.vue';

const routes = [
    { path: '/', component: HomePage },
    { path: '/login', component: Login },
    { path: '/register', component: Register },
    { path: '/doctors', component: Doctors },
    { path: '/appointment/:doctorId', component: Appointment, props: true }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

const app = createApp(App);
app.use(router);
app.mount('#app');
