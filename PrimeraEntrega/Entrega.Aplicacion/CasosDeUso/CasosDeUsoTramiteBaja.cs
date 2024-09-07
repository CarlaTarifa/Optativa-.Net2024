namespace Entrega.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio tRepo,IServicioAutorizacion servicio){
   public void Ejecutar(int idExpediente,int idUsuario){
      if(!servicio.PoseeElPermiso(idUsuario,Permiso.TramiteBaja)){
         throw new AutorizacionException("No tiene los permisos necesarios");
      }
      tRepo.BajaTramite(idExpediente);
   }
   
   public void Ejecutar(Tramite tramite,int idUsuario){
      if(!servicio.PoseeElPermiso(idUsuario,Permiso.TramiteBaja)){
         throw new AutorizacionException("No tiene los permisos necesarios");
      }
      tRepo.BajaTramite(tramite);
   }
}