<template>
    <div>
        <!-- Listing Doctors -->
        <div v-for="doctor in doctors" :key="doctor.id">
            <h3>{{ doctor.name }} - {{ doctor.speciality }}</h3>
            <button @click="editDoctor(doctor)">Edit</button>
            <button @click="deleteDoctor(doctor.id)">Delete</button>
        </div>

        <!-- Form to Add/Edit Doctor -->
        <div>
            <input v-model="currentDoctor.name" placeholder="Doctor Name" />
            <input v-model="currentDoctor.speciality" placeholder="Speciality" />
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
