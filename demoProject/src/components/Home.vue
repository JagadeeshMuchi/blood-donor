<template>
  <div class="container">
  
    <header class="header">
      <h1>Home</h1>
    </header>

    
    <section class="donor-card">
      <img src="" alt="donor" />
      <div class="donor-text">
        <p class="bold">Become a Blood Donor</p>
        <p>Donate directly to people in need</p>
      </div>
    </section>

    
    <section class="donation-card">
      <router-link to="/FindDonar"><div class="action-card" v-tooltip="FindDonar">🔍<br />Find Donors</div></router-link>
      <router-link to="/Donate"><div class="action-card" v-tooltip="Donate">💉<br />Donate</div></router-link>
      <router-link to="/RequestBlood"><div class="action-card">📦<br />Order Blood</div></router-link>
    </section>

    
    <section class="donations">
      <div class="donations-header">
        <h3>Donation Need</h3>
        <a href="#">View all</a>
      </div>

      <div class="donation-card">
        <div class="blood-type">O+</div>
        <div class="donor-info">
          <p class="name">Harika PanciReddy</p>
          <p class="details">1 unit · 8 km away</p>
        </div>
        <p class="time">2 hours ago</p>
      </div>

      <div class="donation-card">
        <div class="blood-type">B+</div>
        <div class="donor-info">
          <p class="name">Vijay</p>
          <p class="details">2 units · 3 km away</p>
          <span class="tag">Platelets</span>
        </div>
        <p class="time">30 mins ago</p>
      </div>
    </section>

   <NavItem></NavItem>
    
  </div>
</template>
<script setup>
import { ref } from 'vue';  
import { useRouter,RouterLink } from 'vue-router';
import NavItem from './NavItem.vue';

</script>

<style scoped>
.container {
  font-family: sans-serif;
  background: #f2f2f2;
  padding-bottom: 80px;
  /* max-width: 580px; */
  margin: 0 auto;
}
/* .container1 {
  max-width: fit-content;
  margin: 0 auto;
  font-family: Arial, sans-serif;
  background-color: #fff;
  border-radius: 12px;
  overflow: hidden;
} */

.header {
  background-color: #e53935;
  color: white;
  padding: 16px;
  font-size: 24px;
  font-weight: bold;
  border-bottom-left-radius: 15px;
  border-bottom-right-radius: 15px;
  text-align: center;
}

.donor-card {
  background: white;
  display: flex;
  padding: 16px;
  margin: 16px;
  border-radius: 12px;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
}

.donor-card img {
  width: 80px;
  height: 80px;
  object-fit: contain;
}

.donor-text {
  margin-left: 12px;
}

.donor-text h2 {
  margin: 0;
  color: #e53935;
}

.bold {
  font-weight: bold;
  margin-top: 4px;
}

.actions {
  display: flex;
  justify-content: space-around;
  margin: 16px;
}

.action-card {
    display: flex;
    justify-content: center;
  width: 20rem;
  height: 4rem;
  margin: 05.rem;
  background: white;
  text-align: center;
  padding: 12px;
  border-radius: 1rem;
  font-weight: bold;
  font-size: 14px;
  border: 1px solid #ccc;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    transition: transform 0.3s ease, box-shadow 0.3s ease;
  cursor: pointer;
  transform-style: preserve-3d;
  will-change: transform ;
}
.action-card:hover {
  background: linear-gradient(white, white) padding-box,
              linear-gradient(45deg, #f44336, #e91e63) border-box;
  border: 2px solid transparent;
 transform: translateY(-10px) scale(1.02) rotateX(1deg) rotateY(1deg);
  box-shadow: 0 12px 24px rgba(0, 0, 0, 0.2);
}

.donations {
  margin: 16px;
}

.donations-header {
  display: flex;
  justify-content: space-between;
  margin-bottom: 12px;
}

.donations-header a {
  color: #e53935;
  font-size: 14px;
  text-decoration: none;
}

.donation-card {
  background: white;
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 12px;
  border-radius: 10px;
  margin-bottom: 10px;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
}

.blood-type {
  background: #e53935;
  color: white;
  font-weight: bold;
  padding: 10px;
  border-radius: 20px;
  min-width: 40px;
  text-align: center;
}

.donor-info {
  flex: 1;
  margin-left: 10px;
}

.donor-info .name {
  font-weight: bold;
  margin: 0;
}

.donor-info .details {
  font-size: 12px;
  color: gray;
}

.donor-info .tag {
  display: inline-block;
  background: #ffcccb;
  color: #b71c1c;
  font-size: 11px;
  padding: 2px 6px;
  margin-top: 4px;
  border-radius: 5px;
}

.time {
  font-size: 12px;
  color: gray;
}

.bottom-nav {
  bottom: 0;
  left: 0;
  right: 0;
  background: white;
  display: flex;
  justify-content: space-around;
  border-top: 1px solid #ccc;
  padding: 8px 0;
}

.nav-item {
  text-align: center;
  font-size: 12px;
  color: #666;
}

.nav-item.active {
  color: #e53935;
  font-weight: bold;
}
</style>
