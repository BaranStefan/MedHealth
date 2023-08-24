<template>
    <div class="container">
        <!-- Listing Doctors -->
        <div v-for="doctor in doctors" :key="doctor.id">
            <h3>{{ doctor.name }} - {{ doctor.speciality }}</h3>
            <p>Phone: {{ doctor.phone }}</p>
            <p>Email: {{ doctor.mail }}</p>
            <button @click="editDoctor(doctor)">Edit</button>
            <button @click="deleteDoctor(doctor.id)">Delete</button>
        </div>

        <!-- Form to Add/Edit Doctor -->
        <div class="form-container">
            <input v-model="currentDoctor.name" placeholder="Doctor Name" />
            <input v-model="currentDoctor.speciality" placeholder="Speciality" />
            <input v-model="currentDoctor.phone" placeholder="Phone" />
            <input v-model="currentDoctor.mail" type="email" placeholder="Email" />
            <button v-if="!currentDoctor.id" @click="createDoctor">Add</button>
            <button v-if="currentDoctor.id" @click="updateDoctor">Update</button>
        </div>
    </div>
</template>

<script>
    import axios from "axios";

    export default {
        data() {
            return {
                doctors: [],
                currentDoctor: {}
            };
        },
        async created() {
            await this.fetchDoctors();
        },
        methods: {
            async fetchDoctors() {
                const response = await axios.get("/api/doctors");
                this.doctors = response.data;
            },
            editDoctor(doctor) {
                this.currentDoctor = { ...doctor };
            },
            async createDoctor() {
                await axios.post("/api/doctors", this.currentDoctor);
                await this.fetchDoctors();
            },
            async updateDoctor() {
                await axios.put(`/api/doctors/${this.currentDoctor.id}`, this.currentDoctor);
                await this.fetchDoctors();
                this.currentDoctor = {};
            },
            async deleteDoctor(id) {
                await axios.delete(`/api/doctors/${id}`);
                await this.fetchDoctors();
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
        gap: 10px; /* provides spacing between form elements */
        width: 300px;
        margin-top: 20px;
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
</style>