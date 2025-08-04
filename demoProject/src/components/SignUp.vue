<template>
  <div class="signup-container">
    <div v-if="signupMessage" :class="['signup-alert', signupMessageType === 'success' ? 'signup-success' : 'signup-error']">
      {{ signupMessage }}
      <span class="signup-alert-close" @click="signupMessage = ''">×</span>
    </div>
    <div class="signup-logo">
      <img src="/src/assets/BloodDonorLogo.png" alt="Blood Donor Logo" />
    </div>
    <h2>Create your account</h2>
    <form @submit.prevent="handleSubmit" class="signup-form" novalidate>
      <div class="form-group">
        <label for="username">Username</label>
        <input type="text" id="username" v-model="loginView.username" @blur="validateUsername" />
        <span v-if="errors.username" class="error-msg">{{ errors.username }}</span>
      </div>
      <div class="form-group">
        <label for="email">Email address</label>
        <input type="email" id="email" v-model="loginView.email" @blur="validateEmail" />
        <span v-if="errors.email" class="error-msg">{{ errors.email }}</span>
      </div>
      <div class="form-group">
        <label for="password">Password</label>
        <input type="password" id="password" v-model="loginView.password" @blur="validatePassword" />
        <span v-if="errors.password" class="error-msg">{{ errors.password }}</span>
      </div>
      <div class="form-group">
        <label for="country">Country</label>
        <select id="country" v-model="loginView.country">
          <option value="">Select country</option>
          <option value="India">India</option>
          <option value="USA">USA</option>
          <option value="UK">UK</option>
          <option value="Canada">Canada</option>
          <option value="Australia">Australia</option>
          <!-- Add more countries as needed -->
        </select>
      </div>

      <button type="submit" class="signup-btn">Create account</button>
    </form>
    <p class="signup-footer">Already have an account?  <router-link to="/">Sign in</router-link></p>
  </div>
</template>

<script>
import { ref } from 'vue';
import { useRouter, RouterLink } from 'vue-router';
import login from './Login.vue';
import apiServer from '../Services/apiServer';

export default {
  name: 'SignUp',
  data() {
    return {
      username: '',
      email: '',
      password: '',
      errors: {
        username: '',
        email: '',
        password: '',
      },
      loginView: { username: '', password: '', email: '', country: '' },
      signupMessage: '',
      signupMessageType: '',
    };
  },
  // removed toast setup
  methods: {
    validateUsername() {
      if (!this.loginView.username) {
        this.errors.username = 'Username is required.';
      } else {
        this.errors.username = '';
      }
    },
    validateEmail() {
      const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      if (!this.loginView.email) {
        this.errors.email = 'Email is required.';
      } else if (!emailPattern.test(this.loginView.email)) {
        this.errors.email = 'Please enter a valid email address.';
      } else {
        this.errors.email = '';
      }
    },
    validatePassword() {
      if (!this.loginView.password) {
        this.errors.password = 'Password is required.';
      } else if (this.loginView.password.length < 8) {
        this.errors.password = 'Password must be at least 8 characters.';
      } else {
        this.errors.password = '';
      }
    },
    clearData() {
      this.loginView.country = '';
      this.loginView.username = '';
      this.loginView.password = '';
      this.loginView.email = '';
    },
    handleSubmit() {
      this.validateUsername();
      this.validateEmail();
      this.validatePassword();
      if (!this.errors.username && !this.errors.email && !this.errors.password) {
        apiServer.createAccount(this.loginView).then((res) => {
          if (res.data > 0) {
            this.signupMessage = 'Account Created';
            this.signupMessageType = 'success';
            this.clearData();
          } else {
            this.signupMessage = 'Server is not working, please try again later';
            this.signupMessageType = 'error';
          }
          // Auto-hide message after 3 seconds
          setTimeout(() => {
            this.signupMessage = '';
          }, 3000);
        });
      }
    },
  },
  components: {
    login,
  },
};
</script>

<style scoped>
.signup-container {
  max-width: 400px;
  margin: 40px auto;
  padding: 32px 24px;
  background: #fff;
  border-radius: 8px;
  box-shadow: 0 2px 16px rgba(0,0,0,0.08);
  text-align: center;
}
.signup-logo img {
  width: 108px;
  margin-bottom: 10px;
}
h2 {
  margin-bottom: 24px;
  font-weight: 600;
}
.signup-form {
  display: flex;
  flex-direction: column;
  gap: 16px;
}
.form-group {
  text-align: left;
}
label {
  display: block;
  margin-bottom: 6px;
  font-size: 14px;
  font-weight: 500;
}
input, select {
  width: 100%;
  padding: 8px 10px;
  border: 1px solid #d0d7de;
  border-radius: 4px;
  font-size: 15px;
  background: #f6f8fa;
  transition: border-color 0.2s;
}
input:focus, select:focus {
  border-color: #0969da;
  outline: none;
}
.signup-btn {
  background: #2ea44f;
  color: #fff;
  border: none;
  padding: 10px 0;
  border-radius: 6px;
  font-size: 16px;
  font-weight: 600;
  cursor: pointer;
  margin-top: 8px;
  transition: background 0.2s;
}
.signup-btn:hover {
  background: #22863a;
}
.signup-footer {
  margin-top: 24px;
  font-size: 14px;
}
.signup-footer a {
  color: #0969da;
  text-decoration: none;
}
.signup-footer a:hover {
  text-decoration: underline;
}
 .error-msg {
   color: #d73a49;
   font-size: 13px;
   margin-top: 4px;
   display: block;
 }
 .signup-success {
   color: #2ea44f;
   font-size: 15px;
   margin-top: 16px;
   font-weight: 600;
 }
 .signup-error {
   color: #d73a49;
   font-size: 15px;
   margin-top: 16px;
   font-weight: 600;
 }
 .signup-alert {
   position: fixed;
   top: 0;
   left: 3;
   width: 30%;
   padding: 16px 9px;
   text-align: left;
   font-size: 16px;
   font-weight: 600;
   z-index: 100;
   border-radius: 0 0 8px 8px;
   box-shadow: 0 2px 8px rgba(0,0,0,0.08);
   display: flex;
   justify-content: center;
   align-items: center;
   margin: 0rem 0rem 0rem 35rem;
 }
 .signup-success.signup-alert {
   background: #e6f4ea;
   color: #22863a;
   border-bottom: 2px solid #2ea44f;
 }
 .signup-error.signup-alert {
   background: #fbeaea;
   color: #d73a49;
   border-bottom: 2px solid #d73a49;
 }
 .signup-alert-close {
   margin-left: 16px;
   cursor: pointer;
   font-size: 22px;
   color: #888;
   font-weight: bold;
   background: none;
   border: none;
 }
</style>
