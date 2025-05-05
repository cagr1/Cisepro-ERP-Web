using System;
using System.Collections.Generic;
using Cisepro.Data.DTOs;
using Cisepro.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cisepro.Data.Context;

public partial class AppDbContext : DbContext
{
    

    //public AppDbContext(DbContextOptions<AppDbContext> options)
    //    : base(options)
    //{
    //}

    
    public AppDbContext(string connectionString) : base(GetOptions(connectionString)) { }

    private static DbContextOptions<AppDbContext> GetOptions(string connectionString)
    {
        return new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(connectionString)
            .Options;
    }

    public virtual DbSet<ActividadInventario> ActividadInventarios { get; set; }

    public virtual DbSet<ActivoFijoBaja> ActivoFijoBajas { get; set; }

    public virtual DbSet<ActivoFijoGeneral> ActivoFijoGenerals { get; set; }

    public virtual DbSet<ActivoFijoMantenimiento> ActivoFijoMantenimientos { get; set; }

    public virtual DbSet<ActivoFijoTransferencia> ActivoFijoTransferencias { get; set; }

    public virtual DbSet<AgenteRetencion> AgenteRetencions { get; set; }

    public virtual DbSet<AnticiposPrestamo> AnticiposPrestamos { get; set; }

    public virtual DbSet<AreaGeneral> AreaGenerals { get; set; }

    public virtual DbSet<Arma> Armas { get; set; }

    public virtual DbSet<AsientosLibroDiario> AsientosLibroDiarios { get; set; }

    public virtual DbSet<AsignacionPersonal> AsignacionPersonals { get; set; }

    public virtual DbSet<Aspirante> Aspirantes { get; set; }

    public virtual DbSet<At> Ats { get; set; }

    public virtual DbSet<AuditoriaGeneral> AuditoriaGenerals { get; set; }

    public virtual DbSet<AuxiliarCajaChica> AuxiliarCajaChicas { get; set; }

    public virtual DbSet<AuxiliarConcepto> AuxiliarConceptos { get; set; }

    public virtual DbSet<AuxiliarFondoRotativo> AuxiliarFondoRotativos { get; set; }

    public virtual DbSet<AuxiliarKilometraje> AuxiliarKilometrajes { get; set; }

    public virtual DbSet<BalanceComprobacion> BalanceComprobacions { get; set; }

    public virtual DbSet<Banco> Bancos { get; set; }

    public virtual DbSet<BancoRole> BancoRoles { get; set; }

    public virtual DbSet<BancosCobro> BancosCobros { get; set; }

    public virtual DbSet<BitacoraOperativo> BitacoraOperativos { get; set; }

    public virtual DbSet<Bodega> Bodegas { get; set; }

    public virtual DbSet<CajaChica> CajaChicas { get; set; }

    public virtual DbSet<CalificacionProveedor> CalificacionProveedors { get; set; }

    public virtual DbSet<CamarasSeguridad> CamarasSeguridads { get; set; }

    public virtual DbSet<CargoOcupacional> CargoOcupacionals { get; set; }

    public virtual DbSet<CategoriaItem> CategoriaItems { get; set; }

    public virtual DbSet<CategoriaSuministro> CategoriaSuministros { get; set; }

