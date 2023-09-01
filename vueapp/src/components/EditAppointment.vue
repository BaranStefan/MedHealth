<template>
    <div class="edit-appointment-container">
        <h2>Edit Appointment</h2>
        <form @submit.prevent="updateAppointment">
            <div>
                <label for="doctorId">Doctor:</label>
                <select id="doctorId" v-model="currentAppointment.doctorId" required>
                    <option v-for="doctor in doctors" :key="doctor.id" :value="doctor.id">
                        {{ doctor.name }}
                    </option>
                </select>
            </div>

            <div>
                <label for="date">Date:</label>
                <input type="date" id="date" v-model="currentAppointment.date" required />
            </div>

            <div>
                <label for="time">Time:</label>
                <input type="time" id="time" v-model="currentAppointment.time" required />
            </div>

            <button type="submit">Update</button>
        </form>
    </div>
</template>

<script>
    import axios from "axios";

    export default {
        data() {
            return {
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
            await this.fetchDoctors();
            await this.fetchCurrentAppointment();
        },
        methods: {
            async fetchDoctors() {
                const response = await axios.get("/api/doctors");
                this.doctors = response.data;
            },
            async fetchCurrentAppointment() {
                const response = await axios.get(`/api/appointments/${this.$route.params.id}`);
                this.currentAppointment = response.data;
            },
            async updateAppointment() {
                const dateTime = `${this.currentAppointment.date}T${this.currentAppointment.time}:00`;
                await axios.put(`/api/appointments/${this.currentAppointment.id}`, {
                    ...this.currentAppointment,
                    date: dateTime
                });
                this.$router.push("/list-appointments"); 
            }
        }
    };
</script>

<style scoped>
    .edit-appointment-container {
        max-width: 300px;
        margin: 0 auto;
        padding: 20px;
        border: 1px solid #ccc;
        border-radius: 5px;
    }

    label {
        display: block;
        margin-bottom: 10px;
    }

    input, select {
        width: 100%;
        padding: 10px;
        margin-bottom: 20px;
        border: 1px solid #ccc;
        border-radius: 4px;
    }

    button {
        padding: 10px 15px;
        background-color: #007bff;
        color: white;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

        button:hover {
            background-color: #0056b3;
        }
</style>
