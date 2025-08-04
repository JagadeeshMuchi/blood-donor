<template>
  <div class="login-container">
    <h2 class="text-xl font-bold mb-4">Sign in to BloodDonor</h2>
    
    <form @submit.prevent="login" class="login-form">
      <div class="form-group">
        <label for="email" class="label-password">Username or email address</label>
        <input type="text" id="email" v-model="email" placeholder="Enter Username or email" required />
      </div>
      <div class="form-group">
        <div class="label-row">
          <label for="password" class="label-password">Password</label>
          <router-link to="/ForgetPassword" class="forget-link">Forget Password?</router-link>
        </div>
        <input type="password" id="password" v-model="password" placeholder="Enter password" required /> 
      </div>
     
      <button type="submit" class="btn">Login</button>
    </form>
    <p>Don't have an account?<router-link to="/SignUp" class="forget-link">Sign Up</router-link></p>
    
    <div v-if="error" class="text-red-600 mt-2">{{ error }}</div>
  </div>
</template>

<script setup>
import { ref,onMounted } from 'vue'
import { useRouter } from 'vue-router'
import  apiServer  from '../Services/apiServer'


const email = ref('')
const password = ref('')
const error = ref('')
const router = useRouter();


onMounted(()=>{
  //getLogin();
});

const login=function(){
    apiServer.getlogin(email.value,password.value).then((res)=>{
      //alert(res.data.count)
        if(res.data.count>0){
          localStorage.setItem('ProfileId',res.data.id);
           router.push('/Home');
          // router.push({
          //   name: '/Home',
          //   query: {
          //     //username: this.username,
          //     iProfileId: res.data.id
          //   }
          // })
        }
    }).catch((err)=>{
      alert('Mvc Sever is Not Running could you want to  check in node server');
      console.error(err);
      apiServer.checkLogin(email.value,password.value).then((res)=>{
        if(res.data.UserId){
          localStorage.setItem('ProfileId',res.data.UserId);
          router.push('/Home');
        }
        else{
          error.value = 'Invalid username or password';
        }
      }).catch((err)=>{
        console.error(err);
        error.value = err;
      });
    })
}


</script>

<style scoped>
.login-container {
  max-width: 400px;
  margin: auto;
  padding: 1rem;
  border-radius: 10px;
  box-shadow: 0 2px 8px rgba(0,0,0,0.1);
  background: #fff;
}
.login-form {
  display: flex;
  flex-direction: column;
  gap: 16px;
}
 .form-group {
   text-align: left;
   margin-bottom: 1rem;
 }
 .label-row {
   display: flex;
   justify-content: space-between;
   align-items: center;
   margin-bottom: 6px;
 }
 .label-password {
   font-size: 14px;
   font-weight: 500;
 }
 .forget-link {
   font-size: 13px;
   color: #0969da;
   text-decoration: none;
   margin-left: 8px;
 }
 .forget-link:hover {
   text-decoration: underline;
 }
input {
  width: 100%;
  padding: 8px 10px;
  border: 1px solid #d0d7de;
  border-radius: 4px;
  font-size: 15px;
  background: #f6f8fa;
  transition: border-color 0.2s;
}
input:focus {
  border-color: #0969da;
  outline: none;
}

.btn {
  padding: 10px 20px;
  background-color: #4f46e5;
  color: #fff;
  border: none;
  border-radius: 5px;
  margin-top: 10px;
}
</style>
