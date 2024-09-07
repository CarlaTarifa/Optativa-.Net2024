namespace Entrega.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio exRepo,ExpedienteValidador expedienteValidador, IServicioAutorizacion servicio){

     public void Ejecutar(int idExpediente,int idUsuario){
         if(!servicio.PoseeElPermiso(idUsuario,Permiso.ExpedienteBaja)){
            throw new AutorizacionException("No tiene los permisos necesarios");
         }
         List<Expediente> idExpedientes=exRepo.ListarTodos();
         Boolean valido=false;
         foreach(Expediente ex in idExpedientes){
             if(ex.idExpediente==idExpediente){
                 valido=true;
             }
         }
         if(!valido){
            throw new RepositorioException("No existe expediente"); 
         }
         else {
            exRepo.BajaExpediente(idExpediente);
         }
     }
}
