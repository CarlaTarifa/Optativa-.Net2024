namespace Entrega.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio tRepo,IServicioAutorizacion servicio){
   public void Ejecutar(Tramite tramite,int idUsuario){
      if(servicio.PoseeElPermiso(idUsuario,Permiso.TramiteModificacion)){
         throw new AutorizacionException("No tiene los permisos necesarios");
      }
      tRepo.ModificarT(tramite);
      //actualiza estado

   }
}