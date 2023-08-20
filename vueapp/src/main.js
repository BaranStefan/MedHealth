// main.js

import { createApp } from 'vue';
import App from './App.vue';
import { createRouter, createWebHistory } from 'vue-router';
import AppointmentForm from './components/AppointmentForm.vue';
import Login from './components/Login.vue';
import Register from './components/Register.vue';
import DoctorsList from '@/components/DoctorsList.vue';
import Appointment from '@/components/Appointment.vue';

const routes = [
    { path: '/', component: AppointmentForm },
    { path: '/login', component: Login },
    { path: '/register', component: Register },
    { path: '/doctors', component: DoctorsList },
    { path: '/appointment/:doctorId', component: Appointment, props: true }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

const app = createApp(App);
app.use(router);
app.mount('#app');
