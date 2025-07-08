<script setup>
import { Notivue, Notification, pastelTheme } from 'notivue';


</script>

<template>
 
  <router-view></router-view>
  <Notivue v-slot="item">
    <Notification :item="item"
      :theme="pastelTheme" />
  </Notivue>
  
</template>



