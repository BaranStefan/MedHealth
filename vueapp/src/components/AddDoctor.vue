<template>
    <div class="add-doctor-container">
        <h2>Add Doctor</h2>
        <form @submit.prevent="createDoctor">
            <div>
                <label for="doctorName">Doctor Name:</label>
                <input type="text" id="doctorName" v-model="currentDoctor.name" required />
            </div>
            <div>
                <label for="speciality">Speciality:</label>
                <input type="text" id="speciality" v-model="currentDoctor.speciality" required />
            </div>
            <div>
                <label for="phone">Phone:</label>
                <input type="text" id="phone" v-model="currentDoctor.phone" required />
            </div>
            <div>
                <label for="email">Email:</label>
                <input type="email" id="email" v-model="currentDoctor.mail" required />
            </div>
            <button type="submit">Add</button>
        </form>
    </div>
</template>

<script>
    import axios from "axios";

    export default {
        data() {
            return {
                currentDoctor: {}
            };
        },
        methods: {
            async createDoctor() {
                await axios.post("/api/doctors", this.currentDoctor);
                this.$router.push('/doctors');  
            }
        }
    };
</script>

<style scoped>
    .add-doctor-container {
        background-color: #f7f7f7;
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

    input {
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
