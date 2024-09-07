namespace Entrega.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio tRepo,IServicioAutorizacion servicio,TramiteValidador tramiteValidador){
    public void Ejecutar(Tramite tramite,int idExpediente,int idUsuario){
       if(!servicio.PoseeElPermiso(idUsuario,Permiso.TramiteAlta)){
         throw new AutorizacionException("No poseer permiso");
         }
       if(!tramiteValidador.validarT(tramite,out string mensajeError)){
          throw new Exception(mensajeError);
        }
        tRepo.AltaTramite(tramite,idExpediente,idUsuario);
        //Deberia actualizar estado     
    }
}