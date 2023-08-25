<template>
    <div>
        <!-- Listing Appointments -->
        <div v-for="appointment in appointments" :key="appointment.id">
            <h3>Doctor: {{ appointment.doctor.name }} - Date: {{ appointment.date }} - Time: {{ appointment.time }}</h3>
            <button @click="editAppointment(appointment)">Edit</button>
            <button @click="deleteAppointment(appointment.id)">Delete</button>
        </div>

        <!-- Form to Add/Edit Appointment -->
        <div>
            <label for="doctorId">Doctor:</label>
            <!-- Dropdown to select a doctor by name but bind the value to doctorId -->
            <select id="doctorId" v-model="currentAppointment.doctorId" required>
                <option v-for="doctor in doctors" :key="doctor.id" :value="doctor.id">
                    {{ doctor.name }}
                </option>
            </select>

            <label for="date">Date:</label>
            <input type="date" id="date" v-model="currentAppointment.date" required />
            <label for="time">Time:</label>
            <input type="time" id="time" v-model="currentAppointment.time" required />

            <button v-if="!currentAppointment.id" @click="createAppointment">Add</button>
            <button v-if="currentAppointment.id" @click="updateAppointment">Update</button>
        </div>
    </div>
</template>

<script>
    import axios from "axios";

    export default {
        data() {
            return {
                appointments: [],
                doctors: [], // To hold the list of all doctors
                currentAppointment: {
                    id: null,
                    doctorId: '',
                    date: '',
                    time: ''
                }
            };
        },
        async created() {
            await this.fetchAppointments();
            await this.fetchDoctors(); // Fetch doctors when the component is created
        },
        methods: {
            async fetchAppointments() {
                const response = await axios.get("/api/appointments");
                this.appointments = response.data;
            },
            async fetchDoctors() {
                const response = await axios.get("/api/doctors"); // Assuming you have a doctors API endpoint
                this.doctors = response.data;
            },
            editAppointment(appointment) {
                this.currentAppointment = { ...appointment };
            },
            async createAppointment() {
                await axios.post("/api/appointments", this.currentAppointment);
                await this.fetchAppointments();
                this.resetForm();
            },
            async updateAppointment() {
                await axios.put(`/api/appointments/${this.currentAppointment.id}`, this.currentAppointment);
                await this.fetchAppointments();
                this.resetForm();
            },
            async deleteAppointment(id) {
                await axios.delete(`/api/appointments/${id}`);
                await this.fetchAppointments();
            },
            resetForm() {
                this.currentAppointment = {
                    id: null,
                    doctorId: '',
                    date: '',
                    time: ''
                };
            }
        }
    };
</script>
