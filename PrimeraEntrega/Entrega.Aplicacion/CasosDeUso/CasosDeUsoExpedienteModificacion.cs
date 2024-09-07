namespace Entrega.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio exRepo,IServicioAutorizacion servicio){
    public void Ejecutar(Expediente ex,int idUsuario){
       if(!servicio.PoseeElPermiso(idUsuario,Permiso.ExpedienteModificacion)){
          throw new AutorizacionException("No tiene los permisos necesarios");
       }
       List<Expediente> idExpedientes=exRepo.ListarTodos();
       Boolean valido=false;
       foreach(Expediente exp in idExpedientes){
          if(exp.idExpediente==ex.idExpediente){
             valido=true;
          }
       }
       if(!valido){
          throw new RepositorioException("No existe expediente"); 
       }
       else {
          exRepo.ModificacionE(ex,idUsuario);
       }
     }
}