<template>
    <div v-if="message" class="text-red-500 text-sm mt-1" >
        {{ message }}
    </div>
</template>

<script>
export default {
    props: {
        message: String
    }
}
</script>

<style scoped>
.fade-enter-active, .fade-leave-active {
  transition: opacity 0.3s;
}
.fade-enter, .fade-leave-to {
  opacity: 0;
}
</style>