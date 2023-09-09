<template>
    <div class="add-appointment-container">
        <h2>Add Appointment</h2>
        <form @submit.prevent="createAppointment">
            <div>
                <label for="doctorId">Doctor:</label>
                <select id="doctorId" v-model="currentAppointment.doctor" required>
                    <option v-for="doctor in doctors" :key="doctor.id" :value="doctor">
                        {{ doctor.name }} -{{doctor.speciality}}
                    </option>
                </select>
            </div>

            <div>
                <label for="date">Date:</label>
                <input type="date" id="date" v-model="currentAppointment.date" />
            </div>

            <div>
                <label for="time">Time:</label>
                <input type="time" id="time" v-model="currentAppointment.time" />
            </div>

            <button type="submit">Add</button>
        </form>
    </div>
</template>

<script>
    import { ref, onMounted } from 'vue';
    import axios from "axios";

    export default {
        data() {
            return {
                doctors: [],
                doctorId: ref(null),
                currentAppointment: {
                    doctor: null,
                    doctorId: '',
                    date: '',
                    time: ''
                }
            };
        },
        async created() {
            await this.fetchDoctors();
            this.doctorId = this.$route.params.doctorId;
            if (this.doctorId) {
                this.currentAppointment.doctor = this.doctors.find(d => d.id == this.doctorId);
            }
        },
        methods: {
            async fetchDoctors() {
                const response = await axios.get("/api/doctors");
                this.doctors = response.data;
            },
            async createAppointment() {
                const dateTime = `${this.currentAppointment.date}T${this.currentAppointment.time}:00`;
                try {
                    await axios.post("/api/appointments", {
                        doctorId: this.currentAppointment.doctor.id,
                        doctor: this.currentAppointment.doctor,
                        date: dateTime
                    });
                    this.$router.push("/list-appointments");
                } catch (error) {
                    if (error.response && error.response.status === 400) {
                        alert(error.response.data);
                    } else {
                        alert("An unexpected error occurred.");
                    }
                }
            }
        }
    };
</script>

<style scoped>
    .add-appointment-container {
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