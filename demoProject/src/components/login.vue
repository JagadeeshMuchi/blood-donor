<template>
  <div class="login-container">
    <h2 class="text-xl font-bold mb-4">Login</h2>
    
    <form @submit.prevent="login">
      <div class="mb-3">
        <label>Email</label>
        <input v-model="email" type="email" placeholder="Enter email" class="input" required />
      </div>

      <div class="mb-3">
        <label>Password</label>
        <input v-model="password" type="password" placeholder="Enter password" class="input" required />
      </div>

      <button type="submit" class="btn">Login</button>
    </form>

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
    })
}

// async function getLogin() {
//   let response = await apiClient.get('/getLogin');

//     email.value=response.data.UserName
// } 
// const login = async () => {
//   error.value = ''
//   try {
//     const response = await axios.post('http://bloodDonar:8080/api/login/getLogin', {
//       email: email.value,
//       password: password.value
//     })

//     // Handle token or success message
//     const token = response.data.token
//     localStorage.setItem('token', token)

//     router.push('/dashboard') // Redirect to dashboard or home
//   } catch (err) {
//     error.value = err.response?.data?.message || 'Login failed'
//   }
// }
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

.input {
  width: 100%;
  padding: 8px;
  margin-top: 4px;
  border-radius: 4px;
  border: 1px solid #ccc;
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
