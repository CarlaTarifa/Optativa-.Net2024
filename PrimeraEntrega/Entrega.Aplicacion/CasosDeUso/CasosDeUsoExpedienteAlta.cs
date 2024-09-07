namespace Entrega.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio exRepo,ExpedienteValidador expedienteValidador,IServicioAutorizacion servicio) {

    public void Ejecutar(Expediente expediente,int idUsuario){
        if( !servicio.PoseeElPermiso(idUsuario,Permiso.ExpedienteAlta)){
            throw new AutorizacionException("No tiene los permisos necesario");
        
        }
        if(!expedienteValidador.validarE(expediente, out string mensajeError)){// chequeo que caratula no este vacia
             throw new Exception(mensajeError);
        }
        else{
             exRepo.AltaExpediente(expediente);     
        }
    }

}