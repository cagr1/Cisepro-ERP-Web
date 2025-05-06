import { ref } from "vue";

export const useFormValidation = () => {
    const errors = ref({})

    const validateRequire = (fields) => {
        errors.value = {}

        Object.entries(fields).forEach(([key, value]) => {
            if (!value?.trim()) {
                errors.value[key] = `${key} es requerido`                
            }
    })
    return Object.keys(errors.value).length === 0
    }

    return {
        errors,
        validateRequire
    }
}