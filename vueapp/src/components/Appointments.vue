<template>
    <div>
        <!-- Listing Appointments -->
        <div v-for="appointment in appointments" :key="appointment.id">
            <h3>Doctor: {{ appointment.doctor.name }} - Date: {{ appointment.dateOnly }} - Time: {{ appointment.timeOnly }}</h3>
            <button @click="editAppointment(appointment)">Edit</button>
            <button @click="deleteAppointment(appointment.id)">Delete</button>
        </div>

        <!-- Form to Add/Edit Appointment -->
        <div>
            <label for="doctorId">Doctor:</label>
            <select id="doctorId" v-model="currentAppointment.doctorId" required>
                <option v-for="doctor in doctors" :key="doctor.id" :value="doctor.id">
                    {{ doctor.name }}
                </option>
            </select>

            <label for="date">Date:</label>
            <input type="date" id="date" v-model="currentAppointment.date" />
            <label for="time">Time:</label>
            <input type="time" id="time" v-model="currentAppointment.time" />

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
                doctors: [],
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
            await this.fetchDoctors();
        },
        methods: {
            async fetchAppointments() {
                const response = await axios.get("/api/appointments");
                this.appointments = response.data.map(app => {
                    const dateTime = new Date(app.date); // Assuming the date is in ISO string format
                    return {
                        ...app,
                        dateOnly: dateTime.toISOString().split('T')[0],
                        timeOnly: `${dateTime.getHours().toString().padStart(2, '0')}:${dateTime.getMinutes().toString().padStart(2, '0')}`
                    };
                });
            },
            async fetchDoctors() {
                const response = await axios.get("/api/doctors");
                this.doctors = response.data;
            },
            editAppointment(appointment) {
                this.currentAppointment = {
                    id: appointment.id,
                    doctorId: appointment.doctorId,
                    date: appointment.dateOnly,
                    time: appointment.timeOnly
                };
            },
            async createAppointment() {
                const dateTime = `${this.currentAppointment.date}T${this.currentAppointment.time}:00`;
                await axios.post("/api/appointments", {
                    ...this.currentAppointment,
                    date: dateTime
                });
                await this.fetchAppointments();
                this.resetForm();
            },
            async updateAppointment() {
                const dateTime = `${this.currentAppointment.date}T${this.currentAppointment.time}:00`;
                await axios.put(`/api/appointments/${this.currentAppointment.id}`, {
                    ...this.currentAppointment,
                    date: dateTime
                });
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
