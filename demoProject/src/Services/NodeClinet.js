import axios from "axios";

export const nodeClient = axios.create({
    baseURL: 'http://localhost:3000/',
    withCredentials: true,
    headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
    },
});