    public virtual DbSet<CategoriaUbicacion> CategoriaUbicacions { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<CentroCosto> CentroCostos { get; set; }

    public virtual DbSet<Chaleco> Chalecos { get; set; }

    public virtual DbSet<ChequesEmitido> ChequesEmitidos { get; set; }

    public virtual DbSet<ChequesRecibido> ChequesRecibidos { get; set; }

    public virtual DbSet<Ciudade> Ciudades { get; set; }

    public virtual DbSet<ClienteGeneral> ClienteGenerals { get; set; }

    public virtual DbSet<CodigoAutorizarFactura> CodigoAutorizarFacturas { get; set; }

    public virtual DbSet<CodigoCargoOcupacional> CodigoCargoOcupacionals { get; set; }

    public virtual DbSet<CodigosActivo> CodigosActivos { get; set; }

    public virtual DbSet<ColorGeneral> ColorGenerals { get; set; }

    public virtual DbSet<CompEgresoPagosCompCompra> CompEgresoPagosCompCompras { get; set; }

    public virtual DbSet<ComprobanteAjusteBodega> ComprobanteAjusteBodegas { get; set; }

    public virtual DbSet<ComprobanteDonacionBodega> ComprobanteDonacionBodegas { get; set; }

    public virtual DbSet<ComprobanteEgresoBanco> ComprobanteEgresoBancos { get; set; }

    public virtual DbSet<ComprobanteEgresoBodega> ComprobanteEgresoBodegas { get; set; }

    public virtual DbSet<ComprobanteIngresoBanco> ComprobanteIngresoBancos { get; set; }

    public virtual DbSet<ComprobanteIngresoBodega> ComprobanteIngresoBodegas { get; set; }

    public virtual DbSet<ComprobanteReingresoBodega> ComprobanteReingresoBodegas { get; set; }

    public virtual DbSet<ComprobanteRetencionCompra> ComprobanteRetencionCompras { get; set; }

    public virtual DbSet<ComprobanteRetencionVentum> ComprobanteRetencionVenta { get; set; }

    public virtual DbSet<ComprobantesCompra> ComprobantesCompras { get; set; }

    public virtual DbSet<ConceptoPago> ConceptoPagos { get; set; }

    public virtual DbSet<ConceptosComprobanteEgresoBanco> ConceptosComprobanteEgresoBancos { get; set; }

    public virtual DbSet<ConceptosComprobanteIngresoBanco> ConceptosComprobanteIngresoBancos { get; set; }

    public virtual DbSet<ConceptosComprobantesCompra> ConceptosComprobantesCompras { get; set; }

    public virtual DbSet<ConceptosFacturaVentum> ConceptosFacturaVenta { get; set; }

    public virtual DbSet<ConceptosInventario> ConceptosInventarios { get; set; }

    public virtual DbSet<ContactosProveedorCalificado> ContactosProveedorCalificados { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<ContratoCliente> ContratoClientes { get; set; }

    public virtual DbSet<ContratoProyecto> ContratoProyectos { get; set; }

    public virtual DbSet<ContribuyenteRetenido> ContribuyenteRetenidos { get; set; }

    public virtual DbSet<ControlCombustible> ControlCombustibles { get; set; }

    public virtual DbSet<ControlUniforme> ControlUniformes { get; set; }

    public virtual DbSet<ConvenioClienteBancoDebito> ConvenioClienteBancoDebitos { get; set; }

    public virtual DbSet<CortesContable> CortesContables { get; set; }

    public virtual DbSet<CuentasBanco> CuentasBancos { get; set; }

    public virtual DbSet<CuentasPersonal> CuentasPersonals { get; set; }

    public virtual DbSet<DepreciacionesGeneral> DepreciacionesGenerals { get; set; }

    public virtual DbSet<DescuentosRol> DescuentosRols { get; set; }

    public virtual DbSet<DetalleBalanceComprobación> DetalleBalanceComprobacións { get; set; }

    public virtual DbSet<DetalleComprobanteAjusteBodega> DetalleComprobanteAjusteBodegas { get; set; }

    public virtual DbSet<DetalleComprobanteDonacionBodega> DetalleComprobanteDonacionBodegas { get; set; }

    public virtual DbSet<DetalleComprobanteEgresoBodega> DetalleComprobanteEgresoBodegas { get; set; }

    public virtual DbSet<DetalleComprobanteIngresoBodega> DetalleComprobanteIngresoBodegas { get; set; }

    public virtual DbSet<DetalleComprobanteReingresoBodega> DetalleComprobanteReingresoBodegas { get; set; }

    public virtual DbSet<DetalleComprobanteRetencionCompra> DetalleComprobanteRetencionCompras { get; set; }

    public virtual DbSet<DetalleComprobanteRetencionVentum> DetalleComprobanteRetencionVenta { get; set; }

    public virtual DbSet<DetalleConceptoInventario> DetalleConceptoInventarios { get; set; }

    public virtual DbSet<DetalleDepreciacion> DetalleDepreciacions { get; set; }

    public virtual DbSet<DetalleEgresoSuministro> DetalleEgresoSuministros { get; set; }

    public virtual DbSet<DetalleEpp> DetalleEpps { get; set; }

    public virtual DbSet<DetalleFacturaVentum> DetalleFacturaVenta { get; set; }

    public virtual DbSet<DetalleItemsPuesto> DetalleItemsPuestos { get; set; }

    public virtual DbSet<DetalleKardex> DetalleKardices { get; set; }

    public virtual DbSet<DetalleLiquidacionCompra> DetalleLiquidacionCompras { get; set; }

    public virtual DbSet<DetalleMantenimiento> DetalleMantenimientos { get; set; }

    public virtual DbSet<DetalleMayore> DetalleMayores { get; set; }

    public virtual DbSet<DetalleOrdenCompra> DetalleOrdenCompras { get; set; }

    public virtual DbSet<DetalleOrdenComprobanteCompra> DetalleOrdenComprobanteCompras { get; set; }

    public virtual DbSet<DetalleOrdenTecnicaSupervision> DetalleOrdenTecnicaSupervisions { get; set; }

    public virtual DbSet<DetallePlanillaCobrosPago> DetallePlanillaCobrosPagos { get; set; }

    public virtual DbSet<DetallePorcentejeContribuyente> DetallePorcentejeContribuyentes { get; set; }

    public virtual DbSet<DetalleProgramacion> DetalleProgramacions { get; set; }

    public virtual DbSet<DetalleProveedor> DetalleProveedors { get; set; }

    public virtual DbSet<DetalleProveedorItem> DetalleProveedorItems { get; set; }

    public virtual DbSet<DetalleRequisicionProductoServicio> DetalleRequisicionProductoServicios { get; set; }

    public virtual DbSet<DetalleRetencionPlanCuenta> DetalleRetencionPlanCuentas { get; set; }

    public virtual DbSet<DetalleSecuencialSuministro> DetalleSecuencialSuministros { get; set; }

    public virtual DbSet<DetalleSolicitudSuministro> DetalleSolicitudSuministros { get; set; }

    public virtual DbSet<DetalleTransferencia> DetalleTransferencias { get; set; }

    public virtual DbSet<DetalleUbicacion> DetalleUbicacions { get; set; }

    public virtual DbSet<DetalleUniforme> DetalleUniformes { get; set; }

    public virtual DbSet<DetalleVacacione> DetalleVacaciones { get; set; }

    public virtual DbSet<DetallesRol> DetallesRols { get; set; }

    public virtual DbSet<DireccionesFacturacionCliente> DireccionesFacturacionClientes { get; set; }

    public virtual DbSet<DocumentoNodeducible> DocumentoNodeducibles { get; set; }

    public virtual DbSet<DocumentosContrato> DocumentosContratos { get; set; }

    public virtual DbSet<DocumentosElectronico> DocumentosElectronicos { get; set; }

    public virtual DbSet<EgresoSuministro> EgresoSuministros { get; set; }

    public virtual DbSet<EmpresaGeneral> EmpresaGenerals { get; set; }

    public virtual DbSet<EntregaEpp> EntregaEpps { get; set; }

    public virtual DbSet<EntregaUniforme> EntregaUniformes { get; set; }

    public virtual DbSet<EquipoPuestoSitioTrabajo> EquipoPuestoSitioTrabajos { get; set; }

    public virtual DbSet<EquipoPuestoTrabajo> EquipoPuestoTrabajos { get; set; }

    public virtual DbSet<EquiposAmbientacion> EquiposAmbientacions { get; set; }

    public virtual DbSet<EquiposCocina> EquiposCocinas { get; set; }

    public virtual DbSet<EquiposComputo> EquiposComputos { get; set; }

    public virtual DbSet<EquiposComunicacionTelefonium> EquiposComunicacionTelefonia { get; set; }

    public virtual DbSet<EquiposOficina> EquiposOficinas { get; set; }

    public virtual DbSet<EquiposSeguridadIndustrial> EquiposSeguridadIndustrials { get; set; }

    public virtual DbSet<EvaluacionProveedorMateriale> EvaluacionProveedorMateriales { get; set; }

    public virtual DbSet<EvaluacionProveedorServicio> EvaluacionProveedorServicios { get; set; }

    public virtual DbSet<FacturaDebitoConvenio> FacturaDebitoConvenios { get; set; }

    public virtual DbSet<FacturaSecuenciale> FacturaSecuenciales { get; set; }

    public virtual DbSet<FacturaVentum> FacturaVenta { get; set; }

    public virtual DbSet<FacturasImpagasGeneral> FacturasImpagasGenerals { get; set; }

    public virtual DbSet<FondoRotativo> FondoRotativos { get; set; }

    public virtual DbSet<FormasPago> FormasPagos { get; set; }

    public virtual DbSet<Foto> Fotos { get; set; }

    public virtual DbSet<Gasto> Gastos { get; set; }

    public virtual DbSet<GastosCajaChica> GastosCajaChicas { get; set; }

    public virtual DbSet<GastosFondoRotativo> GastosFondoRotativos { get; set; }

    public virtual DbSet<Generadore> Generadores { get; set; }

    public virtual DbSet<GerenciaGeneral> GerenciaGenerals { get; set; }

    public virtual DbSet<GerenciasGeneral> GerenciasGenerals { get; set; }

    public virtual DbSet<GrupoGeneral> GrupoGenerals { get; set; }

    public virtual DbSet<GrupoItem> GrupoItems { get; set; }

    public virtual DbSet<GrupoOcupacional> GrupoOcupacionals { get; set; }

    public virtual DbSet<GrupoStitio> GrupoStitios { get; set; }

    public virtual DbSet<GrupoSuministro> GrupoSuministros { get; set; }

    public virtual DbSet<GrupoUbicacion> GrupoUbicacions { get; set; }

    public virtual DbSet<HistoriaLaboral> HistoriaLaborals { get; set; }

    public virtual DbSet<HistorialFacturacionCliente> HistorialFacturacionClientes { get; set; }

    public virtual DbSet<HistorialVehiculo> HistorialVehiculos { get; set; }

    public virtual DbSet<HorariosOperacion> HorariosOperacions { get; set; }

    public virtual DbSet<ImpuestoRetenido> ImpuestoRetenidos { get; set; }

    public virtual DbSet<InformacionTributarium> InformacionTributaria { get; set; }

    public virtual DbSet<InventarioItem> InventarioItems { get; set; }

    public virtual DbSet<Kardex> Kardices { get; set; }

    public virtual DbSet<LibroColeccione> LibroColecciones { get; set; }

    public virtual DbSet<LibroDiarioGeneral> LibroDiarioGenerals { get; set; }

    public virtual DbSet<LiquidacionCajaChica> LiquidacionCajaChicas { get; set; }

    public virtual DbSet<LiquidacionCompra> LiquidacionCompras { get; set; }

    public virtual DbSet<LiquidacionFondoRotativo> LiquidacionFondoRotativos { get; set; }

    public virtual DbSet<LlegadaVehiculo> LlegadaVehiculos { get; set; }

    public virtual DbSet<Logsql> Logsqls { get; set; }

    public virtual DbSet<Lote> Lotes { get; set; }

    public virtual DbSet<MarcaGeneral> MarcaGenerals { get; set; }

    public virtual DbSet<MaterialGeneral> MaterialGenerals { get; set; }

    public virtual DbSet<MayorGeneral> MayorGenerals { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<ModeloGeneral> ModeloGenerals { get; set; }

    public virtual DbSet<MueblesOficina> MueblesOficinas { get; set; }

    public virtual DbSet<NotaCreditoVentum> NotaCreditoVenta { get; set; }

    public virtual DbSet<NotaDebitoCompra> NotaDebitoCompras { get; set; }

    public virtual DbSet<NotaVentaCompra> NotaVentaCompras { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<NotificacionesDenuncia> NotificacionesDenuncias { get; set; }

    public virtual DbSet<NroComprobanteBodega> NroComprobanteBodegas { get; set; }

    public virtual DbSet<NumeroRegistroAsiento> NumeroRegistroAsientos { get; set; }

    public virtual DbSet<NumeroRegistroAsientosComprobanteCompra> NumeroRegistroAsientosComprobanteCompras { get; set; }

    public virtual DbSet<NumeroRegistroAsientosComprobanteEgreso> NumeroRegistroAsientosComprobanteEgresos { get; set; }

    public virtual DbSet<NumeroRegistroAsientosComprobanteIngreso> NumeroRegistroAsientosComprobanteIngresos { get; set; }

    public virtual DbSet<NumeroRegistroAsientosFacturaVentum> NumeroRegistroAsientosFacturaVenta { get; set; }

    public virtual DbSet<NumeroRegistroAsientosNotaCreditoVentum> NumeroRegistroAsientosNotaCreditoVenta { get; set; }

    public virtual DbSet<OrdenCompra> OrdenCompras { get; set; }

    public virtual DbSet<OrdenTecnicaSupervision> OrdenTecnicaSupervisions { get; set; }

    public virtual DbSet<PagosComprobantesCompra> PagosComprobantesCompras { get; set; }

    public virtual DbSet<PagosFacturaVentum> PagosFacturaVenta { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<ParametrosRolPago> ParametrosRolPagos { get; set; }

    public virtual DbSet<Parroquia> Parroquias { get; set; }

    public virtual DbSet<PasswordReset> PasswordResets { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<PlanCuentasGeneral> PlanCuentasGenerals { get; set; }

    public virtual DbSet<PlanillaCobrosPago> PlanillaCobrosPagos { get; set; }

    public virtual DbSet<PorcentajeRet> PorcentajeRets { get; set; }

    public virtual DbSet<PorcentajeRetencion> PorcentajeRetencions { get; set; }

    public virtual DbSet<PrametrosDocumento> PrametrosDocumentos { get; set; }

    public virtual DbSet<ProductoCisepro> ProductoCisepros { get; set; }

    public virtual DbSet<ProgramacionOperativo> ProgramacionOperativos { get; set; }

    public virtual DbSet<ProveedorCalificado> ProveedorCalificados { get; set; }

    public virtual DbSet<ProveedorGeneral> ProveedorGenerals { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<PuestoTrabajo> PuestoTrabajos { get; set; }

    public virtual DbSet<PuntoSitioTrabajo> PuntoSitioTrabajos { get; set; }

    public virtual DbSet<Radio> Radios { get; set; }

    public virtual DbSet<RegistroPermisosPersonal> RegistroPermisosPersonals { get; set; }

    public virtual DbSet<RegistroSancionesPersonal> RegistroSancionesPersonals { get; set; }

    public virtual DbSet<RegistroDepreciaciones> RegistroDepreciaciones { get; set; }

    public virtual DbSet<RequisicionProductoServicio> RequisicionProductoServicios { get; set; }

    public virtual DbSet<ResponsableAutorizacionFondoCaja> ResponsableAutorizacionFondoCajas { get; set; }

    public virtual DbSet<ResponsableAutorizacionFondoRotativo> ResponsableAutorizacionFondoRotativos { get; set; }

    public virtual DbSet<RetencionIva> RetencionIvas { get; set; }

    public virtual DbSet<RetencionRentum> RetencionRenta { get; set; }

    public virtual DbSet<RolPago> RolPagos { get; set; }

    public virtual DbSet<RotacionVehiculo> RotacionVehiculos { get; set; }

    public virtual DbSet<Rubro> Rubros { get; set; }

    public virtual DbSet<RutaDocElectronico> RutaDocElectronicos { get; set; }

    public virtual DbSet<SalidaVehiculo> SalidaVehiculos { get; set; }

    public virtual DbSet<SancionesPersonal> SancionesPersonals { get; set; }

    public virtual DbSet<SeccionGeneral> SeccionGenerals { get; set; }

    public virtual DbSet<Secuecial> Secuecials { get; set; }

    public virtual DbSet<Secuencial> Secuencials { get; set; }

    public virtual DbSet<SecuencialItem> SecuencialItems { get; set; }

    public virtual DbSet<SecuencialSuministro> SecuencialSuministros { get; set; }

    public virtual DbSet<SecuencialesContrato> SecuencialesContratos { get; set; }

    public virtual DbSet<SerieOcupacional> SerieOcupacionals { get; set; }

    public virtual DbSet<SitiosTrabajo> SitiosTrabajos { get; set; }

    public virtual DbSet<Software> Softwares { get; set; }

    public virtual DbSet<SolicitudCajaChica> SolicitudCajaChicas { get; set; }

    public virtual DbSet<SolicitudFondoRotativo> SolicitudFondoRotativos { get; set; }

    public virtual DbSet<SolicitudMensualSuministro> SolicitudMensualSuministros { get; set; }

    public virtual DbSet<SubGrupoGeneral> SubGrupoGenerals { get; set; }

    public virtual DbSet<SubGrupoItem> SubGrupoItems { get; set; }

    public virtual DbSet<SubGrupoUbicacion> SubGrupoUbicacions { get; set; }

    public virtual DbSet<SubSeccionGeneral> SubSeccionGenerals { get; set; }

    public virtual DbSet<SubgrupoSuministro> SubgrupoSuministros { get; set; }

    public virtual DbSet<SucursalGeneral> SucursalGenerals { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TblComparacion> TblComparacions { get; set; }

    public virtual DbSet<TblDetalleComparacion> TblDetalleComparacions { get; set; }

    public virtual DbSet<TblDetallePrestamo> TblDetallePrestamos { get; set; }

    public virtual DbSet<TblMenuDosUser> TblMenuDosUsers { get; set; }

    public virtual DbSet<TblMenuTresUser> TblMenuTresUsers { get; set; }

    public virtual DbSet<TblMenuUser> TblMenuUsers { get; set; }

    public virtual DbSet<TblPago> TblPagos { get; set; }

    public virtual DbSet<TblPermisosUser> TblPermisosUsers { get; set; }

    public virtual DbSet<TblPrestamo> TblPrestamos { get; set; }

    public virtual DbSet<TblRolUser> TblRolUsers { get; set; }

    public virtual DbSet<TblRolesFirmado> TblRolesFirmados { get; set; }

    public virtual DbSet<TblSalidaPersonal> TblSalidaPersonals { get; set; }

    public virtual DbSet<Terreno> Terrenos { get; set; }

    public virtual DbSet<TicketsFarmaciaComecsa> TicketsFarmaciaComecsas { get; set; }

    public virtual DbSet<TiqueteMaquinaRegistradoraCompra> TiqueteMaquinaRegistradoraCompras { get; set; }

    public virtual DbSet<UnidadMedidum> UnidadMedida { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<UsuarioGeneral> UsuarioGenerals { get; set; }

    public virtual DbSet<ValoresSecuenciale> ValoresSecuenciales { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<VehiculosOtro> VehiculosOtros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.0.5;Database=SYSCISEPRO;TrustServerCertificate= true;User Id=sa;Password=C1s3pr0c14;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<ActividadInventario>(entity =>
        {
            entity.HasKey(e => e.IdActividad);

            entity.ToTable("ACTIVIDAD_INVENTARIOS");

            entity.Property(e => e.IdActividad)
                .ValueGeneratedNever()
                .HasColumnName("ID_ACTIVIDAD");
            entity.Property(e => e.DetalleActividad).HasColumnName("DETALLE_ACTIVIDAD");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.NumerosConceptos).HasColumnName("NUMEROS_CONCEPTOS");
        });

        modelBuilder.Entity<ActivoFijoBaja>(entity =>
        {
            entity.HasKey(e => e.IdBaja);

            entity.ToTable("ACTIVO_FIJO_BAJAS");

            entity.Property(e => e.IdBaja)
                .ValueGeneratedNever()
                .HasColumnName("ID_BAJA");
            entity.Property(e => e.Autorizo).HasColumnName("AUTORIZO");
            entity.Property(e => e.Destinatario).HasColumnName("DESTINATARIO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoActivo).HasColumnName("ESTADO_ACTIVO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdActivo).HasColumnName("ID_ACTIVO");
            entity.Property(e => e.IdCustodio).HasColumnName("ID_CUSTODIO");
            entity.Property(e => e.InformeTecnico).HasColumnName("INFORME_TECNICO");
            entity.Property(e => e.Motivo).HasColumnName("MOTIVO");
            entity.Property(e => e.NroMemorandum).HasColumnName("NRO_MEMORANDUM");
            entity.Property(e => e.TipoActivo).HasColumnName("TIPO_ACTIVO");

            entity.HasOne(d => d.IdActivoNavigation).WithMany(p => p.ActivoFijoBajas)
                .HasForeignKey(d => d.IdActivo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ACTIVO_FIJO_BAJAS_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<ActivoFijoGeneral>(entity =>
        {
            entity.HasKey(e => e.IdActivoFijo);

            entity.ToTable("ACTIVO_FIJO_GENERAL");

            entity.Property(e => e.IdActivoFijo)
                .ValueGeneratedNever()
                .HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.AñosVidaUtil).HasColumnName("AÑOS_VIDA_UTIL");
            entity.Property(e => e.Carpeta).HasColumnName("CARPETA");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.CodigoArancel).HasColumnName("CODIGO_ARANCEL");
            entity.Property(e => e.Contrato).HasColumnName("CONTRATO");
            entity.Property(e => e.CtaActivo).HasColumnName("CTA_ACTIVO");
            entity.Property(e => e.CtaDepreciacion).HasColumnName("CTA_DEPRECIACION");
            entity.Property(e => e.CtaGastos).HasColumnName("CTA_GASTOS");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoActivo).HasColumnName("ESTADO_ACTIVO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.FechaAdquisicion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ADQUISICION");
            entity.Property(e => e.FechaMantenimiento)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MANTENIMIENTO");
            entity.Property(e => e.IdArea).HasColumnName("ID_AREA");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdGerencias).HasColumnName("ID_GERENCIAS");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProoveedorGeneral).HasColumnName("ID_PROOVEEDOR_GENERAL");
            entity.Property(e => e.IdSitio).HasColumnName("ID_SITIO");
            entity.Property(e => e.IdSucursal).HasColumnName("ID_SUCURSAL");
            entity.Property(e => e.Mantenimiento).HasColumnName("MANTENIMIENTO");
            entity.Property(e => e.NombreActivo).HasColumnName("NOMBRE_ACTIVO");
            entity.Property(e => e.NombreCustodio).HasColumnName("NOMBRE_CUSTODIO");
            entity.Property(e => e.NombreProvedor).HasColumnName("NOMBRE_PROVEDOR");
            entity.Property(e => e.NumFactura).HasColumnName("NUM_FACTURA");
            entity.Property(e => e.NumOrdenCompra).HasColumnName("NUM_ORDEN_COMPRA");
            entity.Property(e => e.Responsable).HasColumnName("RESPONSABLE");
            entity.Property(e => e.TipoActivo).HasColumnName("TIPO_ACTIVO");
            entity.Property(e => e.ValorAdicional)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_ADICIONAL");
            entity.Property(e => e.ValorFactura)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_FACTURA");
            entity.Property(e => e.ValorResidual)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_RESIDUAL");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.ActivoFijoGenerals)
                .HasForeignKey(d => d.IdPersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ACTIVO_FIJO_GENERAL_PERSONAL");

            entity.HasOne(d => d.IdSitioNavigation).WithMany(p => p.ActivoFijoGenerals)
                .HasForeignKey(d => d.IdSitio)
                .HasConstraintName("FK_ACTIVO_FIJO_GENERAL_SITIOS_TRABAJO");
        });

        modelBuilder.Entity<ActivoFijoMantenimiento>(entity =>
        {
            entity.HasKey(e => e.IdMantenimiento);

            entity.ToTable("ACTIVO_FIJO_MANTENIMIENTOS");

            entity.Property(e => e.IdMantenimiento)
                .ValueGeneratedNever()
                .HasColumnName("ID_MANTENIMIENTO");
            entity.Property(e => e.Asiento).HasColumnName("ASIENTO");
            entity.Property(e => e.Autorizo).HasColumnName("AUTORIZO");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("COSTO");
            entity.Property(e => e.DetalleTrabajo).HasColumnName("DETALLE_TRABAJO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.FechaNuevoMantenimiento)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_NUEVO_MANTENIMIENTO");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.NombreTallerTecnico).HasColumnName("NOMBRE_TALLER_TECNICO");
        });

        modelBuilder.Entity<ActivoFijoTransferencia>(entity =>
        {
            entity.HasKey(e => e.IdTransferencia);

            entity.ToTable("ACTIVO_FIJO_TRANSFERENCIAS");

            entity.Property(e => e.IdTransferencia)
                .ValueGeneratedNever()
                .HasColumnName("ID_TRANSFERENCIA");
            entity.Property(e => e.CustodioAnterior).HasColumnName("CUSTODIO_ANTERIOR");
            entity.Property(e => e.CustodioNuevo).HasColumnName("CUSTODIO_NUEVO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdPersonalAnterior).HasColumnName("ID_PERSONAL_ANTERIOR");
            entity.Property(e => e.IdPersonalNuevo).HasColumnName("ID_PERSONAL_NUEVO");
            entity.Property(e => e.NombreAutoriza).HasColumnName("NOMBRE_AUTORIZA");
            entity.Property(e => e.Razon).HasColumnName("RAZON");
            entity.Property(e => e.UbicacionAnterior).HasColumnName("UBICACION_ANTERIOR");
            entity.Property(e => e.UbicacionNueva).HasColumnName("UBICACION_NUEVA");
        });

        modelBuilder.Entity<AgenteRetencion>(entity =>
        {
            entity.HasKey(e => e.IdAgente);

            entity.ToTable("AGENTE_RETENCION");

            entity.Property(e => e.IdAgente)
                .ValueGeneratedNever()
                .HasColumnName("ID_AGENTE");
            entity.Property(e => e.DescripcionAgente).HasColumnName("DESCRIPCION_AGENTE");
            entity.Property(e => e.EstadoAgenteRetencion).HasColumnName("ESTADO_AGENTE_RETENCION");
        });

        modelBuilder.Entity<AnticiposPrestamo>(entity =>
        {
            entity.HasKey(e => e.IdAntipres);

            entity.ToTable("ANTICIPOS_PRESTAMOS");

            entity.Property(e => e.IdAntipres)
                .ValueGeneratedNever()
                .HasColumnName("id_antipres");
            entity.Property(e => e.Detalle)
                .IsUnicode(false)
                .HasColumnName("detalle");
            entity.Property(e => e.Diferido).HasColumnName("diferido");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Forma)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("forma");
            entity.Property(e => e.IdPersonal).HasColumnName("id_personal");
            entity.Property(e => e.IdfrIdeg).HasColumnName("idfr_ideg");
            entity.Property(e => e.Interes).HasColumnName("interes");
            entity.Property(e => e.SaldoCuotas).HasColumnName("saldo_cuotas");
            entity.Property(e => e.SaldoTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("saldo_total");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.ValCuota)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("val_cuota");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("valor");
        });

        modelBuilder.Entity<AreaGeneral>(entity =>
        {
            entity.HasKey(e => e.IdAreaGeneral);

            entity.ToTable("AREA_GENERAL");

            entity.Property(e => e.IdAreaGeneral)
                .ValueGeneratedNever()
                .HasColumnName("ID_AREA_GENERAL");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.EstadoArea).HasColumnName("ESTADO_AREA");
            entity.Property(e => e.IdGerenciasGeneral).HasColumnName("ID_GERENCIAS_GENERAL");
            entity.Property(e => e.NombreArea).HasColumnName("NOMBRE_AREA");

            entity.HasOne(d => d.IdGerenciasGeneralNavigation).WithMany(p => p.AreaGenerals)
                .HasForeignKey(d => d.IdGerenciasGeneral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AREA_GENERAL_GERENCIAS_GENERAL");
        });

        modelBuilder.Entity<Arma>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ARMAS");

            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FecAceptacionMatricula)
                .HasColumnType("datetime")
                .HasColumnName("FEC_ACEPTACION_MATRICULA");
            entity.Property(e => e.FecAceptacionTenencia)
                .HasColumnType("datetime")
                .HasColumnName("FEC_ACEPTACION_TENENCIA");
            entity.Property(e => e.FecCaducidadMatricula)
                .HasColumnType("datetime")
                .HasColumnName("FEC_CADUCIDAD_MATRICULA");
            entity.Property(e => e.FecCaducidadTenencia)
                .HasColumnType("datetime")
                .HasColumnName("FEC_CADUCIDAD_TENENCIA");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.NumMatriculaArma).HasColumnName("NUM_MATRICULA_ARMA");
            entity.Property(e => e.NumPermisoComando).HasColumnName("NUM_PERMISO_COMANDO");
            entity.Property(e => e.NumPermisoGobierno).HasColumnName("NUM_PERMISO_GOBIERNO");
            entity.Property(e => e.NumTenenciaArmas).HasColumnName("NUM_TENENCIA_ARMAS");
            entity.Property(e => e.Origen).HasColumnName("ORIGEN");
            entity.Property(e => e.Serie).HasColumnName("SERIE");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ARMAS_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<AsientosLibroDiario>(entity =>
        {
            entity.HasKey(e => e.IdAsiento);

            entity.ToTable("ASIENTOS_LIBRO_DIARIO");

            entity.Property(e => e.IdAsiento)
                .ValueGeneratedNever()
                .HasColumnName("ID_ASIENTO");
            entity.Property(e => e.CentroCostoAsiento).HasColumnName("CENTRO_COSTO_ASIENTO");
            entity.Property(e => e.CiudadAsiento).HasColumnName("CIUDAD_ASIENTO");
            entity.Property(e => e.CodigoCuentaAsiento).HasColumnName("CODIGO_CUENTA_ASIENTO");
            entity.Property(e => e.ConceptoAsiento).HasColumnName("CONCEPTO_ASIENTO");
            entity.Property(e => e.ConciliarAsiento).HasColumnName("CONCILIAR_ASIENTO");
            entity.Property(e => e.DebeHaber).HasColumnName("DEBE_HABER");
            entity.Property(e => e.DetalleTransaccionAsiento).HasColumnName("DETALLE_TRANSACCION_ASIENTO");
            entity.Property(e => e.EstadoAsiento).HasColumnName("ESTADO_ASIENTO");
            entity.Property(e => e.EstadoMayor).HasColumnName("ESTADO_MAYOR");
            entity.Property(e => e.FechaAsiento)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ASIENTO");
            entity.Property(e => e.IdLibroDiario).HasColumnName("ID_LIBRO_DIARIO");
            entity.Property(e => e.NombreCuentaAsiento).HasColumnName("NOMBRE_CUENTA_ASIENTO");
            entity.Property(e => e.NumeroRegistroAsiento).HasColumnName("NUMERO_REGISTRO_ASIENTO");
            entity.Property(e => e.ParroquiaAsiento).HasColumnName("PARROQUIA_ASIENTO");
            entity.Property(e => e.ProvinciaAsiento).HasColumnName("PROVINCIA_ASIENTO");
            entity.Property(e => e.ValorDebeAsiento)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_DEBE_ASIENTO");
            entity.Property(e => e.ValorHaberAsiento)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_HABER_ASIENTO");

            entity.HasOne(d => d.IdLibroDiarioNavigation).WithMany(p => p.AsientosLibroDiarios)
                .HasForeignKey(d => d.IdLibroDiario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ASIENTOS_LIBRO_DIARIO_LIBRO_DIARIO_GENERAL");
        });

        modelBuilder.Entity<AsignacionPersonal>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion);

            entity.ToTable("ASIGNACION_PERSONAL");

            entity.Property(e => e.IdAsignacion)
                .ValueGeneratedNever()
                .HasColumnName("id_asignacion");
            entity.Property(e => e.C40)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("c40");
            entity.Property(e => e.C41)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("c41");
            entity.Property(e => e.C50)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("c50");
            entity.Property(e => e.C51)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("c51");
            entity.Property(e => e.Cantrep)
                .HasDefaultValue(0)
                .HasColumnName("cantrep");
            entity.Property(e => e.Entrada)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("entrada");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.FldContarMultas).HasColumnName("fld_contar_multas");
            entity.Property(e => e.Horario)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("horario");
            entity.Property(e => e.IdHorario).HasColumnName("id_horario");
            entity.Property(e => e.IdPersonal).HasColumnName("id_personal");
            entity.Property(e => e.IdProgramacion).HasColumnName("id_programacion");
            entity.Property(e => e.IdPuesto).HasColumnName("id_puesto");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Observacion)
                .IsUnicode(false)
                .HasColumnName("observacion");
            entity.Property(e => e.Report)
                .HasColumnType("text")
                .HasColumnName("report");
            entity.Property(e => e.Salida)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("salida");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.AsignacionPersonals)
                .HasForeignKey(d => d.IdHorario)
                .HasConstraintName("FKHO");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.AsignacionPersonals)
                .HasForeignKey(d => d.IdPersonal)
                .HasConstraintName("FKPR");

            entity.HasOne(d => d.IdProgramacionNavigation).WithMany(p => p.AsignacionPersonals)
                .HasForeignKey(d => d.IdProgramacion)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FKPRO");

            entity.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.AsignacionPersonals)
                .HasForeignKey(d => d.IdPuesto)
                .HasConstraintName("FKPU");
        });

        modelBuilder.Entity<Aspirante>(entity =>
        {
            entity.HasKey(e => e.IdAspirante);

            entity.ToTable("ASPIRANTE");

            entity.Property(e => e.IdAspirante)
                .ValueGeneratedNever()
                .HasColumnName("ID_ASPIRANTE");
            entity.Property(e => e.Apellidos).HasColumnName("APELLIDOS");
            entity.Property(e => e.AptoPara).HasColumnName("APTO_PARA");
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .HasColumnName("CEDULA");
            entity.Property(e => e.Ciudad).HasColumnName("CIUDAD");
            entity.Property(e => e.DetalleAfis).HasColumnName("DETALLE_AFIS");
            entity.Property(e => e.DetalleAntecedentes).HasColumnName("DETALLE_ANTECEDENTES");
            entity.Property(e => e.DetalleBachiller).HasColumnName("DETALLE_BACHILLER");
            entity.Property(e => e.DetalleCertTrabajo).HasColumnName("DETALLE_CERT_TRABAJO");
            entity.Property(e => e.DetalleNoViolencia).HasColumnName("DETALLE_NO_VIOLENCIA");
            entity.Property(e => e.DetallePoligrafica).HasColumnName("DETALLE_POLIGRAFICA");
            entity.Property(e => e.DetallePsicologico).HasColumnName("DETALLE_PSICOLOGICO");
            entity.Property(e => e.DetalleRecomendacion).HasColumnName("DETALLE_RECOMENDACION");
            entity.Property(e => e.DetalleVehiculo).HasColumnName("DETALLE_VEHICULO");
            entity.Property(e => e.Direccion).HasColumnName("DIRECCION");
            entity.Property(e => e.Documentos).HasColumnName("DOCUMENTOS");
            entity.Property(e => e.Edad).HasColumnName("EDAD");
            entity.Property(e => e.Email).HasColumnName("EMAIL");
            entity.Property(e => e.EntidadCredencial).HasColumnName("ENTIDAD_CREDENCIAL");
            entity.Property(e => e.EntidadCurso).HasColumnName("ENTIDAD_CURSO");
            entity.Property(e => e.EstadoCivil).HasColumnName("ESTADO_CIVIL");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_NACIMIENTO");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.Instruccion).HasColumnName("INSTRUCCION");
            entity.Property(e => e.Movil).HasColumnName("MOVIL");
            entity.Property(e => e.Nombres).HasColumnName("NOMBRES");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.Parroquia).HasColumnName("PARROQUIA");
            entity.Property(e => e.Provincia).HasColumnName("PROVINCIA");
            entity.Property(e => e.PruebaAntidroga).HasColumnName("PRUEBA_ANTIDROGA");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .HasColumnName("SEXO");
            entity.Property(e => e.Telefono).HasColumnName("TELEFONO");
            entity.Property(e => e.TieneAfis).HasColumnName("TIENE_AFIS");
            entity.Property(e => e.TieneAntecedentes).HasColumnName("TIENE_ANTECEDENTES");
            entity.Property(e => e.TieneBachiller).HasColumnName("TIENE_BACHILLER");
            entity.Property(e => e.TieneCedula).HasColumnName("TIENE_CEDULA");
            entity.Property(e => e.TieneCertTrabajo).HasColumnName("TIENE_CERT_TRABAJO");
            entity.Property(e => e.TieneCertificadoVotacion).HasColumnName("TIENE_CERTIFICADO_VOTACION");
            entity.Property(e => e.TieneCredencial).HasColumnName("TIENE_CREDENCIAL");
            entity.Property(e => e.TieneCurso).HasColumnName("TIENE_CURSO");
            entity.Property(e => e.TieneDiscapacidad).HasColumnName("TIENE_DISCAPACIDAD");
            entity.Property(e => e.TieneLibretaMilitar).HasColumnName("TIENE_LIBRETA_MILITAR");
            entity.Property(e => e.TieneNoViolencia).HasColumnName("TIENE_NO_VIOLENCIA");
            entity.Property(e => e.TienePoligrafica).HasColumnName("TIENE_POLIGRAFICA");
            entity.Property(e => e.TienePsicologico).HasColumnName("TIENE_PSICOLOGICO");
            entity.Property(e => e.TieneRecomendacion).HasColumnName("TIENE_RECOMENDACION");
            entity.Property(e => e.TieneVehiculo).HasColumnName("TIENE_VEHICULO");
            entity.Property(e => e.TipoDiscapacidad).HasColumnName("TIPO_DISCAPACIDAD");
        });

        modelBuilder.Entity<At>(entity =>
        {
            entity.HasKey(e => e.IdAts);

            entity.ToTable("ATS");

            entity.Property(e => e.IdAts).HasColumnName("ID_ATS");
            entity.Property(e => e.ComprasFacturasAts).HasColumnName("COMPRAS_FACTURAS_ATS");
            entity.Property(e => e.ComprasLiquidacionesAts).HasColumnName("COMPRAS_LIQUIDACIONES_ATS");
            entity.Property(e => e.ComprasNotasCredito).HasColumnName("COMPRAS_NOTAS_CREDITO");
            entity.Property(e => e.ComprasNotasVentaAts).HasColumnName("COMPRAS_NOTAS_VENTA_ATS");
            entity.Property(e => e.EstadoAts).HasColumnName("ESTADO_ATS");
            entity.Property(e => e.FechaCreacionAts)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION_ATS");
            entity.Property(e => e.PeriodoAts)
                .HasColumnType("datetime")
                .HasColumnName("PERIODO_ATS");
            entity.Property(e => e.RetencionesComprasAts).HasColumnName("RETENCIONES_COMPRAS_ATS");
            entity.Property(e => e.VentasFacturasAts).HasColumnName("VENTAS_FACTURAS_ATS");
            entity.Property(e => e.VentasNotasCreditoAts).HasColumnName("VENTAS_NOTAS_CREDITO_ATS");
        });

        modelBuilder.Entity<AuditoriaGeneral>(entity =>
        {
            entity.HasKey(e => e.IdAuditoriaGeneral);

            entity.ToTable("AUDITORIA_GENERAL");

            entity.Property(e => e.IdAuditoriaGeneral)
                .ValueGeneratedNever()
                .HasColumnName("ID_AUDITORIA_GENERAL");
            entity.Property(e => e.Accion).HasColumnName("ACCION");
            entity.Property(e => e.EstadoAuditoriaGeneral).HasColumnName("ESTADO_AUDITORIA_GENERAL");
            entity.Property(e => e.FechaAuditoriaGeneral)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_AUDITORIA_GENERAL");
            entity.Property(e => e.Formulario).HasColumnName("FORMULARIO");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.AuditoriaGenerals)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AUDITORIA_GENERAL_USUARIO_GENERAL");
        });

        modelBuilder.Entity<AuxiliarCajaChica>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AUXILIAR_CAJA_CHICA");

            entity.Property(e => e.IdCajaChica).HasColumnName("ID_CAJA_CHICA");
            entity.Property(e => e.MontoAnterior)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MONTO_ANTERIOR");
            entity.Property(e => e.MontoCajaChica)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MONTO_CAJA_CHICA");
        });

        modelBuilder.Entity<AuxiliarConcepto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AUXILIAR_CONCEPTOS");

            entity.Property(e => e.CtaContableConcepto).HasColumnName("CTA_CONTABLE_CONCEPTO");
            entity.Property(e => e.EstadoConcepto).HasColumnName("ESTADO_CONCEPTO");
            entity.Property(e => e.IdConcepto).HasColumnName("ID_CONCEPTO");
            entity.Property(e => e.NombreConcepto).HasColumnName("NOMBRE_CONCEPTO");
        });

        modelBuilder.Entity<AuxiliarFondoRotativo>(entity =>
        {
            entity.HasKey(e => e.IdFondoRotativo);

            entity.ToTable("AUXILIAR_FONDO_ROTATIVO");

            entity.Property(e => e.IdFondoRotativo)
                .ValueGeneratedNever()
                .HasColumnName("ID_FONDO_ROTATIVO");
            entity.Property(e => e.MontoAnterior)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MONTO_ANTERIOR");
            entity.Property(e => e.MontoFondoRotativo)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MONTO_FONDO_ROTATIVO");
        });

        modelBuilder.Entity<AuxiliarKilometraje>(entity =>
        {
            entity.HasKey(e => e.IdAuxiliarKm);

            entity.ToTable("AUXILIAR_KILOMETRAJE");

            entity.Property(e => e.IdAuxiliarKm)
                .ValueGeneratedNever()
                .HasColumnName("ID_AUXILIAR_KM");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.IdControlC).HasColumnName("ID_CONTROL_C");
            entity.Property(e => e.KilometrajeAuxiliarKm).HasColumnName("KILOMETRAJE_AUXILIAR_KM");
        });

        modelBuilder.Entity<BalanceComprobacion>(entity =>
        {
            entity.HasKey(e => e.IdBalance);

            entity.ToTable("BALANCE_COMPROBACION");

            entity.Property(e => e.IdBalance)
                .ValueGeneratedNever()
                .HasColumnName("ID_BALANCE");
            entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.FechaFinCorte)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_FIN_CORTE");
            entity.Property(e => e.FechaInicioCorte)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO_CORTE");
            entity.Property(e => e.IdCorte).HasColumnName("ID_CORTE");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.TotalAcreedor)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("TOTAL_ACREEDOR");
            entity.Property(e => e.TotalDebe)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("TOTAL_DEBE");
            entity.Property(e => e.TotalDeudor)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("TOTAL_DEUDOR");
            entity.Property(e => e.TotalHaber)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("TOTAL_HABER");
        });

        modelBuilder.Entity<Banco>(entity =>
        {
            entity.HasKey(e => e.IdBanco);

            entity.ToTable("BANCOS");

            entity.Property(e => e.IdBanco)
                .ValueGeneratedNever()
                .HasColumnName("ID_BANCO");
            entity.Property(e => e.CodigoBanco).HasColumnName("CODIGO_BANCO");
            entity.Property(e => e.DireccionBanco).HasColumnName("DIRECCION_BANCO");
            entity.Property(e => e.EmailBanco).HasColumnName("EMAIL_BANCO");
            entity.Property(e => e.EstadoBanco).HasColumnName("ESTADO_BANCO");
            entity.Property(e => e.FaxBanco).HasColumnName("FAX_BANCO");
            entity.Property(e => e.NombreBanco).HasColumnName("NOMBRE_BANCO");
            entity.Property(e => e.OficialCreditoBanco).HasColumnName("OFICIAL_CREDITO_BANCO");
            entity.Property(e => e.TelefonoBanco).HasColumnName("TELEFONO_BANCO");
        });

        modelBuilder.Entity<BancoRole>(entity =>
        {
            entity.HasKey(e => e.IdBanco).HasName("PK__BANCO_RO__1579AAAB4F296100");

            entity.ToTable("BANCO_ROLES");

            entity.Property(e => e.IdBanco)
                .ValueGeneratedNever()
                .HasColumnName("ID_BANCO");
            entity.Property(e => e.Banco)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BANCO");
            entity.Property(e => e.Cod)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("COD");
        });

        modelBuilder.Entity<BancosCobro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BANCOS_COBROS");

            entity.Property(e => e.CiudadBancoCobros).HasColumnName("CIUDAD_BANCO_COBROS");
            entity.Property(e => e.EstadoBancoCobros).HasColumnName("ESTADO_BANCO_COBROS");
            entity.Property(e => e.IdBancoCobros).HasColumnName("ID_BANCO_COBROS");
            entity.Property(e => e.NombreBancoCobros).HasColumnName("NOMBRE_BANCO_COBROS");
            entity.Property(e => e.PaisBancoCobros).HasColumnName("PAIS_BANCO_COBROS");
        });

        modelBuilder.Entity<BitacoraOperativo>(entity =>
        {
            entity.HasKey(e => e.IdBitacora).HasName("PK__BITACORA__44E70BF352F9F1E4");

            entity.ToTable("BITACORA_OPERATIVO");

            entity.Property(e => e.IdBitacora)
                .ValueGeneratedNever()
                .HasColumnName("ID_BITACORA");
            entity.Property(e => e.Ciudad).HasColumnName("CIUDAD");
            entity.Property(e => e.DetalleBitacora).HasColumnName("DETALLE_BITACORA");
            entity.Property(e => e.FechaBitacora)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_BITACORA");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.IdPuesto).HasColumnName("ID_PUESTO");
            entity.Property(e => e.IdVigilante).HasColumnName("ID_VIGILANTE");
            entity.Property(e => e.Provincia).HasColumnName("PROVINCIA");
            entity.Property(e => e.Puesto).HasColumnName("PUESTO");
            entity.Property(e => e.River).HasColumnName("RIVER");
            entity.Property(e => e.TipoBitacora).HasColumnName("TIPO_BITACORA");
            entity.Property(e => e.Vigilante).HasColumnName("VIGILANTE");
        });

        modelBuilder.Entity<Bodega>(entity =>
        {
            entity.HasKey(e => e.IdBodega);

            entity.ToTable("BODEGA");

            entity.Property(e => e.IdBodega)
                .ValueGeneratedNever()
                .HasColumnName("ID_BODEGA");
            entity.Property(e => e.EstadoBodega).HasColumnName("ESTADO_BODEGA");
            entity.Property(e => e.FechaCreacionBodega)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION_BODEGA");
            entity.Property(e => e.IdPersonalBodega).HasColumnName("ID_PERSONAL_BODEGA");
            entity.Property(e => e.IdSitioTrabajoBodega).HasColumnName("ID_SITIO_TRABAJO_BODEGA");
            entity.Property(e => e.NombreBodega).HasColumnName("NOMBRE_BODEGA");
            entity.Property(e => e.ObservacionBodega).HasColumnName("OBSERVACION_BODEGA");
            entity.Property(e => e.TelefonoBodega).HasColumnName("TELEFONO_BODEGA");

            entity.HasOne(d => d.IdPersonalBodegaNavigation).WithMany(p => p.Bodegas)
                .HasForeignKey(d => d.IdPersonalBodega)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BODEGA_PERSONAL");

            entity.HasOne(d => d.IdSitioTrabajoBodegaNavigation).WithMany(p => p.Bodegas)
                .HasForeignKey(d => d.IdSitioTrabajoBodega)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BODEGA_SITIOS_TRABAJO");
        });

        modelBuilder.Entity<CajaChica>(entity =>
        {
            entity.HasKey(e => e.IdCajaChica);

            entity.ToTable("CAJA_CHICA");

            entity.Property(e => e.IdCajaChica)
                .ValueGeneratedNever()
                .HasColumnName("ID_CAJA_CHICA");
            entity.Property(e => e.CtaContable).HasColumnName("CTA_CONTABLE");
            entity.Property(e => e.DetalleCajaChica).HasColumnName("DETALLE_CAJA_CHICA");
            entity.Property(e => e.EstadoCajaChica).HasColumnName("ESTADO_CAJA_CHICA");
            entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProvincias).HasColumnName("ID_PROVINCIAS");
            entity.Property(e => e.MontoCajaChica)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MONTO_CAJA_CHICA");
            entity.Property(e => e.NivelCta).HasColumnName("NIVEL_CTA");
            entity.Property(e => e.TipoCta).HasColumnName("TIPO_CTA");
            entity.Property(e => e.ValorGasto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_GASTO");

            entity.HasOne(d => d.IdCentroCostoNavigation).WithMany(p => p.CajaChicas)
                .HasForeignKey(d => d.IdCentroCosto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CAJA_CHICA_CENTRO_COSTO");
        });

        modelBuilder.Entity<CalificacionProveedor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CALIFICACION_PROVEEDOR");

            entity.Property(e => e.AprobadoCalificacionProveedor)
                .HasMaxLength(10)
                .HasColumnName("APROBADO_CALIFICACION_PROVEEDOR");
            entity.Property(e => e.CertificacionesCalificacionProveedor).HasColumnName("CERTIFICACIONES_CALIFICACION_PROVEEDOR");
            entity.Property(e => e.EspecificacionProductoCalificacionProveedor).HasColumnName("ESPECIFICACION_PRODUCTO_CALIFICACION_PROVEEDOR");
            entity.Property(e => e.EstadoCalificacionProveedor).HasColumnName("ESTADO_CALIFICACION_PROVEEDOR");
            entity.Property(e => e.FechaCalificacionProveedor)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CALIFICACION_PROVEEDOR");
            entity.Property(e => e.FormaPagoCalificacionProveedor).HasColumnName("FORMA_PAGO_CALIFICACION_PROVEEDOR");
            entity.Property(e => e.IdCalificacionProveedor).HasColumnName("ID_CALIFICACION_PROVEEDOR");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProveedorGeneral).HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.ObservacionesCalificacionProveedor).HasColumnName("OBSERVACIONES_CALIFICACION_PROVEEDOR");
            entity.Property(e => e.PresentacionProductoCalificacionProveedor).HasColumnName("PRESENTACION_PRODUCTO_CALIFICACION_PROVEEDOR");
            entity.Property(e => e.RucActualizadoCalificacionProveedor).HasColumnName("RUC_ACTUALIZADO_CALIFICACION_PROVEEDOR");
            entity.Property(e => e.TiempoEntregaCalificacionProveedor).HasColumnName("TIEMPO_ENTREGA_CALIFICACION_PROVEEDOR");
            entity.Property(e => e.TotalCalificacionProveedor).HasColumnName("TOTAL_CALIFICACION_PROVEEDOR");
        });

        modelBuilder.Entity<CamarasSeguridad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CAMARAS_SEGURIDAD");

            entity.Property(e => e.Adicionales).HasColumnName("ADICIONALES");
            entity.Property(e => e.Ano).HasColumnName("ANO");
            entity.Property(e => e.Caducidad)
                .HasColumnType("datetime")
                .HasColumnName("CADUCIDAD");
            entity.Property(e => e.Color).HasColumnName("COLOR");
            entity.Property(e => e.Documento).HasColumnName("DOCUMENTO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoActivo).HasColumnName("ESTADO_ACTIVO");
            entity.Property(e => e.Garantia).HasColumnName("GARANTIA");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Material).HasColumnName("MATERIAL");
            entity.Property(e => e.Modelo).HasColumnName("MODELO");
            entity.Property(e => e.Ruta).HasColumnName("RUTA");
            entity.Property(e => e.Serie).HasColumnName("SERIE");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CAMARAS_SEGURIDAD_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<CargoOcupacional>(entity =>
        {
            entity.HasKey(e => e.IdCargoOcupacional);

            entity.ToTable("CARGO_OCUPACIONAL");

            entity.Property(e => e.IdCargoOcupacional)
                .ValueGeneratedNever()
                .HasColumnName("ID_CARGO_OCUPACIONAL");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.IdSerieOcupacional).HasColumnName("ID_SERIE_OCUPACIONAL");
            entity.Property(e => e.SueldoBasico)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUELDO_BASICO");

            entity.HasOne(d => d.IdSerieOcupacionalNavigation).WithMany(p => p.CargoOcupacionals)
                .HasForeignKey(d => d.IdSerieOcupacional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CARGO_OCUPACIONAL_SERIE_OCUPACIONAL");
        });

        modelBuilder.Entity<CategoriaItem>(entity =>
        {
            entity.HasKey(e => e.IdCategoriaItem);

            entity.ToTable("CATEGORIA_ITEM");

            entity.Property(e => e.IdCategoriaItem)
                .ValueGeneratedNever()
                .HasColumnName("ID_CATEGORIA_ITEM");
            entity.Property(e => e.EstadoCategoriaItem).HasColumnName("ESTADO_CATEGORIA_ITEM");
            entity.Property(e => e.FechaCategoriaItem)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CATEGORIA_ITEM");
            entity.Property(e => e.NombreCategoriaItem).HasColumnName("NOMBRE_CATEGORIA_ITEM");
        });

        modelBuilder.Entity<CategoriaSuministro>(entity =>
        {
            entity.HasKey(e => e.IdCategoriaSuministros);

            entity.ToTable("CATEGORIA_SUMINISTROS");

            entity.Property(e => e.IdCategoriaSuministros)
                .ValueGeneratedNever()
                .HasColumnName("ID_CATEGORIA_SUMINISTROS");
            entity.Property(e => e.CategoriaCat).HasColumnName("CATEGORIA_CAT");
            entity.Property(e => e.EstadoCategoriaSuministros).HasColumnName("ESTADO_CATEGORIA_SUMINISTROS");
            entity.Property(e => e.NombreCategoriaSuministros).HasColumnName("NOMBRE_CATEGORIA_SUMINISTROS");
        });

        modelBuilder.Entity<CategoriaUbicacion>(entity =>
        {
            entity.HasKey(e => e.IdCategoriaUbicacion);

            entity.ToTable("CATEGORIA_UBICACION");

            entity.Property(e => e.IdCategoriaUbicacion)
                .ValueGeneratedNever()
                .HasColumnName("ID_CATEGORIA_UBICACION");
            entity.Property(e => e.EstadoCategoriaUbicacion).HasColumnName("ESTADO_CATEGORIA_UBICACION");
            entity.Property(e => e.FechaCategoriaUbicacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CATEGORIA_UBICACION");
            entity.Property(e => e.FilasTotalCategoriaUbicacion).HasColumnName("FILAS_TOTAL_CATEGORIA_UBICACION");
            entity.Property(e => e.FilasUsadasCategoriaUbicacion).HasColumnName("FILAS_USADAS__CATEGORIA_UBICACION");
            entity.Property(e => e.FilasVaciasCategoriaUbicacion).HasColumnName("FILAS_VACIAS_CATEGORIA_UBICACION");
            entity.Property(e => e.IdBodega).HasColumnName("ID_BODEGA");
            entity.Property(e => e.NombreCategoriaUbicacion).HasColumnName("NOMBRE_CATEGORIA_UBICACION");

            entity.HasOne(d => d.IdBodegaNavigation).WithMany(p => p.CategoriaUbicacions)
                .HasForeignKey(d => d.IdBodega)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CATEGORIA_UBICACION_BODEGA");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.IdCategoria)
                .ValueGeneratedNever()
                .HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.EstadoCategoria).HasColumnName("ESTADO_CATEGORIA");
            entity.Property(e => e.NombreCategoria).HasColumnName("NOMBRE_CATEGORIA");
        });

        modelBuilder.Entity<CentroCosto>(entity =>
        {
            entity.HasKey(e => e.IdCentroCosto).HasName("PK__CENTRO_COSTO__1387E197");

            entity.ToTable("CENTRO_COSTO");

            entity.Property(e => e.IdCentroCosto)
                .ValueGeneratedNever()
                .HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.CodigoCentroCosto).HasColumnName("CODIGO_CENTRO_COSTO");
            entity.Property(e => e.DetalleCentroCosto).HasColumnName("DETALLE_CENTRO_COSTO");
            entity.Property(e => e.EstadoCentroCosto).HasColumnName("ESTADO_CENTRO_COSTO");
        });

        modelBuilder.Entity<Chaleco>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CHALECOS");

            entity.Property(e => e.Adicionales).HasColumnName("ADICIONALES");
            entity.Property(e => e.Ano).HasColumnName("ANO");
            entity.Property(e => e.Caducidad)
                .HasColumnType("datetime")
                .HasColumnName("CADUCIDAD");
            entity.Property(e => e.Color).HasColumnName("COLOR");
            entity.Property(e => e.Documento).HasColumnName("DOCUMENTO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoActivo).HasColumnName("ESTADO_ACTIVO");
            entity.Property(e => e.Garantia).HasColumnName("GARANTIA");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Material).HasColumnName("MATERIAL");
            entity.Property(e => e.Modelo).HasColumnName("MODELO");
            entity.Property(e => e.Ruta).HasColumnName("RUTA");
            entity.Property(e => e.Serie).HasColumnName("SERIE");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHALECOS_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<ChequesEmitido>(entity =>
        {
            entity.HasKey(e => e.IdChequeEmitido);

            entity.ToTable("CHEQUES_EMITIDOS");

            entity.Property(e => e.IdChequeEmitido)
                .ValueGeneratedNever()
                .HasColumnName("ID_CHEQUE_EMITIDO");
            entity.Property(e => e.BancoChequeEmitido).HasColumnName("BANCO_CHEQUE_EMITIDO");
            entity.Property(e => e.BeneficiarioChequeEmitido).HasColumnName("BENEFICIARIO_CHEQUE_EMITIDO");
            entity.Property(e => e.CtaCteChequeEmitido)
                .HasMaxLength(50)
                .HasColumnName("CTA_CTE_CHEQUE_EMITIDO");
            entity.Property(e => e.EstadoChequeEmitido).HasColumnName("ESTADO_CHEQUE_EMITIDO");
            entity.Property(e => e.FechaCobroChequeEmitido)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_COBRO_CHEQUE_EMITIDO");
            entity.Property(e => e.FechaEmisionChequeEmitido)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION_CHEQUE_EMITIDO");
            entity.Property(e => e.IdComprobanteEgresoBancos).HasColumnName("ID_COMPROBANTE_EGRESO_BANCOS");
            entity.Property(e => e.NumeroChequeEmitido)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_CHEQUE_EMITIDO");
            entity.Property(e => e.ValorChequeEmitido)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_CHEQUE_EMITIDO");
        });

        modelBuilder.Entity<ChequesRecibido>(entity =>
        {
            entity.HasKey(e => e.IdChequeRecibido);

            entity.ToTable("CHEQUES_RECIBIDOS");

            entity.Property(e => e.IdChequeRecibido)
                .ValueGeneratedNever()
                .HasColumnName("ID_CHEQUE_RECIBIDO");
            entity.Property(e => e.BancoChequeRecibido)
                .HasMaxLength(50)
                .HasColumnName("BANCO_CHEQUE_RECIBIDO");
            entity.Property(e => e.CtaCteChequeRecibido)
                .HasMaxLength(50)
                .HasColumnName("CTA_CTE_CHEQUE_RECIBIDO");
            entity.Property(e => e.EstadoChequeRecibido).HasColumnName("ESTADO_CHEQUE_RECIBIDO");
            entity.Property(e => e.FechaEmisionChequeRecibido)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION_CHEQUE_RECIBIDO");
            entity.Property(e => e.IdClienteGeneral).HasColumnName("ID_CLIENTE_GENERAL");
            entity.Property(e => e.IdComprobanteIngresoBancos).HasColumnName("ID_COMPROBANTE_INGRESO_BANCOS");
            entity.Property(e => e.NumeroChequeRecibido).HasColumnName("NUMERO_CHEQUE_RECIBIDO");
            entity.Property(e => e.TitularChequeRecibido)
                .HasMaxLength(50)
                .HasColumnName("TITULAR_CHEQUE_RECIBIDO");
            entity.Property(e => e.ValorChequeRecibido)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_CHEQUE_RECIBIDO");
        });

        modelBuilder.Entity<Ciudade>(entity =>
        {
            entity.HasKey(e => e.IdCiudad);

            entity.ToTable("CIUDADES");

            entity.Property(e => e.IdCiudad)
                .ValueGeneratedNever()
                .HasColumnName("ID_CIUDAD");
            entity.Property(e => e.EstadoCiudades).HasColumnName("ESTADO_CIUDADES");
            entity.Property(e => e.IdProvincias).HasColumnName("ID_PROVINCIAS");
            entity.Property(e => e.NombreCiudades).HasColumnName("NOMBRE_CIUDADES");

            entity.HasOne(d => d.IdProvinciasNavigation).WithMany(p => p.Ciudades)
                .HasForeignKey(d => d.IdProvincias)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CIUDADES_PROVINCIAS");
        });

        modelBuilder.Entity<ClienteGeneral>(entity =>
        {
            entity.HasKey(e => e.IdClienteGeneral);

            entity.ToTable("CLIENTE_GENERAL");

            entity.Property(e => e.IdClienteGeneral)
                .ValueGeneratedNever()
                .HasColumnName("ID_CLIENTE_GENERAL");
            entity.Property(e => e.ApellidoNombreComercialClienteGenral).HasColumnName("APELLIDO_NOMBRE_COMERCIAL_CLIENTE_GENRAL");
            entity.Property(e => e.CodigoClienteGeneral)
                .HasMaxLength(15)
                .HasColumnName("CODIGO_CLIENTE_GENERAL");
            entity.Property(e => e.ConsorcioClienteGeneral).HasColumnName("CONSORCIO_CLIENTE_GENERAL");
            entity.Property(e => e.ContactoClienteGeneral).HasColumnName("CONTACTO_CLIENTE_GENERAL");
            entity.Property(e => e.DireccionFacturacionClienteGeneral).HasColumnName("DIRECCION_FACTURACION_CLIENTE_GENERAL");
            entity.Property(e => e.DireccionUbicacionClienteGeneral).HasColumnName("DIRECCION_UBICACION_CLIENTE_GENERAL");
            entity.Property(e => e.EmailClienteGeneral).HasColumnName("EMAIL_CLIENTE_GENERAL");
            entity.Property(e => e.EstadoClienteGeneral)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ESTADO_CLIENTE_GENERAL");
            entity.Property(e => e.FechaIngresoClienteGeneral)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INGRESO_CLIENTE_GENERAL");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.NompreRazonSocialClienteGeneral).HasColumnName("NOMPRE_RAZON_SOCIAL_CLIENTE_GENERAL");
            entity.Property(e => e.NroResContEspecialClienteGeneral)
                .HasMaxLength(50)
                .HasColumnName("NRO_RES_CONT_ESPECIAL_CLIENTE_GENERAL");
            entity.Property(e => e.ObligLlevarContClienteGeneral)
                .HasMaxLength(5)
                .HasColumnName("OBLIG_LLEVAR_CONT_CLIENTE_GENERAL");
            entity.Property(e => e.ObservacionesClienteGeneral).HasColumnName("OBSERVACIONES_CLIENTE_GENERAL");
            entity.Property(e => e.RucCiClienteGeneral)
                .HasMaxLength(15)
                .HasColumnName("RUC_CI_CLIENTE_GENERAL");
            entity.Property(e => e.Telefono1ClienteGeneral)
                .HasMaxLength(50)
                .HasColumnName("TELEFONO_1_CLIENTE_GENERAL");
            entity.Property(e => e.Telefono2ClienteGeneral)
                .HasMaxLength(50)
                .HasColumnName("TELEFONO_2_CLIENTE_GENERAL");
            entity.Property(e => e.TipoClienteGeneral)
                .HasMaxLength(50)
                .HasColumnName("TIPO_CLIENTE_GENERAL");
            entity.Property(e => e.TipoEmpresaCliente)
                .HasMaxLength(15)
                .HasColumnName("TIPO_EMPRESA_CLIENTE");
            entity.Property(e => e.TipoIdentificacionClienteGeneral)
                .HasMaxLength(10)
                .HasColumnName("TIPO_IDENTIFICACION_CLIENTE_GENERAL");
        });

        modelBuilder.Entity<CodigoAutorizarFactura>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CODIGO_AUTORIZAR_FACTURA");

            entity.Property(e => e.EstadoCodigoAutorizarFactura).HasColumnName("ESTADO_CODIGO_AUTORIZAR_FACTURA");
            entity.Property(e => e.FechaCodigoAutorizarFactura)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CODIGO_AUTORIZAR_FACTURA");
            entity.Property(e => e.IdCodigoAutorizarFactura).HasColumnName("ID_CODIGO_AUTORIZAR_FACTURA");
            entity.Property(e => e.NumeroCodigoAutorizarFactura)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_CODIGO_AUTORIZAR_FACTURA");
            entity.Property(e => e.NumeroFacturaVenta)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_FACTURA_VENTA");
            entity.Property(e => e.ObservacionCodigoAutorizarFactura).HasColumnName("OBSERVACION_CODIGO_AUTORIZAR_FACTURA");
        });

        modelBuilder.Entity<CodigoCargoOcupacional>(entity =>
        {
            entity.HasKey(e => e.IdCodigo).HasName("PK__CODIGO_CARGO_OCU__2BE024C3");

            entity.ToTable("CODIGO_CARGO_OCUPACIONAL");

            entity.Property(e => e.IdCodigo)
                .ValueGeneratedNever()
                .HasColumnName("ID_CODIGO");
            entity.Property(e => e.CodigoOcupacional).HasColumnName("CODIGO_OCUPACIONAL");
            entity.Property(e => e.IdCargoOcupacional).HasColumnName("ID_CARGO_OCUPACIONAL");
        });

        modelBuilder.Entity<CodigosActivo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CODIGOS_ACTIVOS");

            entity.Property(e => e.Categoria).HasColumnName("CATEGORIA");
            entity.Property(e => e.CodigoCategoria).HasColumnName("CODIGO CATEGORIA");
            entity.Property(e => e.CodigoGrupo).HasColumnName("CODIGO GRUPO");
            entity.Property(e => e.CodigoSecuencial).HasColumnName("CODIGO SECUENCIAL");
            entity.Property(e => e.CodigoSubgrupo).HasColumnName("CODIGO SUBGRUPO");
            entity.Property(e => e.Depreciable)
                .HasMaxLength(2)
                .HasColumnName("DEPRECIABLE");
            entity.Property(e => e.EstadoCategoria).HasColumnName("ESTADO_CATEGORIA");
            entity.Property(e => e.EstadoGrupo).HasColumnName("ESTADO_GRUPO");
            entity.Property(e => e.EstadoSecuencial).HasColumnName("ESTADO_SECUENCIAL");
            entity.Property(e => e.EstadoSubGrupo).HasColumnName("ESTADO_SUB_GRUPO");
            entity.Property(e => e.Grupo).HasColumnName("GRUPO");
            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.IdGrupo).HasColumnName("ID_GRUPO");
            entity.Property(e => e.Secuencial).HasColumnName("SECUENCIAL");
            entity.Property(e => e.Subgrupo).HasColumnName("SUBGRUPO");
        });

        modelBuilder.Entity<ColorGeneral>(entity =>
        {
            entity.HasKey(e => e.IdColor);

            entity.ToTable("COLOR_GENERAL");

            entity.Property(e => e.IdColor)
                .ValueGeneratedNever()
                .HasColumnName("ID_COLOR");
            entity.Property(e => e.Detalle).HasColumnName("DETALLE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
        });

        modelBuilder.Entity<CompEgresoPagosCompCompra>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("COMP_EGRESO_PAGOS_COMP_COMPRA");

            entity.Property(e => e.IdComprobanteCompra).HasColumnName("ID_COMPROBANTE_COMPRA");
            entity.Property(e => e.IdComprobanteEgresoBancos).HasColumnName("ID_COMPROBANTE_EGRESO_BANCOS");
            entity.Property(e => e.IdPagosComprobanteCompra).HasColumnName("ID_PAGOS_COMPROBANTE_COMPRA");
            entity.Property(e => e.MontoPagosComprobanteCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MONTO_PAGOS_COMPROBANTE_COMPRA");
            entity.Property(e => e.NumeroRegistroAsiento).HasColumnName("NUMERO_REGISTRO_ASIENTO");
        });

        modelBuilder.Entity<ComprobanteAjusteBodega>(entity =>
        {
            entity.HasKey(e => e.IdComprobante);

            entity.ToTable("COMPROBANTE_AJUSTE_BODEGA");

            entity.Property(e => e.IdComprobante)
                .HasMaxLength(8)
                .HasColumnName("ID_COMPROBANTE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaComprobante)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_COMPROBANTE");
            entity.Property(e => e.IdActividad).HasColumnName("ID_ACTIVIDAD");
            entity.Property(e => e.IdBodega).HasColumnName("ID_BODEGA");
            entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdConcepto).HasColumnName("ID_CONCEPTO");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdParametroDocumento).HasColumnName("ID_PARAMETRO_DOCUMENTO");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProvincias).HasColumnName("ID_PROVINCIAS");
            entity.Property(e => e.IdSitioTrabajo).HasColumnName("ID_SITIO_TRABAJO");
            entity.Property(e => e.NroParametro).HasColumnName("NRO_PARAMETRO");
            entity.Property(e => e.Razon).HasColumnName("RAZON");
        });

        modelBuilder.Entity<ComprobanteDonacionBodega>(entity =>
        {
            entity.HasKey(e => e.IdComprobante);

            entity.ToTable("COMPROBANTE_DONACION_BODEGA");

            entity.Property(e => e.IdComprobante)
                .HasMaxLength(8)
                .HasColumnName("ID_COMPROBANTE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaComprobante)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_COMPROBANTE");
            entity.Property(e => e.IdActividad).HasColumnName("ID_ACTIVIDAD");
            entity.Property(e => e.IdBodega).HasColumnName("ID_BODEGA");
            entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdConcepto).HasColumnName("ID_CONCEPTO");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdParametroDocumento).HasColumnName("ID_PARAMETRO_DOCUMENTO");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProvincias).HasColumnName("ID_PROVINCIAS");
            entity.Property(e => e.IdSitioTrabajo).HasColumnName("ID_SITIO_TRABAJO");
            entity.Property(e => e.NroParametro).HasColumnName("NRO_PARAMETRO");
            entity.Property(e => e.Razon).HasColumnName("RAZON");
        });

        modelBuilder.Entity<ComprobanteEgresoBanco>(entity =>
        {
            entity.HasKey(e => e.IdComprobanteEgresoBancos);

            entity.ToTable("COMPROBANTE_EGRESO_BANCOS");

            entity.Property(e => e.IdComprobanteEgresoBancos)
                .ValueGeneratedNever()
                .HasColumnName("ID_COMPROBANTE_EGRESO_BANCOS");
            entity.Property(e => e.Actividad).HasColumnName("ACTIVIDAD");
            entity.Property(e => e.Concepto).HasColumnName("CONCEPTO");
            entity.Property(e => e.EstadoComprobanteEgresoBanco).HasColumnName("ESTADO_COMPROBANTE_EGRESO_BANCO");
            entity.Property(e => e.FechaComprobanteEgresoBancos)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_COMPROBANTE_EGRESO_BANCOS");
            entity.Property(e => e.IdBanco).HasColumnName("ID_BANCO");
            entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdCuentaBancos).HasColumnName("ID_CUENTA_BANCOS");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdProvincias).HasColumnName("ID_PROVINCIAS");
            entity.Property(e => e.NombreReceptor).HasColumnName("NOMBRE_RECEPTOR");
            entity.Property(e => e.NumeroCheque)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_CHEQUE");
            entity.Property(e => e.NumeroComprobanteEgresobancos).HasColumnName("NUMERO_COMPROBANTE_EGRESOBANCOS");
            entity.Property(e => e.NumeroFacturaReceptor).HasColumnName("NUMERO_FACTURA_RECEPTOR");
            entity.Property(e => e.RazonComprobanteEgresoBancos).HasColumnName("RAZON_COMPROBANTE_EGRESO_BANCOS");
            entity.Property(e => e.RucCiReceptor).HasColumnName("RUC_CI_RECEPTOR");
            entity.Property(e => e.TipoPagoComprobanteEgresoBancos).HasColumnName("TIPO_PAGO_COMPROBANTE_EGRESO_BANCOS");
            entity.Property(e => e.ValorComprobanteEgresoBancos)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_COMPROBANTE_EGRESO_BANCOS");
        });

        modelBuilder.Entity<ComprobanteEgresoBodega>(entity =>
        {
            entity.HasKey(e => e.IdComprobante);

            entity.ToTable("COMPROBANTE_EGRESO_BODEGA");

            entity.Property(e => e.IdComprobante)
                .HasMaxLength(8)
                .HasColumnName("ID_COMPROBANTE");
            entity.Property(e => e.Cliente).HasColumnName("CLIENTE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaComprobante)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_COMPROBANTE");
            entity.Property(e => e.IdActividad).HasColumnName("ID_ACTIVIDAD");
            entity.Property(e => e.IdBodega).HasColumnName("ID_BODEGA");
            entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdConcepto).HasColumnName("ID_CONCEPTO");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdParametroDocumento).HasColumnName("ID_PARAMETRO_DOCUMENTO");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProvincias).HasColumnName("ID_PROVINCIAS");
            entity.Property(e => e.IdSitioTrabajo).HasColumnName("ID_SITIO_TRABAJO");
            entity.Property(e => e.NroParametro).HasColumnName("NRO_PARAMETRO");
            entity.Property(e => e.Razon).HasColumnName("RAZON");
        });

        modelBuilder.Entity<ComprobanteIngresoBanco>(entity =>
        {
            entity.HasKey(e => e.IdComprobanteIngresoBancos);

            entity.ToTable("COMPROBANTE_INGRESO_BANCOS");

            entity.Property(e => e.IdComprobanteIngresoBancos)
                .ValueGeneratedNever()
                .HasColumnName("ID_COMPROBANTE_INGRESO_BANCOS");
            entity.Property(e => e.ActividadComprobanteIngresoBancos)
                .HasMaxLength(50)
                .HasColumnName("ACTIVIDAD_COMPROBANTE_INGRESO_BANCOS");
            entity.Property(e => e.ConceptoComprobanteIngresoBancos).HasColumnName("CONCEPTO_COMPROBANTE_INGRESO_BANCOS");
            entity.Property(e => e.EstadoComprobanteIngresoBancos).HasColumnName("ESTADO_COMPROBANTE_INGRESO_BANCOS");
            entity.Property(e => e.FechaComprobanteIngresoBancos)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_COMPROBANTE_INGRESO_BANCOS");
            entity.Property(e => e.FormaPagoComprobanteIngresoBancos)
                .HasMaxLength(50)
                .HasColumnName("FORMA_PAGO_COMPROBANTE_INGRESO_BANCOS");
            entity.Property(e => e.IdBanco).HasColumnName("ID_BANCO");
            entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdClienteGeneral).HasColumnName("ID_CLIENTE_GENERAL");
            entity.Property(e => e.IdCuentaBancos).HasColumnName("ID_CUENTA_BANCOS");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");
            entity.Property(e => e.NumeroDepositoComprobanteIngresoBancos)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_DEPOSITO_COMPROBANTE_INGRESO_BANCOS");
            entity.Property(e => e.NumeroFacturaVenta).HasColumnName("NUMERO_FACTURA_VENTA");
            entity.Property(e => e.ObservacionesComprobanteIngresoBancos).HasColumnName("OBSERVACIONES_COMPROBANTE_INGRESO_BANCOS");
            entity.Property(e => e.ValorComprobanteIngresoBancos)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_COMPROBANTE_INGRESO_BANCOS");
        });

        modelBuilder.Entity<ComprobanteIngresoBodega>(entity =>
        {
            entity.HasKey(e => e.IdComprobante);

            entity.ToTable("COMPROBANTE_INGRESO_BODEGA");

            entity.HasIndex(e => e.FechaComprobante, "IX_COMPROBANTE_INGRESO_BODEGA");

            entity.Property(e => e.IdComprobante)
                .HasMaxLength(8)
                .HasColumnName("ID_COMPROBANTE");
            entity.Property(e => e.Cliente).HasColumnName("CLIENTE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaComprobante)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_COMPROBANTE");
            entity.Property(e => e.IdActividad).HasColumnName("ID_ACTIVIDAD");
            entity.Property(e => e.IdBodega).HasColumnName("ID_BODEGA");
            entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdConcepto).HasColumnName("ID_CONCEPTO");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdParametroDocumento).HasColumnName("ID_PARAMETRO_DOCUMENTO");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProvincias).HasColumnName("ID_PROVINCIAS");
            entity.Property(e => e.IdSitioTrabajo).HasColumnName("ID_SITIO_TRABAJO");
            entity.Property(e => e.NroParametro).HasColumnName("NRO_PARAMETRO");
            entity.Property(e => e.Razon).HasColumnName("RAZON");
        });

        modelBuilder.Entity<ComprobanteReingresoBodega>(entity =>
        {
            entity.HasKey(e => e.IdComprobante);

            entity.ToTable("COMPROBANTE_REINGRESO_BODEGA");

            entity.Property(e => e.IdComprobante)
                .HasMaxLength(8)
                .HasColumnName("ID_COMPROBANTE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaComprobante)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_COMPROBANTE");
            entity.Property(e => e.IdActividad).HasColumnName("ID_ACTIVIDAD");
            entity.Property(e => e.IdBodega).HasColumnName("ID_BODEGA");
            entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdConcepto).HasColumnName("ID_CONCEPTO");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdParametroDocumento).HasColumnName("ID_PARAMETRO_DOCUMENTO");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProvincias).HasColumnName("ID_PROVINCIAS");
            entity.Property(e => e.IdSitioTrabajo).HasColumnName("ID_SITIO_TRABAJO");
            entity.Property(e => e.NroParametro).HasColumnName("NRO_PARAMETRO");
            entity.Property(e => e.Razon).HasColumnName("RAZON");
        });

        modelBuilder.Entity<ComprobanteRetencionCompra>(entity =>
        {
            entity.HasKey(e => e.IdComprobanteRetencionCompra);

            entity.ToTable("COMPROBANTE_RETENCION_COMPRA");

            entity.Property(e => e.IdComprobanteRetencionCompra)
                .ValueGeneratedNever()
                .HasColumnName("ID_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.EstadoComprobanteRetencionCompra).HasColumnName("ESTADO_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.FechaAutoSriComprobanteRetencionCompa)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_AUTO_SRI_COMPROBANTE_RETENCION_COMPA");
            entity.Property(e => e.FechaEmisionComprobanteRetencionCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.IdComprobanteCompra).HasColumnName("ID_COMPROBANTE_COMPRA");
            entity.Property(e => e.IdProveedorGeneral).HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.NumAutoSriComprobanteRetencionCompra)
                .HasMaxLength(50)
                .HasColumnName("NUM_AUTO_SRI_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.NumCompVentaComprobanteRetencionCompra)
                .HasMaxLength(50)
                .HasColumnName("NUM_COMP_VENTA_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.NumeroComprobanteRetencionCompra).HasColumnName("NUMERO_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.TipoCompVentaComprobanteRetencionCompra).HasColumnName("TIPO_COMP_VENTA_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.TotalComprobanteRetencionCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_COMPROBANTE_RETENCION_COMPRA");
        });

        modelBuilder.Entity<ComprobanteRetencionVentum>(entity =>
        {
            entity.HasKey(e => e.IdComprobanteRetencionVenta);

            entity.ToTable("COMPROBANTE_RETENCION_VENTA");

            entity.Property(e => e.IdComprobanteRetencionVenta)
                .ValueGeneratedNever()
                .HasColumnName("ID_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.EstadoComprobanteRetencionVenta).HasColumnName("ESTADO_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.FechaEmisionComprobanteRetencionVenta)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.IdClienteGeneral).HasColumnName("ID_CLIENTE_GENERAL");
            entity.Property(e => e.IdFacturaVenta).HasColumnName("ID_FACTURA_VENTA");
            entity.Property(e => e.NumAutoSriComprobanteRetencionVenta)
                .HasMaxLength(50)
                .HasColumnName("NUM_AUTO_SRI_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.NumCompVentaComprobanteRetencionVenta)
                .HasMaxLength(50)
                .HasColumnName("NUM_COMP_VENTA_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.NumeroComprobanteRetencionVenta)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.TipoCompVentaComprobanteRetencionVenta)
                .HasMaxLength(50)
                .HasColumnName("TIPO_COMP_VENTA_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.TotalComprobanteRetencionVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_COMPROBANTE_RETENCION_VENTA");
        });

        modelBuilder.Entity<ComprobantesCompra>(entity =>
        {
            entity.HasKey(e => e.IdComprobanteCompra);

            entity.ToTable("COMPROBANTES_COMPRA");

            entity.Property(e => e.IdComprobanteCompra)
                .ValueGeneratedNever()
                .HasColumnName("ID_COMPROBANTE_COMPRA");
            entity.Property(e => e.DescuentoComprobanteCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DESCUENTO_COMPROBANTE_COMPRA");
            entity.Property(e => e.DocModComprobanteCompra)
                .HasMaxLength(50)
                .HasColumnName("DOC_MOD_COMPROBANTE_COMPRA");
            entity.Property(e => e.EstadoComprobanteCompra).HasColumnName("ESTADO_COMPROBANTE_COMPRA");
            entity.Property(e => e.FechaAutoSriComprobanteCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_AUTO_SRI_COMPROBANTE_COMPRA");
            entity.Property(e => e.FechaEmisionComprobanteCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION_COMPROBANTE_COMPRA");
            entity.Property(e => e.GuiaRemisionComprobanteCompra)
                .HasMaxLength(50)
                .HasColumnName("GUIA_REMISION_COMPROBANTE_COMPRA");
            entity.Property(e => e.IdProveedorGeneral).HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.Iva5ComprobanteCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IVA5_COMPROBANTE_COMPRA");
            entity.Property(e => e.IvaComprobanteCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IVA_COMPROBANTE_COMPRA");
            entity.Property(e => e.NumAutoSriComprobanteCompra)
                .HasMaxLength(50)
                .HasColumnName("NUM_AUTO_SRI_COMPROBANTE_COMPRA");
            entity.Property(e => e.NumeroComprobanteCompra)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_COMPROBANTE_COMPRA");
            entity.Property(e => e.ObservacionComprobanteCompra).HasColumnName("OBSERVACION_COMPROBANTE_COMPRA");
            entity.Property(e => e.PorcentajeIvaComprobanteCompra).HasColumnName("PORCENTAJE_IVA_COMPROBANTE_COMPRA");
            entity.Property(e => e.RazModComprobanteCompra).HasColumnName("RAZ_MOD_COMPROBANTE_COMPRA");
            entity.Property(e => e.Subtotal0ComprobanteCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUBTOTAL_0_COMPROBANTE_COMPRA");
            entity.Property(e => e.Subtotal12ComprobanteCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUBTOTAL_12_COMPROBANTE_COMPRA");
            entity.Property(e => e.Subtotal5ComprobanteCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUBTOTAL_5_COMPROBANTE_COMPRA");
            entity.Property(e => e.SubtotalComprobanteCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUBTOTAL_COMPROBANTE_COMPRA");
            entity.Property(e => e.TipoComprobanteCompra).HasColumnName("TIPO_COMPROBANTE_COMPRA");
            entity.Property(e => e.TotalComprobanteCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_COMPROBANTE_COMPRA");
        });

        modelBuilder.Entity<ConceptoPago>(entity =>
        {
            entity.HasKey(e => e.IdConceptoPago).HasName("PK_CONCPETO_PAGO");

            entity.ToTable("CONCEPTO_PAGO");

            entity.Property(e => e.IdConceptoPago)
                .ValueGeneratedNever()
                .HasColumnName("ID_CONCEPTO_PAGO");
            entity.Property(e => e.CodigoConceptoPago)
                .HasMaxLength(10)
                .HasColumnName("CODIGO_CONCEPTO_PAGO");
            entity.Property(e => e.DescripcionConceptoPago).HasColumnName("DESCRIPCION_CONCEPTO_PAGO");
            entity.Property(e => e.EjercicioFiscalConceptoPago).HasColumnName("EJERCICIO_FISCAL_CONCEPTO_PAGO");
            entity.Property(e => e.EstadoConceptoPago).HasColumnName("ESTADO_CONCEPTO_PAGO");
        });

        modelBuilder.Entity<ConceptosComprobanteEgresoBanco>(entity =>
        {
            entity.HasKey(e => e.IdConceptoComprobanteEgresoBancos);

            entity.ToTable("CONCEPTOS_COMPROBANTE_EGRESO_BANCOS");

            entity.Property(e => e.IdConceptoComprobanteEgresoBancos)
                .ValueGeneratedNever()
                .HasColumnName("ID_CONCEPTO_COMPROBANTE_EGRESO_BANCOS");
            entity.Property(e => e.CuentaConceptoComprobanteEgresoBancos)
                .HasMaxLength(50)
                .HasColumnName("CUENTA_CONCEPTO_COMPROBANTE_EGRESO_BANCOS");
            entity.Property(e => e.EstadoConceptoComprobanteEgresoBancos).HasColumnName("ESTADO_CONCEPTO_COMPROBANTE_EGRESO_BANCOS");
            entity.Property(e => e.IdPlan).HasColumnName("ID_PLAN");
            entity.Property(e => e.NombreConceptoComprobanteEgresoBancos).HasColumnName("NOMBRE_CONCEPTO_COMPROBANTE_EGRESO_BANCOS");
        });

        modelBuilder.Entity<ConceptosComprobanteIngresoBanco>(entity =>
        {
            entity.HasKey(e => e.IdConceptoComprobanteIngresoBancos);

            entity.ToTable("CONCEPTOS_COMPROBANTE_INGRESO_BANCOS");

            entity.Property(e => e.IdConceptoComprobanteIngresoBancos)
                .ValueGeneratedNever()
                .HasColumnName("ID_CONCEPTO_COMPROBANTE_INGRESO_BANCOS");
            entity.Property(e => e.CuentaConceptoComprobanteIngresoBancos)
                .HasMaxLength(50)
                .HasColumnName("CUENTA_CONCEPTO_COMPROBANTE_INGRESO_BANCOS");
            entity.Property(e => e.EstadoConceptoComprobanteIngresoBancos).HasColumnName("ESTADO_CONCEPTO_COMPROBANTE_INGRESO_BANCOS");
            entity.Property(e => e.IdPlan).HasColumnName("ID_PLAN");
            entity.Property(e => e.NombreConceptoComprobanteIngresoBancos).HasColumnName("NOMBRE_CONCEPTO_COMPROBANTE_INGRESO_BANCOS");
        });

        modelBuilder.Entity<ConceptosComprobantesCompra>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CONCEPTOS_COMPROBANTES_COMPRA");

            entity.Property(e => e.CuentaConceptoComprobanteCompra)
                .HasMaxLength(50)
                .HasColumnName("CUENTA_CONCEPTO_COMPROBANTE_COMPRA");
            entity.Property(e => e.EstadoConceptoComprobanteCompra).HasColumnName("ESTADO_CONCEPTO_COMPROBANTE_COMPRA");
            entity.Property(e => e.IdConceptoComprobanteCompra).HasColumnName("ID_CONCEPTO_COMPROBANTE_COMPRA");
            entity.Property(e => e.IdPlan).HasColumnName("ID_PLAN");
            entity.Property(e => e.NombreConceptoComprobanteCompra).HasColumnName("NOMBRE_CONCEPTO_COMPROBANTE_COMPRA");
        });

        modelBuilder.Entity<ConceptosFacturaVentum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CONCEPTOS_FACTURA_VENTA");

            entity.Property(e => e.CuentaConceptoFacturaVenta)
                .HasMaxLength(50)
                .HasColumnName("CUENTA_CONCEPTO_FACTURA_VENTA");
            entity.Property(e => e.EstadoConceptoFacturaVenta).HasColumnName("ESTADO_CONCEPTO_FACTURA_VENTA");
            entity.Property(e => e.IdConceptoFacturaVenta).HasColumnName("ID_CONCEPTO_FACTURA_VENTA");
            entity.Property(e => e.IdPlan).HasColumnName("ID_PLAN");
            entity.Property(e => e.NombreConceptoFacturaVenta).HasColumnName("NOMBRE_CONCEPTO_FACTURA_VENTA");
        });

        modelBuilder.Entity<ConceptosInventario>(entity =>
        {
            entity.HasKey(e => e.IdConcepto);

            entity.ToTable("CONCEPTOS_INVENTARIOS");

            entity.Property(e => e.IdConcepto)
                .ValueGeneratedNever()
                .HasColumnName("ID_CONCEPTO");
            entity.Property(e => e.CodigoConcepto).HasColumnName("CODIGO_CONCEPTO");
            entity.Property(e => e.EstadoConcepto).HasColumnName("ESTADO_CONCEPTO");
            entity.Property(e => e.IdActividad).HasColumnName("ID_ACTIVIDAD");
            entity.Property(e => e.IdDetalle).HasColumnName("ID_DETALLE");

            entity.HasOne(d => d.IdActividadNavigation).WithMany(p => p.ConceptosInventarios)
                .HasForeignKey(d => d.IdActividad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CONCEPTOS_INVENTARIOS_ACTIVIDAD_INVENTARIOS1");

            entity.HasOne(d => d.IdDetalleNavigation).WithMany(p => p.ConceptosInventarios)
                .HasForeignKey(d => d.IdDetalle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CONCEPTOS_INVENTARIOS_DETALLE_CONCEPTO_INVENTARIOS");
        });

        modelBuilder.Entity<ContactosProveedorCalificado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CONTACTOS_PROVEEDOR_CALIFICADO");

            entity.Property(e => e.ApellidosContactoProveedorCalificado).HasColumnName("APELLIDOS_CONTACTO_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.CargoContactoProveedorCalificado).HasColumnName("CARGO_CONTACTO_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.CelularContactoProveedorCalificado)
                .HasMaxLength(50)
                .HasColumnName("CELULAR_CONTACTO_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.EmailContactoProveedorCalificado).HasColumnName("EMAIL_CONTACTO_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.EstadoContactoProveedorCalificado).HasColumnName("ESTADO_CONTACTO_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.IdContactoProveedorCalificado).HasColumnName("ID_CONTACTO_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.IdProveedorGeneral).HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.NombresContactoProveedorCalificado).HasColumnName("NOMBRES_CONTACTO_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.TelefonoContactoProveedorCalificado)
                .HasMaxLength(50)
                .HasColumnName("TELEFONO_CONTACTO_PROVEEDOR_CALIFICADO");
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.IdContrato);

            entity.ToTable("CONTRATO");

            entity.Property(e => e.IdContrato).HasColumnName("ID_CONTRATO");
            entity.Property(e => e.AcumFonRes).HasColumnName("ACUM_FON_RES");
            entity.Property(e => e.CobraQuince)
                .HasDefaultValue(0)
                .HasColumnName("COBRA_QUINCE");
            entity.Property(e => e.DescSeg).HasColumnName("DESC_SEG");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoContrato).HasColumnName("ESTADO_CONTRATO");
            entity.Property(e => e.Extsal)
                .HasDefaultValue(0)
                .HasColumnName("EXTSAL");
            entity.Property(e => e.FechaAfiliacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_AFILIACION");
            entity.Property(e => e.FechaInicialContrato)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIAL_CONTRATO");
            entity.Property(e => e.FechaVencimientoContrato)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_VENCIMIENTO_CONTRATO");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProyecto).HasColumnName("ID_PROYECTO");
            entity.Property(e => e.Iess).HasColumnName("IESS");
            entity.Property(e => e.NroContrato).HasColumnName("NRO_CONTRATO");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.PeriodoContrato).HasColumnName("PERIODO_CONTRATO");
            entity.Property(e => e.RecExt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("REC_EXT");
            entity.Property(e => e.ReservaRol).HasColumnName("RESERVA_ROL");
            entity.Property(e => e.TipoContrato).HasColumnName("TIPO_CONTRATO");
            entity.Property(e => e.XiiiRol).HasColumnName("XIII_ROL");
            entity.Property(e => e.XivRol).HasColumnName("XIV_ROL");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdPersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CONTRATO_PERSONAL");
        });

        modelBuilder.Entity<ContratoCliente>(entity =>
        {
            entity.HasKey(e => e.IdContrato).HasName("PK__CONTRATO_CLIENTE__131476F9");

            entity.ToTable("CONTRATO_CLIENTE");

            entity.Property(e => e.IdContrato)
                .ValueGeneratedNever()
                .HasColumnName("ID_CONTRATO");
            entity.Property(e => e.Anio).HasColumnName("ANIO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdClienteGeneral).HasColumnName("ID_CLIENTE_GENERAL");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR");

            entity.HasOne(d => d.IdClienteGeneralNavigation).WithMany(p => p.ContratoClientes)
                .HasForeignKey(d => d.IdClienteGeneral)
                .HasConstraintName("FKCCLI");
        });

        modelBuilder.Entity<ContratoProyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("PK__CONTRATO__6D661D313198FE19");

            entity.ToTable("CONTRATO_PROYECTO");

            entity.Property(e => e.IdProyecto)
                .ValueGeneratedNever()
                .HasColumnName("ID_PROYECTO");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_FIN");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO");
            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.NombreProyecto).HasColumnName("NOMBRE_PROYECTO");
        });

        modelBuilder.Entity<ContribuyenteRetenido>(entity =>
        {
            entity.HasKey(e => e.IdContribuyenteRetenido);

            entity.ToTable("CONTRIBUYENTE_RETENIDO");

            entity.Property(e => e.IdContribuyenteRetenido)
                .ValueGeneratedNever()
                .HasColumnName("ID_CONTRIBUYENTE_RETENIDO");
            entity.Property(e => e.EstadoContribuyenteRetenido).HasColumnName("ESTADO_CONTRIBUYENTE_RETENIDO");
            entity.Property(e => e.TipoContribuyenteRetenido).HasColumnName("TIPO_CONTRIBUYENTE_RETENIDO");
        });

        modelBuilder.Entity<ControlCombustible>(entity =>
        {
            entity.HasKey(e => e.IdControlC);

            entity.ToTable("CONTROL_COMBUSTIBLES");

            entity.Property(e => e.IdControlC)
                .ValueGeneratedNever()
                .HasColumnName("ID_CONTROL_C");
            entity.Property(e => e.DestinoControlC).HasColumnName("DESTINO_CONTROL_C");
            entity.Property(e => e.EstadoControlC).HasColumnName("ESTADO_CONTROL_C");
            entity.Property(e => e.FechaControlC)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CONTROL_C");
            entity.Property(e => e.IdAcivoFijo).HasColumnName("ID_ACIVO_FIJO");
            entity.Property(e => e.IdGastosCch).HasColumnName("ID_GASTOS_CCH");
            entity.Property(e => e.IdGastosFr).HasColumnName("ID_GASTOS_FR");
            entity.Property(e => e.IdLlegadaV).HasColumnName("ID_LLEGADA_V");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdResponsableAutoCch).HasColumnName("ID_RESPONSABLE_AUTO_CCH");
            entity.Property(e => e.IdResponsableAutoFr).HasColumnName("ID_RESPONSABLE_AUTO_FR");
            entity.Property(e => e.IdRubro).HasColumnName("ID_RUBRO");
            entity.Property(e => e.IdSalidaV).HasColumnName("ID_SALIDA_V");
            entity.Property(e => e.IdSolicitudCch).HasColumnName("ID_SOLICITUD_CCH");
            entity.Property(e => e.IdSolicitudFr).HasColumnName("ID_SOLICITUD_FR");
            entity.Property(e => e.MotivoControlC).HasColumnName("MOTIVO_CONTROL_C");
            entity.Property(e => e.TotalKmControlC).HasColumnName("TOTAL_KM_CONTROL_C");
            entity.Property(e => e.ValorControlC)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_CONTROL_C");

            entity.HasOne(d => d.IdLlegadaVNavigation).WithMany(p => p.ControlCombustibles)
                .HasForeignKey(d => d.IdLlegadaV)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CONTROL_COMBUSTIBLES_LLEGADA_VEHICULO");

            entity.HasOne(d => d.IdSalidaVNavigation).WithMany(p => p.ControlCombustibles)
                .HasForeignKey(d => d.IdSalidaV)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CONTROL_COMBUSTIBLES_SALIDA_VEHICULO");
        });

        modelBuilder.Entity<ControlUniforme>(entity =>
        {
            entity.HasKey(e => e.IdControl);

            entity.ToTable("CONTROL_UNIFORMES");

            entity.Property(e => e.IdControl)
                .ValueGeneratedNever()
                .HasColumnName("ID_CONTROL");
            entity.Property(e => e.CantidadArticulos).HasColumnName("CANTIDAD_ARTICULOS");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdActividad).HasColumnName("ID_ACTIVIDAD");
            entity.Property(e => e.IdComprobante)
                .HasMaxLength(8)
                .HasColumnName("ID_COMPROBANTE");
            entity.Property(e => e.IdDetalleKardex).HasColumnName("ID_DETALLE_KARDEX");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
        });

        modelBuilder.Entity<ConvenioClienteBancoDebito>(entity =>
        {
            entity.HasKey(e => e.IdConvenio);

            entity.ToTable("CONVENIO_CLIENTE_BANCO_DEBITO");

            entity.Property(e => e.IdConvenio)
                .ValueGeneratedNever()
                .HasColumnName("ID_CONVENIO");
            entity.Property(e => e.BancoConvenio).HasColumnName("BANCO_CONVENIO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.IdClienteGeneral).HasColumnName("ID_CLIENTE_GENERAL");
            entity.Property(e => e.NumCiRuc)
                .HasMaxLength(13)
                .HasColumnName("NUM_CI_RUC");
            entity.Property(e => e.NumCuentaTarj)
                .HasMaxLength(25)
                .HasColumnName("NUM_CUENTA_TARJ");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.TipoCuenta)
                .HasMaxLength(25)
                .HasColumnName("TIPO_CUENTA");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(20)
                .HasColumnName("TIPO_DOC");
            entity.Property(e => e.TitularCuenta).HasColumnName("TITULAR_CUENTA");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR");
        });

        modelBuilder.Entity<CortesContable>(entity =>
        {
            entity.HasKey(e => e.IdCorte);

            entity.ToTable("CORTES_CONTABLES");

            entity.Property(e => e.IdCorte)
                .ValueGeneratedNever()
                .HasColumnName("ID_CORTE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.FechaFinCorte)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_FIN_CORTE");
            entity.Property(e => e.FechaInicioCorte)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO_CORTE");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
        });

        modelBuilder.Entity<CuentasBanco>(entity =>
        {
            entity.HasKey(e => e.IdCuentaBancos);

            entity.ToTable("CUENTAS_BANCOS");

            entity.Property(e => e.IdCuentaBancos)
                .ValueGeneratedNever()
                .HasColumnName("ID_CUENTA_BANCOS");
            entity.Property(e => e.CodigoPlanCuentas)
                .HasMaxLength(50)
                .HasColumnName("CODIGO_PLAN_CUENTAS");
            entity.Property(e => e.EstadoCuentaBancos).HasColumnName("ESTADO_CUENTA_BANCOS");
            entity.Property(e => e.IdBanco).HasColumnName("ID_BANCO");
            entity.Property(e => e.MontoCuentaBancos)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MONTO_CUENTA_BANCOS");
            entity.Property(e => e.NumeroCuentaBancos)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_CUENTA_BANCOS");
            entity.Property(e => e.TipoCuentaBancos)
                .HasMaxLength(50)
                .HasColumnName("TIPO_CUENTA_BANCOS");

            entity.HasOne(d => d.IdBancoNavigation).WithMany(p => p.CuentasBancos)
                .HasForeignKey(d => d.IdBanco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CUENTAS_BANCOS_BANCOS");
        });

        modelBuilder.Entity<CuentasPersonal>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CUENTAS_PERSONAL");

            entity.Property(e => e.IdBanco).HasColumnName("ID_BANCO");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.NumCuenta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NUM_CUENTA");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("TIPO");
        });

        modelBuilder.Entity<DepreciacionesGeneral>(entity =>
        {
            entity.HasKey(e => e.IdDepreciacion);

            entity.ToTable("DEPRECIACIONES_GENERAL");

            entity.Property(e => e.IdDepreciacion)
                .ValueGeneratedNever()
                .HasColumnName("ID_DEPRECIACION");
            entity.Property(e => e.CuentaContable).HasColumnName("CUENTA_CONTABLE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Porcentaje)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PORCENTAJE");
            entity.Property(e => e.TopeDepreciaciones).HasColumnName("TOPE_DEPRECIACIONES");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany(p => p.DepreciacionesGenerals)
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DEPRECIACIONES_GENERAL_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<DescuentosRol>(entity =>
        {
            entity.HasKey(e => e.IdRegistro).HasName("PK__DESCUENTOS_ROL__401C279A");

            entity.ToTable("DESCUENTOS_ROL");

            entity.Property(e => e.IdRegistro)
                .ValueGeneratedNever()
                .HasColumnName("id_registro");
            entity.Property(e => e.AnioRol).HasColumnName("anio_rol");
            entity.Property(e => e.Anual)
                .IsUnicode(false)
                .HasColumnName("anual");
            entity.Property(e => e.Estado)
                .HasDefaultValue(1)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdPersonal).HasColumnName("id_personal");
            entity.Property(e => e.IdProg).HasColumnName("id_prog");
            entity.Property(e => e.IdRol)
                .HasDefaultValue(0)
                .HasColumnName("id_rol");
            entity.Property(e => e.MesRol).HasColumnName("mes_rol");
            entity.Property(e => e.Observacion)
                .IsUnicode(false)
                .HasColumnName("observacion");
            entity.Property(e => e.Procesado).HasColumnName("procesado");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
            entity.Property(e => e.Tipox)
                .IsUnicode(false)
                .HasColumnName("tipox");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("valor");
        });

        modelBuilder.Entity<DetalleBalanceComprobación>(entity =>
        {
            entity.HasKey(e => e.IdDetalle);

            entity.ToTable("DETALLE_BALANCE_COMPROBACIÓN");

            entity.Property(e => e.IdDetalle)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE");
            entity.Property(e => e.Acreedor)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("ACREEDOR");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.Debe)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("DEBE");
            entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            entity.Property(e => e.Deudor)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("DEUDOR");
            entity.Property(e => e.DeudorAcreedor).HasColumnName("DEUDOR_ACREEDOR");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.Haber)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("HABER");
            entity.Property(e => e.IdBalance).HasColumnName("ID_BALANCE");
            entity.Property(e => e.Referencia).HasColumnName("REFERENCIA");

            entity.HasOne(d => d.IdBalanceNavigation).WithMany(p => p.DetalleBalanceComprobacións)
                .HasForeignKey(d => d.IdBalance)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_BALANCE_COMPROBACIÓN_BALANCE_COMPROBACION");
        });

        modelBuilder.Entity<DetalleComprobanteAjusteBodega>(entity =>
        {
            entity.HasKey(e => e.IdDetalleComprobante).HasName("PK_DETALLE_COMPROBANTE_AJUSTE");

            entity.ToTable("DETALLE_COMPROBANTE_AJUSTE_BODEGA");

            entity.Property(e => e.IdDetalleComprobante)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_COMPROBANTE");
            entity.Property(e => e.EstadoDetalle).HasColumnName("ESTADO_DETALLE");
            entity.Property(e => e.IdComprobante)
                .HasMaxLength(8)
                .HasColumnName("ID_COMPROBANTE");
            entity.Property(e => e.IdDetalleKardex).HasColumnName("ID_DETALLE_KARDEX");
            entity.Property(e => e.IdKardex).HasColumnName("ID_KARDEX");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.ObservacionDetalle).HasColumnName("OBSERVACION_DETALLE");

            entity.HasOne(d => d.IdComprobanteNavigation).WithMany(p => p.DetalleComprobanteAjusteBodegas)
                .HasForeignKey(d => d.IdComprobante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_COMPROBANTE_AJUSTE_BODEGA_COMPROBANTE_AJUSTE_BODEGA");
        });

        modelBuilder.Entity<DetalleComprobanteDonacionBodega>(entity =>
        {
            entity.HasKey(e => e.IdDetalleComprobante).HasName("PK_DETALLE_COMPROBANTE_DONACION");

            entity.ToTable("DETALLE_COMPROBANTE_DONACION_BODEGA");

            entity.Property(e => e.IdDetalleComprobante)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_COMPROBANTE");
            entity.Property(e => e.EstadoDetalle).HasColumnName("ESTADO_DETALLE");
            entity.Property(e => e.IdComprobante)
                .HasMaxLength(8)
                .HasColumnName("ID_COMPROBANTE");
            entity.Property(e => e.IdDetalleKardex).HasColumnName("ID_DETALLE_KARDEX");
            entity.Property(e => e.IdKardex).HasColumnName("ID_KARDEX");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.ObservacionDetalle).HasColumnName("OBSERVACION_DETALLE");

            entity.HasOne(d => d.IdComprobanteNavigation).WithMany(p => p.DetalleComprobanteDonacionBodegas)
                .HasForeignKey(d => d.IdComprobante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_COMPROBANTE_DONACION_BODEGA_COMPROBANTE_DONACION_BODEGA");
        });

        modelBuilder.Entity<DetalleComprobanteEgresoBodega>(entity =>
        {
            entity.HasKey(e => e.IdDetalleComprobante);

            entity.ToTable("DETALLE_COMPROBANTE_EGRESO_BODEGA");

            entity.Property(e => e.IdDetalleComprobante)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_COMPROBANTE");
            entity.Property(e => e.EstadoDetalle).HasColumnName("ESTADO_DETALLE");
            entity.Property(e => e.IdComprobante)
                .HasMaxLength(8)
                .HasColumnName("ID_COMPROBANTE");
            entity.Property(e => e.IdDetalleKardex).HasColumnName("ID_DETALLE_KARDEX");
            entity.Property(e => e.IdKardex).HasColumnName("ID_KARDEX");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.ObservacionDetalle).HasColumnName("OBSERVACION_DETALLE");

            entity.HasOne(d => d.IdComprobanteNavigation).WithMany(p => p.DetalleComprobanteEgresoBodegas)
                .HasForeignKey(d => d.IdComprobante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_COMPROBANTE_EGRESO_BODEGA_COMPROBANTE_EGRESO_BODEGA");
        });

        modelBuilder.Entity<DetalleComprobanteIngresoBodega>(entity =>
        {
            entity.HasKey(e => e.IdDetalleComprobante);

            entity.ToTable("DETALLE_COMPROBANTE_INGRESO_BODEGA");

            entity.Property(e => e.IdDetalleComprobante)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_COMPROBANTE");
            entity.Property(e => e.EstadoDetalle).HasColumnName("ESTADO_DETALLE");
            entity.Property(e => e.IdComprobante)
                .HasMaxLength(8)
                .HasColumnName("ID_COMPROBANTE");
            entity.Property(e => e.IdDetalleKardex).HasColumnName("ID_DETALLE_KARDEX");
            entity.Property(e => e.IdKardex).HasColumnName("ID_KARDEX");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.ObservacionDetalle).HasColumnName("OBSERVACION_DETALLE");

            entity.HasOne(d => d.IdComprobanteNavigation).WithMany(p => p.DetalleComprobanteIngresoBodegas)
                .HasForeignKey(d => d.IdComprobante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_COMPROBANTE_INGRESO_BODEGA_COMPROBANTE_INGRESO_BODEGA");
        });

        modelBuilder.Entity<DetalleComprobanteReingresoBodega>(entity =>
        {
            entity.HasKey(e => e.IdDetalleComprobante);

            entity.ToTable("DETALLE_COMPROBANTE_REINGRESO_BODEGA");

            entity.Property(e => e.IdDetalleComprobante)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_COMPROBANTE");
            entity.Property(e => e.EstadoDetalle).HasColumnName("ESTADO_DETALLE");
            entity.Property(e => e.IdComprobante)
                .HasMaxLength(8)
                .HasColumnName("ID_COMPROBANTE");
            entity.Property(e => e.IdDetalleKardex).HasColumnName("ID_DETALLE_KARDEX");
            entity.Property(e => e.IdKardex).HasColumnName("ID_KARDEX");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.ObservacionDetalle).HasColumnName("OBSERVACION_DETALLE");

            entity.HasOne(d => d.IdComprobanteNavigation).WithMany(p => p.DetalleComprobanteReingresoBodegas)
                .HasForeignKey(d => d.IdComprobante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_COMPROBANTE_REINGRESO_BODEGA_COMPROBANTE_REINGRESO_BODEGA");
        });

        modelBuilder.Entity<DetalleComprobanteRetencionCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleComprobanteRetencionCompra);

            entity.ToTable("DETALLE_COMPROBANTE_RETENCION_COMPRA");

            entity.Property(e => e.IdDetalleComprobanteRetencionCompra)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.BaseImponibleDetalleComprobanteRetencionCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("BASE_IMPONIBLE_DETALLE_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.CodigoDetalleComprobanteRetencionCompra)
                .HasMaxLength(50)
                .HasColumnName("CODIGO_DETALLE_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.EjFiscalDetalleComprobanteRetencionCompra).HasColumnName("EJ_FISCAL_DETALLE_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.EstadoDetalleComprobanteRetencionCompra).HasColumnName("ESTADO_DETALLE_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.IdComprobanteCompra).HasColumnName("ID_COMPROBANTE_COMPRA");
            entity.Property(e => e.IdComprobanteRetencionCompra).HasColumnName("ID_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.ImpuestoDetalleComprobanteRetencionCompra)
                .HasMaxLength(50)
                .HasColumnName("IMPUESTO_DETALLE_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.PorcentajeDetalleComprobanteRetencionCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PORCENTAJE_DETALLE_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.ValorDetalleComprobanteRetencionCompra)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("VALOR_DETALLE_COMPROBANTE_RETENCION_COMPRA");

            entity.HasOne(d => d.IdComprobanteRetencionCompraNavigation).WithMany(p => p.DetalleComprobanteRetencionCompras)
                .HasForeignKey(d => d.IdComprobanteRetencionCompra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_COMPROBANTE_RETENCION_COMPRA_COMPROBANTE_RETENCION_COMPRA");
        });

        modelBuilder.Entity<DetalleComprobanteRetencionVentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleComprobanteRetencionVenta);

            entity.ToTable("DETALLE_COMPROBANTE_RETENCION_VENTA");

            entity.Property(e => e.IdDetalleComprobanteRetencionVenta)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.BaseImponibleDetalleComprobanteRetencionVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("BASE_IMPONIBLE_DETALLE_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.CodigoDetalleComprobanteRetencionVenta)
                .HasMaxLength(50)
                .HasColumnName("CODIGO_DETALLE_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.EjFiscalDetalleComprobanteRetencionVenta).HasColumnName("EJ_FISCAL_DETALLE_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.EstadoDetalleComprobanteRetencionVenta).HasColumnName("ESTADO_DETALLE_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.IdComprobanteRetencionVenta).HasColumnName("ID_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.IdFacturaVenta).HasColumnName("ID_FACTURA_VENTA");
            entity.Property(e => e.ImpuestoDetalleComprobanteRetencionVenta)
                .HasMaxLength(50)
                .HasColumnName("IMPUESTO_DETALLE_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.PorcentajeDetalleComprobanteRetencionVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PORCENTAJE_DETALLE_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.ValorDetalleComprobanteRetencionVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_DETALLE_COMPROBANTE_RETENCION_VENTA");

            entity.HasOne(d => d.IdComprobanteRetencionVentaNavigation).WithMany(p => p.DetalleComprobanteRetencionVenta)
                .HasForeignKey(d => d.IdComprobanteRetencionVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_COMPROBANTE_RETENCION_VENTA_COMPROBANTE_RETENCION_VENTA");
        });

        modelBuilder.Entity<DetalleConceptoInventario>(entity =>
        {
            entity.HasKey(e => e.IdDetalle);

            entity.ToTable("DETALLE_CONCEPTO_INVENTARIOS");

            entity.Property(e => e.IdDetalle)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE");
            entity.Property(e => e.Detalle).HasColumnName("DETALLE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
        });

        modelBuilder.Entity<DetalleDepreciacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DETALLE_DEPRECIACION");

            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdDepreciacion).HasColumnName("ID_DEPRECIACION");
            entity.Property(e => e.IdDepreciacionGeneral).HasColumnName("ID_DEPRECIACION_GENERAL");
            entity.Property(e => e.NumDepreciacion).HasColumnName("NUM_DEPRECIACION");
            entity.Property(e => e.ValorDepreciacion)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_DEPRECIACION");
            entity.Property(e => e.ValorResidualDepreciacion)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_RESIDUAL_DEPRECIACION");
        });

        modelBuilder.Entity<DetalleEgresoSuministro>(entity =>
        {
            entity.HasKey(e => e.IdDetalleEgresoSuministros);

            entity.ToTable("DETALLE_EGRESO_SUMINISTROS");

            entity.Property(e => e.IdDetalleEgresoSuministros)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_EGRESO_SUMINISTROS");
            entity.Property(e => e.CantidadDetalleEgresoSuministros).HasColumnName("CANTIDAD_DETALLE_EGRESO_SUMINISTROS");
            entity.Property(e => e.EstadoDetalleEgresoSuministros).HasColumnName("ESTADO_DETALLE_EGRESO_SUMINISTROS");
            entity.Property(e => e.IdEgresoSuministros).HasColumnName("ID_EGRESO_SUMINISTROS");
            entity.Property(e => e.IdSecuencialSuministros).HasColumnName("ID_SECUENCIAL_SUMINISTROS");
            entity.Property(e => e.IdUnidadMedida).HasColumnName("ID_UNIDAD_MEDIDA");

            entity.HasOne(d => d.IdEgresoSuministrosNavigation).WithMany(p => p.DetalleEgresoSuministros)
                .HasForeignKey(d => d.IdEgresoSuministros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_EGRESO_SUMINISTROS_EGRESO_SUMINISTROS");
        });

        modelBuilder.Entity<DetalleEpp>(entity =>
        {
            entity.HasKey(e => e.IdDetalleEpp);

            entity.ToTable("DETALLE_EPP");

            entity.Property(e => e.IdDetalleEpp)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_EPP");
            entity.Property(e => e.CantidadDetalleEpp).HasColumnName("CANTIDAD_DETALLE_EPP");
            entity.Property(e => e.EstadoDetalleEpp).HasColumnName("ESTADO_DETALLE_EPP");
            entity.Property(e => e.FechaRenovacionDetalleEpp)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_RENOVACION_DETALLE_EPP");
            entity.Property(e => e.IdDetalleKardexDetalleEpp).HasColumnName("ID_DETALLE_KARDEX_DETALLE_EPP");
            entity.Property(e => e.IdEpp).HasColumnName("ID_EPP");
            entity.Property(e => e.IdKardexDetalleEpp).HasColumnName("ID_KARDEX_DETALLE_EPP");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.ObservacionDetalleEpp).HasColumnName("OBSERVACION_DETALLE_EPP");

            entity.HasOne(d => d.IdEppNavigation).WithMany(p => p.DetalleEpps)
                .HasForeignKey(d => d.IdEpp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_EPP_ENTREGA_EPP");
        });

        modelBuilder.Entity<DetalleFacturaVentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleFacturaVenta);

            entity.ToTable("DETALLE_FACTURA_VENTA");

            entity.Property(e => e.IdDetalleFacturaVenta)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_FACTURA_VENTA");
            entity.Property(e => e.CantidadDetalleFacturaVenta).HasColumnName("CANTIDAD_DETALLE_FACTURA_VENTA");
            entity.Property(e => e.EstadoDetalleFacturaVenta).HasColumnName("ESTADO_DETALLE_FACTURA_VENTA");
            entity.Property(e => e.IdFacturaVenta).HasColumnName("ID_FACTURA_VENTA");
            entity.Property(e => e.IdSecuencialItem).HasColumnName("ID_SECUENCIAL_ITEM");
            entity.Property(e => e.ValordDetalleFacturaVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALORD_DETALLE_FACTURA_VENTA");
            entity.Property(e => e.ValortDetalleFacturaVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALORT_DETALLE_FACTURA_VENTA");
            entity.Property(e => e.ValoruDetalleFacturaVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALORU_DETALLE_FACTURA_VENTA");

            entity.HasOne(d => d.IdFacturaVentaNavigation).WithMany(p => p.DetalleFacturaVenta)
                .HasForeignKey(d => d.IdFacturaVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_FACTURA_VENTA_FACTURA_VENTA");
        });

        modelBuilder.Entity<DetalleItemsPuesto>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DETALLE_ITEMS_PU__6932806F");

            entity.ToTable("DETALLE_ITEMS_PUESTO");

            entity.Property(e => e.IdDetalle)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdDetalleComprobante).HasColumnName("ID_DETALLE_COMPROBANTE");
            entity.Property(e => e.IdSitio).HasColumnName("ID_SITIO");
            entity.Property(e => e.Serie).HasColumnName("SERIE");
            entity.Property(e => e.Tipo).HasColumnName("TIPO");
        });

        modelBuilder.Entity<DetalleKardex>(entity =>
        {
            entity.HasKey(e => e.IdDetalle);

            entity.ToTable("DETALLE_KARDEX");

            entity.Property(e => e.IdDetalle)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE");
            entity.Property(e => e.CantidadEgreso).HasColumnName("CANTIDAD_EGRESO");
            entity.Property(e => e.CantidadIngreso).HasColumnName("CANTIDAD_INGRESO");
            entity.Property(e => e.CantidadSaldo).HasColumnName("CANTIDAD_SALDO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdActividad).HasColumnName("ID_ACTIVIDAD");
            entity.Property(e => e.IdComprobante)
                .HasMaxLength(8)
                .HasColumnName("ID_COMPROBANTE");
            entity.Property(e => e.IdConcepto).HasColumnName("ID_CONCEPTO");
            entity.Property(e => e.IdKardex).HasColumnName("ID_KARDEX");
            entity.Property(e => e.ValorTotalEgreso)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("VALOR_TOTAL_EGRESO");
            entity.Property(e => e.ValorTotalIngreso)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("VALOR_TOTAL_INGRESO");
            entity.Property(e => e.ValorTotalSaldo)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("VALOR_TOTAL_SALDO");
            entity.Property(e => e.ValorUnitarioEgreso)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("VALOR_UNITARIO_EGRESO");
            entity.Property(e => e.ValorUnitarioIngreso)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("VALOR_UNITARIO_INGRESO");
            entity.Property(e => e.ValorUnitarioSaldo)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("VALOR_UNITARIO_SALDO");

            entity.HasOne(d => d.IdKardexNavigation).WithMany(p => p.DetalleKardices)
                .HasForeignKey(d => d.IdKardex)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_KARDEX_KARDEX");
        });

        modelBuilder.Entity<DetalleLiquidacionCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleLiquidacionCompras);

            entity.ToTable("DETALLE_LIQUIDACION_COMPRAS");

            entity.Property(e => e.IdDetalleLiquidacionCompras)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_LIQUIDACION_COMPRAS");
            entity.Property(e => e.CantidadDetalleLiquidacionCompras).HasColumnName("CANTIDAD_DETALLE_LIQUIDACION_COMPRAS");
            entity.Property(e => e.EstadoDetalleLiquidacionCompras).HasColumnName("ESTADO_DETALLE_LIQUIDACION_COMPRAS");
            entity.Property(e => e.IdLiquidacionCompras).HasColumnName("ID_LIQUIDACION_COMPRAS");
            entity.Property(e => e.IdSecuencialItem).HasColumnName("ID_SECUENCIAL_ITEM");
            entity.Property(e => e.ValortDetalleLiquidacionCompras)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALORT_DETALLE_LIQUIDACION_COMPRAS");
            entity.Property(e => e.ValoruDetalleLiquidacionCompras)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALORU_DETALLE_LIQUIDACION_COMPRAS");

            entity.HasOne(d => d.IdLiquidacionComprasNavigation).WithMany(p => p.DetalleLiquidacionCompras)
                .HasForeignKey(d => d.IdLiquidacionCompras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_LIQUIDACION_COMPRAS_LIQUIDACION_COMPRAS");
        });

        modelBuilder.Entity<DetalleMantenimiento>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DETALLE_MANTENIMIENTOS");

            entity.Property(e => e.CodigoActivo).HasColumnName("CODIGO_ACTIVO");
            entity.Property(e => e.Cumplio).HasColumnName("CUMPLIO");
            entity.Property(e => e.DetalleMantenimiento1).HasColumnName("DETALLE_MANTENIMIENTO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.IdArea).HasColumnName("ID_AREA");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdGerencias).HasColumnName("ID_GERENCIAS");
            entity.Property(e => e.IdMantenimiento).HasColumnName("ID_MANTENIMIENTO");
            entity.Property(e => e.IdSucursal).HasColumnName("ID_SUCURSAL");
            entity.Property(e => e.NombreActivo).HasColumnName("NOMBRE_ACTIVO");
            entity.Property(e => e.NroFactura).HasColumnName("NRO_FACTURA");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR");

            entity.HasOne(d => d.IdMantenimientoNavigation).WithMany()
                .HasForeignKey(d => d.IdMantenimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_MANTENIMIENTOS_ACTIVO_FIJO_MANTENIMIENTOS");
        });

        modelBuilder.Entity<DetalleMayore>(entity =>
        {
            entity.HasKey(e => e.IdDetalle);

            entity.ToTable("DETALLE_MAYORES");

            entity.Property(e => e.IdDetalle)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE");
            entity.Property(e => e.Debe)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("DEBE");
            entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.Haber)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("HABER");
            entity.Property(e => e.IdAsiento).HasColumnName("ID_ASIENTO");
            entity.Property(e => e.IdCorte).HasColumnName("ID_CORTE");
            entity.Property(e => e.IdMayor).HasColumnName("ID_MAYOR");
            entity.Property(e => e.Referencia).HasColumnName("REFERENCIA");

            entity.HasOne(d => d.IdMayorNavigation).WithMany(p => p.DetalleMayores)
                .HasForeignKey(d => d.IdMayor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_MAYORES_MAYOR_GENERAL");
        });

        modelBuilder.Entity<DetalleOrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleOrdenCompra);

            entity.ToTable("DETALLE_ORDEN_COMPRA");

            entity.Property(e => e.IdDetalleOrdenCompra)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_ORDEN_COMPRA");
            entity.Property(e => e.CantidadDetalleOrdenCompra).HasColumnName("CANTIDAD_DETALLE_ORDEN_COMPRA");
            entity.Property(e => e.EstadoDetalleOrdenCompra)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ESTADO_DETALLE_ORDEN_COMPRA");
            entity.Property(e => e.IdOrdenCompra).HasColumnName("ID_ORDEN_COMPRA");
            entity.Property(e => e.IdSecuencialItem).HasColumnName("ID_SECUENCIAL_ITEM");
            entity.Property(e => e.UmedidaDetalleOrdenCompra)
                .HasMaxLength(50)
                .HasColumnName("UMEDIDA_DETALLE_ORDEN_COMPRA");
            entity.Property(e => e.ValortDetalleOrdenCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALORT_DETALLE_ORDEN_COMPRA");
            entity.Property(e => e.ValoruDetalleOrdenCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALORU_DETALLE_ORDEN_COMPRA");

            entity.HasOne(d => d.IdOrdenCompraNavigation).WithMany(p => p.DetalleOrdenCompras)
                .HasForeignKey(d => d.IdOrdenCompra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_ORDEN_COMPRA_ORDEN_COMPRA");

            entity.HasOne(d => d.IdSecuencialItemNavigation).WithMany(p => p.DetalleOrdenCompras)
                .HasForeignKey(d => d.IdSecuencialItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_ORDEN_COMPRA_SECUENCIAL_ITEM");
        });

        modelBuilder.Entity<DetalleOrdenComprobanteCompra>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DETALLE_ORDEN_COMPROBANTE_COMPRA");

            entity.Property(e => e.IdComprobanteCompra).HasColumnName("ID_COMPROBANTE_COMPRA");
            entity.Property(e => e.IdComprobanteIngreso).HasColumnName("ID_COMPROBANTE_INGRESO");
            entity.Property(e => e.IdOrdenCompra).HasColumnName("ID_ORDEN_COMPRA");
        });

        modelBuilder.Entity<DetalleOrdenTecnicaSupervision>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DETALLE___B4F46A57459FF6C6");

            entity.ToTable("DETALLE_ORDEN_TECNICA_SUPERVISION");

            entity.Property(e => e.IdDetalle)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE");
            entity.Property(e => e.Detalle)
                .HasColumnType("text")
                .HasColumnName("DETALLE");
            entity.Property(e => e.IdOrden).HasColumnName("ID_ORDEN");
            entity.Property(e => e.Observacion)
                .HasColumnType("text")
                .HasColumnName("OBSERVACION");
            entity.Property(e => e.Ok).HasColumnName("OK");
        });

        modelBuilder.Entity<DetallePlanillaCobrosPago>(entity =>
        {
            entity.HasKey(e => e.IdDetalle);

            entity.ToTable("DETALLE_PLANILLA_COBROS_PAGOS");

            entity.Property(e => e.IdDetalle)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE");
            entity.Property(e => e.Banco).HasColumnName("BANCO");
            entity.Property(e => e.BaseImponible)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("BASE_IMPONIBLE");
            entity.Property(e => e.CiRuc).HasColumnName("CI_RUC");
            entity.Property(e => e.Cliente).HasColumnName("CLIENTE");
            entity.Property(e => e.Contrato).HasColumnName("CONTRATO");
            entity.Property(e => e.FechaProceso)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_PROCESO");
            entity.Property(e => e.FormaPago).HasColumnName("FORMA_PAGO");
            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.IdFactura).HasColumnName("ID_FACTURA");
            entity.Property(e => e.IdPlanilla).HasColumnName("ID_PLANILLA");
            entity.Property(e => e.IvaCausado)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IVA_CAUSADO");
            entity.Property(e => e.NumCuenta).HasColumnName("NUM_CUENTA");
            entity.Property(e => e.NumFactura).HasColumnName("NUM_FACTURA");
            entity.Property(e => e.Ordenante).HasColumnName("ORDENANTE");
            entity.Property(e => e.PRetenIva).HasColumnName("P_RETEN_IVA");
            entity.Property(e => e.Proces).HasColumnName("PROCES");
            entity.Property(e => e.Procesado)
                .HasDefaultValue(0)
                .HasColumnName("PROCESADO");
            entity.Property(e => e.Submotivo).HasColumnName("SUBMOTIVO");
            entity.Property(e => e.TipoCuenta).HasColumnName("TIPO_CUENTA");
            entity.Property(e => e.TipoDoc).HasColumnName("TIPO_DOC");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR");
            entity.Property(e => e.ValorReten)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_RETEN");

            entity.HasOne(d => d.IdPlanillaNavigation).WithMany(p => p.DetallePlanillaCobrosPagos)
                .HasForeignKey(d => d.IdPlanilla)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PLANILLA_COBROS_PAGOS");
        });

        modelBuilder.Entity<DetallePorcentejeContribuyente>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DETALLE_PORCENTEJE_CONTRIBUYENTE");

            entity.Property(e => e.IdContribuyenteRetenido).HasColumnName("ID_CONTRIBUYENTE_RETENIDO");
            entity.Property(e => e.IdPorcentajeRetencion).HasColumnName("ID_PORCENTAJE_RETENCION");
        });

        modelBuilder.Entity<DetalleProgramacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DETALLE_PROGRAMACION");

            entity.Property(e => e.Detalle).HasColumnName("DETALLE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaDesde)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_DESDE");
            entity.Property(e => e.FechaHasta)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HASTA");
            entity.Property(e => e.IdHorario).HasColumnName("ID_HORARIO");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProgramacion).HasColumnName("ID_PROGRAMACION");
            entity.Property(e => e.IdPuesto).HasColumnName("ID_PUESTO");
            entity.Property(e => e.Tipo)
                .HasDefaultValue(1)
                .HasColumnName("TIPO");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany()
                .HasForeignKey(d => d.IdPersonal)
                .HasConstraintName("FKP");

            entity.HasOne(d => d.IdProgramacionNavigation).WithMany()
                .HasForeignKey(d => d.IdProgramacion)
                .HasConstraintName("IKD");

            entity.HasOne(d => d.IdPuestoNavigation).WithMany()
                .HasForeignKey(d => d.IdPuesto)
                .HasConstraintName("FKPS");
        });

        modelBuilder.Entity<DetalleProveedor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DETALLE_PROVEEDOR");

            entity.Property(e => e.IdProveedorGeneral).HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.TipoIdentificacion)
                .HasMaxLength(50)
                .HasColumnName("TIPO_IDENTIFICACION");
            entity.Property(e => e.TipoProveedorGeneral)
                .HasMaxLength(50)
                .HasColumnName("TIPO_PROVEEDOR_GENERAL");
        });

        modelBuilder.Entity<DetalleProveedorItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DETALLE_PROVEEDOR_ITEM");

            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdProveedorGeneral).HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.IdSecuencialItem).HasColumnName("ID_SECUENCIAL_ITEM");

            entity.HasOne(d => d.IdProveedorGeneralNavigation).WithMany()
                .HasForeignKey(d => d.IdProveedorGeneral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_PROVEEDOR_ITEM_PROVEEDOR_GENERAL");

            entity.HasOne(d => d.IdSecuencialItemNavigation).WithMany()
                .HasForeignKey(d => d.IdSecuencialItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_PROVEEDOR_ITEM_SECUENCIAL_ITEM");
        });

        modelBuilder.Entity<DetalleRequisicionProductoServicio>(entity =>
        {
            entity.HasKey(e => e.IdDetalleRequisicionPs);

            entity.ToTable("DETALLE_REQUISICION_PRODUCTO_SERVICIO");

            entity.Property(e => e.IdDetalleRequisicionPs)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_REQUISICION_PS");
            entity.Property(e => e.CantidadDetalleRequisicionPs).HasColumnName("CANTIDAD_DETALLE_REQUISICION_PS");
            entity.Property(e => e.EspecificacionDetalleRequisicionPs).HasColumnName("ESPECIFICACION_DETALLE_REQUISICION_PS");
            entity.Property(e => e.EstadoDetalleRequisicionPs).HasColumnName("ESTADO_DETALLE_REQUISICION_PS");
            entity.Property(e => e.IdRequisicionPs).HasColumnName("ID_REQUISICION_PS");
            entity.Property(e => e.IdSecuencialItem).HasColumnName("ID_SECUENCIAL_ITEM");
            entity.Property(e => e.ObservacionesDetalleRequisicionPs).HasColumnName("OBSERVACIONES_DETALLE_REQUISICION_PS");
            entity.Property(e => e.UmedidaDetalleRequisicionPs)
                .HasMaxLength(50)
                .HasColumnName("UMEDIDA_DETALLE_REQUISICION_PS");

            entity.HasOne(d => d.IdRequisicionPsNavigation).WithMany(p => p.DetalleRequisicionProductoServicios)
                .HasForeignKey(d => d.IdRequisicionPs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_REQUISICION_PRODUCTO_SERVICIO_REQUISICION_PRODUCTO_SERVICIO");
        });

        modelBuilder.Entity<DetalleRetencionPlanCuenta>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DETALLE___B4F46A57497087AA");

            entity.ToTable("DETALLE_RETENCION_PLAN_CUENTAS");

            entity.Property(e => e.IdDetalle)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE");
            entity.Property(e => e.Codigo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CODIGO");
            entity.Property(e => e.Cuenta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CUENTA");
            entity.Property(e => e.IdComprobanteCompra).HasColumnName("ID_COMPROBANTE_COMPRA");
            entity.Property(e => e.IdDetalleComprobanteRetencionCompra).HasColumnName("ID_DETALLE_COMPROBANTE_RETENCION_COMPRA");
            entity.Property(e => e.IdDetalleComprobanteRetencionVenta).HasColumnName("ID_DETALLE_COMPROBANTE_RETENCION_VENTA");
            entity.Property(e => e.IdFacturaVenta).HasColumnName("ID_FACTURA_VENTA");
        });

        modelBuilder.Entity<DetalleSecuencialSuministro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DETALLE_SECUENCIAL_SUMINISTROS");

            entity.Property(e => e.IdProveedor).HasColumnName("ID_PROVEEDOR");
            entity.Property(e => e.IdSecuencialSuministros).HasColumnName("ID_SECUENCIAL_SUMINISTROS");
        });

        modelBuilder.Entity<DetalleSolicitudSuministro>(entity =>
        {
            entity.HasKey(e => e.IdDetalleSolicitudSuministros);

            entity.ToTable("DETALLE_SOLICITUD_SUMINISTROS");

            entity.Property(e => e.IdDetalleSolicitudSuministros)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_SOLICITUD_SUMINISTROS");
            entity.Property(e => e.CantidadDetalleSolicitudSuministros).HasColumnName("CANTIDAD_DETALLE_SOLICITUD_SUMINISTROS");
            entity.Property(e => e.EstadoDetalleSolicitudSuministros).HasColumnName("ESTADO_DETALLE_SOLICITUD_SUMINISTROS");
            entity.Property(e => e.IdSecuencialSuministros).HasColumnName("ID_SECUENCIAL_SUMINISTROS");
            entity.Property(e => e.IdSolicitudSuministros).HasColumnName("ID_SOLICITUD_SUMINISTROS");

            entity.HasOne(d => d.IdSolicitudSuministrosNavigation).WithMany(p => p.DetalleSolicitudSuministros)
                .HasForeignKey(d => d.IdSolicitudSuministros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_SOLICITUD_SUMINISTROS_SOLICITUD_MENSUAL_SUMINISTROS");
        });

        modelBuilder.Entity<DetalleTransferencia>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DETALLE_TRANSFERENCIAS");

            entity.Property(e => e.CodigoActivo).HasColumnName("CODIGO_ACTIVO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoTransferencia).HasColumnName("ESTADO_TRANSFERENCIA");
            entity.Property(e => e.IdArea).HasColumnName("ID_AREA");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdGerencias).HasColumnName("ID_GERENCIAS");
            entity.Property(e => e.IdSucursal).HasColumnName("ID_SUCURSAL");
            entity.Property(e => e.IdTransferencia).HasColumnName("ID_TRANSFERENCIA");
            entity.Property(e => e.NombreActivo).HasColumnName("NOMBRE_ACTIVO");

            entity.HasOne(d => d.IdTransferenciaNavigation).WithMany()
                .HasForeignKey(d => d.IdTransferencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_TRANSFERENCIAS_ACTIVO_FIJO_TRANSFERENCIAS");
        });

        modelBuilder.Entity<DetalleUbicacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DETALLE_UBICACION");

            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdKardex).HasColumnName("ID_KARDEX");
            entity.Property(e => e.IdSubGrupoUbicacion).HasColumnName("ID_SUB_GRUPO_UBICACION");

            entity.HasOne(d => d.IdKardexNavigation).WithMany()
                .HasForeignKey(d => d.IdKardex)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_UBICACION_KARDEX");

            entity.HasOne(d => d.IdSubGrupoUbicacionNavigation).WithMany()
                .HasForeignKey(d => d.IdSubGrupoUbicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_UBICACION_SUB_GRUPO_UBICACION");
        });

        modelBuilder.Entity<DetalleUniforme>(entity =>
        {
            entity.HasKey(e => e.IdDetalleUniformes);

            entity.ToTable("DETALLE_UNIFORMES");

            entity.Property(e => e.IdDetalleUniformes)
                .ValueGeneratedNever()
                .HasColumnName("ID_DETALLE_UNIFORMES");
            entity.Property(e => e.CantidadDetalleUniformes).HasColumnName("CANTIDAD_DETALLE_UNIFORMES");
            entity.Property(e => e.EstadoDetalleUniformes).HasColumnName("ESTADO_DETALLE_UNIFORMES");
            entity.Property(e => e.FechaRenovacionDetalleUniformes)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_RENOVACION_DETALLE_UNIFORMES");
            entity.Property(e => e.IdDetalleKardexDetalleUniformes).HasColumnName("ID_DETALLE_KARDEX_DETALLE_UNIFORMES");
            entity.Property(e => e.IdKardexDetalleUniformes).HasColumnName("ID_KARDEX_DETALLE_UNIFORMES");
            entity.Property(e => e.IdUniformes).HasColumnName("ID_UNIFORMES");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.ObservacionDetalleUniformes).HasColumnName("OBSERVACION_DETALLE_UNIFORMES");

            entity.HasOne(d => d.IdUniformesNavigation).WithMany(p => p.DetalleUniformes)
                .HasForeignKey(d => d.IdUniformes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLE_UNIFORMES_ENTREGA_UNIFORMES");
        });

        modelBuilder.Entity<DetalleVacacione>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DETALLE_VACACION__5CB86648");

            entity.ToTable("DETALLE_VACACIONES");

            entity.Property(e => e.IdDetalle)
                .ValueGeneratedNever()
                .HasColumnName("id_detalle");
            entity.Property(e => e.Estado)
                .HasDefaultValue(1)
                .HasColumnName("estado");
            entity.Property(e => e.FechaEntrada)
                .HasColumnType("datetime")
                .HasColumnName("fecha_entrada");
            entity.Property(e => e.FechaFirma)
                .HasColumnType("datetime")
                .HasColumnName("fecha_firma");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("datetime")
                .HasColumnName("fecha_salida");
            entity.Property(e => e.IdPermiso).HasColumnName("id_permiso");
            entity.Property(e => e.IdPersonal).HasColumnName("id_personal");
            entity.Property(e => e.Ndiasp).HasColumnName("ndiasp");
            entity.Property(e => e.Ndiasv).HasColumnName("ndiasv");
            entity.Property(e => e.Num).HasColumnName("num");
            entity.Property(e => e.Obs)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("obs");
            entity.Property(e => e.Periodo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("periodo");
            entity.Property(e => e.ValorCobro)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("valor_cobro");
        });

        modelBuilder.Entity<DetallesRol>(entity =>
        {
            entity.HasKey(e => e.IdDetaRol).HasName("PK__DETALLES_ROL_5A1103C7");

            entity.ToTable("DETALLES_ROL");

            entity.Property(e => e.IdDetaRol)
                .ValueGeneratedNever()
                .HasColumnName("id_deta_rol");
            entity.Property(e => e.Acufor)
                .HasDefaultValue(1)
                .HasColumnName("acufor");
            entity.Property(e => e.Adicional)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("adicional");
            entity.Property(e => e.AntEme)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ant_eme");
            entity.Property(e => e.AntVari)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ant_vari");
            entity.Property(e => e.Area)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("area");
            entity.Property(e => e.Banco)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("banco");
            entity.Property(e => e.Cargo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cargo");
            entity.Property(e => e.Cedula)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Cliente)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("cliente");
            entity.Property(e => e.CosHext)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("cos_hext");
            entity.Property(e => e.CosHextf)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("cos_hextf");
            entity.Property(e => e.CosHnor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("cos_hnor");
            entity.Property(e => e.CosHsup)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("cos_hsup");
            entity.Property(e => e.Cuenta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cuenta");
            entity.Property(e => e.DescAlmuerzo)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("desc_almuerzo");
            entity.Property(e => e.DescCapa)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("desc_capa");
            entity.Property(e => e.DescComc)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("desc_comc");
            entity.Property(e => e.DescComi)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("desc_comi");
            entity.Property(e => e.DescDiasnolab)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("desc_diasnolab");
            entity.Property(e => e.DescEquip)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("desc_equip");
            entity.Property(e => e.DescExsc)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("desc_exsc");
            entity.Property(e => e.DescHip)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("desc_hip");
            entity.Property(e => e.DescIess)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("desc_iess");
            entity.Property(e => e.DescMultas)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("desc_multas");
            entity.Property(e => e.DescPension)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("desc_pension");
            entity.Property(e => e.DescPrem)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("desc_prem");
            entity.Property(e => e.DescQuir)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("desc_quir");
            entity.Property(e => e.DescVivi)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("desc_vivi");
            entity.Property(e => e.Deseg)
                .HasDefaultValue(1)
                .HasColumnName("deseg");
            entity.Property(e => e.Diasdm).HasColumnName("diasdm");
            entity.Property(e => e.Diast).HasColumnName("diast");
            entity.Property(e => e.DifDecFon)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("dif_dec_fon");
            entity.Property(e => e.Espacio)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("-")
                .HasColumnName("espacio");
            entity.Property(e => e.Est)
                .HasDefaultValue(0)
                .HasColumnName("est");
            entity.Property(e => e.Extedit).HasColumnName("extedit");
            entity.Property(e => e.Extra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("extra");
            entity.Property(e => e.Extsal).HasColumnName("extsal");
            entity.Property(e => e.FNacim)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime")
                .HasColumnName("f_nacim");
            entity.Property(e => e.FonRes)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fon_res");
            entity.Property(e => e.FonResAnt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fon_res_ant");
            entity.Property(e => e.Fonres)
                .HasDefaultValue(1)
                .HasColumnName("fonres");
            entity.Property(e => e.Forsex).HasColumnName("forsex");
            entity.Property(e => e.Grupo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("grupo");
            entity.Property(e => e.Hext)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("hext");
            entity.Property(e => e.Hextf)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("hextf");
            entity.Property(e => e.Hnor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("hnor");
            entity.Property(e => e.Hsup)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("hsup");
            entity.Property(e => e.IdBanco).HasColumnName("id_banco");
            entity.Property(e => e.IdPersonal).HasColumnName("id_personal");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.IngExt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ing_ext");
            entity.Property(e => e.Ingreso)
                .HasColumnType("datetime")
                .HasColumnName("ingreso");
            entity.Property(e => e.NetoRol)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("neto_rol");
            entity.Property(e => e.Nomina)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nomina");
            entity.Property(e => e.Num).HasColumnName("num");
            entity.Property(e => e.OtDesc)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ot_desc");
            entity.Property(e => e.OtIng)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ot_ing");
            entity.Property(e => e.QuinAnte)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("quin_ante");
            entity.Property(e => e.RecNoturno)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("rec_noturno");
            entity.Property(e => e.Sueldob)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("sueldob");
            entity.Property(e => e.Sueldodm)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("sueldodm");
            entity.Property(e => e.Sueldodt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("sueldodt");
            entity.Property(e => e.Sueldodtdm)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("sueldodtdm");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
            entity.Property(e => e.TipoBanco)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo_banco");
            entity.Property(e => e.TotBen)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tot_ben");
            entity.Property(e => e.TotDesc)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tot_desc");
            entity.Property(e => e.TotExt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tot_ext");
            entity.Property(e => e.TotHext)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tot_hext");
            entity.Property(e => e.TotHextf)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tot_hextf");
            entity.Property(e => e.TotHnor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tot_hnor");
            entity.Property(e => e.TotHsup)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tot_hsup");
            entity.Property(e => e.TotIng)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tot_ing");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ubicacion");
            entity.Property(e => e.ValAcumFonRes)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("val_acum_fon_res");
            entity.Property(e => e.Xiii)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("xiii");
            entity.Property(e => e.XiiiPension)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("xiii_pension");
            entity.Property(e => e.Xiiirol)
                .HasDefaultValue(1)
                .HasColumnName("xiiirol");
            entity.Property(e => e.Xiisex)
                .HasDefaultValue(1)
                .HasColumnName("xiisex");
            entity.Property(e => e.Xiv)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("xiv");
            entity.Property(e => e.XivPension)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("xiv_pension");
            entity.Property(e => e.Xivrol)
                .HasDefaultValue(1)
                .HasColumnName("xivrol");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.DetallesRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("fkderolp");
        });

        modelBuilder.Entity<DireccionesFacturacionCliente>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__DIRECCIO__FC7E9E8E3B226853");

            entity.ToTable("DIRECCIONES_FACTURACION_CLIENTE");

            entity.Property(e => e.IdDireccion)
                .ValueGeneratedNever()
                .HasColumnName("ID_DIRECCION");
            entity.Property(e => e.DireccionFacturacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DIRECCION_FACTURACION");
            entity.Property(e => e.IdClienteGeneral).HasColumnName("ID_CLIENTE_GENERAL");
        });

        modelBuilder.Entity<DocumentoNodeducible>(entity =>
        {
            entity.HasKey(e => e.IdDocumentoNodeducible);

            entity.ToTable("DOCUMENTO_NODEDUCIBLE");

            entity.Property(e => e.IdDocumentoNodeducible)
                .ValueGeneratedNever()
                .HasColumnName("ID_DOCUMENTO_NODEDUCIBLE");
            entity.Property(e => e.DescripcionDocumentoNodeducible).HasColumnName("DESCRIPCION_DOCUMENTO_NODEDUCIBLE");
            entity.Property(e => e.EstadoDocumentoNodeducible).HasColumnName("ESTADO_DOCUMENTO_NODEDUCIBLE");
            entity.Property(e => e.FechaDocumentoNodeducible)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_DOCUMENTO_NODEDUCIBLE");
            entity.Property(e => e.IdParametroDocumentos).HasColumnName("ID_PARAMETRO_DOCUMENTOS");
            entity.Property(e => e.IdSolicitudCch).HasColumnName("ID_SOLICITUD_CCH");
            entity.Property(e => e.IdSolicitudFr).HasColumnName("ID_SOLICITUD_FR");
            entity.Property(e => e.NumeroDocumentoNodeducible).HasColumnName("NUMERO_DOCUMENTO_NODEDUCIBLE");
            entity.Property(e => e.ValorDocumentoNodeducible)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_DOCUMENTO_NODEDUCIBLE");

            entity.HasOne(d => d.IdParametroDocumentosNavigation).WithMany(p => p.DocumentoNodeducibles)
                .HasForeignKey(d => d.IdParametroDocumentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DOCUMENTO_NODEDUCIBLE_PRAMETROS_DOCUMENTOS");
        });

        modelBuilder.Entity<DocumentosContrato>(entity =>
        {
            entity.HasKey(e => e.IdDocumento);

            entity.ToTable("DOCUMENTOS_CONTRATO");

            entity.Property(e => e.IdDocumento)
                .ValueGeneratedNever()
                .HasColumnName("id_documento");
            entity.Property(e => e.Documento).HasColumnName("documento");
            entity.Property(e => e.FechaCarga)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_carga");
            entity.Property(e => e.IdContrato).HasColumnName("id_contrato");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.TipoDocumento).HasColumnName("tipo_documento");
        });

        modelBuilder.Entity<DocumentosElectronico>(entity =>
        {
            entity.HasKey(e => e.IdArc).HasName("PK__DOCUMENTOS_ELECT__25332734");

            entity.ToTable("DOCUMENTOS_ELECTRONICOS");

            entity.Property(e => e.IdArc)
                .ValueGeneratedNever()
                .HasColumnName("ID_ARC");
            entity.Property(e => e.Documento).HasColumnName("DOCUMENTO");
            entity.Property(e => e.FechaGenerado)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_GENERADO");
            entity.Property(e => e.IdDoc).HasColumnName("ID_DOC");
            entity.Property(e => e.Numdoc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NUMDOC");
            entity.Property(e => e.Tipo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TIPO");
        });

        modelBuilder.Entity<EgresoSuministro>(entity =>
        {
            entity.HasKey(e => e.IdEgresoSuministros);

            entity.ToTable("EGRESO_SUMINISTROS");

            entity.Property(e => e.IdEgresoSuministros)
                .ValueGeneratedNever()
                .HasColumnName("ID_EGRESO_SUMINISTROS");
            entity.Property(e => e.EstadoEgresoSuministros).HasColumnName("ESTADO_EGRESO_SUMINISTROS");
            entity.Property(e => e.FechaEgresoSuministros)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EGRESO_SUMINISTROS");
            entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.IdCuidad).HasColumnName("ID_CUIDAD");
            entity.Property(e => e.IdParroquia).HasColumnName("ID_PARROQUIA");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");
        });

        modelBuilder.Entity<EmpresaGeneral>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa);

            entity.ToTable("EMPRESA_GENERAL");

            entity.Property(e => e.IdEmpresa)
                .ValueGeneratedNever()
                .HasColumnName("ID_EMPRESA");
            entity.Property(e => e.CodigoEmpresa).HasColumnName("CODIGO_EMPRESA");
            entity.Property(e => e.DireccionMatrizEmpresa).HasColumnName("DIRECCION_MATRIZ_EMPRESA");
            entity.Property(e => e.EstadoEmpresa).HasColumnName("ESTADO_EMPRESA");
            entity.Property(e => e.NombreComercialEmpresa).HasColumnName("NOMBRE_COMERCIAL_EMPRESA");
            entity.Property(e => e.NroResContEspecialEmpresa)
                .HasMaxLength(50)
                .HasColumnName("NRO_RES_CONT_ESPECIAL_EMPRESA");
            entity.Property(e => e.ObligadoLlevarContEmpresa)
                .HasMaxLength(50)
                .HasColumnName("OBLIGADO_LLEVAR_CONT_EMPRESA");
            entity.Property(e => e.RazonSocialEmpresa).HasColumnName("RAZON_SOCIAL_EMPRESA");
            entity.Property(e => e.RucEmpre)
                .HasMaxLength(15)
                .HasColumnName("RUC_EMPRE");
            entity.Property(e => e.RucEmpresa)
                .HasMaxLength(15)
                .HasColumnName("RUC_EMPRESA");
            entity.Property(e => e.Telefono).HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<EntregaEpp>(entity =>
        {
            entity.HasKey(e => e.IdEpp);

            entity.ToTable("ENTREGA_EPP");

            entity.Property(e => e.IdEpp)
                .ValueGeneratedNever()
                .HasColumnName("ID_EPP");
            entity.Property(e => e.AprobadoEpp).HasColumnName("APROBADO_EPP");
            entity.Property(e => e.CedulaEpp).HasColumnName("CEDULA_EPP");
            entity.Property(e => e.ClienteEpp).HasColumnName("CLIENTE_EPP");
            entity.Property(e => e.CodigoEpp).HasColumnName("CODIGO_EPP");
            entity.Property(e => e.EstadoEpp).HasColumnName("ESTADO_EPP");
            entity.Property(e => e.FechaEpp)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EPP");
            entity.Property(e => e.FechaIngresoEpp)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INGRESO_EPP");
            entity.Property(e => e.NombreEpp).HasColumnName("NOMBRE_EPP");
            entity.Property(e => e.ObservacionEpp).HasColumnName("OBSERVACION_EPP");
            entity.Property(e => e.RealizadoEpp).HasColumnName("REALIZADO_EPP");
            entity.Property(e => e.RegistradoEpp).HasColumnName("REGISTRADO_EPP");
            entity.Property(e => e.RevisadoEpp).HasColumnName("REVISADO_EPP");
            entity.Property(e => e.VersionEpp).HasColumnName("VERSION_EPP");
        });

        modelBuilder.Entity<EntregaUniforme>(entity =>
        {
            entity.HasKey(e => e.IdUniformes);

            entity.ToTable("ENTREGA_UNIFORMES");

            entity.Property(e => e.IdUniformes)
                .ValueGeneratedNever()
                .HasColumnName("ID_UNIFORMES");
            entity.Property(e => e.AprobadoUniformes).HasColumnName("APROBADO_UNIFORMES");
            entity.Property(e => e.CedulaUniformes).HasColumnName("CEDULA_UNIFORMES");
            entity.Property(e => e.ClienteUniformes).HasColumnName("CLIENTE_UNIFORMES");
            entity.Property(e => e.CodigoUniformes).HasColumnName("CODIGO_UNIFORMES");
            entity.Property(e => e.EstadoUniformes).HasColumnName("ESTADO_UNIFORMES");
            entity.Property(e => e.FechaIngresoUniformes)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INGRESO_UNIFORMES");
            entity.Property(e => e.FechaUniformes)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_UNIFORMES");
            entity.Property(e => e.NombreUniformes).HasColumnName("NOMBRE_UNIFORMES");
            entity.Property(e => e.ObservacionUniformes).HasColumnName("OBSERVACION_UNIFORMES");
            entity.Property(e => e.RealizadoUniformes).HasColumnName("REALIZADO_UNIFORMES");
            entity.Property(e => e.RegistradoUniformes).HasColumnName("REGISTRADO_UNIFORMES");
            entity.Property(e => e.RevisadoUniformes).HasColumnName("REVISADO_UNIFORMES");
            entity.Property(e => e.VersionUniformes).HasColumnName("VERSION_UNIFORMES");
        });

        modelBuilder.Entity<EquipoPuestoSitioTrabajo>(entity =>
        {
            entity.HasKey(e => e.IdEquipoPuntoTrabajo).HasName("PK_EQUIPO_SITIO_TRABAJO");

            entity.ToTable("EQUIPO_PUESTO_SITIO_TRABAJO");

            entity.Property(e => e.IdEquipoPuntoTrabajo)
                .ValueGeneratedNever()
                .HasColumnName("ID_EQUIPO_PUNTO_TRABAJO");
            entity.Property(e => e.Caduca)
                .HasColumnType("datetime")
                .HasColumnName("CADUCA");
            entity.Property(e => e.Calibre).HasColumnName("CALIBRE");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Custodio).HasColumnName("CUSTODIO");
            entity.Property(e => e.Equipo).HasColumnName("EQUIPO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoEquipo).HasColumnName("ESTADO_EQUIPO");
            entity.Property(e => e.FechaAsignacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ASIGNACION");
            entity.Property(e => e.FechaLevantamiento)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_LEVANTAMIENTO");
            entity.Property(e => e.IdComprobante).HasColumnName("ID_COMPROBANTE");
            entity.Property(e => e.IdPunto).HasColumnName("ID_PUNTO");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Origen).HasColumnName("ORIGEN");
            entity.Property(e => e.Permiso).HasColumnName("PERMISO");
            entity.Property(e => e.Serie).HasColumnName("SERIE");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("TIPO");
        });

        modelBuilder.Entity<EquipoPuestoTrabajo>(entity =>
        {
            entity.HasKey(e => e.IdEquipoPuestoTrabajo);

            entity.ToTable("EQUIPO_PUESTO_TRABAJO");

            entity.Property(e => e.IdEquipoPuestoTrabajo)
                .ValueGeneratedNever()
                .HasColumnName("ID_EQUIPO_PUESTO_TRABAJO");
            entity.Property(e => e.Caduca)
                .HasColumnType("datetime")
                .HasColumnName("CADUCA");
            entity.Property(e => e.Calibre).HasColumnName("CALIBRE");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Custodio)
                .HasColumnType("text")
                .HasColumnName("CUSTODIO");
            entity.Property(e => e.Equipo).HasColumnName("EQUIPO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoEquipo).HasColumnName("ESTADO_EQUIPO");
            entity.Property(e => e.FechaLevantamiento)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_LEVANTAMIENTO");
            entity.Property(e => e.IdPuesto).HasColumnName("ID_PUESTO");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Origen).HasColumnName("ORIGEN");
            entity.Property(e => e.Permiso).HasColumnName("PERMISO");
            entity.Property(e => e.Serie).HasColumnName("SERIE");
            entity.Property(e => e.Supervisor).HasColumnName("SUPERVISOR");
            entity.Property(e => e.Tipo).HasColumnName("TIPO");
        });

        modelBuilder.Entity<EquiposAmbientacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EQUIPOS_AMBIENTACION");

            entity.Property(e => e.Amperaje).HasColumnName("AMPERAJE");
            entity.Property(e => e.Ano).HasColumnName("ANO");
            entity.Property(e => e.Color).HasColumnName("COLOR");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoActivo).HasColumnName("ESTADO_ACTIVO");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Material).HasColumnName("MATERIAL");
            entity.Property(e => e.Modelo).HasColumnName("MODELO");
            entity.Property(e => e.Serie).HasColumnName("SERIE");
            entity.Property(e => e.Tipo).HasColumnName("TIPO");
            entity.Property(e => e.Voltaje).HasColumnName("VOLTAJE");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EQUIPOS_AMBIENTACION_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<EquiposCocina>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EQUIPOS_COCINA");

            entity.Property(e => e.Ano).HasColumnName("ANO");
            entity.Property(e => e.Color).HasColumnName("COLOR");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoActivo).HasColumnName("ESTADO_ACTIVO");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Material).HasColumnName("MATERIAL");
            entity.Property(e => e.Modelo).HasColumnName("MODELO");
            entity.Property(e => e.Serie).HasColumnName("SERIE");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EQUIPOS_COCINA_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<EquiposComputo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EQUIPOS_COMPUTO");

            entity.Property(e => e.Caducidad)
                .HasColumnType("datetime")
                .HasColumnName("CADUCIDAD");
            entity.Property(e => e.CodigoComponente).HasColumnName("CODIGO_COMPONENTE");
            entity.Property(e => e.ColorComponente).HasColumnName("COLOR_COMPONENTE");
            entity.Property(e => e.Componente).HasColumnName("COMPONENTE");
            entity.Property(e => e.Documento).HasColumnName("DOCUMENTO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoComponente).HasColumnName("ESTADO_COMPONENTE");
            entity.Property(e => e.Garantia).HasColumnName("GARANTIA");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Modelo).HasColumnName("MODELO");
            entity.Property(e => e.Ruta).HasColumnName("RUTA");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EQUIPOS_COMPUTO_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<EquiposComunicacionTelefonium>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EQUIPOS_COMUNICACION_TELEFONIA");

            entity.Property(e => e.Ano).HasColumnName("ANO");
            entity.Property(e => e.Color).HasColumnName("COLOR");
            entity.Property(e => e.Documento).HasColumnName("DOCUMENTO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoActivo).HasColumnName("ESTADO_ACTIVO");
            entity.Property(e => e.FinalPermisoFrecuencia)
                .HasColumnType("datetime")
                .HasColumnName("FINAL_PERMISO_FRECUENCIA");
            entity.Property(e => e.Garantia).HasColumnName("GARANTIA");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.InicioPermisoFrecuencia)
                .HasColumnType("datetime")
                .HasColumnName("INICIO_PERMISO_FRECUENCIA");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Material).HasColumnName("MATERIAL");
            entity.Property(e => e.Modelo).HasColumnName("MODELO");
            entity.Property(e => e.Ruta).HasColumnName("RUTA");
            entity.Property(e => e.Serie).HasColumnName("SERIE");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EQUIPOS_COMUNICACION_TELEFONIA_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<EquiposOficina>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EQUIPOS_OFICINA");

            entity.Property(e => e.Ano).HasColumnName("ANO");
            entity.Property(e => e.Caducidad)
                .HasColumnType("datetime")
                .HasColumnName("CADUCIDAD");
            entity.Property(e => e.Color).HasColumnName("COLOR");
            entity.Property(e => e.Documento).HasColumnName("DOCUMENTO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoActivo).HasColumnName("ESTADO_ACTIVO");
            entity.Property(e => e.Garantia).HasColumnName("GARANTIA");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Material).HasColumnName("MATERIAL");
            entity.Property(e => e.Modelo).HasColumnName("MODELO");
            entity.Property(e => e.Ruta).HasColumnName("RUTA");
            entity.Property(e => e.Serie).HasColumnName("SERIE");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EQUIPOS_OFICINA_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<EquiposSeguridadIndustrial>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EQUIPOS_SEGURIDAD_INDUSTRIAL");

            entity.Property(e => e.Adicional).HasColumnName("ADICIONAL");
            entity.Property(e => e.Ano).HasColumnName("ANO");
            entity.Property(e => e.Color).HasColumnName("COLOR");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoActivo).HasColumnName("ESTADO_ACTIVO");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Material).HasColumnName("MATERIAL");
            entity.Property(e => e.Modelo).HasColumnName("MODELO");
            entity.Property(e => e.Serie).HasColumnName("SERIE");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EQUIPOS_SEGURIDAD_INDUSTRIAL_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<EvaluacionProveedorMateriale>(entity =>
        {
            entity.HasKey(e => e.IdEvaluacionProveedorMateriales);

            entity.ToTable("EVALUACION_PROVEEDOR_MATERIALES");

            entity.Property(e => e.IdEvaluacionProveedorMateriales)
                .ValueGeneratedNever()
                .HasColumnName("ID_EVALUACION_PROVEEDOR_MATERIALES");
            entity.Property(e => e.CalidadMaterialEvaluacionProveedorMateriales).HasColumnName("CALIDAD_MATERIAL_EVALUACION_PROVEEDOR_MATERIALES");
            entity.Property(e => e.CapacidadProvisionProveedorMateriales).HasColumnName("CAPACIDAD_PROVISION_PROVEEDOR_MATERIALES");
            entity.Property(e => e.CondicionesPagoEvaluacionProveedorMateriales).HasColumnName("CONDICIONES_PAGO_EVALUACION_PROVEEDOR_MATERIALES");
            entity.Property(e => e.EstadoEvaluacionProveedorMateriales).HasColumnName("ESTADO_EVALUACION_PROVEEDOR_MATERIALES");
            entity.Property(e => e.FechaEvaluacionProveedorMateriales)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EVALUACION_PROVEEDOR_MATERIALES");
            entity.Property(e => e.GarantiasEvaluacionProveedorMateriales).HasColumnName("GARANTIAS_EVALUACION_PROVEEDOR_MATERIALES");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProveedorGeneral).HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.PrecioEvaluacionProveedorMateriales).HasColumnName("PRECIO_EVALUACION_PROVEEDOR_MATERIALES");
            entity.Property(e => e.PuntosEntregaEvaluacionProveedorMateriales).HasColumnName("PUNTOS_ENTREGA_EVALUACION_PROVEEDOR_MATERIALES");
            entity.Property(e => e.ServiciosAsociadosEvaluacionProveedorMateriales).HasColumnName("SERVICIOS_ASOCIADOS_EVALUACION_PROVEEDOR_MATERIALES");
            entity.Property(e => e.SoporteTecnicoEvaluacionProveedorMateriales).HasColumnName("SOPORTE_TECNICO_EVALUACION_PROVEEDOR_MATERIALES");
            entity.Property(e => e.TiemposEntregaEvaluacionProveedorMateriales).HasColumnName("TIEMPOS_ENTREGA_EVALUACION_PROVEEDOR_MATERIALES");
            entity.Property(e => e.TotalEvaluacionProveedorMateriales).HasColumnName("TOTAL_EVALUACION_PROVEEDOR_MATERIALES");

            entity.HasOne(d => d.IdProveedorGeneralNavigation).WithMany(p => p.EvaluacionProveedorMateriales)
                .HasForeignKey(d => d.IdProveedorGeneral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EVALUACION_PROVEEDOR_MATERIALES_PROVEEDOR_GENERAL");
        });

        modelBuilder.Entity<EvaluacionProveedorServicio>(entity =>
        {
            entity.HasKey(e => e.IdEvaluacionProveedorServicios);

            entity.ToTable("EVALUACION_PROVEEDOR_SERVICIOS");

            entity.Property(e => e.IdEvaluacionProveedorServicios)
                .ValueGeneratedNever()
                .HasColumnName("ID_EVALUACION_PROVEEDOR_SERVICIOS");
            entity.Property(e => e.CondicionesPagoEvaluacionProveedorServicios).HasColumnName("CONDICIONES_PAGO_EVALUACION_PROVEEDOR_SERVICIOS");
            entity.Property(e => e.CumplimientoTiemposEntregaEvaluacionProveedorServicios).HasColumnName("CUMPLIMIENTO_TIEMPOS_ENTREGA_EVALUACION_PROVEEDOR_SERVICIOS");
            entity.Property(e => e.DocumentosActualizadosEvaluacionProveedorServicios).HasColumnName("DOCUMENTOS_ACTUALIZADOS_EVALUACION_PROVEEDOR_SERVICIOS");
            entity.Property(e => e.EstadoEvaluacionProveedorServicios).HasColumnName("ESTADO_EVALUACION_PROVEEDOR_SERVICIOS");
            entity.Property(e => e.FechaEvaluacionProveedorServicios)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EVALUACION_PROVEEDOR_SERVICIOS");
            entity.Property(e => e.GarantiasEvaluacionProveedorServicios).HasColumnName("GARANTIAS_EVALUACION_PROVEEDOR_SERVICIOS");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProveedorGeneral).HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.InstalacionesEvaluacionProveedorServicios).HasColumnName("INSTALACIONES_EVALUACION_PROVEEDOR_SERVICIOS");
            entity.Property(e => e.PersonalPropioEvaluacionProveedorServicios).HasColumnName("PERSONAL_PROPIO_EVALUACION_PROVEEDOR_SERVICIOS");
            entity.Property(e => e.PrecioEvaluacionProveedorServicios).HasColumnName("PRECIO_EVALUACION_PROVEEDOR_SERVICIOS");
            entity.Property(e => e.SoporteTecnicoEvaluacionProveedorServicios).HasColumnName("SOPORTE_TECNICO_EVALUACION_PROVEEDOR_SERVICIOS");
            entity.Property(e => e.TiempoRespuestaEvaluacionProveedorServicios).HasColumnName("TIEMPO_RESPUESTA_EVALUACION_PROVEEDOR_SERVICIOS");
            entity.Property(e => e.TotalEvaluacionProveedorServicios).HasColumnName("TOTAL_EVALUACION_PROVEEDOR_SERVICIOS");
            entity.Property(e => e.TransporteEvaluacionProveedorServicios).HasColumnName("TRANSPORTE_EVALUACION_PROVEEDOR_SERVICIOS");

            entity.HasOne(d => d.IdProveedorGeneralNavigation).WithMany(p => p.EvaluacionProveedorServicios)
                .HasForeignKey(d => d.IdProveedorGeneral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EVALUACION_PROVEEDOR_SERVICIOS_PROVEEDOR_GENERAL");
        });

        modelBuilder.Entity<FacturaDebitoConvenio>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FACTURA_DEBITO_CONVENIO");

            entity.Property(e => e.IdConvenio).HasColumnName("ID_CONVENIO");
            entity.Property(e => e.IdFactura).HasColumnName("ID_FACTURA");
        });

        modelBuilder.Entity<FacturaSecuenciale>(entity =>
        {
            entity.HasKey(e => e.IdFacturaSecuencial).HasName("PK_FACTURA_COMPRA");

            entity.ToTable("FACTURA_SECUENCIALES");

            entity.Property(e => e.IdFacturaSecuencial)
                .ValueGeneratedNever()
                .HasColumnName("ID_FACTURA_SECUENCIAL");
            entity.Property(e => e.ActualFacturaSecuenciales).HasColumnName("ACTUAL_FACTURA_SECUENCIALES");
            entity.Property(e => e.CantidadFacturaSecuenciales).HasColumnName("CANTIDAD_FACTURA_SECUENCIALES");
            entity.Property(e => e.EstadoFacturaSecuenciales).HasColumnName("ESTADO_FACTURA_SECUENCIALES");
            entity.Property(e => e.FechaEmisionFacturaSecuenciales)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION_FACTURA_SECUENCIALES");
            entity.Property(e => e.NumeroFinalFacturaSecuenciales).HasColumnName("NUMERO_FINAL_FACTURA_SECUENCIALES");
            entity.Property(e => e.NumeroInicialFacturaSecuenciales).HasColumnName("NUMERO_INICIAL_FACTURA_SECUENCIALES");
            entity.Property(e => e.ObservacionesFacturaSecuenciales).HasColumnName("OBSERVACIONES_FACTURA_SECUENCIALES");
        });

        modelBuilder.Entity<FacturaVentum>(entity =>
        {
            entity.HasKey(e => e.IdFacturaVenta);

            entity.ToTable("FACTURA_VENTA");

            entity.Property(e => e.IdFacturaVenta)
                .ValueGeneratedNever()
                .HasColumnName("ID_FACTURA_VENTA");
            entity.Property(e => e.ConceptoFacturaVenta).HasColumnName("CONCEPTO_FACTURA_VENTA");
            entity.Property(e => e.DescuentoFacturaVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DESCUENTO_FACTURA_VENTA");
            entity.Property(e => e.EstadoFacturaVenta).HasColumnName("ESTADO_FACTURA_VENTA");
            entity.Property(e => e.FechaEmisionFacturaVenta)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION_FACTURA_VENTA");
            entity.Property(e => e.GuiaRemisionFacturaVenta)
                .HasMaxLength(50)
                .HasColumnName("GUIA_REMISION_FACTURA_VENTA");
            entity.Property(e => e.IdClienteGeneral).HasColumnName("ID_CLIENTE_GENERAL");
            entity.Property(e => e.IdEmpresaGeneral).HasColumnName("ID_EMPRESA_GENERAL");
            entity.Property(e => e.IvaFacturaVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IVA_FACTURA_VENTA");
            entity.Property(e => e.NumeroFacturaVenta)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_FACTURA_VENTA");
            entity.Property(e => e.ObservacionesFacturaVenta).HasColumnName("OBSERVACIONES_FACTURA_VENTA");
            entity.Property(e => e.PlazoFacturaVenta)
                .HasColumnType("datetime")
                .HasColumnName("PLAZO_FACTURA_VENTA");
            entity.Property(e => e.PorcentajeIvaFacturaVenta).HasColumnName("PORCENTAJE_IVA_FACTURA_VENTA");
            entity.Property(e => e.Subtotal0FacturaVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUBTOTAL_0_FACTURA_VENTA");
            entity.Property(e => e.Subtotal12FacturaVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUBTOTAL_12_FACTURA_VENTA");
            entity.Property(e => e.SubtotalFacturaVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUBTOTAL_FACTURA_VENTA");
            entity.Property(e => e.TipoPagoFacturaVenta).HasColumnName("TIPO_PAGO_FACTURA_VENTA");
            entity.Property(e => e.TotalFacturaVenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_FACTURA_VENTA");
        });

        modelBuilder.Entity<FacturasImpagasGeneral>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("FACTURAS_IMPAGAS_GENERAL");

            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.ApellidoNombreComercialClienteGenral).HasColumnName("APELLIDO_NOMBRE_COMERCIAL_CLIENTE_GENRAL");
            entity.Property(e => e.BancoConvenio).HasColumnName("BANCO_CONVENIO");
            entity.Property(e => e.Convenio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CONVENIO");
            entity.Property(e => e.FechaEmisionFacturaVenta)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION_FACTURA_VENTA");
            entity.Property(e => e.IdClienteGeneral).HasColumnName("ID_CLIENTE_GENERAL");
            entity.Property(e => e.IdFacturaVenta).HasColumnName("ID_FACTURA_VENTA");
            entity.Property(e => e.Mes).HasColumnName("mes");
            entity.Property(e => e.NompreRazonSocialClienteGeneral).HasColumnName("NOMPRE_RAZON_SOCIAL_CLIENTE_GENERAL");
            entity.Property(e => e.NumCiRuc)
                .HasMaxLength(13)
                .HasColumnName("NUM_CI_RUC");
            entity.Property(e => e.NumCuentaTarj)
                .HasMaxLength(25)
                .HasColumnName("NUM_CUENTA_TARJ");
            entity.Property(e => e.NumeroFacturaVenta)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_FACTURA_VENTA");
            entity.Property(e => e.RucCiClienteGeneral)
                .HasMaxLength(15)
                .HasColumnName("RUC_CI_CLIENTE_GENERAL");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("saldo");
            entity.Property(e => e.TipoCuenta)
                .HasMaxLength(25)
                .HasColumnName("TIPO_CUENTA");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(20)
                .HasColumnName("TIPO_DOC");
            entity.Property(e => e.TitularCuenta).HasColumnName("TITULAR_CUENTA");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL");
        });

        modelBuilder.Entity<FondoRotativo>(entity =>
        {
            entity.HasKey(e => e.IdFondoRotativo);

            entity.ToTable("FONDO_ROTATIVO");

            entity.Property(e => e.IdFondoRotativo)
                .ValueGeneratedNever()
                .HasColumnName("ID_FONDO_ROTATIVO");
            entity.Property(e => e.CtaContable).HasColumnName("CTA_CONTABLE");
            entity.Property(e => e.DetalleFondoRotativo).HasColumnName("DETALLE_FONDO_ROTATIVO");
            entity.Property(e => e.EstadoFondoRotativo).HasColumnName("ESTADO_FONDO_ROTATIVO");
            entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProvincias).HasColumnName("ID_PROVINCIAS");
            entity.Property(e => e.MontoFondoRotativo)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MONTO_FONDO_ROTATIVO");
            entity.Property(e => e.NivelCta).HasColumnName("NIVEL_CTA");
            entity.Property(e => e.TipoCta).HasColumnName("TIPO_CTA");

            entity.HasOne(d => d.IdCentroCostoNavigation).WithMany(p => p.FondoRotativos)
                .HasForeignKey(d => d.IdCentroCosto)
                .HasConstraintName("FK_FONDO_ROTATIVO_CENTRO_COSTO");
        });

        modelBuilder.Entity<FormasPago>(entity =>
        {
            entity.HasKey(e => e.IdFormaPago);

            entity.ToTable("FORMAS_PAGO");

            entity.Property(e => e.IdFormaPago).HasColumnName("ID_FORMA_PAGO");
            entity.Property(e => e.CodigoFormaPago)
                .HasMaxLength(50)
                .HasColumnName("CODIGO_FORMA_PAGO");
            entity.Property(e => e.DetalleFormaPago).HasColumnName("DETALLE_FORMA_PAGO");
            entity.Property(e => e.EstadoFormaPago).HasColumnName("ESTADO_FORMA_PAGO");
        });

        modelBuilder.Entity<Foto>(entity =>
        {
            entity.HasKey(e => e.IdFoto).HasName("PK__FOTO__620EA3A53751D76F");

            entity.ToTable("FOTO");

            entity.Property(e => e.IdFoto)
                .ValueGeneratedNever()
                .HasColumnName("id_foto");
            entity.Property(e => e.Aux).HasColumnName("aux");
            entity.Property(e => e.Foto1)
                .HasColumnType("image")
                .HasColumnName("foto");
        });

        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.HasKey(e => e.IdGastos);

            entity.ToTable("GASTOS");

            entity.Property(e => e.IdGastos)
                .ValueGeneratedNever()
                .HasColumnName("ID_GASTOS");
            entity.Property(e => e.CtaContableGastos).HasColumnName("CTA_CONTABLE_GASTOS");
            entity.Property(e => e.CtaPadreGastos).HasColumnName("CTA_PADRE_GASTOS");
            entity.Property(e => e.DetalleCtaGastos)
                .HasMaxLength(50)
                .HasColumnName("DETALLE_CTA_GASTOS");
            entity.Property(e => e.EstadoGastos).HasColumnName("ESTADO_GASTOS");
            entity.Property(e => e.TipoCta).HasColumnName("TIPO_CTA");
        });

        modelBuilder.Entity<GastosCajaChica>(entity =>
        {
            entity.HasKey(e => e.IdGastosCajaCh).HasName("PK_GASTOS_CAJA_CHICA_1");

            entity.ToTable("GASTOS_CAJA_CHICA");

            entity.Property(e => e.IdGastosCajaCh)
                .ValueGeneratedNever()
                .HasColumnName("ID_GASTOS_CAJA_CH");
            entity.Property(e => e.CtaContableGastoCajaCh).HasColumnName("CTA_CONTABLE_GASTO_CAJA_CH");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.IdPlan).HasColumnName("ID_PLAN");
            entity.Property(e => e.NombreGastoCajaCh).HasColumnName("NOMBRE_GASTO_CAJA_CH");
        });

        modelBuilder.Entity<GastosFondoRotativo>(entity =>
        {
            entity.HasKey(e => e.IdGastosFr);

            entity.ToTable("GASTOS_FONDO_ROTATIVO");

            entity.Property(e => e.IdGastosFr)
                .ValueGeneratedNever()
                .HasColumnName("ID_GASTOS_FR");
            entity.Property(e => e.CtaContableGastosFr).HasColumnName("CTA_CONTABLE_GASTOS_FR");
            entity.Property(e => e.EstadoGastosFr).HasColumnName("ESTADO_GASTOS_FR");
            entity.Property(e => e.IdFondoRotativo).HasColumnName("ID_FONDO_ROTATIVO");
            entity.Property(e => e.IdPlan).HasColumnName("ID_PLAN");
            entity.Property(e => e.NombreGastosFr).HasColumnName("NOMBRE_GASTOS_FR");
        });

        modelBuilder.Entity<Generadore>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GENERADORES");

            entity.Property(e => e.Adicionales).HasColumnName("ADICIONALES");
            entity.Property(e => e.Amperaje).HasColumnName("AMPERAJE");
            entity.Property(e => e.Ano).HasColumnName("ANO");
            entity.Property(e => e.Color).HasColumnName("COLOR");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoActivo).HasColumnName("ESTADO_ACTIVO");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Material).HasColumnName("MATERIAL");
            entity.Property(e => e.Modelo).HasColumnName("MODELO");
            entity.Property(e => e.Serie).HasColumnName("SERIE");
            entity.Property(e => e.Tipo).HasColumnName("TIPO");
            entity.Property(e => e.Voltaje).HasColumnName("VOLTAJE");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GENERADORES_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<GerenciaGeneral>(entity =>
        {
            entity.HasKey(e => e.IdGerencia);

            entity.ToTable("GERENCIA_GENERAL");

            entity.Property(e => e.IdGerencia)
                .ValueGeneratedNever()
                .HasColumnName("ID_GERENCIA");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            entity.Property(e => e.EstadoGerencia).HasColumnName("ESTADO_GERENCIA");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdSucursal).HasColumnName("ID_SUCURSAL");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.GerenciaGenerals)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GERENCIA_GENERAL_EMPRESA_GENERAL");
        });

        modelBuilder.Entity<GerenciasGeneral>(entity =>
        {
            entity.HasKey(e => e.IdGerenciasGeneral);

            entity.ToTable("GERENCIAS_GENERAL");

            entity.Property(e => e.IdGerenciasGeneral)
                .ValueGeneratedNever()
                .HasColumnName("ID_GERENCIAS_GENERAL");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.EstadoGerencias).HasColumnName("ESTADO_GERENCIAS");
            entity.Property(e => e.IdGerencia).HasColumnName("ID_GERENCIA");
            entity.Property(e => e.NombreGerencias).HasColumnName("NOMBRE_GERENCIAS");

            entity.HasOne(d => d.IdGerenciaNavigation).WithMany(p => p.GerenciasGenerals)
                .HasForeignKey(d => d.IdGerencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GERENCIAS_GENERAL_GERENCIA_GENERAL");
        });

        modelBuilder.Entity<GrupoGeneral>(entity =>
        {
            entity.HasKey(e => e.IdGrupo);

            entity.ToTable("GRUPO_GENERAL");

            entity.Property(e => e.IdGrupo)
                .ValueGeneratedNever()
                .HasColumnName("ID_GRUPO");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.EstadoGrupo).HasColumnName("ESTADO_GRUPO");
            entity.Property(e => e.IdCategoriaGrupo).HasColumnName("ID_CATEGORIA_GRUPO");
            entity.Property(e => e.NombreGrupo).HasColumnName("NOMBRE_GRUPO");

            entity.HasOne(d => d.IdCategoriaGrupoNavigation).WithMany(p => p.GrupoGenerals)
                .HasForeignKey(d => d.IdCategoriaGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRUPO_GENERAL_CATEGORIA");
        });

        modelBuilder.Entity<GrupoItem>(entity =>
        {
            entity.HasKey(e => e.IdGrupoItem);

            entity.ToTable("GRUPO_ITEM");

            entity.Property(e => e.IdGrupoItem)
                .ValueGeneratedNever()
                .HasColumnName("ID_GRUPO_ITEM");
            entity.Property(e => e.CodigoGrupoItem).HasColumnName("CODIGO_GRUPO_ITEM");
            entity.Property(e => e.EstadoGrupoItem).HasColumnName("ESTADO_GRUPO_ITEM");
            entity.Property(e => e.FechaGrupoItem)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_GRUPO_ITEM");
            entity.Property(e => e.IdCategoriaItem).HasColumnName("ID_CATEGORIA_ITEM");
            entity.Property(e => e.NombreGrupoItem).HasColumnName("NOMBRE_GRUPO_ITEM");

            entity.HasOne(d => d.IdCategoriaItemNavigation).WithMany(p => p.GrupoItems)
                .HasForeignKey(d => d.IdCategoriaItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRUPO_ITEM_CATEGORIA_ITEM");
        });

        modelBuilder.Entity<GrupoOcupacional>(entity =>
        {
            entity.HasKey(e => e.IdGrupoOcupacional);

            entity.ToTable("GRUPO_OCUPACIONAL");

            entity.Property(e => e.IdGrupoOcupacional)
                .ValueGeneratedNever()
                .HasColumnName("ID_GRUPO_OCUPACIONAL");
            entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
        });

        modelBuilder.Entity<GrupoStitio>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GRUPO_STITIO");

            entity.HasIndex(e => e.Grupo, "ug").IsUnique();

            entity.Property(e => e.DescDiff).HasColumnName("desc_diff");
            entity.Property(e => e.Grupo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("grupo");
        });

        modelBuilder.Entity<GrupoSuministro>(entity =>
        {
            entity.HasKey(e => e.IdGrupoSuministros);

            entity.ToTable("GRUPO_SUMINISTROS");

            entity.Property(e => e.IdGrupoSuministros)
                .ValueGeneratedNever()
                .HasColumnName("ID_GRUPO_SUMINISTROS");
            entity.Property(e => e.CategoriaGr).HasColumnName("CATEGORIA_GR");
            entity.Property(e => e.EstadoGrupoSuministros).HasColumnName("ESTADO_GRUPO_SUMINISTROS");
            entity.Property(e => e.GrupoGr).HasColumnName("GRUPO_GR");
            entity.Property(e => e.IdCategoriaSuministros).HasColumnName("ID_CATEGORIA_SUMINISTROS");
            entity.Property(e => e.NombreGrupoSuministros).HasColumnName("NOMBRE_GRUPO_SUMINISTROS");

            entity.HasOne(d => d.IdCategoriaSuministrosNavigation).WithMany(p => p.GrupoSuministros)
                .HasForeignKey(d => d.IdCategoriaSuministros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRUPO_SUMINISTROS_CATEGORIA_SUMINISTROS");
        });

        modelBuilder.Entity<GrupoUbicacion>(entity =>
        {
            entity.HasKey(e => e.IdGrupoUbicacion);

            entity.ToTable("GRUPO_UBICACION");

            entity.Property(e => e.IdGrupoUbicacion)
                .ValueGeneratedNever()
                .HasColumnName("ID_GRUPO_UBICACION");
            entity.Property(e => e.CasillerosTotalCategoriaUbicacion).HasColumnName("CASILLEROS_TOTAL_CATEGORIA_UBICACION");
            entity.Property(e => e.CasillerosUsadasCategoriaUbicacion).HasColumnName("CASILLEROS_USADAS_CATEGORIA_UBICACION");
            entity.Property(e => e.CasillerosVaciasCategoriaUbicacion).HasColumnName("CASILLEROS_VACIAS_CATEGORIA_UBICACION");
            entity.Property(e => e.EstadoGrupoUbicacion).HasColumnName("ESTADO_GRUPO_UBICACION");
            entity.Property(e => e.FechaGrupoUbicacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_GRUPO_UBICACION");
            entity.Property(e => e.IdBodega).HasColumnName("ID_BODEGA");
            entity.Property(e => e.IdCategoriaUbicacion).HasColumnName("ID_CATEGORIA_UBICACION");
            entity.Property(e => e.NombreGrupoUbicacion).HasColumnName("NOMBRE_GRUPO_UBICACION");

            entity.HasOne(d => d.IdCategoriaUbicacionNavigation).WithMany(p => p.GrupoUbicacions)
                .HasForeignKey(d => d.IdCategoriaUbicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRUPO_UBICACION_CATEGORIA_UBICACION");
        });

        modelBuilder.Entity<HistoriaLaboral>(entity =>
        {
            entity.HasKey(e => e.IdHistoriaLaboral);

            entity.ToTable("HISTORIA_LABORAL");

            entity.Property(e => e.IdHistoriaLaboral)
                .ValueGeneratedNever()
                .HasColumnName("ID_HISTORIA_LABORAL");
            entity.Property(e => e.DetalleHistoriaLaboral).HasColumnName("DETALLE_HISTORIA_LABORAL");
            entity.Property(e => e.EstadoHistoriaLaboral).HasColumnName("ESTADO_HISTORIA_LABORAL");
            entity.Property(e => e.FechaHistoriaLaboral)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HISTORIA_LABORAL");
            entity.Property(e => e.IdAux).HasColumnName("ID_AUX");
            entity.Property(e => e.IdPersonalHistoriaLaboral).HasColumnName("ID_PERSONAL_HISTORIA_LABORAL");
            entity.Property(e => e.IdSitioPuesto).HasColumnName("ID_SITIO_PUESTO");

            entity.HasOne(d => d.IdPersonalHistoriaLaboralNavigation).WithMany(p => p.HistoriaLaborals)
                .HasForeignKey(d => d.IdPersonalHistoriaLaboral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HISTORIA_LABORAL_PERSONAL");
        });

        modelBuilder.Entity<HistorialFacturacionCliente>(entity =>
        {
            entity.HasKey(e => e.IdHistorialFacturacion);

            entity.ToTable("HISTORIAL_FACTURACION_CLIENTE");

            entity.Property(e => e.IdHistorialFacturacion)
                .ValueGeneratedNever()
                .HasColumnName("ID_HISTORIAL_FACTURACION");
            entity.Property(e => e.CodigoHistorialFacturacion)
                .HasMaxLength(50)
                .HasColumnName("CODIGO_HISTORIAL_FACTURACION");
            entity.Property(e => e.CuentaHistorialFacturacion).HasColumnName("CUENTA_HISTORIAL_FACTURACION");
            entity.Property(e => e.EstadoHistorialFacturacion).HasColumnName("ESTADO_HISTORIAL_FACTURACION");
            entity.Property(e => e.FechaHistorialFacturacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HISTORIAL_FACTURACION");
            entity.Property(e => e.IdClienteGeneral).HasColumnName("ID_CLIENTE_GENERAL");
            entity.Property(e => e.IdFacturaVenta).HasColumnName("ID_FACTURA_VENTA");
        });

        modelBuilder.Entity<HistorialVehiculo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HISTORIAL_VEHICULOS");

            entity.Property(e => e.Aseguradora).HasColumnName("ASEGURADORA");
            entity.Property(e => e.Broker).HasColumnName("BROKER");
            entity.Property(e => e.CostoPrima)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("COSTO_PRIMA");
            entity.Property(e => e.DispositivoSeguridad).HasColumnName("DISPOSITIVO_SEGURIDAD");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.FechaFinalContrato)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_FINAL_CONTRATO");
            entity.Property(e => e.FechaFinalDisSeg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_FINAL_DIS_SEG");
            entity.Property(e => e.FechaInicioContrato)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO_CONTRATO");
            entity.Property(e => e.FechaInicioDisSeg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO_DIS_SEG");
            entity.Property(e => e.FechaRenovacionContrato)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_RENOVACION_CONTRATO");
            entity.Property(e => e.FechaRenovacionDisSeg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_RENOVACION_DIS_SEG");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.NroHistorial).HasColumnName("NRO_HISTORIAL");
            entity.Property(e => e.NroPoliza).HasColumnName("NRO_POLIZA");
            entity.Property(e => e.Seguro).HasColumnName("SEGURO");
            entity.Property(e => e.Soat)
                .HasColumnType("datetime")
                .HasColumnName("SOAT");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HISTORIAL_VEHICULOS_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<HorariosOperacion>(entity =>
        {
            entity.HasKey(e => e.IdHorario);

            entity.ToTable("HORARIOS_OPERACION");

            entity.Property(e => e.IdHorario)
                .ValueGeneratedNever()
                .HasColumnName("id_horario");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Detalle).HasColumnName("detalle");
            entity.Property(e => e.Dias).HasColumnName("dias");
            entity.Property(e => e.DoDi)
                .HasDefaultValue(1)
                .HasColumnName("do_di");
            entity.Property(e => e.Domingo).HasColumnName("domingo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.HoraCien)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("hora_cien");
            entity.Property(e => e.HoraCincuenta)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("hora_cincuenta");
            entity.Property(e => e.HoraRegular)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("hora_regular");
            entity.Property(e => e.JuDi)
                .HasDefaultValue(1)
                .HasColumnName("ju_di");
            entity.Property(e => e.Jueves).HasColumnName("jueves");
            entity.Property(e => e.LuDi)
                .HasDefaultValue(1)
                .HasColumnName("lu_di");
            entity.Property(e => e.Lunes).HasColumnName("lunes");
            entity.Property(e => e.MaDi)
                .HasDefaultValue(1)
                .HasColumnName("ma_di");
            entity.Property(e => e.Martes).HasColumnName("martes");
            entity.Property(e => e.MiDi)
                .HasDefaultValue(1)
                .HasColumnName("mi_di");
            entity.Property(e => e.Miercoles).HasColumnName("miercoles");
            entity.Property(e => e.Observacion).HasColumnName("observacion");
            entity.Property(e => e.RecargoNocturno)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("recargo_nocturno");
            entity.Property(e => e.SaDi)
                .HasDefaultValue(1)
                .HasColumnName("sa_di");
            entity.Property(e => e.Sabado).HasColumnName("sabado");
            entity.Property(e => e.Tipo)
                .HasDefaultValue(0)
                .HasColumnName("tipo");
            entity.Property(e => e.TotalHoras)
                .HasDefaultValueSql("('')")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total_horas");
            entity.Property(e => e.ViDi)
                .HasDefaultValue(1)
                .HasColumnName("vi_di");
            entity.Property(e => e.Viernes).HasColumnName("viernes");
        });

        modelBuilder.Entity<ImpuestoRetenido>(entity =>
        {
            entity.HasKey(e => e.IdImpuestoRetenido);

            entity.ToTable("IMPUESTO_RETENIDO");

            entity.Property(e => e.IdImpuestoRetenido)
                .ValueGeneratedNever()
                .HasColumnName("ID_IMPUESTO_RETENIDO");
            entity.Property(e => e.DescripcionImpuestoRetenido)
                .HasMaxLength(50)
                .HasColumnName("DESCRIPCION_IMPUESTO_RETENIDO");
            entity.Property(e => e.EstadoImpuestoRetenido)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ESTADO_IMPUESTO_RETENIDO");
        });

        modelBuilder.Entity<InformacionTributarium>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("INFORMACION_TRIBUTARIA");

            entity.Property(e => e.CtaIvaCn).HasColumnName("CTA_IVA_CN");
            entity.Property(e => e.CtaIvaCompra)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CTA_IVA_COMPRA");
            entity.Property(e => e.CtaIvaCompra2019)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CTA_IVA_COMPRA_2019");
            entity.Property(e => e.EstablecimientoFacturaIt)
                .HasMaxLength(50)
                .HasColumnName("ESTABLECIMIENTO_FACTURA_IT");
            entity.Property(e => e.EstablecimientoLiquidacionCompraIt)
                .HasMaxLength(50)
                .HasColumnName("ESTABLECIMIENTO_LIQUIDACION_COMPRA_IT");
            entity.Property(e => e.EstableciminetoComprobanteRetencionIt)
                .HasMaxLength(50)
                .HasColumnName("ESTABLECIMINETO_COMPROBANTE_RETENCION_IT");
            entity.Property(e => e.EstableciminetoNotaCreditoIt)
                .HasMaxLength(50)
                .HasColumnName("ESTABLECIMINETO_NOTA_CREDITO_IT");
            entity.Property(e => e.EstadoIt).HasColumnName("ESTADO_IT");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdInformacion).HasColumnName("ID_INFORMACION");
            entity.Property(e => e.NroAutorizacionCompRetencionIt)
                .HasMaxLength(50)
                .HasColumnName("NRO_AUTORIZACION_COMP_RETENCION_IT");
            entity.Property(e => e.NroAutorizacionFacturaIt)
                .HasMaxLength(50)
                .HasColumnName("NRO_AUTORIZACION_FACTURA_IT");
            entity.Property(e => e.NroAutorizacionLiquidacionCompraIt)
                .HasMaxLength(50)
                .HasColumnName("NRO_AUTORIZACION_LIQUIDACION_COMPRA_IT");
            entity.Property(e => e.NroAutorizacionNotaCreditoIt)
                .HasMaxLength(50)
                .HasColumnName("NRO_AUTORIZACION_NOTA_CREDITO_IT");
            entity.Property(e => e.NroResolucionAgenteRetencion)
                .HasMaxLength(50)
                .HasColumnName("NRO_RESOLUCION_AGENTE_RETENCION");
            entity.Property(e => e.PorcentajeIceIt).HasColumnName("PORCENTAJE_ICE_IT");
            entity.Property(e => e.PorcentajeIvaIt).HasColumnName("PORCENTAJE_IVA_IT");
            entity.Property(e => e.PuntoEmisionComprobanteRetencionIt)
                .HasMaxLength(50)
                .HasColumnName("PUNTO_EMISION_COMPROBANTE_RETENCION_IT");
            entity.Property(e => e.PuntoEmisionFacturaIt)
                .HasMaxLength(50)
                .HasColumnName("PUNTO_EMISION_FACTURA_IT");
            entity.Property(e => e.PuntoEmisionLiquidacionCompraIt)
                .HasMaxLength(50)
                .HasColumnName("PUNTO_EMISION_LIQUIDACION_COMPRA_IT");
            entity.Property(e => e.PuntoEmisionNotaCreditoIt)
                .HasMaxLength(50)
                .HasColumnName("PUNTO_EMISION_NOTA_CREDITO_IT");
            entity.Property(e => e.SecuencialComprobanteRetencionIt)
                .HasMaxLength(50)
                .HasColumnName("SECUENCIAL_COMPROBANTE_RETENCION_IT");
            entity.Property(e => e.SecuencialComprobanteRetencionIt3)
                .HasMaxLength(50)
                .HasColumnName("SECUENCIAL_COMPROBANTE_RETENCION_IT3");
            entity.Property(e => e.SecuencialComprobanteRetencionIt4)
                .HasMaxLength(50)
                .HasColumnName("SECUENCIAL_COMPROBANTE_RETENCION_IT4");
            entity.Property(e => e.SecuencialFacturaIt)
                .HasMaxLength(50)
                .HasColumnName("SECUENCIAL_FACTURA_IT");
            entity.Property(e => e.SecuencialFacturaIt3)
                .HasMaxLength(50)
                .HasColumnName("SECUENCIAL_FACTURA_IT3");
            entity.Property(e => e.SecuencialFacturaIt4)
                .HasMaxLength(50)
                .HasColumnName("SECUENCIAL_FACTURA_IT4");
            entity.Property(e => e.SecuencialLiquidacionCompraIt)
                .HasMaxLength(50)
                .HasColumnName("SECUENCIAL_LIQUIDACION_COMPRA_IT");
            entity.Property(e => e.SecuencialLiquidacionCompraIt3)
                .HasMaxLength(50)
                .HasColumnName("SECUENCIAL_LIQUIDACION_COMPRA_IT3");
            entity.Property(e => e.SecuencialLiquidacionCompraIt4)
                .HasMaxLength(50)
                .HasColumnName("SECUENCIAL_LIQUIDACION_COMPRA_IT4");
            entity.Property(e => e.SecuencialNotaCreditoIt)
                .HasMaxLength(50)
                .HasColumnName("SECUENCIAL_NOTA_CREDITO_IT");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany()
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_INFORMACION_TRIBUTARIA_EMPRESA_GENERAL");
        });

        modelBuilder.Entity<InventarioItem>(entity =>
        {
            entity.HasKey(e => e.IdInventarioItem);

            entity.ToTable("INVENTARIO_ITEM");

            entity.Property(e => e.IdInventarioItem)
                .ValueGeneratedNever()
                .HasColumnName("ID_INVENTARIO_ITEM");
            entity.Property(e => e.EstadoInventarioItem).HasColumnName("ESTADO_INVENTARIO_ITEM");
            entity.Property(e => e.FechaInventarioItem)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INVENTARIO_ITEM");
            entity.Property(e => e.IdBodega).HasColumnName("ID_BODEGA");
            entity.Property(e => e.NombreInventarioItem).HasColumnName("NOMBRE_INVENTARIO_ITEM");

            entity.HasOne(d => d.IdBodegaNavigation).WithMany(p => p.InventarioItems)
                .HasForeignKey(d => d.IdBodega)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INVENTARIO_ITEM_BODEGA");
        });

        modelBuilder.Entity<Kardex>(entity =>
        {
            entity.HasKey(e => e.IdKardex);

            entity.ToTable("KARDEX");

            entity.Property(e => e.IdKardex)
                .ValueGeneratedNever()
                .HasColumnName("ID_KARDEX");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdSecuencialItem).HasColumnName("ID_SECUENCIAL_ITEM");
        });

        modelBuilder.Entity<LibroColeccione>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LIBRO_COLECCIONES");

            entity.Property(e => e.AnosEdicion).HasColumnName("ANOS_EDICION");
            entity.Property(e => e.Autor).HasColumnName("AUTOR");
            entity.Property(e => e.Editorial).HasColumnName("EDITORIAL");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Tomos).HasColumnName("TOMOS");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LIBRO_COLECCIONES_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<LibroDiarioGeneral>(entity =>
        {
            entity.HasKey(e => e.IdLibroDiario);

            entity.ToTable("LIBRO_DIARIO_GENERAL");

            entity.Property(e => e.IdLibroDiario)
                .ValueGeneratedNever()
                .HasColumnName("ID_LIBRO_DIARIO");
            entity.Property(e => e.EstadoLibroDiario)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ESTADO_LIBRO_DIARIO");
            entity.Property(e => e.FechaLibroDiario)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_LIBRO_DIARIO");
            entity.Property(e => e.TotalDebeLibroDiario)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_DEBE_LIBRO_DIARIO");
            entity.Property(e => e.TotalHaberLibroDiario)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_HABER_LIBRO_DIARIO");
        });

        modelBuilder.Entity<LiquidacionCajaChica>(entity =>
        {
            entity.HasKey(e => e.IdLiquidacionCch);

            entity.ToTable("LIQUIDACION_CAJA_CHICA");

            entity.Property(e => e.IdLiquidacionCch)
                .ValueGeneratedNever()
                .HasColumnName("ID_LIQUIDACION_CCH");
            entity.Property(e => e.EstadoLiquidacionCch).HasColumnName("ESTADO_LIQUIDACION_CCH");
            entity.Property(e => e.FechaLiquidacionCch)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_LIQUIDACION_CCH");
            entity.Property(e => e.FondoLiquidacionCch)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("FONDO_LIQUIDACION_CCH");
            entity.Property(e => e.GastosLiquidacionCch)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GASTOS_LIQUIDACION_CCH");
            entity.Property(e => e.IdCajaCch).HasColumnName("ID_CAJA_CCH");
            entity.Property(e => e.IdCentroCostoCch).HasColumnName("ID_CENTRO_COSTO_CCH");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdProvincias).HasColumnName("ID_PROVINCIAS");
            entity.Property(e => e.NroAsiento).HasColumnName("NRO_ASIENTO");
            entity.Property(e => e.ReposicionLiquidacionCch)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("REPOSICION_LIQUIDACION_CCH");
            entity.Property(e => e.SaldoLiquidacionCch)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SALDO_LIQUIDACION_CCH");
            entity.Property(e => e.TotalLiquidacionCch)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_LIQUIDACION_CCH");
        });

        modelBuilder.Entity<LiquidacionCompra>(entity =>
        {
            entity.HasKey(e => e.IdLiquidacionCompras);

            entity.ToTable("LIQUIDACION_COMPRAS");

            entity.Property(e => e.IdLiquidacionCompras)
                .ValueGeneratedNever()
                .HasColumnName("ID_LIQUIDACION_COMPRAS");
            entity.Property(e => e.EstadoLiquidacionCompra).HasColumnName("ESTADO_LIQUIDACION_COMPRA");
            entity.Property(e => e.FechaAutoSriLiquidacionCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_AUTO_SRI_LIQUIDACION_COMPRA");
            entity.Property(e => e.FechaEmisionLiquidacionCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION_LIQUIDACION_COMPRA");
            entity.Property(e => e.IdComprobanteCompra).HasColumnName("ID_COMPROBANTE_COMPRA");
            entity.Property(e => e.IdProveedorGeneral).HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.IvaLiquidacionCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IVA_LIQUIDACION_COMPRA");
            entity.Property(e => e.NumAutoSriLiquidacionCompra)
                .HasMaxLength(50)
                .HasColumnName("NUM_AUTO_SRI_LIQUIDACION_COMPRA");
            entity.Property(e => e.NumeroLiquidacionCompras).HasColumnName("NUMERO_LIQUIDACION_COMPRAS");
            entity.Property(e => e.ObservacionComprobanteCompra)
                .HasMaxLength(1)
                .HasColumnName("OBSERVACION_COMPROBANTE_COMPRA");
            entity.Property(e => e.Subtotal0LiquidacionCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUBTOTAL_0_LIQUIDACION_COMPRA");
            entity.Property(e => e.Subtotal12LiquidacionCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUBTOTAL_12_LIQUIDACION_COMPRA");
            entity.Property(e => e.SubtotalLiquidacionCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUBTOTAL_LIQUIDACION_COMPRA");
            entity.Property(e => e.TotalLiquidacionCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_LIQUIDACION_COMPRA");
        });

        modelBuilder.Entity<LiquidacionFondoRotativo>(entity =>
        {
            entity.HasKey(e => e.IdLiquidacionFr);

            entity.ToTable("LIQUIDACION_FONDO_ROTATIVO");

            entity.Property(e => e.IdLiquidacionFr)
                .ValueGeneratedNever()
                .HasColumnName("ID_LIQUIDACION_FR");
            entity.Property(e => e.EstadoLiquidacionFr).HasColumnName("ESTADO_LIQUIDACION_FR");
            entity.Property(e => e.FechaLiquidacionFr)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_LIQUIDACION_FR");
            entity.Property(e => e.FondoLiquidacionFr)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("FONDO_LIQUIDACION_FR");
            entity.Property(e => e.GastosLiquidacionFr)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GASTOS_LIQUIDACION_FR");
            entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdProvicias).HasColumnName("ID_PROVICIAS");
            entity.Property(e => e.NroAsiento).HasColumnName("NRO_ASIENTO");
            entity.Property(e => e.ReposicionLiquidacionFr)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("REPOSICION_LIQUIDACION_FR");
            entity.Property(e => e.SaldoLiquidacionFr)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SALDO_LIQUIDACION_FR");
            entity.Property(e => e.TotalLiquidacion)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_LIQUIDACION");
        });

        modelBuilder.Entity<LlegadaVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdLlegadaV);

            entity.ToTable("LLEGADA_VEHICULO");

            entity.Property(e => e.IdLlegadaV)
                .ValueGeneratedNever()
                .HasColumnName("ID_LLEGADA_V");
            entity.Property(e => e.EstadoLlegadaV).HasColumnName("ESTADO_LLEGADA_V");
            entity.Property(e => e.FechaLlegadaV)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_LLEGADA_V");
            entity.Property(e => e.HoraLlegadaV).HasColumnName("HORA_LLEGADA_V");
            entity.Property(e => e.KmLlegadaV).HasColumnName("KM_LLEGADA_V");
        });

        modelBuilder.Entity<Logsql>(entity =>
        {
            entity.HasKey(e => e.IdLog);

            entity.ToTable("LOGSQL");

            entity.Property(e => e.IdLog)
                .ValueGeneratedNever()
                .HasColumnName("id_log");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasColumnName("nombre");
            entity.Property(e => e.Sqls).HasColumnName("sqls");
        });

        modelBuilder.Entity<Lote>(entity =>
        {
            entity.HasKey(e => e.IdLote);

            entity.ToTable("LOTE");

            entity.Property(e => e.IdLote)
                .ValueGeneratedNever()
                .HasColumnName("ID_LOTE");
            entity.Property(e => e.CaducidadLote)
                .HasColumnType("datetime")
                .HasColumnName("CADUCIDAD_LOTE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaLote)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_LOTE");
            entity.Property(e => e.NombreLote).HasColumnName("NOMBRE_LOTE");
        });

        modelBuilder.Entity<MarcaGeneral>(entity =>
        {
            entity.HasKey(e => e.IdMarca);

            entity.ToTable("MARCA_GENERAL");

            entity.Property(e => e.IdMarca)
                .ValueGeneratedNever()
                .HasColumnName("ID_MARCA");
            entity.Property(e => e.Detalle).HasColumnName("DETALLE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
        });

        modelBuilder.Entity<MaterialGeneral>(entity =>
        {
            entity.HasKey(e => e.IdMaterial);

            entity.ToTable("MATERIAL_GENERAL");

            entity.Property(e => e.IdMaterial)
                .ValueGeneratedNever()
                .HasColumnName("ID_MATERIAL");
            entity.Property(e => e.Detalle).HasColumnName("DETALLE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
        });

        modelBuilder.Entity<MayorGeneral>(entity =>
        {
            entity.HasKey(e => e.IdMayor);

            entity.ToTable("MAYOR_GENERAL");

            entity.Property(e => e.IdMayor)
                .ValueGeneratedNever()
                .HasColumnName("ID_MAYOR");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.CodigoPadre).HasColumnName("CODIGO_PADRE");
            entity.Property(e => e.DeudorAcreedor).HasColumnName("DEUDOR_ACREEDOR");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.TotalAcreedor)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("TOTAL_ACREEDOR");
            entity.Property(e => e.TotalDebe)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("TOTAL_DEBE");
            entity.Property(e => e.TotalDeudor)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("TOTAL_DEUDOR");
            entity.Property(e => e.TotalHaber)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("TOTAL_HABER");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("migrations");

            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.Migration1)
                .HasMaxLength(255)
                .HasColumnName("migration");
        });

        modelBuilder.Entity<ModeloGeneral>(entity =>
        {
            entity.HasKey(e => e.IdModelo);

            entity.ToTable("MODELO_GENERAL");

            entity.Property(e => e.IdModelo)
                .ValueGeneratedNever()
                .HasColumnName("ID_MODELO");
            entity.Property(e => e.Detalle).HasColumnName("DETALLE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
        });

        modelBuilder.Entity<MueblesOficina>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MUEBLES_OFICINA");

            entity.Property(e => e.Ano).HasColumnName("ANO");
            entity.Property(e => e.Color).HasColumnName("COLOR");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoActivo).HasColumnName("ESTADO_ACTIVO");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Material).HasColumnName("MATERIAL");
            entity.Property(e => e.Modelo).HasColumnName("MODELO");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MUEBLES_OFICINA_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<NotaCreditoVentum>(entity =>
        {
            entity.HasKey(e => e.IdNotaCredito);

            entity.ToTable("NOTA_CREDITO_VENTA");

            entity.Property(e => e.IdNotaCredito)
                .ValueGeneratedNever()
                .HasColumnName("ID_NOTA_CREDITO");
            entity.Property(e => e.EstadoNotaCredito).HasColumnName("ESTADO_NOTA_CREDITO");
            entity.Property(e => e.FechaAutoSriNotaCredito)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_AUTO_SRI_NOTA_CREDITO");
            entity.Property(e => e.FechaEmisionNotaCredito)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION_NOTA_CREDITO");
            entity.Property(e => e.IdClienteGeneral).HasColumnName("ID_CLIENTE_GENERAL");
            entity.Property(e => e.IdFacturaVenta).HasColumnName("ID_FACTURA_VENTA");
            entity.Property(e => e.IvaNotaCredito)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("IVA_NOTA_CREDITO");
            entity.Property(e => e.NumAutoSriNotaCredito)
                .HasMaxLength(50)
                .HasColumnName("NUM_AUTO_SRI_NOTA_CREDITO");
            entity.Property(e => e.NumDocModificacionNotaCredito)
                .HasMaxLength(50)
                .HasColumnName("NUM_DOC_MODIFICACION_NOTA_CREDITO");
            entity.Property(e => e.NumeroNotaCredito)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_NOTA_CREDITO");
            entity.Property(e => e.PorcentajeIvaNotaCredito).HasColumnName("PORCENTAJE_IVA_NOTA_CREDITO");
            entity.Property(e => e.RazonModificacionNotaCredito).HasColumnName("RAZON_MODIFICACION_NOTA_CREDITO");
            entity.Property(e => e.Subtotal0TotaCredito)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("SUBTOTAL_0_TOTA_CREDITO");
            entity.Property(e => e.Subtotal12NotaCredito)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("SUBTOTAL_12_NOTA_CREDITO");
            entity.Property(e => e.SubtotalNotaCredito)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("SUBTOTAL_NOTA_CREDITO");
            entity.Property(e => e.TotalNotaCredito)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("TOTAL_NOTA_CREDITO");
        });

        modelBuilder.Entity<NotaDebitoCompra>(entity =>
        {
            entity.HasKey(e => e.IdNotaDebitoCompra);

            entity.ToTable("NOTA_DEBITO_COMPRA");

            entity.Property(e => e.IdNotaDebitoCompra)
                .ValueGeneratedNever()
                .HasColumnName("ID_NOTA_DEBITO_COMPRA");
            entity.Property(e => e.EstadoNotaDebitoCompra).HasColumnName("ESTADO_NOTA_DEBITO_COMPRA");
            entity.Property(e => e.FechaAutoSriNotaDebitoCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_AUTO_SRI_NOTA_DEBITO_COMPRA");
            entity.Property(e => e.FechaEmisionNotaDebitoCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION_NOTA_DEBITO_COMPRA");
            entity.Property(e => e.IvaNotaDebitoCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IVA_NOTA_DEBITO_COMPRA");
            entity.Property(e => e.NumAutoSriNotaDebitoCompra)
                .HasMaxLength(50)
                .HasColumnName("NUM_AUTO_SRI_NOTA_DEBITO_COMPRA");
            entity.Property(e => e.NumeroNotaDebitoCompra)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_NOTA_DEBITO_COMPRA");
            entity.Property(e => e.RazonModificacionNotaDebitoCompra).HasColumnName("RAZON_MODIFICACION_NOTA_DEBITO_COMPRA");
            entity.Property(e => e.TotalNotaDebitoCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_NOTA_DEBITO_COMPRA");
        });

        modelBuilder.Entity<NotaVentaCompra>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NOTA_VENTA_COMPRA");

            entity.Property(e => e.EstadoNotaVentaCompra).HasColumnName("ESTADO_NOTA_VENTA_COMPRA");
            entity.Property(e => e.FechaAutoSriNotaVentaCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_AUTO_SRI_NOTA_VENTA_COMPRA");
            entity.Property(e => e.FechaEmisionNotaVentaCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION_NOTA_VENTA_COMPRA");
            entity.Property(e => e.IdNotaVentaCompra).HasColumnName("ID_NOTA_VENTA_COMPRA");
            entity.Property(e => e.IdProveedorGeneral).HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.NumAutoSriNotaVentaCompra)
                .HasMaxLength(50)
                .HasColumnName("NUM_AUTO_SRI_NOTA_VENTA_COMPRA");
            entity.Property(e => e.NumeroNotaVentaCompra)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_NOTA_VENTA_COMPRA");
            entity.Property(e => e.TotalNotaVentaCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_NOTA_VENTA_COMPRA");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__notes__0D3BA212");

            entity.ToTable("notes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Note1).HasColumnName("note");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<NotificacionesDenuncia>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK_ID_NOTIFICACION");

            entity.ToTable("NOTIFICACIONES_DENUNCIAS");

            entity.Property(e => e.IdNotificacion)
                .ValueGeneratedNever()
                .HasColumnName("ID_NOTIFICACION");
            entity.Property(e => e.ApellidosNombres).HasColumnName("APELLIDOS_NOMBRES");
            entity.Property(e => e.Cedularuc).HasColumnName("CEDULARUC");
            entity.Property(e => e.DetalleNotificacion).HasColumnName("DETALLE_NOTIFICACION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaNotificacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_NOTIFICACION");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.NumNotificacion).HasColumnName("NUM_NOTIFICACION");
        });

        modelBuilder.Entity<NroComprobanteBodega>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NRO_COMPROBANTE_BODEGA");

            entity.Property(e => e.Ajuste).HasColumnName("AJUSTE");
            entity.Property(e => e.Donacion).HasColumnName("DONACION");
            entity.Property(e => e.Egreso).HasColumnName("EGRESO");
            entity.Property(e => e.Ingreso).HasColumnName("INGRESO");
            entity.Property(e => e.Reingreso).HasColumnName("REINGRESO");
        });

        modelBuilder.Entity<NumeroRegistroAsiento>(entity =>
        {
            entity.HasKey(e => e.NumeroRegistro);

            entity.ToTable("NUMERO_REGISTRO_ASIENTOS");

            entity.Property(e => e.NumeroRegistro)
                .ValueGeneratedNever()
                .HasColumnName("NUMERO_REGISTRO");
            entity.Property(e => e.NumeroAnterior).HasColumnName("NUMERO_ANTERIOR");
        });

        modelBuilder.Entity<NumeroRegistroAsientosComprobanteCompra>(entity =>
        {
            entity.HasKey(e => e.IdComprobanteCompra);

            entity.ToTable("NUMERO_REGISTRO_ASIENTOS_COMPROBANTE_COMPRA");

            entity.Property(e => e.IdComprobanteCompra)
                .ValueGeneratedNever()
                .HasColumnName("ID_COMPROBANTE_COMPRA");
            entity.Property(e => e.IdAsiento).HasColumnName("ID_ASIENTO");
            entity.Property(e => e.IdLibroDiario).HasColumnName("ID_LIBRO_DIARIO");
            entity.Property(e => e.NumeroRegistro).HasColumnName("NUMERO_REGISTRO");
        });

        modelBuilder.Entity<NumeroRegistroAsientosComprobanteEgreso>(entity =>
        {
            entity.HasKey(e => e.TempId);

            entity.ToTable("NUMERO_REGISTRO_ASIENTOS_COMPROBANTE_EGRESO");

            entity.Property(e => e.TempId).HasColumnName("TempID");
            entity.Property(e => e.IdAsiento).HasColumnName("ID_ASIENTO");
            entity.Property(e => e.IdComprobanteEgresoBancos).HasColumnName("ID_COMPROBANTE_EGRESO_BANCOS");
            entity.Property(e => e.IdLibroDiario).HasColumnName("ID_LIBRO_DIARIO");
            entity.Property(e => e.NumeroRegistro).HasColumnName("NUMERO_REGISTRO");
        });

        modelBuilder.Entity<NumeroRegistroAsientosComprobanteIngreso>(entity =>
        {
            entity.HasKey(e => e.TempId);

            entity.ToTable("NUMERO_REGISTRO_ASIENTOS_COMPROBANTE_INGRESO");

            entity.Property(e => e.TempId).HasColumnName("TempID");
            entity.Property(e => e.IdAsiento).HasColumnName("ID_ASIENTO");
            entity.Property(e => e.IdComprobanteIngresoBancos).HasColumnName("ID_COMPROBANTE_INGRESO_BANCOS");
            entity.Property(e => e.IdLibroDiario).HasColumnName("ID_LIBRO_DIARIO");
            entity.Property(e => e.NumeroRegistro).HasColumnName("NUMERO_REGISTRO");
        });

        modelBuilder.Entity<NumeroRegistroAsientosFacturaVentum>(entity =>
        {
            entity.HasKey(e => e.IdFacturaVenta);

            entity.ToTable("NUMERO_REGISTRO_ASIENTOS_FACTURA_VENTA");

            entity.Property(e => e.IdFacturaVenta)
                .ValueGeneratedNever()
                .HasColumnName("ID_FACTURA_VENTA");
            entity.Property(e => e.IdAsiento).HasColumnName("ID_ASIENTO");
            entity.Property(e => e.IdLibroDiario).HasColumnName("ID_LIBRO_DIARIO");
            entity.Property(e => e.NumeroRegistro).HasColumnName("NUMERO_REGISTRO");
        });

        modelBuilder.Entity<NumeroRegistroAsientosNotaCreditoVentum>(entity =>
        {
            entity.HasKey(e => e.IdNotaCredito);

            entity.ToTable("NUMERO_REGISTRO_ASIENTOS_NOTA_CREDITO_VENTA");

            entity.Property(e => e.IdNotaCredito)
                .ValueGeneratedNever()
                .HasColumnName("ID_NOTA_CREDITO");
            entity.Property(e => e.IdAsiento).HasColumnName("ID_ASIENTO_");
            entity.Property(e => e.IdLibroDiario).HasColumnName("ID_LIBRO_DIARIO");
            entity.Property(e => e.NumeroRegistro).HasColumnName("NUMERO_REGISTRO");
        });

        modelBuilder.Entity<OrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdOrdenCompra);

            entity.ToTable("ORDEN_COMPRA");

            entity.Property(e => e.IdOrdenCompra)
                .ValueGeneratedNever()
                .HasColumnName("ID_ORDEN_COMPRA");
            entity.Property(e => e.DescuentoOrdenCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DESCUENTO_ORDEN_COMPRA");
            entity.Property(e => e.EstadoOrdenCompra).HasColumnName("ESTADO_ORDEN_COMPRA");
            entity.Property(e => e.FechaOrdenCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ORDEN_COMPRA");
            entity.Property(e => e.FormaPagoOrdenCompra)
                .HasMaxLength(50)
                .HasColumnName("FORMA_PAGO_ORDEN_COMPRA");
            entity.Property(e => e.IdProveedorGeneral).HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.IdRequisicion).HasColumnName("ID_REQUISICION");
            entity.Property(e => e.IvaOrdenCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IVA_ORDEN_COMPRA");
            entity.Property(e => e.ObservacionesOrdenCompra).HasColumnName("OBSERVACIONES_ORDEN_COMPRA");
            entity.Property(e => e.Subtotal0OrdenCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUBTOTAL_0_ORDEN_COMPRA");
            entity.Property(e => e.Subtotal12OrdenCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUBTOTAL_12_ORDEN_COMPRA");
            entity.Property(e => e.TipoPagoOrdenCompra)
                .HasMaxLength(50)
                .HasColumnName("TIPO_PAGO_ORDEN_COMPRA");
            entity.Property(e => e.TotalOrdenCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_ORDEN_COMPRA");

            entity.HasOne(d => d.IdProveedorGeneralNavigation).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.IdProveedorGeneral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDEN_COMPRA_PROVEEDOR_GENERAL");
        });

        modelBuilder.Entity<OrdenTecnicaSupervision>(entity =>
        {
            entity.HasKey(e => e.IdOrden).HasName("PK_ID_ORDEN");

            entity.ToTable("ORDEN_TECNICA_SUPERVISION");

            entity.Property(e => e.IdOrden)
                .ValueGeneratedNever()
                .HasColumnName("ID_ORDEN");
            entity.Property(e => e.ApellidosNombres).HasColumnName("APELLIDOS_NOMBRES");
            entity.Property(e => e.Cedularuc).HasColumnName("CEDULARUC");
            entity.Property(e => e.DetalleNotificacion).HasColumnName("DETALLE_NOTIFICACION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaOrden)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ORDEN");
            entity.Property(e => e.FechaPendiente)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_PENDIENTE");
            entity.Property(e => e.FechaRealizado)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REALIZADO");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.FechaRevision)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REVISION");
            entity.Property(e => e.IdClienteGeneral).HasColumnName("ID_CLIENTE_GENERAL");
            entity.Property(e => e.IdSeg).HasColumnName("ID_SEG");
            entity.Property(e => e.Tipo).HasColumnName("TIPO");
        });

        modelBuilder.Entity<PagosComprobantesCompra>(entity =>
        {
            entity.HasKey(e => e.IdPagosComprobanteCompra).HasName("PK_PAGOS_FACTURA_COMPRA");

            entity.ToTable("PAGOS_COMPROBANTES_COMPRA");

            entity.Property(e => e.IdPagosComprobanteCompra)
                .ValueGeneratedNever()
                .HasColumnName("ID_PAGOS_COMPROBANTE_COMPRA");
            entity.Property(e => e.EstadoPagosComprobanteCompra).HasColumnName("ESTADO_PAGOS_COMPROBANTE_COMPRA");
            entity.Property(e => e.FechaPagosComprobanteCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_PAGOS_COMPROBANTE_COMPRA");
            entity.Property(e => e.IdComprobanteCompra).HasColumnName("ID_COMPROBANTE_COMPRA");
            entity.Property(e => e.IdComprobanteEgresoBancos).HasColumnName("ID_COMPROBANTE_EGRESO_BANCOS");
            entity.Property(e => e.IdProveedorGeneral).HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.MontoPagosComprobanteCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MONTO_PAGOS_COMPROBANTE_COMPRA");
            entity.Property(e => e.NumeroPagosComprobanteCompra).HasColumnName("NUMERO_PAGOS_COMPROBANTE_COMPRA");
            entity.Property(e => e.SaldoPagosComprobanteCompra)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SALDO_PAGOS_COMPROBANTE_COMPRA");
        });

        modelBuilder.Entity<PagosFacturaVentum>(entity =>
        {
            entity.HasKey(e => e.IdPagoFacturaVenta);

            entity.ToTable("PAGOS_FACTURA_VENTA");

            entity.Property(e => e.IdPagoFacturaVenta)
                .ValueGeneratedNever()
                .HasColumnName("ID_PAGO_FACTURA_VENTA");
            entity.Property(e => e.EstadoPagoFacturaVenta).HasColumnName("ESTADO_PAGO_FACTURA_VENTA");
            entity.Property(e => e.FechaPagoFacturaCompra)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_PAGO_FACTURA_COMPRA");
            entity.Property(e => e.FormaPagoFacturaVenta)
                .HasMaxLength(50)
                .HasColumnName("FORMA_PAGO_FACTURA_VENTA");
            entity.Property(e => e.IdClienteGeneral).HasColumnName("ID_CLIENTE_GENERAL");
            entity.Property(e => e.IdComprobanteIngresoBancos).HasColumnName("ID_COMPROBANTE_INGRESO_BANCOS");
            entity.Property(e => e.IdFacturaVenta).HasColumnName("ID_FACTURA_VENTA");
            entity.Property(e => e.MontoPagoFacturaVenta)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("MONTO_PAGO_FACTURA_VENTA");
            entity.Property(e => e.NumeroPagoFacturaVenta).HasColumnName("NUMERO_PAGO_FACTURA_VENTA");
            entity.Property(e => e.SaldoPagoFacturaVenta)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("SALDO_PAGO_FACTURA_VENTA");
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.IdPaises);

            entity.ToTable("PAISES");

            entity.Property(e => e.IdPaises)
                .ValueGeneratedNever()
                .HasColumnName("ID_PAISES");
            entity.Property(e => e.EstadoPaises).HasColumnName("ESTADO_PAISES");
            entity.Property(e => e.NombrePaises)
                .HasMaxLength(50)
                .HasColumnName("NOMBRE_PAISES");
        });

        modelBuilder.Entity<ParametrosRolPago>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PARAMETROS_ROL_PAGO");

            entity.Property(e => e.AnticipoUtilidadMes)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ANTICIPO_UTILIDAD_MES");
            entity.Property(e => e.CostoHoras)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("COSTO_HORAS");
            entity.Property(e => e.CostoHoras100)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("COSTO_HORAS_100");
            entity.Property(e => e.CostoHoras50)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("COSTO_HORAS_50");
            entity.Property(e => e.OtrosDescAdmi)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("OTROS_DESC_ADMI");
            entity.Property(e => e.OtrosDescVigi)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("OTROS_DESC_VIGI");
            entity.Property(e => e.PorcenAportePatronal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PORCEN_APORTE_PATRONAL");
            entity.Property(e => e.PorcentajeDesMed)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PORCENTAJE_DES_MED");
            entity.Property(e => e.PorcentajeExtSal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PORCENTAJE_EXT_SAL");
            entity.Property(e => e.ProcenAportePersonal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PROCEN_APORTE_PERSONAL");
            entity.Property(e => e.ProcentajeFondoReserva)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PROCENTAJE_FONDO_RESERVA");
            entity.Property(e => e.QuinceAdSbEx).HasColumnName("QUINCE_AD_SB_EX");
            entity.Property(e => e.SueldoBasicoUnificado)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUELDO_BASICO_UNIFICADO");
            entity.Property(e => e.SueldoVigilantes)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUELDO_VIGILANTES");
            entity.Property(e => e.ValorAnticipoGuardias)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_ANTICIPO_GUARDIAS");
        });

        modelBuilder.Entity<Parroquia>(entity =>
        {
            entity.HasKey(e => e.IdParroquias);

            entity.ToTable("PARROQUIAS");

            entity.Property(e => e.IdParroquias)
                .ValueGeneratedNever()
                .HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.EstadoParroquias).HasColumnName("ESTADO_PARROQUIAS");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.NombreParroquias).HasColumnName("NOMBRE_PARROQUIAS");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Parroquia)
                .HasForeignKey(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PARROQUIAS_CIUDADES");
        });

        modelBuilder.Entity<PasswordReset>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("password_resets");

            entity.HasIndex(e => e.Email, "password_resets_email_index");

            entity.HasIndex(e => e.Token, "password_resets_token_index");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .HasColumnName("token");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.IdPersonal);

            entity.ToTable("PERSONAL");

            entity.HasIndex(e => e.Cedula, "CEDULA").IsUnique();

            entity.Property(e => e.IdPersonal)
                .ValueGeneratedNever()
                .HasColumnName("ID_PERSONAL");
            entity.Property(e => e.AQuienAdeuda).HasColumnName("A_QUIEN_ADEUDA");
            entity.Property(e => e.AnteriorTrabajo).HasColumnName("ANTERIOR_TRABAJO");
            entity.Property(e => e.Apellidos).HasColumnName("APELLIDOS");
            entity.Property(e => e.Arriendo).HasColumnName("ARRIENDO");
            entity.Property(e => e.CantidadDeuda)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CANTIDAD_DEUDA");
            entity.Property(e => e.CantidadHijos).HasColumnName("CANTIDAD_HIJOS");
            entity.Property(e => e.CargoAnteriorTrabajo).HasColumnName("CARGO_ANTERIOR_TRABAJO");
            entity.Property(e => e.CarnetConadis).HasColumnName("CARNET_CONADIS");
            entity.Property(e => e.Casa).HasColumnName("CASA");
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .HasColumnName("CEDULA");
            entity.Property(e => e.Ciudad).HasColumnName("CIUDAD");
            entity.Property(e => e.Credencial).HasColumnName("CREDENCIAL");
            entity.Property(e => e.CursoVigilante).HasColumnName("CURSO_VIGILANTE");
            entity.Property(e => e.DatosEmergencia)
                .HasColumnType("text")
                .HasColumnName("DATOS_EMERGENCIA");
            entity.Property(e => e.DatosEsposa)
                .HasColumnType("text")
                .HasColumnName("DATOS_ESPOSA");
            entity.Property(e => e.DatosFamiliares)
                .HasColumnType("text")
                .HasColumnName("DATOS_FAMILIARES");
            entity.Property(e => e.DatosHijos)
                .HasColumnType("text")
                .HasColumnName("DATOS_HIJOS");
            entity.Property(e => e.DeudorGarante).HasColumnName("DEUDOR_GARANTE");
            entity.Property(e => e.Direccion).HasColumnName("DIRECCION");
            entity.Property(e => e.Discapacidad).HasColumnName("DISCAPACIDAD");
            entity.Property(e => e.Edad).HasColumnName("EDAD");
            entity.Property(e => e.Email).HasColumnName("EMAIL");
            entity.Property(e => e.EmisorCursoVigilante).HasColumnName("EMISOR_CURSO_VIGILANTE");
            entity.Property(e => e.EntradaAnterior)
                .HasColumnType("datetime")
                .HasColumnName("ENTRADA_ANTERIOR");
            entity.Property(e => e.EstadoCivil).HasColumnName("ESTADO_CIVIL");
            entity.Property(e => e.EstadoPersonal).HasColumnName("ESTADO_PERSONAL");
            entity.Property(e => e.Estatura)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ESTATURA");
            entity.Property(e => e.ExamenPsicologico).HasColumnName("EXAMEN_PSICOLOGICO");
            entity.Property(e => e.FechaEntrada)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ENTRADA");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_NACIMIENTO");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_SALIDA");
            entity.Property(e => e.Foto)
                .HasColumnType("image")
                .HasColumnName("FOTO");
            entity.Property(e => e.HistoriaClinica).HasColumnName("HISTORIA_CLINICA");
            entity.Property(e => e.IdArea).HasColumnName("ID_AREA");
            entity.Property(e => e.IdCargoOcupacional).HasColumnName("ID_CARGO_OCUPACIONAL");
            entity.Property(e => e.Instruccion).HasColumnName("INSTRUCCION");
            entity.Property(e => e.LibretaMilitar)
                .HasMaxLength(20)
                .HasColumnName("LIBRETA_MILITAR");
            entity.Property(e => e.LugarExamenPsicologico).HasColumnName("LUGAR_EXAMEN_PSICOLOGICO");
            entity.Property(e => e.MotivoSalidaTrabajo).HasColumnName("MOTIVO_SALIDA_TRABAJO");
            entity.Property(e => e.Movil).HasColumnName("MOVIL");
            entity.Property(e => e.Nombres).HasColumnName("NOMBRES");
            entity.Property(e => e.NombresPatronoAnterior).HasColumnName("NOMBRES_PATRONO_ANTERIOR");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.Parroquia).HasColumnName("PARROQUIA");
            entity.Property(e => e.Pasaporte)
                .HasMaxLength(20)
                .HasColumnName("PASAPORTE");
            entity.Property(e => e.Perfil)
                .HasColumnType("image")
                .HasColumnName("PERFIL");
            entity.Property(e => e.Peso).HasColumnName("PESO");
            entity.Property(e => e.Provincia).HasColumnName("PROVINCIA");
            entity.Property(e => e.PruebaAntidroga)
                .HasMaxLength(20)
                .HasColumnName("PRUEBA_ANTIDROGA");
            entity.Property(e => e.Recomendaciones)
                .HasColumnType("text")
                .HasColumnName("RECOMENDACIONES");
            entity.Property(e => e.SalidaAnterior)
                .HasColumnType("datetime")
                .HasColumnName("SALIDA_ANTERIOR");
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .HasColumnName("SEXO");
            entity.Property(e => e.Sueldo)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUELDO");
            entity.Property(e => e.Telefono).HasColumnName("TELEFONO");
            entity.Property(e => e.TelefonoPatronoAnterior).HasColumnName("TELEFONO_PATRONO_ANTERIOR");
            entity.Property(e => e.TipoSangre)
                .HasMaxLength(5)
                .HasColumnName("TIPO_SANGRE");
            entity.Property(e => e.TrabajoAteriormente).HasColumnName("TRABAJO_ATERIORMENTE");
            entity.Property(e => e.Ubicacion).HasColumnName("UBICACION");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PERSONAL_AREA_GENERAL");

            entity.HasOne(d => d.IdCargoOcupacionalNavigation).WithMany(p => p.Personals)
                .HasForeignKey(d => d.IdCargoOcupacional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PERSONAL_CARGO_OCUPACIONAL");
        });

        modelBuilder.Entity<PlanCuentasGeneral>(entity =>
        {
            entity.HasKey(e => e.IdPlan);

            entity.ToTable("PLAN_CUENTAS_GENERAL");

            entity.Property(e => e.IdPlan)
                .ValueGeneratedNever()
                .HasColumnName("ID_PLAN");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.Detalle).HasColumnName("DETALLE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoContable).HasColumnName("ESTADO_CONTABLE");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.Movimiento).HasColumnName("MOVIMIENTO");
            entity.Property(e => e.Nivel).HasColumnName("NIVEL");
            entity.Property(e => e.PadreCuenta).HasColumnName("PADRE_CUENTA");
            entity.Property(e => e.Presupuesto).HasColumnName("PRESUPUESTO");
            entity.Property(e => e.TipoCuenta).HasColumnName("TIPO_CUENTA");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.PlanCuentasGenerals)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PLAN_CUENTAS_GENERAL_EMPRESA_GENERAL");
        });

        modelBuilder.Entity<PlanillaCobrosPago>(entity =>
        {
            entity.HasKey(e => e.IdPlanilla);

            entity.ToTable("PLANILLA_COBROS_PAGOS");

            entity.Property(e => e.IdPlanilla)
                .ValueGeneratedNever()
                .HasColumnName("ID_PLANILLA");
            entity.Property(e => e.Beneficiario).HasColumnName("BENEFICIARIO");
            entity.Property(e => e.CantCuentas).HasColumnName("CANT_CUENTAS");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaProceso)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_PROCESO");
            entity.Property(e => e.FechaVence)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_VENCE");
            entity.Property(e => e.NumComprobante).HasColumnName("NUM_COMPROBANTE");
            entity.Property(e => e.NumCuenta).HasColumnName("NUM_CUENTA");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.Referencia).HasColumnName("REFERENCIA");
            entity.Property(e => e.TipoCuenta).HasColumnName("TIPO_CUENTA");
            entity.Property(e => e.TipoNegociacion).HasColumnName("TIPO_NEGOCIACION");
            entity.Property(e => e.TipoServicio).HasColumnName("TIPO_SERVICIO");
            entity.Property(e => e.TotalCuentas)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_CUENTAS");
        });

        modelBuilder.Entity<PorcentajeRet>(entity =>
        {
            entity.HasKey(e => e.IdPorcentajeRetencion).HasName("PK_PORCENTAJE_RETENCION");

            entity.ToTable("PORCENTAJE_RET");

            entity.Property(e => e.IdPorcentajeRetencion)
                .ValueGeneratedNever()
                .HasColumnName("ID_PORCENTAJE_RETENCION");
            entity.Property(e => e.CantidadPorcentajeRetencion)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("CANTIDAD_PORCENTAJE_RETENCION");
            entity.Property(e => e.IdConceptoPago).HasColumnName("ID_CONCEPTO_PAGO");
            entity.Property(e => e.IdContribuyenteRetenido).HasColumnName("ID_CONTRIBUYENTE_RETENIDO");
            entity.Property(e => e.IdImpuestoRetenido).HasColumnName("ID_IMPUESTO_RETENIDO");

            entity.HasOne(d => d.IdConceptoPagoNavigation).WithMany(p => p.PorcentajeRets)
                .HasForeignKey(d => d.IdConceptoPago)
                .HasConstraintName("FK_PORCENTAJE_RETENCION_CONCEPTO_PAGO");

            entity.HasOne(d => d.IdContribuyenteRetenidoNavigation).WithMany(p => p.PorcentajeRets)
                .HasForeignKey(d => d.IdContribuyenteRetenido)
                .HasConstraintName("FK_PORCENTAJE_RETENCION_CONTRIBUYENTE_RETENIDO");

            entity.HasOne(d => d.IdImpuestoRetenidoNavigation).WithMany(p => p.PorcentajeRets)
                .HasForeignKey(d => d.IdImpuestoRetenido)
                .HasConstraintName("FK_PORCENTAJE_RETENCION_IMPUESTO_RETENIDO");
        });

        modelBuilder.Entity<PorcentajeRetencion>(entity =>
        {
            entity.HasKey(e => e.IdPorcentajeRetencion).HasName("PK_PORCENTAJE_RETENCION_1");

            entity.ToTable("PORCENTAJE_RETENCION");

            entity.Property(e => e.IdPorcentajeRetencion)
                .ValueGeneratedNever()
                .HasColumnName("ID_PORCENTAJE_RETENCION");
            entity.Property(e => e.CantidadPorcentajeRetencion)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CANTIDAD_PORCENTAJE_RETENCION");
            entity.Property(e => e.CuentaCompra)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CUENTA_COMPRA");
            entity.Property(e => e.CuentaVenta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CUENTA_VENTA");
            entity.Property(e => e.IdConceptoPago).HasColumnName("ID_CONCEPTO_PAGO");
            entity.Property(e => e.IdContribuyenteRetenido).HasColumnName("ID_CONTRIBUYENTE_RETENIDO");
            entity.Property(e => e.IdImpuestoRetenido).HasColumnName("ID_IMPUESTO_RETENIDO");
            entity.Property(e => e.TipoBS).HasColumnName("TIPO_B_S");
        });

        modelBuilder.Entity<PrametrosDocumento>(entity =>
        {
            entity.HasKey(e => e.IdParametroDocumentos);

            entity.ToTable("PRAMETROS_DOCUMENTOS");

            entity.Property(e => e.IdParametroDocumentos)
                .ValueGeneratedNever()
                .HasColumnName("ID_PARAMETRO_DOCUMENTOS");
            entity.Property(e => e.EstadoParametroDocumentos).HasColumnName("ESTADO_PARAMETRO_DOCUMENTOS");
            entity.Property(e => e.NombreParametroDocumentos).HasColumnName("NOMBRE_PARAMETRO_DOCUMENTOS");
            entity.Property(e => e.TipoParametroDocumentos).HasColumnName("TIPO_PARAMETRO_DOCUMENTOS");
        });

        modelBuilder.Entity<ProductoCisepro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PRODUCTO_CISEPRO");

            entity.Property(e => e.EstadoProducto).HasColumnName("ESTADO_PRODUCTO");
            entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(50)
                .HasColumnName("NOMBRE_PRODUCTO");
        });

        modelBuilder.Entity<ProgramacionOperativo>(entity =>
        {
            entity.HasKey(e => e.IdProgramacion).HasName("PK__PROGRAMACION__22C0CEDD");

            entity.ToTable("PROGRAMACION_OPERATIVOS");

            entity.Property(e => e.IdProgramacion)
                .ValueGeneratedNever()
                .HasColumnName("ID_PROGRAMACION");
            entity.Property(e => e.AnioProgramacion).HasColumnName("ANIO_PROGRAMACION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaDesde)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_DESDE");
            entity.Property(e => e.FechaHasta)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HASTA");
            entity.Property(e => e.MesProgramacion).HasColumnName("MES_PROGRAMACION");
        });

        modelBuilder.Entity<ProveedorCalificado>(entity =>
        {
            entity.HasKey(e => e.IdProveedorCalificado);

            entity.ToTable("PROVEEDOR_CALIFICADO");

            entity.Property(e => e.IdProveedorCalificado)
                .ValueGeneratedNever()
                .HasColumnName("ID_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.ActividadProveedorCalificado)
                .HasMaxLength(50)
                .HasColumnName("ACTIVIDAD_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.CertificacionesProveedorCalificado).HasColumnName("CERTIFICACIONES_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.EsImportadorProveedorCalificado)
                .HasMaxLength(10)
                .HasColumnName("ES_IMPORTADOR_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.EstadoProveedorCalificado).HasColumnName("ESTADO_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.FechaActualizacionProveedorCalificado)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ACTUALIZACION_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.FechaCeseProveedorCalificado)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CESE_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.FechaInicioProveedorCalificado)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.FormaPagoProveedorCalificado)
                .HasMaxLength(50)
                .HasColumnName("FORMA_PAGO_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.IdProveedorGeneral).HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.NumeroCarpetaProveedorCalificado).HasColumnName("NUMERO_CARPETA_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.ObservacionesProveedorCalificado).HasColumnName("OBSERVACIONES_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.PaginaWebProveedorCalificado).HasColumnName("PAGINA_WEB_PROVEEDOR_CALIFICADO");
            entity.Property(e => e.ServiciosPrestadosProveedorCalificado).HasColumnName("SERVICIOS_PRESTADOS_PROVEEDOR_CALIFICADO");

            entity.HasOne(d => d.IdProveedorGeneralNavigation).WithMany(p => p.ProveedorCalificados)
                .HasForeignKey(d => d.IdProveedorGeneral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PROVEEDOR_CALIFICADO_PROVEEDOR_GENERAL");
        });

        modelBuilder.Entity<ProveedorGeneral>(entity =>
        {
            entity.HasKey(e => e.IdProveedorGeneral);

            entity.ToTable("PROVEEDOR_GENERAL");

            entity.Property(e => e.IdProveedorGeneral)
                .ValueGeneratedNever()
                .HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.ContabilidadProveedorGeneral)
                .HasMaxLength(5)
                .HasColumnName("CONTABILIDAD_PROVEEDOR_GENERAL");
            entity.Property(e => e.ContribuyenteEspecialProveedorGeneral)
                .HasMaxLength(5)
                .HasColumnName("CONTRIBUYENTE_ESPECIAL_PROVEEDOR_GENERAL");
            entity.Property(e => e.DireccionProveedorGeneral).HasColumnName("DIRECCION_PROVEEDOR_GENERAL");
            entity.Property(e => e.DocumentoContriEspeProveedorGeneral).HasColumnName("DOCUMENTO_CONTRI_ESPE_PROVEEDOR_GENERAL");
            entity.Property(e => e.EmailProveedorGeneral)
                .HasMaxLength(50)
                .HasColumnName("EMAIL_PROVEEDOR_GENERAL");
            entity.Property(e => e.EstadoProveedorGeneral).HasColumnName("ESTADO_PROVEEDOR_GENERAL");
            entity.Property(e => e.FechaProveedorGeneral)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_PROVEEDOR_GENERAL");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.NombreComercialProveedorGeneral).HasColumnName("NOMBRE_COMERCIAL_PROVEEDOR_GENERAL");
            entity.Property(e => e.RazonSocialProveedorGeneral).HasColumnName("RAZON_SOCIAL_PROVEEDOR_GENERAL");
            entity.Property(e => e.RucCiProveedorGeneral)
                .HasMaxLength(13)
                .HasColumnName("RUC_CI_PROVEEDOR_GENERAL");
            entity.Property(e => e.Telefono1ProveedorGeneral)
                .HasMaxLength(25)
                .HasColumnName("TELEFONO_1_PROVEEDOR_GENERAL");
            entity.Property(e => e.Telefono2ProveedorGeneral)
                .HasMaxLength(25)
                .HasColumnName("TELEFONO_2_PROVEEDOR_GENERAL");
            entity.Property(e => e.TipoProveedorGeneral)
                .HasMaxLength(50)
                .HasColumnName("TIPO_PROVEEDOR_GENERAL");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.IdProvincias).HasName("PK_PROVINCIAS_1");

            entity.ToTable("PROVINCIAS");

            entity.Property(e => e.IdProvincias)
                .ValueGeneratedNever()
                .HasColumnName("ID_PROVINCIAS");
            entity.Property(e => e.EstadoProvincias).HasColumnName("ESTADO_PROVINCIAS");
            entity.Property(e => e.IdPaises).HasColumnName("ID_PAISES");
            entity.Property(e => e.NombreProvincias).HasColumnName("NOMBRE_PROVINCIAS");

            entity.HasOne(d => d.IdPaisesNavigation).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.IdPaises)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PROVINCIAS_PAISES");
        });

        modelBuilder.Entity<PuestoTrabajo>(entity =>
        {
            entity.HasKey(e => e.IdPuesto);

            entity.ToTable("PUESTO_TRABAJO");

            entity.Property(e => e.IdPuesto)
                .ValueGeneratedNever()
                .HasColumnName("ID_PUESTO");
            entity.Property(e => e.Aprobado).HasColumnName("APROBADO");
            entity.Property(e => e.CentroCosto).HasColumnName("CENTRO_COSTO");
            entity.Property(e => e.Ciudad).HasColumnName("CIUDAD");
            entity.Property(e => e.Cliente).HasColumnName("CLIENTE");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaEmision)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION");
            entity.Property(e => e.IdClienteGeneral).HasColumnName("ID_CLIENTE_GENERAL");
            entity.Property(e => e.IdPersonalSupervisor).HasColumnName("ID_PERSONAL_SUPERVISOR");
            entity.Property(e => e.NombrePuesto).HasColumnName("NOMBRE_PUESTO");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");
            entity.Property(e => e.Parroquia).HasColumnName("PARROQUIA");
            entity.Property(e => e.Provincia).HasColumnName("PROVINCIA");
            entity.Property(e => e.Realizado).HasColumnName("REALIZADO");
            entity.Property(e => e.Registrado).HasColumnName("REGISTRADO");
            entity.Property(e => e.Revisado).HasColumnName("REVISADO");
            entity.Property(e => e.Ubicacion).HasColumnName("UBICACION");
            entity.Property(e => e.Version).HasColumnName("VERSION");

            entity.HasOne(d => d.IdClienteGeneralNavigation).WithMany(p => p.PuestoTrabajos)
                .HasForeignKey(d => d.IdClienteGeneral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PUESTO_TRABAJO_CLIENTE_GENERAL");
        });

        modelBuilder.Entity<PuntoSitioTrabajo>(entity =>
        {
            entity.HasKey(e => e.IdPuntoSitio);

            entity.ToTable("PUNTO_SITIO_TRABAJO");

            entity.Property(e => e.IdPuntoSitio)
                .ValueGeneratedNever()
                .HasColumnName("ID_PUNTO_SITIO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_FIN");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO");
            entity.Property(e => e.IdSitio).HasColumnName("ID_SITIO");
            entity.Property(e => e.Nombre).HasColumnName("NOMBRE");
            entity.Property(e => e.Tipo).HasColumnName("TIPO");
            entity.Property(e => e.Ubicacion).HasColumnName("UBICACION");
        });

        modelBuilder.Entity<Radio>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RADIOS");

            entity.Property(e => e.Color).HasColumnName("COLOR");
            entity.Property(e => e.Documento).HasColumnName("DOCUMENTO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoActivo).HasColumnName("ESTADO_ACTIVO");
            entity.Property(e => e.FecAceptacionPermiso)
                .HasColumnType("datetime")
                .HasColumnName("FEC_ACEPTACION_PERMISO");
            entity.Property(e => e.FecCaducidadPermiso)
                .HasColumnType("datetime")
                .HasColumnName("FEC_CADUCIDAD_PERMISO");
            entity.Property(e => e.Garantia).HasColumnName("GARANTIA");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Modelo).HasColumnName("MODELO");
            entity.Property(e => e.NumPermisoUso).HasColumnName("NUM_PERMISO_USO");
            entity.Property(e => e.Ruta).HasColumnName("RUTA");
            entity.Property(e => e.Serie).HasColumnName("SERIE");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RADIOS_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<RegistroPermisosPersonal>(entity =>
        {
            entity.HasKey(e => e.IdRegistro);

            entity.ToTable("REGISTRO_PERMISOS_PERSONAL");

            entity.Property(e => e.IdRegistro)
                .ValueGeneratedNever()
                .HasColumnName("id_registro");
            entity.Property(e => e.Certificado).HasColumnName("certificado");
            entity.Property(e => e.Desde)
                .HasColumnType("datetime")
                .HasColumnName("desde");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Hasta)
                .HasColumnType("datetime")
                .HasColumnName("hasta");
            entity.Property(e => e.IdPersonal).HasColumnName("id_personal");
            entity.Property(e => e.IdSancion).HasColumnName("id_sancion");
            entity.Property(e => e.IdSitio).HasColumnName("id_sitio");
            entity.Property(e => e.Ndoc).HasColumnName("ndoc");
            entity.Property(e => e.Observacion).HasColumnName("observacion");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.RegistroPermisosPersonals)
                .HasForeignKey(d => d.IdPersonal)
                .HasConstraintName("FKIO");

            entity.HasOne(d => d.IdSancionNavigation).WithMany(p => p.RegistroPermisosPersonals)
                .HasForeignKey(d => d.IdSancion)
                .HasConstraintName("FKSAN");

            entity.HasOne(d => d.IdSitioNavigation).WithMany(p => p.RegistroPermisosPersonals)
                .HasForeignKey(d => d.IdSitio)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FKST");
        });

        modelBuilder.Entity<RegistroDepreciaciones>(entity =>
        {
            entity.HasNoKey();
            entity.ToView(null);
        });


        modelBuilder.Entity<RegistroSancionesPersonal>(entity =>
        {
            entity.HasKey(e => e.IdRegistro);

            entity.ToTable("REGISTRO_SANCIONES_PERSONAL");

            entity.Property(e => e.IdRegistro)
                .ValueGeneratedNever()
                .HasColumnName("id_registro");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdDescuento).HasColumnName("id_descuento");
            entity.Property(e => e.IdPersonal).HasColumnName("id_personal");
            entity.Property(e => e.IdProg).HasColumnName("id_prog");
            entity.Property(e => e.IdSancion).HasColumnName("id_sancion");
            entity.Property(e => e.IdSitio).HasColumnName("id_sitio");
            entity.Property(e => e.Multador)
                .HasMaxLength(500)
                .HasColumnName("multador");
            entity.Property(e => e.Observacion).HasColumnName("observacion");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.RegistroSancionesPersonals)
                .HasForeignKey(d => d.IdPersonal)
                .HasConstraintName("FKSP");

            entity.HasOne(d => d.IdSancionNavigation).WithMany(p => p.RegistroSancionesPersonals)
                .HasForeignKey(d => d.IdSancion)
                .HasConstraintName("FKSA");
        });

        modelBuilder.Entity<RequisicionProductoServicio>(entity =>
        {
            entity.HasKey(e => e.IdRequisicionPs);

            entity.ToTable("REQUISICION_PRODUCTO_SERVICIO");

            entity.Property(e => e.IdRequisicionPs)
                .ValueGeneratedNever()
                .HasColumnName("ID_REQUISICION_PS");
            entity.Property(e => e.EstadoRequisicionPs).HasColumnName("ESTADO_REQUISICION_PS");
            entity.Property(e => e.FechaRequisicionPs)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REQUISICION_PS");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.PrioridadEntregaRequisicionPs)
                .HasMaxLength(50)
                .HasColumnName("PRIORIDAD_ENTREGA_REQUISICION_PS");
            entity.Property(e => e.TiempoEntregaRequisicionPs)
                .HasMaxLength(50)
                .HasColumnName("TIEMPO_ENTREGA_REQUISICION_PS");
        });

        modelBuilder.Entity<ResponsableAutorizacionFondoCaja>(entity =>
        {
            entity.HasKey(e => e.IdResponsableAutoCch);

            entity.ToTable("RESPONSABLE_AUTORIZACION_FONDO_CAJA");

            entity.Property(e => e.IdResponsableAutoCch)
                .ValueGeneratedNever()
                .HasColumnName("ID_RESPONSABLE_AUTO_CCH");
            entity.Property(e => e.CedulaAutoCch)
                .HasMaxLength(10)
                .HasColumnName("CEDULA_AUTO_CCH");
            entity.Property(e => e.EstadoResponsableAutoCch).HasColumnName("ESTADO_RESPONSABLE_AUTO_CCH");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");
            entity.Property(e => e.NombresAutoCch).HasColumnName("NOMBRES_AUTO_CCH");
        });

        modelBuilder.Entity<ResponsableAutorizacionFondoRotativo>(entity =>
        {
            entity.HasKey(e => e.IdResponsableAutoFr);

            entity.ToTable("RESPONSABLE_AUTORIZACION_FONDO_ROTATIVO");

            entity.Property(e => e.IdResponsableAutoFr)
                .ValueGeneratedNever()
                .HasColumnName("ID_RESPONSABLE_AUTO_FR");
            entity.Property(e => e.ApellidoResponsableAutoFr).HasColumnName("APELLIDO_RESPONSABLE_AUTO_FR");
            entity.Property(e => e.CargoResponsableAutoFr).HasColumnName("CARGO_RESPONSABLE_AUTO_FR");
            entity.Property(e => e.CiResponsableAutoFr)
                .HasMaxLength(10)
                .HasColumnName("CI_RESPONSABLE_AUTO_FR");
            entity.Property(e => e.EstadoResponsableAutoFr).HasColumnName("ESTADO_RESPONSABLE_AUTO_FR");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdProvincias).HasColumnName("ID_PROVINCIAS");
            entity.Property(e => e.NombreResponsableAutoFr).HasColumnName("NOMBRE_RESPONSABLE_AUTO_FR");
        });

        modelBuilder.Entity<RetencionIva>(entity =>
        {
            entity.HasKey(e => e.IdRetencionIva);

            entity.ToTable("RETENCION_IVA");

            entity.Property(e => e.IdRetencionIva)
                .ValueGeneratedNever()
                .HasColumnName("ID_RETENCION_IVA");
            entity.Property(e => e.ContabilidadRetencionIva).HasColumnName("CONTABILIDAD_RETENCION_IVA");
            entity.Property(e => e.DescripcionRetencionIva).HasColumnName("DESCRIPCION_RETENCION_IVA");
            entity.Property(e => e.EstadoRetencionIva).HasColumnName("ESTADO_RETENCION_IVA");
            entity.Property(e => e.TipoRetencionIva).HasColumnName("TIPO_RETENCION_IVA");
        });

        modelBuilder.Entity<RetencionRentum>(entity =>
        {
            entity.HasKey(e => e.IdRetencionRenta).HasName("PK_IMPUESTO_RENTA");

            entity.ToTable("RETENCION_RENTA");

            entity.Property(e => e.IdRetencionRenta)
                .ValueGeneratedNever()
                .HasColumnName("ID_RETENCION_RENTA");
            entity.Property(e => e.AñoRetencionRenta).HasColumnName("AÑO_RETENCION_RENTA");
            entity.Property(e => e.CodigoAnualRetencionRenta).HasColumnName("CODIGO_ANUAL_RETENCION_RENTA");
            entity.Property(e => e.ConceptoAnualRetencionRenta).HasColumnName("CONCEPTO_ANUAL_RETENCION_RENTA");
            entity.Property(e => e.EstadoRetencionRenta).HasColumnName("ESTADO_RETENCION_RENTA");
            entity.Property(e => e.PorcentajeRetencionRenta).HasColumnName("PORCENTAJE_RETENCION_RENTA");
        });

        modelBuilder.Entity<RolPago>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("ROL_PAGO");

            entity.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("id_rol");
            entity.Property(e => e.AnioRol).HasColumnName("anio_rol");
            entity.Property(e => e.AnticipoUtilidadMes)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ANTICIPO_UTILIDAD_MES");
            entity.Property(e => e.Auxfil).HasColumnName("auxfil");
            entity.Property(e => e.CostoHoras)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("COSTO_HORAS");
            entity.Property(e => e.CostoHoras100)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("COSTO_HORAS_100");
            entity.Property(e => e.CostoHoras50)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("COSTO_HORAS_50");
            entity.Property(e => e.Desde)
                .HasColumnType("datetime")
                .HasColumnName("desde");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaElab)
                .HasColumnType("datetime")
                .HasColumnName("fecha_elab");
            entity.Property(e => e.FechaVal)
                .HasColumnType("datetime")
                .HasColumnName("fecha_val");
            entity.Property(e => e.Grupo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("GENERAL")
                .HasColumnName("grupo");
            entity.Property(e => e.Hasta)
                .HasColumnType("datetime")
                .HasColumnName("hasta");
            entity.Property(e => e.MesRol).HasColumnName("mes_rol");
            entity.Property(e => e.Observacion)
                .HasColumnType("text")
                .HasColumnName("observacion");
            entity.Property(e => e.OtrosDescAdmi)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("OTROS_DESC_ADMI");
            entity.Property(e => e.OtrosDescVigi)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("OTROS_DESC_VIGI");
            entity.Property(e => e.PorcenAportePatronal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PORCEN_APORTE_PATRONAL");
            entity.Property(e => e.PorcentajeDesMed)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PORCENTAJE_DES_MED");
            entity.Property(e => e.PorcentajeExtSal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PORCENTAJE_EXT_SAL");
            entity.Property(e => e.ProcenAportePersonal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PROCEN_APORTE_PERSONAL");
            entity.Property(e => e.ProcentajeFondoReserva)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PROCENTAJE_FONDO_RESERVA");
            entity.Property(e => e.QuinceAdSbEx).HasColumnName("QUINCE_AD_SB_EX");
            entity.Property(e => e.Quincena).HasColumnName("quincena");
            entity.Property(e => e.Retenidos)
                .HasColumnType("text")
                .HasColumnName("RETENIDOS");
            entity.Property(e => e.SueldoBasicoUnificado)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUELDO_BASICO_UNIFICADO");
            entity.Property(e => e.SueldoVigilantes)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUELDO_VIGILANTES");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
            entity.Property(e => e.ValorAnticipoGuardias)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_ANTICIPO_GUARDIAS");
        });

        modelBuilder.Entity<RotacionVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdRotacion);

            entity.ToTable("ROTACION_VEHICULOS");

            entity.Property(e => e.IdRotacion)
                .ValueGeneratedNever()
                .HasColumnName("ID_ROTACION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdActivo).HasColumnName("ID_ACTIVO");
            entity.Property(e => e.IdCustodioAnterior).HasColumnName("ID_CUSTODIO_ANTERIOR");
            entity.Property(e => e.IdCustodioNuevo).HasColumnName("ID_CUSTODIO_NUEVO");
            entity.Property(e => e.NombreCustodioAnterior).HasColumnName("NOMBRE_CUSTODIO_ANTERIOR");
            entity.Property(e => e.NombreCustodioNuevo).HasColumnName("NOMBRE_CUSTODIO_NUEVO");
            entity.Property(e => e.Observacion).HasColumnName("OBSERVACION");

            entity.HasOne(d => d.IdActivoNavigation).WithMany(p => p.RotacionVehiculos)
                .HasForeignKey(d => d.IdActivo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROTACION_VEHICULOS_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<Rubro>(entity =>
        {
            entity.HasKey(e => e.IdRubro);

            entity.ToTable("RUBROS");

            entity.Property(e => e.IdRubro)
                .ValueGeneratedNever()
                .HasColumnName("ID_RUBRO");
            entity.Property(e => e.EstadoRubro).HasColumnName("ESTADO_RUBRO");
            entity.Property(e => e.NombreRubro).HasColumnName("NOMBRE_RUBRO");
            entity.Property(e => e.ValorRubro)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_RUBRO");
        });

        modelBuilder.Entity<RutaDocElectronico>(entity =>
        {
            entity.HasKey(e => e.NombreRuta).HasName("PK__RUTA_DOC_ELECTRO__271B6FA6");

            entity.ToTable("RUTA_DOC_ELECTRONICO");

            entity.Property(e => e.NombreRuta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_ruta");
            entity.Property(e => e.RutaDireccion)
                .IsUnicode(false)
                .HasColumnName("ruta_direccion");
        });

        modelBuilder.Entity<SalidaVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdSalidaV);

            entity.ToTable("SALIDA_VEHICULO");

            entity.Property(e => e.IdSalidaV)
                .ValueGeneratedNever()
                .HasColumnName("ID_SALIDA_V");
            entity.Property(e => e.EstadoSalidaV).HasColumnName("ESTADO_SALIDA_V");
            entity.Property(e => e.FechaSalidaV)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_SALIDA_V");
            entity.Property(e => e.HoraSalidaV).HasColumnName("HORA_SALIDA_V");
            entity.Property(e => e.KmSalidaV).HasColumnName("KM_SALIDA_V");
        });

        modelBuilder.Entity<SancionesPersonal>(entity =>
        {
            entity.HasKey(e => e.IdSancion).HasName("PK__SANCIONES_PERSON__1625EDCE");

            entity.ToTable("SANCIONES_PERSONAL");

            entity.Property(e => e.IdSancion)
                .ValueGeneratedNever()
                .HasColumnName("id_sancion");
            entity.Property(e => e.Detalle)
                .IsUnicode(false)
                .HasColumnName("detalle");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.SanPer)
                .HasDefaultValue(0)
                .HasColumnName("san_per");
            entity.Property(e => e.TipoSancion)
                .IsUnicode(false)
                .HasColumnName("tipo_sancion");
            entity.Property(e => e.ValorDescuento)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("valor_descuento");
        });

        modelBuilder.Entity<SeccionGeneral>(entity =>
        {
            entity.HasKey(e => e.IdSeccion);

            entity.ToTable("SECCION_GENERAL");

            entity.Property(e => e.IdSeccion)
                .ValueGeneratedNever()
                .HasColumnName("ID_SECCION");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.EstadoSeccion).HasColumnName("ESTADO_SECCION");
            entity.Property(e => e.IdAreaGeneral).HasColumnName("ID_AREA_GENERAL");
            entity.Property(e => e.NombreSeccion).HasColumnName("NOMBRE_SECCION");

            entity.HasOne(d => d.IdAreaGeneralNavigation).WithMany(p => p.SeccionGenerals)
                .HasForeignKey(d => d.IdAreaGeneral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SECCION_GENERAL_AREA_GENERAL");
        });

        modelBuilder.Entity<Secuecial>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SECUECIAL");

            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.EstadoDepreciable)
                .HasMaxLength(2)
                .HasColumnName("ESTADO_DEPRECIABLE");
            entity.Property(e => e.EstadoSecuencial).HasColumnName("ESTADO_SECUENCIAL");
            entity.Property(e => e.IdSecuencial).HasColumnName("ID_SECUENCIAL");
            entity.Property(e => e.IdSubGrupoSecuencial).HasColumnName("ID_SUB_GRUPO_SECUENCIAL");
            entity.Property(e => e.NombreSecuencial).HasColumnName("NOMBRE_SECUENCIAL");
        });

        modelBuilder.Entity<Secuencial>(entity =>
        {
            entity.HasKey(e => e.IdSecuencial);

            entity.ToTable("SECUENCIAL");

            entity.Property(e => e.IdSecuencial)
                .ValueGeneratedNever()
                .HasColumnName("ID_SECUENCIAL");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.EstadoDepreciable)
                .HasMaxLength(2)
                .HasColumnName("ESTADO_DEPRECIABLE");
            entity.Property(e => e.EstadoSecuencial).HasColumnName("ESTADO_SECUENCIAL");
            entity.Property(e => e.IdSubGrupoSecuencial).HasColumnName("ID_SUB_GRUPO_SECUENCIAL");
            entity.Property(e => e.NombreSecuencial).HasColumnName("NOMBRE_SECUENCIAL");

            entity.HasOne(d => d.IdSubGrupoSecuencialNavigation).WithMany(p => p.Secuencials)
                .HasForeignKey(d => d.IdSubGrupoSecuencial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SECUENCIAL_SUB_GRUPO_GENERAL");
        });

        modelBuilder.Entity<SecuencialItem>(entity =>
        {
            entity.HasKey(e => e.IdSecuencialItem);

            entity.ToTable("SECUENCIAL_ITEM");

            entity.Property(e => e.IdSecuencialItem)
                .ValueGeneratedNever()
                .HasColumnName("ID_SECUENCIAL_ITEM");
            entity.Property(e => e.CodigoSecuencialItem).HasColumnName("CODIGO_SECUENCIAL_ITEM");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("COSTO");
            entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            entity.Property(e => e.Descuento).HasColumnName("DESCUENTO");
            entity.Property(e => e.EstadoSecuencialItem).HasColumnName("ESTADO_SECUENCIAL_ITEM");
            entity.Property(e => e.FechaSecuencialItem)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_SECUENCIAL_ITEM");
            entity.Property(e => e.IdColor).HasColumnName("ID_COLOR");
            entity.Property(e => e.IdLote).HasColumnName("ID_LOTE");
            entity.Property(e => e.IdMarca).HasColumnName("ID_MARCA");
            entity.Property(e => e.IdMaterial).HasColumnName("ID_MATERIAL");
            entity.Property(e => e.IdModelo).HasColumnName("ID_MODELO");
            entity.Property(e => e.IdSubGrupoItem).HasColumnName("ID_SUB_GRUPO_ITEM");
            entity.Property(e => e.IdUnidadMedida).HasColumnName("ID_UNIDAD_MEDIDA");
            entity.Property(e => e.NombreSecuencialItem).HasColumnName("NOMBRE_SECUENCIAL_ITEM");
            entity.Property(e => e.Pvp)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("PVP");
            entity.Property(e => e.Serie).HasColumnName("SERIE");

            entity.HasOne(d => d.IdLoteNavigation).WithMany(p => p.SecuencialItems)
                .HasForeignKey(d => d.IdLote)
                .HasConstraintName("FK_SECUENCIAL_ITEM_LOTE");

            entity.HasOne(d => d.IdSubGrupoItemNavigation).WithMany(p => p.SecuencialItems)
                .HasForeignKey(d => d.IdSubGrupoItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SECUENCIAL_ITEM_SUB_GRUPO_ITEM");
        });

        modelBuilder.Entity<SecuencialSuministro>(entity =>
        {
            entity.HasKey(e => e.IdSecuencialSuministros);

            entity.ToTable("SECUENCIAL_SUMINISTROS");

            entity.Property(e => e.IdSecuencialSuministros)
                .ValueGeneratedNever()
                .HasColumnName("ID_SECUENCIAL_SUMINISTROS");
            entity.Property(e => e.CategoriaSec).HasColumnName("CATEGORIA_SEC");
            entity.Property(e => e.DetalleSecuencialSuministros).HasColumnName("DETALLE_SECUENCIAL_SUMINISTROS");
            entity.Property(e => e.EstadoSecuencialSuministros).HasColumnName("ESTADO_SECUENCIAL_SUMINISTROS");
            entity.Property(e => e.GrupoSec).HasColumnName("GRUPO_SEC");
            entity.Property(e => e.IdSubgrupoSuministros).HasColumnName("ID_SUBGRUPO_SUMINISTROS");
            entity.Property(e => e.IdUnidadMedida).HasColumnName("ID_UNIDAD_MEDIDA");
            entity.Property(e => e.MarcaSecuencialSuministros).HasColumnName("MARCA_SECUENCIAL_SUMINISTROS");
            entity.Property(e => e.ModeloSecuencialSuministros).HasColumnName("MODELO_SECUENCIAL_SUMINISTROS");
            entity.Property(e => e.NombreSecuencialSuministros).HasColumnName("NOMBRE_SECUENCIAL_SUMINISTROS");
            entity.Property(e => e.PreciouSecuencialSuministros)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("PRECIOU_SECUENCIAL_SUMINISTROS");
            entity.Property(e => e.SecuencialSec).HasColumnName("SECUENCIAL_SEC");
            entity.Property(e => e.StockSecuencialSuministros).HasColumnName("STOCK_SECUENCIAL_SUMINISTROS");
            entity.Property(e => e.SubgrupoSec).HasColumnName("SUBGRUPO_SEC");

            entity.HasOne(d => d.IdSubgrupoSuministrosNavigation).WithMany(p => p.SecuencialSuministros)
                .HasForeignKey(d => d.IdSubgrupoSuministros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SECUENCIAL_SUMINISTROS_SUBGRUPO_SUMINISTROS");

            entity.HasOne(d => d.IdUnidadMedidaNavigation).WithMany(p => p.SecuencialSuministros)
                .HasForeignKey(d => d.IdUnidadMedida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SECUENCIAL_SUMINISTROS_UNIDAD_MEDIDA");
        });

        modelBuilder.Entity<SecuencialesContrato>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SECUENCIALES_CONTRATOS");

            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Digit)
                .HasDefaultValue(0)
                .HasColumnName("digit");
            entity.Property(e => e.IdSecuencia).HasColumnName("id_secuencia");
        });

        modelBuilder.Entity<SerieOcupacional>(entity =>
        {
            entity.HasKey(e => e.IdSerieOcupacional);

            entity.ToTable("SERIE_OCUPACIONAL");

            entity.Property(e => e.IdSerieOcupacional)
                .ValueGeneratedNever()
                .HasColumnName("ID_SERIE_OCUPACIONAL");
            entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.IdGrupoOcupacional).HasColumnName("ID_GRUPO_OCUPACIONAL");

            entity.HasOne(d => d.IdGrupoOcupacionalNavigation).WithMany(p => p.SerieOcupacionals)
                .HasForeignKey(d => d.IdGrupoOcupacional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SERIE_OCUPACIONAL_GRUPO_OCUPACIONAL");
        });

        modelBuilder.Entity<SitiosTrabajo>(entity =>
        {
            entity.HasKey(e => e.IdSitioTrabajo);

            entity.ToTable("SITIOS_TRABAJO");

            entity.Property(e => e.IdSitioTrabajo)
                .ValueGeneratedNever()
                .HasColumnName("ID_SITIO_TRABAJO");
            entity.Property(e => e.CantAdici)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CANT_ADICI");
            entity.Property(e => e.CantHoras)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CANT_HORAS");
            entity.Property(e => e.CantHoras100)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CANT_HORAS_100");
            entity.Property(e => e.CantHoras50)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CANT_HORAS_50");
            entity.Property(e => e.CantHorasExt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CANT_HORAS_EXT");
            entity.Property(e => e.CantRecNoc)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("CANT_REC_NOC");
            entity.Property(e => e.DecimoExtra)
                .HasDefaultValue(0)
                .HasColumnName("DECIMO_EXTRA");
            entity.Property(e => e.DireccionSitioTrabajo).HasColumnName("DIRECCION_SITIO_TRABAJO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Grupo).HasColumnName("GRUPO");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdClienteGeneral).HasColumnName("ID_CLIENTE_GENERAL");
            entity.Property(e => e.IdParroquia).HasColumnName("ID_PARROQUIA");
            entity.Property(e => e.IdPersonalSupervisor).HasColumnName("ID_PERSONAL_SUPERVISOR");
            entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");
            entity.Property(e => e.Latitud).HasColumnName("LATITUD");
            entity.Property(e => e.Longitud).HasColumnName("LONGITUD");
            entity.Property(e => e.NombreSitioTrabajo).HasColumnName("NOMBRE_SITIO_TRABAJO");
            entity.Property(e => e.PuestoHoras).HasColumnName("PUESTO_HORAS");
            entity.Property(e => e.ReferenciaSitioTrabajo)
                .HasDefaultValueSql("(NULL)")
                .UseCollation("Modern_Spanish_CS_AI_KS")
                .HasColumnName("REFERENCIA_SITIO_TRABAJO");
            entity.Property(e => e.Rive).HasColumnName("RIVE");
            entity.Property(e => e.River).HasColumnName("RIVER");
            entity.Property(e => e.TipoSitioTrabajo).HasColumnName("TIPO_SITIO_TRABAJO");

            entity.HasOne(d => d.IdParroquiaNavigation).WithMany(p => p.SitiosTrabajos)
                .HasForeignKey(d => d.IdParroquia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SITIOS_TRABAJO_PARROQUIAS");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.SitiosTrabajos)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SITIOS_TRABAJO_PROVINCIAS");
        });

        modelBuilder.Entity<Software>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SOFTWARE");

            entity.Property(e => e.Detalle).HasColumnName("DETALLE");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Provedor).HasColumnName("PROVEDOR");
            entity.Property(e => e.Tipo).HasColumnName("TIPO");
            entity.Property(e => e.Version).HasColumnName("VERSION");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SOFTWARE_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<SolicitudCajaChica>(entity =>
        {
            entity.HasKey(e => e.IdSolictudCch);

            entity.ToTable("SOLICITUD_CAJA_CHICA");

            entity.Property(e => e.IdSolictudCch)
                .ValueGeneratedNever()
                .HasColumnName("ID_SOLICTUD_CCH");
            entity.Property(e => e.CedulaEntrega).HasColumnName("CEDULA_ENTREGA");
            entity.Property(e => e.CedulaRecibe).HasColumnName("CEDULA_RECIBE");
            entity.Property(e => e.CodDebeCch).HasColumnName("COD_DEBE_CCH");
            entity.Property(e => e.CodHaberCch).HasColumnName("COD_HABER_CCH");
            entity.Property(e => e.DetalleSolicitudCch).HasColumnName("DETALLE_SOLICITUD_CCH");
            entity.Property(e => e.EstadoSolicitudCch).HasColumnName("ESTADO_SOLICITUD_CCH");
            entity.Property(e => e.FechaSolicitudCch)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_SOLICITUD_CCH");
            entity.Property(e => e.IdCajaChica).HasColumnName("ID_CAJA_CHICA");
            entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdComprobante).HasColumnName("ID_COMPROBANTE");
            entity.Property(e => e.IdGastoCajaCh).HasColumnName("ID_GASTO_CAJA_CH");
            entity.Property(e => e.IdLiquidacion).HasColumnName("ID_LIQUIDACION");
            entity.Property(e => e.IdParametroDocumentos).HasColumnName("ID_PARAMETRO_DOCUMENTOS");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");
            entity.Property(e => e.IdResponsableAutoCch).HasColumnName("ID_RESPONSABLE_AUTO_CCH");
            entity.Property(e => e.NombreRazonSocialClienteGeneral).HasColumnName("NOMBRE_RAZON_SOCIAL_CLIENTE_GENERAL");
            entity.Property(e => e.NombresEntrega).HasColumnName("NOMBRES_ENTREGA");
            entity.Property(e => e.NombresRecibe).HasColumnName("NOMBRES_RECIBE");
            entity.Property(e => e.NroParametroDocumentos).HasColumnName("NRO_PARAMETRO_DOCUMENTOS");
            entity.Property(e => e.NumeroSolicitudCch).HasColumnName("NUMERO_SOLICITUD_CCH");
            entity.Property(e => e.ValorSolicitudCch)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_SOLICITUD_CCH");

            entity.HasOne(d => d.IdCajaChicaNavigation).WithMany(p => p.SolicitudCajaChicas)
                .HasForeignKey(d => d.IdCajaChica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SOLICITUD_CAJA_CHICA_CAJA_CHICA");

            entity.HasOne(d => d.IdResponsableAutoCchNavigation).WithMany(p => p.SolicitudCajaChicas)
                .HasForeignKey(d => d.IdResponsableAutoCch)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SOLICITUD_CAJA_CHICA_RESPONSABLE_AUTORIZACION_FONDO_CAJA");
        });

        modelBuilder.Entity<SolicitudFondoRotativo>(entity =>
        {
            entity.HasKey(e => e.IdSolicitudFr);

            entity.ToTable("SOLICITUD_FONDO_ROTATIVO");

            entity.Property(e => e.IdSolicitudFr)
                .ValueGeneratedNever()
                .HasColumnName("ID_SOLICITUD_FR");
            entity.Property(e => e.CodDebe).HasColumnName("COD_DEBE");
            entity.Property(e => e.CodHaber).HasColumnName("COD_HABER");
            entity.Property(e => e.DetalleSolicitudFr).HasColumnName("DETALLE_SOLICITUD_FR");
            entity.Property(e => e.EstadoSolicitudFr).HasColumnName("ESTADO_SOLICITUD_FR");
            entity.Property(e => e.FechaSolicitudFr)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_SOLICITUD_FR");
            entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdDocumento).HasColumnName("ID_DOCUMENTO");
            entity.Property(e => e.IdFondoRotativo).HasColumnName("ID_FONDO_ROTATIVO");
            entity.Property(e => e.IdGastosFr).HasColumnName("ID_GASTOS_FR");
            entity.Property(e => e.IdLiquidacionFr).HasColumnName("ID_LIQUIDACION_FR");
            entity.Property(e => e.IdParametroDocumentos).HasColumnName("ID_PARAMETRO_DOCUMENTOS");
            entity.Property(e => e.IdParroquias).HasColumnName("ID_PARROQUIAS");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdProvincias).HasColumnName("ID_PROVINCIAS");
            entity.Property(e => e.IdResponsableAutoFr).HasColumnName("ID_RESPONSABLE_AUTO_FR");
            entity.Property(e => e.NombreRazonSocialClienteGeneral).HasColumnName("NOMBRE_RAZON_SOCIAL_CLIENTE_GENERAL");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_DOCUMENTO");
            entity.Property(e => e.NumeroSolicitudFr).HasColumnName("NUMERO_SOLICITUD_FR");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(50)
                .HasColumnName("TIPO_DOCUMENTO");
            entity.Property(e => e.ValorSolicitudFr)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALOR_SOLICITUD_FR");

            entity.HasOne(d => d.IdFondoRotativoNavigation).WithMany(p => p.SolicitudFondoRotativos)
                .HasForeignKey(d => d.IdFondoRotativo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SOLICITUD_FONDO_ROTATIVO_FONDO_ROTATIVO");

            entity.HasOne(d => d.IdResponsableAutoFrNavigation).WithMany(p => p.SolicitudFondoRotativos)
                .HasForeignKey(d => d.IdResponsableAutoFr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SOLICITUD_FONDO_ROTATIVO_RESPONSABLE_AUTORIZACION_FONDO_ROTATIVO");
        });

        modelBuilder.Entity<SolicitudMensualSuministro>(entity =>
        {
            entity.HasKey(e => e.IdSolicitudSuministros);

            entity.ToTable("SOLICITUD_MENSUAL_SUMINISTROS");

            entity.Property(e => e.IdSolicitudSuministros)
                .ValueGeneratedNever()
                .HasColumnName("ID_SOLICITUD_SUMINISTROS");
            entity.Property(e => e.FechaSolicitudSuministros)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_SOLICITUD_SUMINISTROS");
            entity.Property(e => e.IdCentroCosto).HasColumnName("ID_CENTRO_COSTO");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_CIUDAD");
            entity.Property(e => e.IdParroquia).HasColumnName("ID_PARROQUIA");
            entity.Property(e => e.IdProvincia).HasColumnName("ID_PROVINCIA");
            entity.Property(e => e.MesSolicitudSuministros)
                .HasMaxLength(15)
                .HasColumnName("MES_SOLICITUD_SUMINISTROS");
            entity.Property(e => e.NumeroSolicitudSuministros).HasColumnName("NUMERO_SOLICITUD_SUMINISTROS");
        });

        modelBuilder.Entity<SubGrupoGeneral>(entity =>
        {
            entity.HasKey(e => e.IdSubGrupo);

            entity.ToTable("SUB_GRUPO_GENERAL");

            entity.Property(e => e.IdSubGrupo)
                .ValueGeneratedNever()
                .HasColumnName("ID_SUB_GRUPO");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.EstadoSubGrupo).HasColumnName("ESTADO_SUB_GRUPO");
            entity.Property(e => e.IdGrupoSubGrupo).HasColumnName("ID_GRUPO_SUB_GRUPO");
            entity.Property(e => e.NombreSubGrupo).HasColumnName("NOMBRE_SUB_GRUPO");

            entity.HasOne(d => d.IdGrupoSubGrupoNavigation).WithMany(p => p.SubGrupoGenerals)
                .HasForeignKey(d => d.IdGrupoSubGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SUB_GRUPO_GENERAL_GRUPO_GENERAL");
        });

        modelBuilder.Entity<SubGrupoItem>(entity =>
        {
            entity.HasKey(e => e.IdSubGrupoItem);

            entity.ToTable("SUB_GRUPO_ITEM");

            entity.Property(e => e.IdSubGrupoItem)
                .ValueGeneratedNever()
                .HasColumnName("ID_SUB_GRUPO_ITEM");
            entity.Property(e => e.CodigoSubGrupoItem).HasColumnName("CODIGO_SUB_GRUPO_ITEM");
            entity.Property(e => e.EstadoSubGrupoItem).HasColumnName("ESTADO_SUB_GRUPO_ITEM");
            entity.Property(e => e.FechaSubGrupoItem)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_SUB_GRUPO_ITEM");
            entity.Property(e => e.IdGrupoItem).HasColumnName("ID_GRUPO_ITEM");
            entity.Property(e => e.NombreSubGrupoItem).HasColumnName("NOMBRE_SUB_GRUPO_ITEM");

            entity.HasOne(d => d.IdGrupoItemNavigation).WithMany(p => p.SubGrupoItems)
                .HasForeignKey(d => d.IdGrupoItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SUB_GRUPO_ITEM_GRUPO_ITEM");
        });

        modelBuilder.Entity<SubGrupoUbicacion>(entity =>
        {
            entity.HasKey(e => e.IdSubGrupoUbicacion);

            entity.ToTable("SUB_GRUPO_UBICACION");

            entity.Property(e => e.IdSubGrupoUbicacion)
                .ValueGeneratedNever()
                .HasColumnName("ID_SUB_GRUPO_UBICACION");
            entity.Property(e => e.EstadoSubGrupoUbicacion).HasColumnName("ESTADO_SUB_GRUPO_UBICACION");
            entity.Property(e => e.FechaSubGrupoUbicacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_SUB_GRUPO_UBICACION");
            entity.Property(e => e.IdGrupoUbicacion).HasColumnName("ID_GRUPO_UBICACION");
            entity.Property(e => e.NombreSubGrupoUbicacion).HasColumnName("NOMBRE_SUB_GRUPO_UBICACION");

            entity.HasOne(d => d.IdGrupoUbicacionNavigation).WithMany(p => p.SubGrupoUbicacions)
                .HasForeignKey(d => d.IdGrupoUbicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SUB_GRUPO_UBICACION_GRUPO_UBICACION1");
        });

        modelBuilder.Entity<SubSeccionGeneral>(entity =>
        {
            entity.HasKey(e => e.IdSubSeccion);

            entity.ToTable("SUB_SECCION_GENERAL");

            entity.Property(e => e.IdSubSeccion)
                .ValueGeneratedNever()
                .HasColumnName("ID_SUB_SECCION");
            entity.Property(e => e.Codigo).HasColumnName("CODIGO");
            entity.Property(e => e.EstadoSubSeccion).HasColumnName("ESTADO_SUB_SECCION");
            entity.Property(e => e.IdSeccion).HasColumnName("ID_SECCION");
            entity.Property(e => e.NombreSubSeccion).HasColumnName("NOMBRE_SUB_SECCION");

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.SubSeccionGenerals)
                .HasForeignKey(d => d.IdSeccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SUB_SECCION_GENERAL_SECCION_GENERAL");
        });

        modelBuilder.Entity<SubgrupoSuministro>(entity =>
        {
            entity.HasKey(e => e.IdSubgrupoSuministros);

            entity.ToTable("SUBGRUPO_SUMINISTROS");

            entity.Property(e => e.IdSubgrupoSuministros)
                .ValueGeneratedNever()
                .HasColumnName("ID_SUBGRUPO_SUMINISTROS");
            entity.Property(e => e.CategoriaSgr).HasColumnName("CATEGORIA_SGR");
            entity.Property(e => e.EstadoSubgrupoSuministros).HasColumnName("ESTADO_SUBGRUPO_SUMINISTROS");
            entity.Property(e => e.GrupoSgr).HasColumnName("GRUPO_SGR");
            entity.Property(e => e.IdGrupoSuministros).HasColumnName("ID_GRUPO_SUMINISTROS");
            entity.Property(e => e.NombreSubgrupoSuministros).HasColumnName("NOMBRE_SUBGRUPO_SUMINISTROS");
            entity.Property(e => e.SubgrupoSgr).HasColumnName("SUBGRUPO_SGR");

            entity.HasOne(d => d.IdGrupoSuministrosNavigation).WithMany(p => p.SubgrupoSuministros)
                .HasForeignKey(d => d.IdGrupoSuministros)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SUBGRUPO_SUMINISTROS_GRUPO_SUMINISTROS");
        });

        modelBuilder.Entity<SucursalGeneral>(entity =>
        {
            entity.HasKey(e => e.IdSucursal);

            entity.ToTable("SUCURSAL_GENERAL");

            entity.Property(e => e.IdSucursal)
                .ValueGeneratedNever()
                .HasColumnName("ID_SUCURSAL");
            entity.Property(e => e.CodigoSucursal).HasColumnName("CODIGO_SUCURSAL");
            entity.Property(e => e.EstadoSucursal).HasColumnName("ESTADO_SUCURSAL");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.NombreSucursal).HasColumnName("NOMBRE_SUCURSAL");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.SucursalGenerals)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SUCURSAL_GENERAL_EMPRESA_GENERAL");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tags__0F23EA84");

            entity.ToTable("tags");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TblComparacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_comparacion");

            entity.Property(e => e.FldEstado).HasColumnName("fld_estado");
            entity.Property(e => e.FldFecha)
                .HasColumnType("datetime")
                .HasColumnName("fld_fecha");
            entity.Property(e => e.FldIdComparacion).HasColumnName("fld_id_comparacion");
            entity.Property(e => e.FldObservacion)
                .HasMaxLength(800)
                .HasColumnName("fld_observacion");
        });

        modelBuilder.Entity<TblDetalleComparacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_Detalle_Comparacion");

            entity.Property(e => e.FldCredito).HasColumnName("fld_credito");
            entity.Property(e => e.FldDias).HasColumnName("fld_dias");
            entity.Property(e => e.FldEstado).HasColumnName("fld_estado");
            entity.Property(e => e.FldIdComparacion).HasColumnName("fld_id_comparacion");
            entity.Property(e => e.FldIdDetalleComparacion).HasColumnName("fld_id_detalle_comparacion");
            entity.Property(e => e.FldIdProveedor).HasColumnName("fld_id_proveedor");
            entity.Property(e => e.FldIdSecuencialItem).HasColumnName("fld_id_secuencial_item");
            entity.Property(e => e.FldPrecio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fld_precio");
        });

        modelBuilder.Entity<TblDetallePrestamo>(entity =>
        {
            entity.HasKey(e => e.IdDetallePrestamo);

            entity.ToTable("tbl_detalle_prestamo");

            entity.Property(e => e.IdDetallePrestamo)
                .ValueGeneratedNever()
                .HasColumnName("id_detalle_prestamo");
            entity.Property(e => e.CapitalPagado)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("capital_pagado");
            entity.Property(e => e.CapitalRestante)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("capital_restante");
            entity.Property(e => e.Cuota)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("cuota");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdPersonal).HasColumnName("id_personal");
            entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");
            entity.Property(e => e.Periodo).HasColumnName("periodo");
        });

        modelBuilder.Entity<TblMenuDosUser>(entity =>
        {
            entity.HasKey(e => e.FldIdMenuDosUser);

            entity.ToTable("tbl_menu_dos_user");

            entity.Property(e => e.FldIdMenuDosUser)
                .ValueGeneratedNever()
                .HasColumnName("fld_id_menu_dos_user");
            entity.Property(e => e.FldCreateAt)
                .HasColumnType("datetime")
                .HasColumnName("fld_create_at");
            entity.Property(e => e.FldEstado).HasColumnName("fld_estado");
            entity.Property(e => e.FldIdMenuUser).HasColumnName("fld_id_menu_user");
            entity.Property(e => e.FldNombre)
                .HasMaxLength(400)
                .HasColumnName("fld_nombre");
        });

        modelBuilder.Entity<TblMenuTresUser>(entity =>
        {
            entity.HasKey(e => e.FldIdMenuTresUser);

            entity.ToTable("tbl_menu_tres_user");

            entity.Property(e => e.FldIdMenuTresUser)
                .ValueGeneratedNever()
                .HasColumnName("fld_id_menu_tres_user");
            entity.Property(e => e.FldCreateAt)
                .HasColumnType("datetime")
                .HasColumnName("fld_create_at");
            entity.Property(e => e.FldDescripcion)
                .HasMaxLength(200)
                .HasColumnName("fld_descripcion");
            entity.Property(e => e.FldEstado).HasColumnName("fld_estado");
            entity.Property(e => e.FldIdMenuDosUser).HasColumnName("fld_id_menu_dos_user");
            entity.Property(e => e.FldIdMenuUser).HasColumnName("fld_id_menu_user");
            entity.Property(e => e.FldNombre)
                .HasMaxLength(400)
                .HasColumnName("fld_nombre");
        });

        modelBuilder.Entity<TblMenuUser>(entity =>
        {
            entity.HasKey(e => e.FldIdMenu);

            entity.ToTable("tbl_menu_user");

            entity.Property(e => e.FldIdMenu).HasColumnName("fld_id_menu");
            entity.Property(e => e.FldCreateAt)
                .HasColumnType("datetime")
                .HasColumnName("fld_create_at");
            entity.Property(e => e.FldDescripcion)
                .HasMaxLength(150)
                .HasColumnName("fld_descripcion");
            entity.Property(e => e.FldEstado).HasColumnName("fld_estado");
            entity.Property(e => e.FldNombre)
                .HasMaxLength(400)
                .HasColumnName("fld_nombre");
        });

        modelBuilder.Entity<TblPago>(entity =>
        {
            entity.HasKey(e => e.IdPago);

            entity.ToTable("tbl_pagos");

            entity.Property(e => e.IdPago)
                .ValueGeneratedNever()
                .HasColumnName("id_pago");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");
            entity.Property(e => e.MontoPagado)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto_pagado");
            entity.Property(e => e.Periodo).HasColumnName("periodo");
        });

        modelBuilder.Entity<TblPermisosUser>(entity =>
        {
            entity.HasKey(e => e.FldIdPermisosUser);

            entity.ToTable("tbl_permisos_user");

            entity.Property(e => e.FldIdPermisosUser).HasColumnName("fld_id_permisos_user");
            entity.Property(e => e.FldCreateAt)
                .HasColumnType("datetime")
                .HasColumnName("fld_create_at");
            entity.Property(e => e.FldEstado).HasColumnName("fld_estado");
            entity.Property(e => e.FldIdMenu).HasColumnName("fld_id_menu");
            entity.Property(e => e.FldIdMenuDos).HasColumnName("fld_id_menu_dos");
            entity.Property(e => e.FldIdMenuTres).HasColumnName("fld_id_menu_tres");
            entity.Property(e => e.FldIdRolUser).HasColumnName("fld_id_rol_user");
        });

        modelBuilder.Entity<TblPrestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo);

            entity.ToTable("tbl_prestamo");

            entity.Property(e => e.IdPrestamo)
                .ValueGeneratedNever()
                .HasColumnName("id_prestamo");
            entity.Property(e => e.Cuota)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("cuota");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdPersonal).HasColumnName("id_personal");
            entity.Property(e => e.MontoPrestamo)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto_prestamo");
            entity.Property(e => e.Plazo).HasColumnName("plazo");
        });

        modelBuilder.Entity<TblRolUser>(entity =>
        {
            entity.HasKey(e => e.FldIdRol);

            entity.ToTable("tbl_rol_user");

            entity.Property(e => e.FldIdRol).HasColumnName("fld_id_rol");
            entity.Property(e => e.FldCreateAt)
                .HasColumnType("datetime")
                .HasColumnName("fld_create_at");
            entity.Property(e => e.FldDescripcion)
                .HasMaxLength(150)
                .HasColumnName("fld_descripcion");
            entity.Property(e => e.FldEstado).HasColumnName("fld_estado");
            entity.Property(e => e.FldTipoRol)
                .HasMaxLength(150)
                .HasColumnName("fld_tipo_rol");
        });

        modelBuilder.Entity<TblRolesFirmado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_roles_firmados");

            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdPersonal).HasColumnName("id_personal");
            entity.Property(e => e.IdTblRoles).HasColumnName("id_tbl_roles");
            entity.Property(e => e.Mes).HasColumnName("mes");
        });

        modelBuilder.Entity<TblSalidaPersonal>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_salida_personal");

            entity.Property(e => e.CertificadoMedico).HasColumnName("certificado_medico");
            entity.Property(e => e.Credencial).HasColumnName("credencial");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("datetime")
                .HasColumnName("fecha_salida");
            entity.Property(e => e.IdPersonal).HasColumnName("id_personal");
            entity.Property(e => e.IdSalida).HasColumnName("id_salida");
            entity.Property(e => e.Observarciones)
                .HasMaxLength(300)
                .HasColumnName("observarciones");
            entity.Property(e => e.Roles).HasColumnName("roles");
            entity.Property(e => e.Uniformes).HasColumnName("uniformes");
        });

        modelBuilder.Entity<Terreno>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TERRENOS");

            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoTerreno).HasColumnName("ESTADO_TERRENO");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Medida).HasColumnName("MEDIDA");
            entity.Property(e => e.Ubicacion).HasColumnName("UBICACION");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TERRENOS_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<TicketsFarmaciaComecsa>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("PK_ID_TICKET");

            entity.ToTable("TICKETS_FARMACIA_COMECSA");

            entity.Property(e => e.IdTicket)
                .ValueGeneratedNever()
                .HasColumnName("ID_TICKET");
            entity.Property(e => e.ApellidosNombres).HasColumnName("APELLIDOS_NOMBRES");
            entity.Property(e => e.Cedularuc).HasColumnName("CEDULARUC");
            entity.Property(e => e.DetalleObservacion).HasColumnName("DETALLE_OBSERVACION");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.NumTicket).HasColumnName("NUM_TICKET");
            entity.Property(e => e.TipoTicket).HasColumnName("TIPO_TICKET");
        });

        modelBuilder.Entity<TiqueteMaquinaRegistradoraCompra>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TIQUETE_MAQUINA_REGISTRADORA_COMPRA");

            entity.Property(e => e.EstadoTiqueteMaquina).HasColumnName("ESTADO_TIQUETE_MAQUINA");
            entity.Property(e => e.FechaEmisionTiqueteMaquina)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION_TIQUETE_MAQUINA");
            entity.Property(e => e.IdProveedorGeneral).HasColumnName("ID_PROVEEDOR_GENERAL");
            entity.Property(e => e.IdTiqueteMaquina).HasColumnName("ID_TIQUETE_MAQUINA");
            entity.Property(e => e.IvaTiqueteMaquina)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("IVA_TIQUETE_MAQUINA");
            entity.Property(e => e.NumAutoSriTiqueteMaquina)
                .HasMaxLength(50)
                .HasColumnName("NUM_AUTO_SRI_TIQUETE_MAQUINA");
            entity.Property(e => e.NumeroTiqueteMaquina)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_TIQUETE_MAQUINA");
            entity.Property(e => e.SubtotalTiqueteMaquina)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SUBTOTAL_TIQUETE_MAQUINA");
            entity.Property(e => e.TotalTiqueteMaquina)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_TIQUETE_MAQUINA");
        });

        modelBuilder.Entity<UnidadMedidum>(entity =>
        {
            entity.HasKey(e => e.IdUnidadMedida);

            entity.ToTable("UNIDAD_MEDIDA");

            entity.Property(e => e.IdUnidadMedida)
                .ValueGeneratedNever()
                .HasColumnName("ID_UNIDAD_MEDIDA");
            entity.Property(e => e.CodigoUnidadMedida)
                .HasMaxLength(5)
                .HasColumnName("CODIGO_UNIDAD_MEDIDA");
            entity.Property(e => e.DetalleUnidadMedida).HasColumnName("DETALLE_UNIDAD_MEDIDA");
            entity.Property(e => e.EstadoUnidadMedida).HasColumnName("ESTADO_UNIDAD_MEDIDA");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__096B112E");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("('1')")
                .HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(60)
                .HasColumnName("password");
            entity.Property(e => e.RememberToken)
                .HasMaxLength(100)
                .HasColumnName("remember_token");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_profiles__110C32F6");

            entity.ToTable("user_profiles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.Birthdate)
                .HasColumnType("datetime")
                .HasColumnName("birthdate");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Twitter)
                .HasMaxLength(255)
                .HasColumnName("twitter");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .HasColumnName("website");

            entity.HasOne(d => d.User).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_profiles_user_id_foreign");
        });

        modelBuilder.Entity<UsuarioGeneral>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("USUARIO_GENERAL");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("ID_USUARIO");
            entity.Property(e => e.Datos).HasColumnName("DATOS");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.IdArea).HasColumnName("ID_AREA");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdPersonal)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdRol).HasColumnName("ID_ROL");
            entity.Property(e => e.IdSucursal).HasColumnName("ID_SUCURSAL");
            entity.Property(e => e.Login).HasColumnName("LOGIN");
            entity.Property(e => e.Password).HasColumnName("PASSWORD");
            entity.Property(e => e.TipoUsuario).HasColumnName("TIPO_USUARIO");
        });

        modelBuilder.Entity<ValoresSecuenciale>(entity =>
        {
            entity.HasKey(e => e.IdValores);

            entity.ToTable("VALORES_SECUENCIALES");

            entity.Property(e => e.IdValores)
                .ValueGeneratedNever()
                .HasColumnName("ID_VALORES");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VEHICULOS");

            entity.Property(e => e.AnoFabricacion).HasColumnName("ANO_FABRICACION");
            entity.Property(e => e.Aseguradora).HasColumnName("ASEGURADORA");
            entity.Property(e => e.Broker).HasColumnName("BROKER");
            entity.Property(e => e.Capacidad).HasColumnName("CAPACIDAD");
            entity.Property(e => e.Chasis).HasColumnName("CHASIS");
            entity.Property(e => e.Cilindraje).HasColumnName("CILINDRAJE");
            entity.Property(e => e.Color).HasColumnName("COLOR");
            entity.Property(e => e.CostoPrima)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("COSTO_PRIMA");
            entity.Property(e => e.DispositivoSeguridad).HasColumnName("DISPOSITIVO_SEGURIDAD");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.EstadoActivo).HasColumnName("ESTADO_ACTIVO");
            entity.Property(e => e.FechaFinalContrato)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_FINAL_CONTRATO");
            entity.Property(e => e.FechaFinalDisSeg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_FINAL_DIS_SEG");
            entity.Property(e => e.FechaInicioContrato)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO_CONTRATO");
            entity.Property(e => e.FechaInicioDisSeg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INICIO_DIS_SEG");
            entity.Property(e => e.FechaRenovacionContrato)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_RENOVACION_CONTRATO");
            entity.Property(e => e.FechaRenovacionDisSeg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_RENOVACION_DIS_SEG");
            entity.Property(e => e.IdActivoFijo).HasColumnName("ID_ACTIVO_FIJO");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Modelo).HasColumnName("MODELO");
            entity.Property(e => e.Motor).HasColumnName("MOTOR");
            entity.Property(e => e.NroPoliza).HasColumnName("NRO_POLIZA");
            entity.Property(e => e.Placas).HasColumnName("PLACAS");
            entity.Property(e => e.Seguro).HasColumnName("SEGURO");
            entity.Property(e => e.Serie).HasColumnName("SERIE");
            entity.Property(e => e.Soat)
                .HasColumnType("datetime")
                .HasColumnName("SOAT");
            entity.Property(e => e.Tipo).HasColumnName("TIPO");

            entity.HasOne(d => d.IdActivoFijoNavigation).WithMany()
                .HasForeignKey(d => d.IdActivoFijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VEHICULOS_ACTIVO_FIJO_GENERAL");
        });

        modelBuilder.Entity<VehiculosOtro>(entity =>
        {
            entity.HasKey(e => e.IdVehiculos);

            entity.ToTable("VEHICULOS_OTROS");

            entity.Property(e => e.IdVehiculos)
                .ValueGeneratedNever()
                .HasColumnName("ID_VEHICULOS");
            entity.Property(e => e.Capacidad).HasColumnName("CAPACIDAD");
            entity.Property(e => e.Chasis).HasColumnName("CHASIS");
            entity.Property(e => e.Cilindraje).HasColumnName("CILINDRAJE");
            entity.Property(e => e.Color).HasColumnName("COLOR");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Marca).HasColumnName("MARCA");
            entity.Property(e => e.Modelo).HasColumnName("MODELO");
            entity.Property(e => e.Motor).HasColumnName("MOTOR");
            entity.Property(e => e.NombreVehiculo).HasColumnName("NOMBRE_VEHICULO");
            entity.Property(e => e.Placas).HasColumnName("PLACAS");
            entity.Property(e => e.Responsable).HasColumnName("RESPONSABLE");
            entity.Property(e => e.Serie).HasColumnName("SERIE");
            entity.Property(e => e.Soat)
                .HasColumnType("datetime")
                .HasColumnName("SOAT");
            entity.Property(e => e.TipoVehiculo).HasColumnName("TIPO_VEHICULO");
            entity.Property(e => e.Ubicacion).HasColumnName("UBICACION");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
