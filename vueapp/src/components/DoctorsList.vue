<template>
    <div>
        <h2>Select a Doctor</h2>
        <ul>
            <li v-for="doctor in doctors" :key="doctor.id">
                <router-link :to="`/appointment/${doctor.id}`">{{ doctor.name }}</router-link>
            </li>
        </ul>
    </div>
</template>

<script>
export default {
  data() {
    return {
      doctors: [
        { id: 1, name: 'Dr. Smith' },
        { id: 2, name: 'Dr. Johnson' },
        // ... add more doctors as needed
      ],
    };
  }
};
</script>
