import { defineStore } from "pinia";
import { personalService } from "@/api/RRHH/personal";
import { cuentaPersonalService } from "@/api/RRHH/cuentaPersonal";
import { historialService } from "@/api/RRHH/historial";
import { useAuthStore } from "@/stores/auth.store";
import { push } from "notivue";
import { toDateInputFormat } from "@/utils/dateUtils";
import { blobToDataURL } from "@/utils/fileUtils";

export const usePersonalStore = defineStore("MasterData/personal", {
  state: () => ({
    isLoading: false,
    loadingHistorial: false,

    //Datos pricipales
    list: [],
    currentEmployee: null,
    searchResults: [],
    searchQuery: "",
    searchLoading: false,
    historialLaboral: [],

    //Paginacion
    currentPage: 1,
    itemsPerPage: 20,
    totalItems: 0,
    totalPages: 0,
    pageSizesOptions: [10, 20, 50, 100],
  }),
  actions: {
    
    
    
    async searchEmployees(
      tipoConexion,
      searchTerm = null,
      page = 1,
      pageSize = this.itemsPerPage 
    ) {
      this.searchLoading = true;
      try {
        const response = await personalService.getPersonal(
          tipoConexion,
          searchTerm,
          page,
          pageSize
        );
        this.searchResults = response.data;
        this.totalItems = response.pagination?.totalRecords || 0;
        this.totalPages = response.pagination?.totalPages || 0;
        this.currentPage = page;
        this.itemsPerPage = pageSize;
        this.searchQuery = searchTerm || this.searchQuery;

        return response.data;
      } catch (error) {
        push({
          type: "error al buscar personal",
          message:
            error.message ||
            "Error al buscar empleados. Por favor, inténtelo de nuevo más tarde.",
        });
        throw error;
      } finally {
        this.isLoading = false;
        this.searchLoading = false;
      }
    },

    async loadEmployeeDetails(
      tipoConexion,
      employee,
      areaStore,
      cargoStore,
      sitiosStore
    ) {
      try {
        this.currentEmployee = null;
        this.historialLaboral = [];

        
        const sitioNumerico = parseInt(employee.ubicacion, 10);
        const sitioValido = sitiosStore.sitioOptions.find(
          (sitio) => sitio.id === sitioNumerico
        );

        const estadoPersonal = employee.estado_Personal || 1; // Default to activo if not provided
        
        const employeeData = {
          idPersonal: employee.id_Personal,
          cedula: employee.cedula,
          nombres: employee.nombres,
          apellidos: employee.apellidos,
          sexo: employee.sexo,
          estadoCivil: employee.estado_Civil?.toUpperCase(),
          instruccion: employee.instruccion?.toUpperCase(),
          tipoSangre: employee.tipo_Sangre,
          provincia: employee.provincia,
          parroquia: employee.parroquia,
          direccion: employee.direccion,
          edad: employee.edad,
          email: employee.email,
          fechaNacimiento: toDateInputFormat(employee.fecha_Nacimiento),
          libretaMilitar: employee.libreta_Militar,
          pasaporte: employee.pasaporte,
          estado_Personal: employee.estado_Personal,
          peso: employee.peso,
          estatura: employee.estatura,
          ciudad: employee.ciudad,
          telefono: employee.telefono,
          celular: employee.movil,
          sitio: sitioValido ? sitioValido.id : "",
          pruebaAntidroga: employee.prueba_Antidroga,
          fechaEntrada: toDateInputFormat(employee.fecha_Entrada),
          fechaSalida:
            employee.estado_Personal === 1
              ? "en_funciones"
              : toDateInputFormat(employee.fecha_Salida),
          foto: employee.foto ? await blobToDataURL(employee.foto) : null,
        };

        const [cuentasResponse, contratoResponse] = await Promise.all([
          this.loadBankAccounts(tipoConexion, employee.id_Personal),
          this.loadContractDetails(
            tipoConexion,
            employee.id_Personal,
            areaStore,
            cargoStore,
            estadoPersonal
          ),
        ]);

        this.currentEmployee = {
          ...employeeData,
          ...cuentasResponse,
          ...contratoResponse,
        };

        await this.loadEmploymentHistory(tipoConexion, employee.id_Personal);
        return this.currentEmployee;
      } catch (error) {
        push({
          type: "error al cargar detalles del empleado",
          message:
            error.message ||
            "Error al cargar los detalles del empleado. Por favor, inténtelo de nuevo más tarde.",
        });
        throw error;
      }
    },

    async loadBankAccounts(tipoConexion, idPersonal) {
      try {
        const response = await cuentaPersonalService.getCuentaPersonal(
          tipoConexion,
          idPersonal
        );
        if (response.success && response.data && response.data.length > 0) {
          const cuenta = response.data[0];
          return {
            banco: cuenta.idBanco || 0,
            cuentaBanco: cuenta.numCuenta || "",
            tipoCuenta: cuenta.tipoCuenta === "AHO" ? "Ahorros" : "Corriente",
          };
          
        }
        return {
          banco: 0,
          cuentaBanco: "",
          tipoCuenta: "",

        };
      } catch (error) {
        push({
          type: "error al cargar cuentas bancarias",
          message:
            error.message ||
            "Error al cargar las cuentas bancarias. Por favor, inténtelo de nuevo más tarde.",
        });
        return {};
      }
    },

    async loadContractDetails(tipoConexion, idPersonal, areaStore, cargoStore, estadoPersonal) {
      try {
              
        

        const response = await personalService.getPersonalContrato(
          tipoConexion,
          idPersonal,
          estadoPersonal
        );
        console.log("response contrato:", response);
        if (response.success && response.data) {
          const contrato = response.data;
          const areaContrato = contrato.area;
          const areaEncontrada = areaStore.areasOptions.find(
            (a) => a.nombre === areaContrato
          );
          console.log("areaEncontrada:", areaEncontrada);
          const cargoContrato = contrato.descripcion;
          const cargoEncontrado = cargoStore.cargoOptions.find(
            (c) => c.nombre === cargoContrato
          );

          console.log("cargoEncontrado:", cargoEncontrado);
          return {
            nroContrato: contrato.nroContrato,
            area: areaEncontrada ? areaEncontrada.id : "",
            cargo: cargoEncontrado ? cargoEncontrado.id : "",
            proyecto: contrato.idProyecto,
            fechaInicio: toDateInputFormat(contrato.fechaInicio),
            fechaFin: toDateInputFormat(contrato.fechaFin),
            periodo: contrato.periodo,
            tipoContrato: contrato.tipoContrato,
            estadoContrato: contrato.estado,
            iess: contrato.iess === 1,
            fechaAfiliacion: toDateInputFormat(contrato.fechaAfiliacion),
            reservaRol: contrato.reservaRol === 1,
            acumFondoReserva: contrato.acu_fondo === 1,
            xiii: contrato.xiii === 1,
            xiv: contrato.xiv === 1,
            observaciones: contrato.observaciones,
            rec_Extra: contrato.rec_Extra === 1,
            acu_fondo: contrato.acu_fondo === 1,
            desc_Seg: contrato.desc_Seg === 1,
            idProyecto: contrato.idProyecto,
            sueldo: contrato.sueldo,
            
          };
          
          
        }
        
        return {};
      } catch (error) {
        push.error({
          title: "Error al cargar los detalles del contrato",
          message:
            error.message ||
            "Error al cargar los detalles del contrato. Por favor, inténtelo de nuevo más tarde.",
        });
        return {};
      }
    },
    async loadEmploymentHistory(tipoConexion, idPersonal) {
      this.loadingHistorial = true;
      try {
        const response = await historialService.getHistorialPersonal(
          tipoConexion,
          idPersonal
        );
        
        if (response.data) {
          this.historialLaboral = response.data.map((item) => ({
            fecha: toDateInputFormat(item.fechaHistoriaLaboral),
            detalle: item.detalleHistoriaLaboral
          }));
        }
        
      } catch (error) {
        push({
          type: "error al cargar historial laboral",
          message:
            error.message ||
            "Error al cargar el historial laboral. Por favor, inténtelo de nuevo más tarde.",
        });
      } finally {
        this.loadingHistorial = false;
      }
    },

    changePageSize(newSize) {
      this.itemsPerPage = Number(newSize);
      this.currentPage = 1; // Reset to first page on page size change
      const authStore = useAuthStore();
      return this.searchEmployees(authStore.selectedCompany, this.searchQuery, 1, this.itemsPerPage);
    },

    handlePageChange(newPage) {
      this.currentPage = newPage;
      return this.searchEmployees(this.searchQuery);
    },
  },
});
