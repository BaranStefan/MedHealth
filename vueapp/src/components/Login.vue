<template>
    <div class="login-container">
        <h3>Login</h3>
        <form @submit.prevent="submitForm">
            <div>
                <label for="username">Username:</label>
                <input type="text" id="username" v-model="username" required />
            </div>
            <div>
                <label for="password">Password:</label>
                <input type="password" id="password" v-model="password" required />
            </div>
            <button type="submit">Login</button>
        </form>
    </div>
</template>

<script>
export default {
  data() {
    return {
      username: '',
      password: ''
    };
  },
  methods: {
    async submitForm() {
      // TODO: Implement logic to send this data to your .NET 6 backend for validation.
      // For example, using axios:
      /*
      axios.post('/api/auth/login', {
        username: this.username,
        password: this.password
      }).then(response => {
        if (response.data.success) {
          // Store your token or handle login success here
        } else {
          // Handle login failure, show a message, etc.
        }
      }).catch(error => {
        console.error("There was an error during login:", error);
      });
      */

      console.log("Login attempt:", this.username);
    }
  }
};
</script>

<style scoped>
    .login-container {
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
