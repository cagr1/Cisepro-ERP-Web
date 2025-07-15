

export const setFormDisabledState = (formRef, formData, state) => {

    if (formRef && formData.value) {
        const elements = formRef.value.querySelectorAll("input, select, textarea, button");
    };
    elements.forEach((element) => {
        element.disabled = state;
        if (state) {
         element.classList.add("disabled-field");
        } else {
         element.classList.remove("disabled-field");
        }
    });

}

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
