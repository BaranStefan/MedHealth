<template>
    <nav class="navbar">
        <router-link to="/" exact class="nav-item">Home</router-link>
        <router-link to="/Doctors" class="nav-item">Doctors</router-link>
        <router-link to="/Register" class="nav-item">Register</router-link>
        <router-link to="/Login" class="nav-item">Login</router-link>
    </nav>
</template>

<style scoped>
    .navbar {
        background-color: #333;
        padding: 10px 20px;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    .nav-item {
        color: #fff;
        text-decoration: none;
        margin: 0 15px;
        padding: 5px 10px;
        border-radius: 5px;
        transition: background-color 0.3s ease;
    }

        .nav-item:hover {
            background-color: #555;
        }

    .router-link-exact-active {
        background-color: #555;
    }
</style>
