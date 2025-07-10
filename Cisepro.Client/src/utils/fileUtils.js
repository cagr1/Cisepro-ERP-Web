//Transforma un Blob o Buffer a una URL de datos (Data URL) para mostrar imágenes en un componente Vue.js
export const blobToDataURL = async (blobData) => {
  // Si es un Buffer (Node.js) o Blob (navegador)
  if (typeof blobData === "string" && blobData.startsWith("data:image")) {
    return blobData;
  }

  // Si es un string base64 sin prefijo (como el que recibes del backend)
  if (typeof blobData === "string" && blobData.startsWith("/9j")) {
    return `data:image/jpeg;base64,${blobData}`;
  }

  // Si es un Buffer o Blob (código original)
  const blob = new Blob([blobData], { type: "image/jpeg" });
  return new Promise((resolve) => {
    const reader = new FileReader();
    reader.onload = () => resolve(reader.result);
    reader.readAsDataURL(blob);
  });
};