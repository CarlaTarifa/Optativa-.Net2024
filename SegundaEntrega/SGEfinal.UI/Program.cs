using SGEfinal.UI.Components;

//agrego directivas using 
using SGEfinal.Repositorios;
using SGEfinal.Aplicacion;

BaseSqlite.Inicializar();
//BaseContext context= new BaseContext();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//agregar servicios al contenedor DI
/****Casos de uso expediente***/
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoExpedienteListarExpedientes>();
builder.Services.AddTransient<CasoDeUsoExpedienteListarTodos>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();
/*******Casos de uso Tramite****/
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorEtiqueta>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaTramite>();
builder.Services.AddTransient<CasoDeUsoTramiteListarTramites>();
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
/******Casos de uso Usuario ****/
builder.Services.AddTransient<CasoDeUsoUsuarioConsultaId>();
builder.Services.AddTransient<CasoDeUsoUsuarioEliminar>();
builder.Services.AddTransient<CasoDeUsoUsuarioIngresar>();
builder.Services.AddTransient<CasoDeUsoUsuarioListarTodos>();
builder.Services.AddTransient<CasoDeUsoUsuarioModificar>();
builder.Services.AddTransient<CasoDeUsoUsuarioOtorgarPermiso>();
builder.Services.AddTransient<CasoDeUsoUsuarioQuitarPermiso>();
builder.Services.AddTransient<CasoDeUsoUsuarioRegistrarse>();
//Validadores
builder.Services.AddScoped<ExpedienteValidador>();
builder.Services.AddScoped<TramiteValidador>();
//Repositorios
builder.Services.AddScoped<IExpedienteRepositorio,RepositorioExpediente>();
builder.Services.AddScoped<ITramiteRepositorio,RepositorioTramite>();
builder.Services.AddScoped<IUsuarioRepositorio,RepositorioUsuario>();
//Servicios
builder.Services.AddScoped<IActualizacionEstado,ServicioActualizacionEstado>();
builder.Services.AddScoped<IEspecificacionCambioEstado,EspecificacionCambioEstado>();
builder.Services.AddScoped<IServicioAutorizacion,ServicioAutorizacion>();
builder.Services.AddScoped<IServicioHash,ServicioHash>();
builder.Services.AddSingleton<ServicioIniciar>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
