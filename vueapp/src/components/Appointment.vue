<template>
    <div>
        <h2>Appointment with {{ doctorName }}</h2>
        <form @submit.prevent="bookAppointment">
            <div>
                <label for="date">Date:</label>
                <input type="date" v-model="appointmentDate" required />
            </div>
            <div>
                <label for="time">Time:</label>
                <input type="time" v-model="appointmentTime" required />
            </div>
            <button type="submit">Book</button>
        </form>
    </div>
</template>

<script>
export default {
  props: ['doctorId'],
  data() {
    return {
      doctorName: '', // Placeholder, should be fetched based on doctorId
      appointmentDate: '',
      appointmentTime: ''
    };
  },
  created() {
    // Mock fetching doctor's name based on doctorId.
    // In real scenarios, you'd probably do an API call.
    const mockDoctors = {
      1: 'Dr. Smith',
      2: 'Dr. Johnson',
      // ... add other doctors
    };

    this.doctorName = mockDoctors[this.doctorId];
  },
  methods: {
    bookAppointment() {
      // Handle logic for booking an appointment
      console.log(`Appointment set with ${this.doctorName} on ${this.appointmentDate} at ${this.appointmentTime}`);
    }
  }
};
</script>
