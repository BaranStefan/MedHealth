<template>
    <div class="container">
        <div class="appointment-item" v-for="appointment in appointments" :key="appointment.id">
            <h3>Doctor: {{ appointment.doctor.name }} - Date: {{ appointment.dateOnly }} - Time: {{ appointment.timeOnly }}</h3>
            <div class="button-container">
                <button @click="editAppointment(appointment.id)">Edit</button>
                <button @click="deleteAppointment(appointment.id)">Delete</button>
            </div>
        </div>        
        <button @click="goToAddAppointment">Add Appointment</button>
    </div>
</template>

<script>
    import axios from "axios";

    export default {
        data() {
            return {
                appointments: []
            };
        },
        async created() {
            await this.fetchAppointments();
        },
        methods: {
            async fetchAppointments() {
                const response = await axios.get("/api/appointments");
                this.appointments = response.data.map(app => {
                    const dateTime = new Date(app.date);
                    return {
                        ...app,
                        dateOnly: dateTime.toISOString().split('T')[0],
                        timeOnly: `${dateTime.getHours().toString().padStart(2, '0')}:${dateTime.getMinutes().toString().padStart(2, '0')}`
                    };
                });
            },
            editAppointment(id) {
                this.$router.push(`/edit-appointment/${id}`);
            },
            async deleteAppointment(id) {
                await axios.delete(`/api/appointments/${id}`);
                await this.fetchAppointments();
            },
            goToAddAppointment() {
                this.$router.push("/add-appointment");
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

    .appointment-item {
        border-bottom: 1px solid #ccc;
        padding-bottom: 10px;
        margin-bottom: 10px;
    }

    button {
        padding: 10px;
        font-size: 1rem;
        border: 1px solid #ccc;
        border-radius: 5px;
        cursor: pointer;
    }

    .button-container {
        display: flex;
        gap: 30px; 
    }
</style>
