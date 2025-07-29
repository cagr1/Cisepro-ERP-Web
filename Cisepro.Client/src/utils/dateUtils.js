//transforma string a formato de fecha para input HTML
export const toDateInputFormat = (dateString) => {
  if (!dateString) return "";

  const date = new Date(dateString);
  if (isNaN(date.getTime())) return "";

  return date.toISOString().split("T")[0]; // Formato yyyy-MM-dd
};

//transforma string a formato de fecha para input HTML
export function formatDateWithTime(dateString, isEndDate = false, subtractYear = false) {
  if (!dateString) return null;
  
  const date = new Date(dateString + 'T00:00:00Z');
  if (subtractYear) date.setFullYear(date.getFullYear() - 1);
  isEndDate ? date.setUTCHours(23, 59, 59) : date.setUTCHours(0, 0, 0);
  return date.toISOString().slice(0, 19).replace('T', ' ');
}


//Obtiene las fechas por defecto del anio actual 

export function getDefaultDates() {
    const currentYear = new Date().getFullYear();
    return {
        startDate: `${currentYear}-01-01`,
        endDate: `${currentYear}-12-31`
    };
}

//Obtiene el anio de una fecha string
export function getYearFromDate(dateString) {
    if (!dateString) return new Date().getUTCFullYear();
    const date = new Date(dateString + 'T00:00:00Z');
    return date.getUTCFullYear();
}

