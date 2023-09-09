<template>
    <div class="container">
        <h2>Welcome to our Medical Cabinet</h2>

        <div v-if="state.user">
            <p class="doctor-cta">See all the doctors available <router-link to="/doctors" class="link"> Here</router-link></p>

            <div class="specialty-section" v-for="(docs, specialty) in groupedDoctors" :key="specialty">
                <h3>Here are some of our doctors specializing in: {{ specialty }}</h3>
                <ul>
                    <li v-for="doctor in docs" :key="doctor.id">{{ doctor.name }}</li>
                </ul>
            </div>
        </div>

        <div v-if="!state.user" class="login-register">
            <p>Already have an account? <router-link to="/login" class="link">Login</router-link></p>
            <p>Don't have an account? <router-link to="/register" class="link">Register</router-link></p>
        </div>
    </div>
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
        computed: {
            groupedDoctors() {
                const specialties = {};

                this.doctors.forEach(doctor => {
                    if (!specialties[doctor.speciality]) {
                        specialties[doctor.speciality] = [];
                    }
                    if (specialties[doctor.speciality].length < 3) {
                        specialties[doctor.speciality].push(doctor);
                    }
                });

                return specialties;
            }
        },
        methods: {
            async fetchDoctors() {
                const response = await axios.get("/api/doctors");
                this.doctors = response.data;
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
        text-align: center;
    }

    h2 {
        font-size: 2rem;
        color: #34495e;
        margin-bottom: 30px;
    }

    .doctor-cta {
        font-size: 1.2rem;
        margin-bottom: 20px;
    }

    .link {
        color: #3498db;
        text-decoration: none;
        font-weight: bold;
    }

        .link:hover {
            text-decoration: underline;
        }

    .specialty-section {
        background-color: #f7f9fc;
        padding: 20px;
        margin-bottom: 20px;
        border-radius: 5px;
        box-shadow: 0 4px 8px rgba(0,0,0,0.05);
    }

        .specialty-section h3 {
            font-size: 1.5rem;
            color: #2c3e50;
            margin-bottom: 15px;
        }

    ul {
        list-style-type: none;
        padding-left: 0;
    }

    li {
        font-size: 1.1rem;
        margin-bottom: 10px;
    }

    .login-register {
        margin-top: 30px;
    }
</style>