using Entrega.Aplicacion;
using Entrega.Repositorios;

//Configuro las dependencias 
//Repositorios
ITramiteRepositorio repoTramite= new RepositorioTramite();
IExpedienteRepositorio repoExpediente=new RepositorioExpediente();
IServicioAutorizacion servicio = new ServicioAutorizacionProvisorio();
// creo casos de uso para expedientes
var altaExp= new CasoDeUsoExpedienteAlta(repoExpediente,new ExpedienteValidador(),new ServicioAutorizacionProvisorio());
var bajaExp= new CasoDeUsoExpedienteBaja(repoExpediente,new ExpedienteValidador(),new ServicioAutorizacionProvisorio()); 
var modificarExp=new CasoDeUsoExpedienteModificacion(repoExpediente,new ServicioAutorizacionProvisorio());
var consultaExpId= new CasoDeUsoExpedienteConsultaPorId(repoExpediente);
var consultaTodosExp=new CasoDeUsoExpedienteConsultaTodos(repoExpediente);
// creo casos de uso para tramites
var altaTramite=new CasoDeUsoTramiteAlta(repoTramite,new ServicioAutorizacionProvisorio(),new TramiteValidador());
var bajaTramite=new CasoDeUsoTramiteBaja(repoTramite,new ServicioAutorizacionProvisorio());
var modificarTramite=new CasoDeUsoTramiteModificacion(repoTramite,new ServicioAutorizacionProvisorio());
var consultaEtiqueta=new CasoDeUsoTramiteConsultaPorEtiqueta(repoTramite);


// ejecuto casos de uso 
/*altaExp.Ejecutar(new Expediente(){idTramite=1,caratula="tramite1",idUsuario=1,estadoE=(EstadoExpediente)0 },1);
altaExp.Ejecutar(new Expediente(){idTramite=3,caratula="tramite3",idUsuario=1,estadoE=(EstadoExpediente)0 },1);
altaExp.Ejecutar(new Expediente(){idTramite=5,caratula="tramite 5",idUsuario=1,estadoE=(EstadoExpediente)0 },1);
altaExp.Ejecutar(new Expediente(){idTramite=12,caratula="tramite7",idUsuario=2,estadoE=(EstadoExpediente)0 },2);
altaTramite.Ejecutar(new Tramite(){idTramite=1,idExpediente=1,etiqueta=(EtiquetaTramite)0,contenidoT="Tramite1",idUsuario=1},1,1);
altaTramite.Ejecutar(new Tramite(){idTramite=2,idExpediente=1,etiqueta=(EtiquetaTramite)1,contenidoT="Tramite2",idUsuario=1},1,1);
altaTramite.Ejecutar(new Tramite(){idTramite=5,idExpediente=2,etiqueta=(EtiquetaTramite)0,contenidoT="Tramite5",idUsuario=2},1,2);

bajaExp.Ejecutar(2,1);
bajaTramite.Ejecutar(2,1);
*/
var lista = consultaTodosExp.Ejecutar();
foreach(Expediente ex in lista)
{
Console.WriteLine(ex.idExpediente);
}