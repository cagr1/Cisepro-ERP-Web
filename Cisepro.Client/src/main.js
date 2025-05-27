import { createApp, defineAsyncComponent } from "vue";
import App from "./App.vue";
import router from "./router";
import { createPinia } from "pinia";
import "remixicon/fonts/remixicon.css";
import "./styles/tailwind.css";


const app = createApp(App);
app.use(router);
app.use(createPinia());
app.mount("#app");
