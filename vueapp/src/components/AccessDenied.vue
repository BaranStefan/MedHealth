<template>
    <div class="access-denied">
        <h2>Access Denied</h2>
        <p>Please <router-link to="/login">login</router-link> to access this page.</p>
    </div>
</template>

<style scoped>
    .access-denied {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        height: 100vh; 
        text-align: center; 
    }

        .access-denied h2 {
            font-size: 2.5rem; 
            margin-bottom: 1rem; 
        }

        .access-denied p {
            font-size: 1.5rem; 
        }
</style>
