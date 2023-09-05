<template>
    <div class="container">
        <div class="doctor-item" v-for="doctor in doctors" :key="doctor.id">
            <h3>{{ doctor.name }} - {{ doctor.speciality }}</h3>
            <p>Phone: {{ doctor.phone }}</p>
            <p>Email: {{ doctor.mail }}</p>
            <div class="button-container" v-if="state.user && state.user.isAdmiin">
                <button @click="editDoctor(doctor)">Edit</button>
                <button @click="deleteDoctor(doctor.id)">Delete</button>
            </div>

        </div>
        <div v-if="state.user && state.user.isAdmiin">
            <button @click="goToAddDoctor">Add Doctor</button>
        </div>
    </div>
    <template>
        <div class="container">
            <!-- Debugging: Display user info -->
            <pre>{{ state.user }}</pre>
            <!-- ... rest of your code ... -->
        </div>
    </template>

</template>

<script>
    import { inject } from 'vue';
    import axios from "axios";

    export default {
        data() {
            return {
                doctors: []
            };
        },
        setup() {
            const state = inject('appState');
            return { state };
        },
        async created() {
            await this.fetchDoctors();
        },
        methods: {
            async fetchDoctors() {
                const response = await axios.get("/api/doctors");
                this.doctors = response.data;
            },
            async deleteDoctor(id) {
                await axios.delete(`/api/doctors/${id}`);
                await this.fetchDoctors();
            },
            goToAddDoctor() {
                this.$router.push('/add-doctor');
            },
            editDoctor(doctor) {
                this.$router.push(`/edit-doctor/${doctor.id}`);
            }
        }
    };
</script>


<style scoped>
    .container {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        min-height: 100vh;
        padding: 20px;
    }

    .form-container {
        display: flex;
        flex-direction: column;
        gap: 10px;
        width: 300px;
        margin-top: 20px;
    }

    .doctor-item {
        border-bottom: 1px solid #ccc;
        padding-bottom: 10px;
        margin-bottom: 10px;
    }

    input, button {
        padding: 10px;
        font-size: 1rem;
        border: 1px solid #ccc;
        border-radius: 5px;
    }

    button {
        cursor: pointer;
    }

    .button-container {
        display: flex;
        gap: 30px;
    }
</style>
