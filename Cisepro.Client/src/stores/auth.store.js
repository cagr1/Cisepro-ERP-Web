import { defineStore } from "pinia";

export const useAuthStore = defineStore("auth", {
    state: () => ({
        user: null,
        token: null,
    }),


actions: {
        async login (credentials)
        {
            const response = await axios.post('/api/auth/login', credentials);
            this.user = response.data.user;
            this.token = response.data.token;
        }
    }
});