<template>
    <div class="container1">
        <div class="header">
            <button class="menu-btn" @click="openSideBar">☰</button>
            <sidebar v-if="isShowSidebar" :visible="isShowSidebar" @close-mega="openSideBar" :position="center"
                :base-z-index="10000" show-close-icon="true">
                <p>Sidebar content goes here</p>
            </sidebar>
            <div class="profile-img-container">
                <img class="profile-img" :src="profileView.profileUrl" alt="Profile Image" />
            </div>
            <button class="edit-btn">Edit Profile</button>
        </div>

        <div class="profile-info">
            <h2>{{profileView.profileName}}</h2>
            <div class="blood-donations">
                <span><strong>BloodGroup</strong> {{profileView.bloodGroup}}</span>
                <span><strong>Donations:</strong> 3</span>
            </div>

            <div class="info-row"><strong>Email:</strong> {{ profileView.sEmial }}</div>
            <div class="info-row"><strong>Mobile No.:</strong> +91 {{profileView.phoneNumber}}</div>
            <div class="info-row">
                <strong>Address:</strong><br />
                Address Line 1<br />
                Address Line 2
            </div>
            <div class="info-row"><strong>Area:</strong> Adiliya</div>
        </div>

        <div class="acknowledge-section">
            <h3>We Acknowledge</h3>
            <p>
                Here is a badge for you as our appreciation for your contributions made to save lives.
            </p>
            <img class="badge-img" src="https://i.imgur.com/BsN1E9v.png" alt="Blood Donor Badge" />
            <p class="badge-text">I'M A BLOOD DONOR</p>
        </div>
        <nav-item></nav-item>
    </div>
</template>

<script setup>
import { ref,onMounted ,defineProps} from 'vue'
import { useRouter } from 'vue-router'
import  apiServer  from '../Services/apiServer'
import sidebar from 'primevue/sidebar';
import NavItem from './NavItem.vue';
// const props = defineProps({
//   userName: {
//     type: String,
//     default: 'jagadeesh'
//   },
//   password: {
//     type: String,
//     default: '9550075256HaJa'
//   }
// });

const router = useRouter();
// const username = router.query.username
// const password = router.query.password
//const iProfId=router.query.iProfileId;
const profileView=ref({});
const iEmpId=ref(0);
const isShowSidebar = ref(false);

onMounted(() => {
    // You can fetch user data here if needed
   iEmpId.value= localStorage.getItem('ProfileId');
     apiServer.getUserProfile(iEmpId.value).then((res) => { 
        profileView.value = res.data;
        
     }).catch((error) => {
        console.error("Error fetching user profile:", error);});
});
const openSideBar = () => {
  // Logic to open sidebar
  if(!isShowSidebar.value) {
    isShowSidebar.value = true;
  } else {
    isShowSidebar.value = false;
}
 
};
</script>

<style scoped>
.container1 {
  /* display: auto;
  justify-content: center; */
  /* max-width: fit-content; */
  margin: 0 auto;
  font-family: Arial, sans-serif;
  background-color: #fff;
  border-radius: 12px;
  overflow: hidden;
  /* box-shadow: 0 4px 10px rgba(0, 0, 0, 0.15); */
}

.header {
  background-color: #0066cc;
  color: white;
  padding: 20px 50px 50px;
  position: relative;
  text-align: center;
}

.menu-btn {
  position: absolute;
  left: 15px;
  top: 15px;
  background: none;
  border: none;
  color: white;
  font-size: 20px;
}

.profile-img-container {
  position: absolute;
  top: 50px;
  left: 50%;
  transform: translateX(-50%);
  border-radius: 50%;
  overflow: hidden;
  border: 4px solid white;
  width: 100px;
  height: 100px;
}

.profile-img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.edit-btn {
  margin-top: 144px;
  background-color: transparent;
  border: 1px solid white;
  color: white;
  padding: 5px 12px;
  border-radius: 5px;
  font-size: 14px;
  cursor: pointer;
}

.profile-info {
  padding: 80px 15px 20px;
  text-align: center;
}

.profile-info h2 {
  margin-bottom: 10px;
  font-size: 20px;
}

.blood-donations {
  font-size: 14px;
  color: #444;
  margin-bottom: 15px;
}

.blood-donations span {
  display: inline-block;
  margin: 0 10px;
}

.info-row {
  font-size: 14px;
  text-align: left;
  padding: 8px 0;
  border-bottom: 1px solid #eee;
}

.acknowledge-section {
  background-color: #f0f6ff;
  padding: 20px 15px;
  text-align: center;
}

.acknowledge-section h3 {
  color: #d60000;
  margin-bottom: 10px;
}

.acknowledge-section p {
  font-size: 13px;
  color: #555;
}

.badge-img {
  width: 80px;
  margin: 15px auto 5px;
}

.badge-text {
  font-size: 12px;
  color: #444;
  font-style: italic;
}
</style>
