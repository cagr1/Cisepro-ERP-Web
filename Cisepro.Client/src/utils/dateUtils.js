//transforma string a formato de fecha para input HTML
const toDateInputFormat = (dateString) => {
  if (!dateString) return "";

  const date = new Date(dateString);
  if (isNaN(date.getTime())) return "";

  return date.toISOString().split("T")[0]; // Formato yyyy-MM-dd
};