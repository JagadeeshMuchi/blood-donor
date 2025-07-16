<template>
    <div class="container">
        <nav class="bottom-nav">
            <router-link to="/Home"  class="nav-item" active-class="active">
                <div class="nav-item" :active-class="active">🏠<br />Home</div>
            </router-link>
            <router-link  class="nav-item" active-class="active" to="/Search">
                <div>🔍<br />Search</div>
            </router-link>
            <router-link  class="nav-item" active-class="active" to="/notifications">
                <div>🔔<br />Notifications</div>
            </router-link>
            <router-link to="/Profile" class="nav-item" active-class="active">
                <div :class="router.name=='Profile'?'nav-item.active':'nav-item'">👤<br />Account</div>
            </router-link>
        </nav>
    </div>
</template>
<script setup>
import { ref } from 'vue';  
import { useRouter, RouterLink } from 'vue-router';
const router = useRouter();
</script>
<style scoped>
.container {
  font-family: sans-serif;
  background: #f2f2f2;
  padding-bottom: 10px;
  margin: 0 auto;
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
.bottom-nav :hover {
  transform: translateY(-2px) scale(1.05);
  font-weight: bold;
}

.nav-item {
  text-align: center;
  font-size: 12px;
  color: #666;
}
/* .nav-item :hover {
 transform: translateY(-10px) scale(1.02) rotateX(1deg) rotateY(1deg);
  font-weight: bold;
} */
/* .nav-item.active {
  color: #e53935;
  font-weight: bold;
} */
.nav-item.active {
  color: #e53935;
  font-weight: bold;
  border-top: 2px solid #e53935;
}
</style>