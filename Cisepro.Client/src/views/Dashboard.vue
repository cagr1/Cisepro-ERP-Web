<template>
  
    <div class="flex-1 flex flex-col ml-20 transition-all duration-300" id="mainContent">
     <!-- <div class=" bg-white p-4 mx-4 mt-4 items-center rounded-lg  shadow-sm  border-gray-100">
              <div class="logo font-bold text-gray-700 text-lg text-center ">PANEL FINANCIERO</div>
         </div> -->

     <main class="pt-4 px-4">
         <div class="mb-8 bg-white p-4 rounded-lg shadow-sm">
             <div class="flex flex-col md:flex-row md:items-center md:justify-between gap-4">
                 <div class="md:flex-1 ml-10">
                     <h1 class="text-xl font-bold text-gray-900">Panel Financiero</h1>
                 </div>
                 <div class="flex flex-col md:flex-row gap-4 md:items-center md:flex-[2]">
                     <div class="flex-1 flex flex-col md:flex-row gap-3 items-start md:items-center">
                         <!-- Input Fecha Inicio -->
                         <div class="w-full md:w-auto">
                             <label class="block text-sm font-medium text-gray-700 mb-1">Fecha Inicial</label>
                             <input type="date" id="startDate"
                                 class="w-full md:w-[160px] p-1.5 border rounded-md focus:ring-2 focus:ring-blue-500 text-sm" />
                         </div>

                         <!-- Input Fecha Fin -->
                         <div class="w-full md:w-auto">
                             <label class="block text-sm font-medium text-gray-700 mb-1">Fecha Final</label>
                             <input type="date" id="endDate"
                                 class="w-full md:w-[160px] p-1.5 border rounded-md focus:ring-2 focus:ring-blue-500 text-sm" />
                         </div>
                     </div>

                     <div class="md:self-end">
                             <button onclick="loadData()" 
                                 class="bg-gradient-to-r from-blue-500 to-blue-600 hover:from-blue-600 hover:to-blue-700 text-white px-4 py-2.5 rounded-md text-sm font-medium shadow-lg hover:shadow-xl transition-all duration-300 transform hover:-translate-y-0.5 focus:ring-2 focus:ring-blue-300 focus:outline-none flex items-center">
                             
                                 <!-- SVG corregido -->
                                 <svg class="w-5 h-5 mr-2 self-center" viewBox="0 0 24 24" fill="currentColor" style="display: block; transform: translateY(1px);">
                                     <path fill-rule="evenodd" 
                                         clip-rule="evenodd" 
                                         d="M1.85 7.5C1.85 4.66 4.06 1.85 7.5 1.85c2.78 0 4.15 2.06 4.74 3.15H10.5a.5.5 0 0 0 0 1h3a.5.5 0 0 0 .5-.5v-3a.5.5 0 0 0-1 0v1.81C12.3 3.07 10.67.85 7.5.85 3.44.85.85 4.19.85 7.5S3.44 14.15 7.5 14.15c1.94 0 3.56-.77 4.71-1.94.62-.63 1.1-1.37 1.43-2.17.1-.25-.02-.55-.27-.66-.25-.1-.54.02-.65.27-.28.68-.69 1.31-1.21 1.84-.97.99-2.34 1.65-4 1.65-3.44 0-5.65-2.81-5.65-5.65z"/>
                                 </svg>
                             
                                 Actualizar
                             </button>
                     </div>
                 </div>

              
             </div>
         </div>

         <div class="cards-container">
             <!-- Card Ventas Netas -->
             <div class="data-card ingresos">
                 <div class="card-title">Venta Actual</div>
                 <div class="card-main-value" id="ventasRango">$$$</div>
                 <div class="card-secondary-info">
                 <div class="card-acumulado" id="ventasAcumuladas">  $49.9M  </div>
                     <div class="card-variacion positive" id="porcentajeVentasActual">+10%</div>
                 </div>
                 <div class="card-divider"></div>
                 <div class="card-meta">
                     <span class="card-year card-year-actual" >2025</span>
                 </div>
             </div>
             <div class="data-card ingresos">
                 <div class="card-title">Venta Anterior</div>
                 <div class="card-main-value" id="ventasRangoPrevious">$$$</div>
                 <div class="card-secondary-info">
                     <div class="card-acumulado" id="ventasAcumuladasPrevious"> $49.9M </div>
                     <div class="card-variacion positive" id="porcentajeVentasPrevio" >+10%</div>
                 </div>
                 

                 <div class="card-divider"></div>
                 <div class="card-meta">
                     <span class="card-year card-year-previous" >2024</span>
                 </div>
             </div>
            
             
             <!-- <div class="data-card egresos">
                 <div class="card-title">GASTOS</div>
                 <div class="card-main-value" id="ventasRango">$9.8M</div>
                 <div class="card-acumulado" id="ventasAcumuladas">
                     $49.9M acumulado
                 </div>
                 <div class="card-divider"></div>
                 <div class="card-meta">
                     <span class="card-year">2025</span>
                 </div>
             </div> -->

             <!-- Utilidad -->
             <!-- <div class="data-card utilidad">
                 <div class="card-title">UTLIDADES</div>
                 <div class="card-main-value" id="ventasRango">$9.8M</div>
                 <div class="card-acumulado" id="ventasAcumuladas">
                     $49.9M acumulado
                 </div>
                 <div class="card-divider"></div>
             </div> -->
             <!-- Patrimonio -->
             <div class="data-card patrimonio">
                 <div class="card-title">Utilidades</div>
                 <div class="card-main-value" id="utilidadesActuales">$9.8M</div>
                 <div class="card-secondary-info">
                     <div class="card-acumulado" id="utilidadesAcumuladas"> $49.9M acumulado </div>
                     <div class="card-variacion positive" id="porcentajeUtilidades" ></div>
                 </div>
                 <div class="card-divider"></div>
                 <div class="card-meta">
                     <span class="card-year card-year-actual">2025</span>
                 </div>
             </div>

             <div class="data-card margen">
                 <div class="card-title">Margen Neto</div>
                 <div class="card-main-value" id="margenUtilidadNeta">14.8%</div>
                 <div class="card-secondary-info">
                     <div class="card-acumulado">Meta: 50.00%</div>
                     <div class="card-variacion positive" id="variacionMargen">+0.8%</div>
                 </div>
                 <div class="card-divider"></div>
                 <div class="card-meta">
                     <span class="card-year card-year-actual">2024</span>
                 </div>
             </div>
         </div>
          <!-- Sección de Gráficos -->
     <div class="grid grid-cols-1 md:grid-cols-2 gap-4 mt-8 ">
         <!-- Contenedor Gráfico Financiero -->
         <div class="bg-white p-4 rounded-lg shadow-sm">
             <h3 class="text-lg font-semibold mb-4 text-center">Ingresos, Egresos y Utilidades</h3>
             <div id="financialChart" style="width: 100%; height: 400px;"></div>
         </div>

         <!-- Contenedor para otro gráfico (lo dejamos vacío por ahora) -->
         <div class="bg-white p-4 rounded-lg shadow-sm">
             <h3 class="text-lg font-semibold mb-4 text-center">Ventas por Categoria</h3>
             <div class="chart-container" style="height: 350px">
                 <div id="salesChart" style="width: 100%; height: 400px;"></div>
             </div>
         </div>
     </div>
     <div class="mt-8"></div>

     <div class="cards-container mb-8">
         <div class="data-card liquidez">
             <div class="card-title">LIQUIDEZ</div>
             <div class="card-main-value" id="liquidezCorriente">2.4x</div>
             <div class="card-secondary-info">
                 <div class="card-acumulado">Óptimo: 1.5</div>
                 <div class="card-variacion negative" id="variacionLiquidez">-0.2x</div>
             </div>
             <div class="card-divider"></div>
             <div class="card-meta">
                 <span class="card-year card-year-actual">2024</span>
             </div>
         </div>
         
         <!-- Endeudamiento -->
         <div class="data-card endeudamiento">
             <div class="card-title">ENDEUDAMIENTO</div>
             <div class="card-main-value" id="endeudamiento">38%</div>
             <div class="card-secondary-info">
                 <div class="card-acumulado">Límite: 40%</div>
                 <div class="card-variacion positive">-2%</div>
             </div>
             <div class="card-divider"></div>
             <div class="card-meta">
                 <span class="card-year card-year-actual">2024</span>
             </div>
         </div>
         
         <!-- Eficiencia Operativa -->
         <div class="data-card eficiencia">
             <div class="card-title">EFICIENCIA OP.</div>
             <div class="card-main-value" id="eficienciaOperativa">65%</div>
             <div class="card-secondary-info">
                 <div class="card-acumulado">Mejora: 5%</div>
                 <div class="card-variacion positive">+3%</div>
             </div>
             <div class="card-divider"></div>
             <div class="card-meta">
                 <span class="card-year card-year-actual">2024</span>
             </div>
         </div>
         
         <!-- Rentabilidad Patrimonio -->
         <div class="data-card rentabilidad">
             <div class="card-title">RENTAB. PATRIM.</div>
             <div class="card-main-value" id="rentabilidadPatrimonio">22%</div>
             <div class="card-secondary-info">
                 <div class="card-acumulado">Sector: 18%</div>
                 <div class="card-variacion positive">+4%</div>
             </div>
             <div class="card-divider"></div>
             <div class="card-meta">
                 <span class="card-year card-year-actual">2024</span>
             </div>
         </div>
     </div>



     </main>
 </div>

  
    
   
  </template>
  
  <script setup>
  import { useAuthStore } from '@/stores/auth.store'
  import { computed } from 'vue'
  
  
  const authStore = useAuthStore()
  
  const selectedCompany = computed(() => authStore.selectedCompany || 'Cisepro')
  
  
  const logout = () => {
    authStore.logout()
  }
  </script>

  <style scoped>
