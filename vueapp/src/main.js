import { createApp, reactive, ref } from 'vue';
import App from './App.vue';
import { createRouter, createWebHistory } from 'vue-router';
import HomePage from './components/HomePage.vue';
import Login from './components/Login.vue';
import Register from './components/Register.vue';
import ListDoctors from '@/components/ListDoctors.vue';
import AddDoctor from '@/components/AddDoctor.vue';
import EditDoctor from '@/components/EditDoctor.vue';
import ListAppointments from '@/components/ListAppointments.vue';
import AddAppointment from '@/components/AddAppointment.vue';
import EditAppointment from '@/components/EditAppointment.vue';
import AccessDenied from '@/components/AccessDenied.vue';
import axios from 'axios';

axios.defaults.baseURL = 'https://localhost:7053';

const routes = [
    { path: '/', component: HomePage },
    { path: '/login', component: Login },
    { path: '/register', component: Register },
    { path: '/doctors', component: ListDoctors , meta: { requiresAuth: true } },
    { path: '/add-doctor', component: AddDoctor },
    { path: '/edit-doctor/:id', component: EditDoctor },
    { path: '/list-appointments', component: ListAppointments , meta: { requiresAuth: true } },
    { path: '/add-appointment/:doctorId?', name: 'add-appointment', component: AddAppointment },
    { path: '/edit-appointment/:id', component: EditAppointment },
    { path: '/access-denied', component: AccessDenied },
];

const router = createRouter({
    history: createWebHistory(),
    routes
});


router.beforeEach((to, from, next) => {
    
    if (to.matched.some(record => record.meta.requiresAuth)) {
        
        if (!appState.user) {
            
            next({ path: '/access-denied' });
        } else {
            next(); 
        }
    } else {
        next(); 
    }
});

const user = ref(null); 

const appState = reactive({
    user: user.value  
});

const app = createApp(App);

app.use(router);
app.provide('appState', appState);
app.mount('#app');