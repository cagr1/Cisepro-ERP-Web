

export const setFormDisabledState = (formRef, formData, state) => {
  if (!formRef?.value) {
    console.warn("Form reference not available");
    return;
  }
  
  const elements = formRef.value.querySelectorAll(
    "input:not([type=hidden]), select, textarea, button, .v-select, .v-date-picker"
  );
  
  elements.forEach((element) => {
    // Manejo para componentes Vue
    if (element.__vueParentComponent) {
      if (element.__vueParentComponent.ctx?.disable) {
        element.__vueParentComponent.ctx.disable(state);
      } else if (element.__vueParentComponent.ctx?.disabled !== undefined) {
        element.__vueParentComponent.ctx.disabled = state;
      }
    }
    
    // Manejo para elementos nativos
    if (element.disabled !== undefined) {
      element.disabled = state;
    }
    
    // Clases CSS
    if (state) {
      element.classList.add("disabled-field");
      element.setAttribute('readonly', 'true');
    } else {
      element.classList.remove("disabled-field");
      element.removeAttribute('readonly');
    }
  });
};

export const useReadonlyForm = () => {
  const isReadonly = ref(false);

  const enableForm = (formRef, formData) => {
    isReadonly.value = false;
    setFormDisabledState(formRef, formData, false);
  };

  const disableForm = (formRef, formData) => {
    isReadonly.value = true;
    setFormDisabledState(formRef, formData, true);
  };

  return {
    isReadonly,
    enableForm,
    disableForm
  };
};
