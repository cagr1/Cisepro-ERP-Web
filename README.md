# 🚀 Cisepro ERP Web

**Cisepro ERP** es una solución empresarial moderna que integra **backend, frontend, servicios y acceso a datos** para la gestión integral de:

- 👥 Recursos Humanos (RRHH)  
- 💰 Finanzas y contabilidad  
- 🛡️ Seguridad y operaciones  
- 📦 Inventarios  
- 📊 Administración y reportes  

Desarrollado con **.NET 8 + Vue.js 3 + TailwindCSS**, combina rendimiento, escalabilidad y un diseño moderno para la empresa **CISEPRO**.

---

## 📂 Estructura de la Solución

CiseproERP.sln
├── Cisepro.Client # Frontend en Vue.js + TailwindCSS + Vite + Pinia
├── Cisepro.Web # Backend ASP.NET Core 8 (Web API)
├── Cisepro.Services # Lógica de negocio
├── Cisepro.Data # Entidades, DTOs y acceso a datos (EF Core)
└── Cisepro.Legacy # Compatibilidad con funcionalidades antiguas


---

## 🛠️ Tecnologías usadas

### 🌐 Frontend (`Cisepro.Client`)
- [Vue.js 3](https://vuejs.org/)
- [Vite](https://vitejs.dev/)
- [TailwindCSS](https://tailwindcss.com/)
- [Pinia](https://pinia.vuejs.org/) (state management)
- [Axios](https://axios-http.com/) (HTTP requests)
- [Notivue](https://notivue.dev/) (notificaciones)
- [ECharts](https://echarts.apache.org/) (visualización de datos)

### ⚙️ Backend (`Cisepro.Web`)
- [.NET 8 (ASP.NET Core Web API)](https://learn.microsoft.com/aspnet/core/web-api)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [SQL Server](https://www.microsoft.com/sql-server)
- JWT Authentication

### 📡 Servicios y datos
- C# 10+  
- DTOs y entidades fuertemente tipadas  
- Arquitectura por capas (Data → Services → Web/API)

---

## 🔑 Funcionalidades principales

- **RRHH:** gestión de personal, contratos y nómina  
- **Finanzas:** dashboard financiero, facturación y reportes  
- **Operaciones y seguridad:** administración de contratos, sitios y proyectos  
- **Inventarios:** control de stock y bodegas  
- **Visualización:** reportes, estadísticas y mapas interactivos  
- **Seguridad:** autenticación y autorización con JWT  

---

## 🚀 Cómo ejecutar el proyecto

### Backend
1. Abrir la solución en **Visual Studio 2022+**.  
2. Configurar la cadena de conexión a SQL Server en `appsettings.json` de `Cisepro.Web`.  
3. Ejecutar migraciones de base de datos:  
   ```sh
   dotnet ef database update
4. Ejecutar el proyecto **Cisepro.WEB**.

## Frontend
1. Ir a la carpeta **Cisepro.Client:**
cd Cisepro.Client
npm install
npm run dev
2. Acceder a http://localhost:5173 (o el puerto configurado en Vite).
⚠️ Nota: el frontend se comunica con el backend a través de /api (configurado en vite.config.js).
Asegúrate de que backend y frontend estén corriendo al mismo tiempo.

👨‍💻 Autores
Equipo de desarrollo CISEPRO


