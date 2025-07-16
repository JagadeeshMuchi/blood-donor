import axios from 'axios'

export const apiClient=axios.create({
    baseURL:'http://bloodDonar:8080/',
    withCredentials:true,
    headers:{
        Accept:"application/json",
        "Content-Type":"application/json",
    },
})