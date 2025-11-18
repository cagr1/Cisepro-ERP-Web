// Responsabilidad: Formateo de números y moneda
export const formatearNumero = (numero, decimales = 2) => {
  return new Intl.NumberFormat("es-EC", {
    minimumFractionDigits: decimales,
    maximumFractionDigits: decimales,
  }).format(numero);
};

export const formatearMoneda = (numero) => {
  return new Intl.NumberFormat("es-EC", {
    style: "currency",
    currency: "USD",
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
  }).format(numero);
};
