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