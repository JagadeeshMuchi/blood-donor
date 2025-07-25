import { createRouter,createWebHistory } from "vue-router";
import login from '../components/login.vue'
import Profile from "../components/Profile.vue";
import Home from "../components/Home.vue";
import ActionCard from '../components/ActionCard.vue';
import DonationCard from '../components/DonationCard.vue';
import NavItem from '../components/NavItem.vue';
import Donate  from "../components/QuickAction/Donate.vue";
import FindDonar from "../components/QuickAction/FindDonar.vue";
import OrderBlood from "../components/QuickAction/OrderBlood.vue";
import Search from "../components/NavItemComponents/Search.vue";
import signup from '../components/signup.vue';
import ForgetPassword from "../components/ForgetPassword.vue";

const routes=[
    { path:'/',component:login,name:'login' },
    { path:'/Profile',component:Profile ,name:'Profile' },
    { path:'/Home',component:Home ,name:'Home' },
     { path:'/ActionCard',component:ActionCard ,name:'ActionCard' },
      { path:'/DonationCard',component:DonationCard ,name:'DonationCard' },
       { path:'/NavItem',component:NavItem ,name:'NavItem' },
       {path:'/Donate',component:Donate ,name:'Donate'},
       {path:'/FindDonar',component:FindDonar ,name:'FindDonar'},
       {path:'/OrderBlood',component:OrderBlood ,name:'OrderBlood'},
       {path:'/Search',component:Search ,name:'Search'},
       {path:'/signup',component:signup ,name:'signup'},
       {path:'/ForgetPassword',component:ForgetPassword ,name:'ForgetPassword'}
]
const router=createRouter({
    history:createWebHistory(),
    routes
})
export default router