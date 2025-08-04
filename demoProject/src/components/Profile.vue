<template>
    <div class="container1">
        <div class="header"> 
          <!-- @mouseenter="showSidebar" @mouseleave="hideSidebar" -->
            <button class="menu-btn" @click="showSidebar" >☰</button>
            <div v-if="isShowSidebar" class="custom-sidebar" >
                <button class="close-btn" @click="hideSidebar">×</button>
                <div class="sidebar-profile">
                  <img class="sidebar-avatar" v-if="profileView.profileUrl" :src="profileView.profileUrl" alt="Profile" />
                  <img class="sidebar-avatar" v-else src="/src/assets/Panda.png" alt="Profile" />
                  <div class="sidebar-username">{{ profileView.profileName || 'User' }}</div>
                </div>
                <nav class="sidebar-menu">
                  <router-link to="/Profile" class="sidebar-link">Profile</router-link>
                  <a href="#" class="sidebar-link" @click.prevent="showLogoutDialog">Logout</a>
                </nav>
            </div>
            <div class="profile-img-container">
                <img class="profile-img" v-if="profileView.profileUrl" :src="profileView.profileUrl" alt="Profile Image" />
                <img class="profile-img" v-else src="/src/assets/Panda.png" alt="Profile Image" />
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
                {{profileView.state}}<br />
               {{profileView.country}}
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
       <!-- Logout Confirmation Dialog -->
        <div v-if="isShowLogoutDialog" class="logout-dialog-overlay">
          <div class="logout-dialog">
            <p>Are you sure you want to logout?</p>
            <div class="logout-dialog-actions">
              <button @click="confirmLogout" class="logout-yes">Yes</button>
              <button @click="cancelLogout" class="logout-no">No</button>
            </div>
          </div>
        </div>
    </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import  apiServer  from '../Services/apiServer'
// Removed PrimeVue sidebar import
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
const route = useRoute();
const profileView = ref({});
const isShowSidebar = ref(false);
const iEmpId= localStorage.getItem('ProfileId');
onMounted(() => {
  const profileId = route.params.profileId;
  apiServer.getUserProfile(profileId).then((res) => {
    profileView.value = res.data;
  }).catch((error) => {
    console.error("Error fetching user profile:", error);
    apiServer.getProfile(iEmpId).then((res)=>{
      //profileView.value=res.data
      profileView.value.profileName=res.data.sName;
      profileView.value.bloodGroup=res.data.iBloodGroup;
      profileView.value.sEmial=res.data.UserMail;
      profileView.value.country=res.data.Country;
      profileView.value.state=res.data.iLocation

    })
    
  });
});
const showSidebar = () => {
  isShowSidebar.value = true;
};
const hideSidebar = () => {
  isShowSidebar.value = false;
};
const isShowLogoutDialog = ref(false);
const showLogoutDialog = () => {
  isShowLogoutDialog.value = true;
};
const confirmLogout = () => {
  isShowLogoutDialog.value = false;
  router.push('/'); // navigate to login
};
const cancelLogout = () => {
  isShowLogoutDialog.value = false;
};

</script>

<style scoped>
.container1 {
  /* display: auto;
  justify-content: center; */
  max-width: 700px;
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

/* Sidebar styles */
/* Udemy-style sidebar */
.custom-sidebar {
  position: absolute;
  top: 1;
  left: 1;
  height: 100%;
  width: 240px;
  background: #fff;
  box-shadow: 2px 0 12px rgba(0,0,0,0.10);
  z-index: 10001;
  padding: 24px 0 0 0;
  display: flex;
  flex-direction: column;
  align-items: center;
  border-top-right-radius: 16px;
  border-bottom-right-radius: 16px;
  transition: transform 0.3s cubic-bezier(.4,0,.2,1);
}
.custom-sidebar .close-btn {
  position: absolute;
  top: 12px;
  right: 12px;
  background: none;
  border: none;
  font-size: 22px;
  color: #888;
  cursor: pointer;
}
.sidebar-profile {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-bottom: 18px;
}
.sidebar-avatar {
  width: 64px;
  height: 64px;
  border-radius: 50%;
  object-fit: cover;
  border: 2px solid #eee;
  margin-bottom: 8px;
}
.sidebar-username {
  font-size: 16px;
  font-weight: 600;
  color: #222;
}
.sidebar-menu {
  display: flex;
  flex-direction: column;
  gap: 8px;
  width: 100%;
  padding: 0 24px;
}
.sidebar-link {
  display: block;
  padding: 10px 0 10px 16px;
  color: #333;
  text-decoration: none;
  font-size: 15px;
  border-radius: 6px;
  transition: background 0.2s, color 0.2s;
}
.sidebar-link:hover {
  background: #f0f6ff;
  color: #0066cc;
  font-weight: 500;
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
  padding: 25px 15px 20px;
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
/* Logout dialog styles */
.logout-dialog-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100vw;
  height: 100vh;
  background: rgba(0,0,0,0.25);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 20000;
}
.logout-dialog {
  background: #fff;
  padding: 28px 32px;
  border-radius: 10px;
  box-shadow: 0 2px 16px rgba(0,0,0,0.12);
  text-align: center;
}
.logout-dialog-actions {
  margin-top: 18px;
  display: flex;
  gap: 16px;
  justify-content: center;
}
.logout-yes {
  background: #e53935;
  color: #fff;
  border: none;
  padding: 8px 18px;
  border-radius: 6px;
  font-size: 15px;
  cursor: pointer;
}
.logout-no {
  background: #eee;
  color: #333;
  border: none;
  padding: 8px 18px;
  border-radius: 6px;
  font-size: 15px;
  cursor: pointer;
}
.logout-yes:hover {
  background: #b71c1c;
}
.logout-no:hover {
  background: #ddd;
}
</style>
