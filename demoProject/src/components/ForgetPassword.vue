<template>
  <div class="fp-container">
    <div class="fp-card">
      <h2 class="fp-title">Reset your password</h2>
      <p class="fp-desc">Enter your email address and we'll send you a link to reset your password.</p>
      <form @submit.prevent="resetPassword" class="fp-form">
        <div class="fp-form-group">
          <label for="email">Email address</label>
          <input type="email" id="email" v-model="email" placeholder="Enter your email" required />
        </div>
        <button type="submit" class="fp-btn">Send password reset email</button>
      </form>
      <div class="fp-message" v-if="message">{{ message }}</div>
      <router-link to="/" class="fp-back">Back to Sign In</router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ForgetPassword',
  data() {
    return {
      email: '',
      message: '',
    };
  },
  methods: {
    resetPassword() {
      // Add your password reset logic here
      this.message = 'If this email is registered, a reset link will be sent.';
    },
  },
};
</script>

<style scoped>
.fp-container {
  min-height: 100vh;
  display: flex;
  align-items: center;
  justify-content: center;
  background: #f6f8fa;
}
.fp-card {
  background: #fff;
  padding: 32px 28px;
  border-radius: 8px;
  box-shadow: 0 2px 16px rgba(0,0,0,0.08);
  max-width: 400px;
  width: 100%;
  text-align: center;
}
.fp-title {
  font-size: 1.5rem;
  font-weight: 600;
  margin-bottom: 18px;
}
.fp-desc {
  font-size: 15px;
  color: #57606a;
  margin-bottom: 22px;
}
.fp-form {
  display: flex;
  flex-direction: column;
  gap: 16px;
  margin-bottom: 10px;
}
.fp-form-group {
  text-align: left;
}
.fp-form-group label {
  display: block;
  margin-bottom: 6px;
  font-size: 14px;
  font-weight: 500;
}
.fp-form-group input {
  width: 100%;
  padding: 8px 10px;
  border: 1px solid #d0d7de;
  border-radius: 4px;
  font-size: 15px;
  background: #f6f8fa;
  transition: border-color 0.2s;
}
.fp-form-group input:focus {
  border-color: #0969da;
  outline: none;
}
.fp-btn {
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
.fp-btn:hover {
  background: #22863a;
}
.fp-message {
  margin-top: 16px;
  color: #0969da;
  font-size: 14px;
}
.fp-back {
  display: inline-block;
  margin-top: 18px;
  color: #0969da;
  text-decoration: none;
  font-size: 14px;
}
.fp-back:hover {
  text-decoration: underline;
}
</style>