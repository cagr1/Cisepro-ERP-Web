export const useAuthValidations = () => {
    const validateLoginForm = (form) => {
      const errors = {}
      
      if (!form.login?.trim()) errors.login = 'Usuario requerido'
      if (!form.password?.trim()) errors.password = 'Contraseña requerida'
      
      return errors
    }
  
    return {
      validateLoginForm
    }
  }