body{
  font-family: 'Inter', system-ui, sans-serif;
}


  .cards-container {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(260px, 1fr));
    gap: 1.2rem;
    padding: 0.8rem;
    font-family: 'Segoe UI', system-ui, sans-serif;
    
}

.data-card {    
    border-radius: 10px;
    padding: 0.8rem;
    box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);
    min-height: 90px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    border-left: 5px solid;
    border-image: linear-gradient(to right, currentColor 50%, transparent 50%) 1;
    background: white;
    background-clip: padding-box;
    gap: 0.2rem;
    overflow: hidden;
    position: relative;
    transition: all 0.2s cubic-bezier(0.4, 0, 0.2, 1);
    flex: 1; /* Ocupa espacio disponible */
    min-width: 200px; /* Ancho mínimo consistente */
    border-radius: 0.75rem; ;
}

.data-card:hover {
    transform: translateY(-3px);
    box-shadow: 0 4px 16px rgba(0, 0, 0, 0.8);

}

.data-card:hover::after {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: rgba(255, 255, 255, 0.1);
    pointer-events: none;
}


.data-card.ingresos ,
.data-card.ingresos .card-main-value {    
    color: #3b82f6 ;    
}

 .data-card.ingresos {        
    border-color: #3b82f6 ; /* Azul corporativo */
    background: linear-gradient(to right, #eff6ff 85%, #2563eb15);    
} 

.data-card.egresos ,
.data-card.egresos .card-main-value {
    color: #dc2626;
}


.data-card.egresos {
    border-color: #dc2626;
    background: linear-gradient(to right, #fee2e2 85%, #dc262630);
}

.data-card.utilidad ,
.data-card.utilidad .card-main-value {    
    color: #10b981 ;
}

.data-card.utilidad {        
    border-color: #10b981 ; /* Verde financiero */
    background: linear-gradient(to right, #d1fae5 85%, #05966915);
}

.data-card.patrimonio,
.data-card.patrimonio .card-main-value {
    color: #4f46e5;
}

.data-card.patrimonio {    
    border-color: #4f46e5; 
    background: linear-gradient(to right, #eef2ff 85%, #4f46e515);
}


.data-card.ingresos .card-divider { background: #3b82f6 ; } 
.data-card.egresos .card-divider { background: #dc2626; }
.data-card.utilidad .card-divider { background: #059669; }
.data-card.patrimonio .card-divider { background: #4f46e5; }


.card-header {       
    margin-bottom: 0.2rem;
    align-items: center;
    display: flex;
    justify-content: space-between;
}


.card-title {
    font-size: 0.75rem;
    font-family: 'Segoe UI', system-ui, sans-serif;
    font-weight: 800;
    letter-spacing: 0.05em;
    text-transform: uppercase;
    margin-bottom: 0.25rem;
    color: #475569;
}


.card-main-value {
    font-size: 1.2rem;
    font-weight: 600;
    margin: 0.1rem 0;
}

.card-acumulado {
    font-size: 0.8rem;
    color: #64748b;
    margin-top: 0.25rem;
}

.card-divider {
    height: 1px;
    background: rgba(100, 116, 139, 0.2);
    margin: 0.25rem 0;
    border: none;
}


/* Nuevos estilos para variación */
.card-variacion {
    font-size: 0.75rem;
    font-weight: 600;
    padding: 0.15rem 0.35rem;
    border-radius: 4px;
    display: inline-flex;
    align-items: center;
    gap: 0.2rem;
}

.card-variacion::before {
    content: '▲';
    font-size: 0.6rem;
}

.card-variacion.negative::before {
    content: '▼';
}

.card-variacion.positive {
    background: #dcfce7;
    color: #166534;
}

.card-variacion.negative {
    background: #fee2e2;
    color: #991b1b;
}

.card-secondary-info {
    display: flex;
    justify-content: space-between;
    align-items: center;
}


.data-card.ingresos .card-divider {    
    background: #3b82f6;
}

.data-card.egresos .card-divider {
    background: #ef4444;    
}

.data-card.utilidad .card-divider {    
    background:  #10b981;    
}

.data-card.capital .card-divider {
    background: #64748b;    
}

.card-meta {
    display: flex;
    justify-content: space-between;
    font-size: 0.85rem;
    color: #64748b;
}

.card-year {
    font-weight: 600;
    color: #334155;
}

/* Nuevas clases para los indicadores */
.data-card.margen,
.data-card.margen .card-main-value {    
    color: #059669;    
}

.data-card.margen {        
    border-color: #059669;
    background: linear-gradient(to right, #d1fae5 85%, #05966915);    
}

.data-card.liquidez,
.data-card.liquidez .card-main-value {    
    color: #d97706;    
}

.data-card.liquidez {        
    border-color: #d97706;
    background: linear-gradient(to right, #ffedd5 85%, #d9770615);    
}

.data-card.endeudamiento,
.data-card.endeudamiento .card-main-value {    
    color: #dc2626;    
}

.data-card.endeudamiento {        
    border-color: #dc2626;
    background: linear-gradient(to right,#fee2e2 85%, #dc262615);    
}

.data-card.eficiencia,
.data-card.eficiencia .card-main-value {    
    color: #4f46e5;    
}

.data-card.eficiencia {        
    border-color: #4f46e5;
    background: linear-gradient(to right, #eef2ff 85%, #4f46e515);    
}

.data-card.rentabilidad,
.data-card.rentabilidad .card-main-value {    
    color: #d97706;    
}

.data-card.rentabilidad {        
    border-color: #d97706;
    background: linear-gradient(to right,  #fef3c7 85%, #d9770615);    
}

/* Divisores específicos */
.data-card.margen .card-divider { background: #059669; }
.data-card.liquidez .card-divider { background: #d97706; }
.data-card.endeudamiento .card-divider { background: #dc2626; }
.data-card.eficiencia .card-divider { background: #4f46e5; }
.data-card.rentabilidad .card-divider { background: #d97706; }



@media (min-width: 1024px) {
    .cards-container {
        grid-template-columns: repeat(4, minmax(0, 1fr)); /* Grid simétrico */
        gap: 2rem;
        } 
   }








  </style>

  