<template>
    <div class="container">
        <div class="search-box">
            <input v-model="searchTerm" placeholder="Search Doctor" />
        </div>

        <div class="doctor-item" v-for="doctor in filteredDoctors" :key="doctor.id">
            <h3>{{ doctor.name }} <span class="speciality">{{ doctor.speciality }}</span></h3>
            <p>Phone: {{ doctor.phone }}</p>
            <p>Email: {{ doctor.mail }}</p>
            <button class="book-btn" @click="bookAppointment(doctor.id)">Book Appointment</button>
            <div class="button-container" v-if="state.user && state.user.isAdmiin">
                <button @click="editDoctor(doctor)">Edit</button>
                <button @click="deleteDoctor(doctor.id)">Delete</button>
            </div>
        </div>

        <div class="add-doctor" v-if="state.user && state.user.isAdmiin">
            <button @click="goToAddDoctor">Add Doctor</button>
        </div>
    </div>
</template>


<script>
    import { inject } from 'vue';
    import axios from "axios";

    export default {
        data() {
            return {
                doctors: [],
                searchTerm: ''
            };
        },
        computed: {
            filteredDoctors() {  
                if (!this.searchTerm) {
                    return this.doctors;
                }
                const lowerCaseTerm = this.searchTerm.toLowerCase();
                return this.doctors.filter(doctor =>
                    doctor.name.toLowerCase().includes(lowerCaseTerm) ||
                    doctor.speciality.toLowerCase().includes(lowerCaseTerm)
                );
            }
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
            bookAppointment(doctorId) {
                this.$router.push({ name: 'add-appointment', params: { doctorId: doctorId } });
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
        max-width: 800px;
        margin: 0 auto;
        padding: 20px;
        font-family: 'Arial', sans-serif;
    }

    .search-box {
        margin-bottom: 20px;
    }

        .search-box input {
            width: 100%;
            padding: 10px;
            font-size: 18px;
            border: none;
            border-radius: 5px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
        }

    .doctor-item {
        background-color: #f7f7f7;
        border: 1px solid #eee;
        padding: 15px;
        margin-bottom: 20px;
        border-radius: 5px;
        box-shadow: 0 4px 8px rgba(0,0,0,0.05);
    }

        .doctor-item h3 {
            font-size: 24px;
            margin-bottom: 10px;
        }

    .speciality {
        color: #777;
        font-weight: normal;
    }

    .book-btn, button {
        padding: 10px 20px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        margin-right: 10px;
    }

    .book-btn {
        background-color: #3498db;
        color: #fff;
        transition: background-color 0.3s ease;
    }

        .book-btn:hover {
            background-color: #2980b9;
        }

    .add-doctor {
        text-align: center;
        margin-top: 20px;
    }

    .button-container button {
        background-color: #e74c3c;
        color: #fff;
        margin-left: 5px;
    }

        .button-container button:hover {
            background-color: #c0392b;
        }

        .button-container button:nth-child(1) {
            background-color: #f39c12;
        }

            .button-container button:nth-child(1):hover {
                background-color: #e67e22;
            }
</style>