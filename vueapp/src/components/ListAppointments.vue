<template>
    <div class="container">
        <div class="appointment-item" v-for="appointment in appointments" :key="appointment.id">
            <h3>
                Appointment with Dr. {{ appointment.doctor.name }} - {{ appointment.doctor.speciality }}
            </h3>
            <h4>
                Date: {{ appointment.dateOnly }} | Time: {{ appointment.timeOnly }}
            </h4>
            <div class="button-container">
                <button class="edit-btn" @click="editAppointment(appointment.id)">Edit</button>
                <button class="delete-btn" @click="deleteAppointment(appointment.id)">Delete</button>
            </div>
        </div>
        <div class="add-appointment">
            <button @click="goToAddAppointment">Add Appointment</button>
        </div>
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
        max-width: 800px;
        margin: 0 auto;
        padding: 20px;
        font-family: 'Arial', sans-serif;
    }

    .appointment-item {
        background-color: #f7f7f7;
        padding: 15px;
        margin-bottom: 20px;
        border-radius: 5px;
        box-shadow: 0 4px 8px rgba(0,0,0,0.05);
    }

    h3, h4 {
        margin: 10px 0;
    }

    .button-container {
        display: flex;
        gap: 15px;
        margin-top: 15px;
    }

    button {
        padding: 10px 20px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        font-size: 1rem;
        transition: background-color 0.3s ease;
    }

    .edit-btn {
        background-color: #3498db;
        color: #fff;
    }

        .edit-btn:hover {
            background-color: #2980b9;
        }

    .delete-btn {
        background-color: #e74c3c;
        color: #fff;
    }

        .delete-btn:hover {
            background-color: #c0392b;
        }

    .add-appointment {
        text-align: center;
        margin-top: 20px;
    }
</style>