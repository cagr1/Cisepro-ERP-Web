export const validators = {
  cedula: (value) => {
    
    if (!/^\d{10}$/.test(value)) {
      return { 
        valid: false, 
        message: "La cédula debe tener 10 dígitos" };
    }

    const provincia = parseInt(value.substring(0, 2));
    if (provincia < 1 || provincia > 24) {
      return {
        valid: false,
        message: "Codigo de provincia invalido",
      };
    }

    let suma = 0;
    for (let i = 0; i < 9; i++) {
      let digito = parseInt(value[i]);
      if (i % 2 === 0) {
        digito *= 2;
        if (digito > 9) digito -= 9;
      }
      suma += digito;
    }

    const digitoVerificador = suma % 10 === 0 ? 0 : 10 - (suma % 10);
    if (digitoVerificador !== parseInt(value[9])) {
      return { valid: false, message: 'Cédula inválida' };
    }

    return { valid: true };
  },

  // Validar solo números
  numeric: (value) => {
    if (!value) return { valid: true };
    return {
      valid: /^\d+$/.test(value),
      message: "Solo se permiten números",
    };
  },

  // Validar solo letras y espacios
  alpha: (value) => {
    if (!value) return { valid: true };
    return {
      valid: /^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/.test(value),
      message: "Solo se permiten letras y espacios",
    };
  },

  //validar email
  email: (value) => {
    if (!value) return { valid: true };
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return {
      valid: emailRegex.test(value),
      message: 'Por favor ingrese un correo válido'
    };
  },


};

export const createValidationSystem = () => {
  const errors = {};
  const validationStates = {};
  
  return {
    // Inicializar estado para un campo
    initField(fieldName) {
      errors[fieldName] = '';
      validationStates[fieldName] = {
        touched: false,
        dirty: false
      };
    },
    
    // Validar campo con debounce
    validateField: debounce((fieldName, value, validatorFn) => {
      validationStates[fieldName].dirty = true;
      const result = validatorFn(value);
      errors[fieldName] = result.valid ? '' : result.message || 'Campo inválido';
      return result.valid;
    }, 500),
    
    // Obtener clase de validación
    getValidationClass(fieldName, value, validatorFn) {
      if (!validationStates[fieldName]?.dirty) return '';
      const result = validatorFn(value);
      return result.valid ? 'border-green-500' : 'border-red-500';
    },
    
    // Obtener mensaje de error
    getErrorMessage(fieldName) {
      return errors[fieldName];
    },
    
    // Validar todo el formulario
    validateForm(fields) {
      let isValid = true;
      
      Object.entries(fields).forEach(([fieldName, config]) => {
        const { value, validator } = config;
        const result = validator(value);
        
        if (!result.valid) {
          errors[fieldName] = result.message;
          isValid = false;
        }
      });
      
      return isValid;
    }
  };
};

const debounce = (fn, delay) => {
  let timeoutId;
  return (...args) => {
    clearTimeout(timeoutId);
    timeoutId = setTimeout(() => fn.apply(this, args), delay);
  };
};
