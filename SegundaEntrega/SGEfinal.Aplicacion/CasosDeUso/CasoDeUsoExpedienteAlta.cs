namespace SGEfinal.Aplicacion;
public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio exRepo,ExpedienteValidador expVal,IServicioAutorizacion servicio){
    public void Ejecutar(Expediente expediente,Usuario user){
        if(!servicio.PoseeElPermiso(user,Permiso.ExpedienteAlta)){
            throw new AutorizacionException("No tiene los permisos necesario");
        }
        else {
            expediente.idUsuario=user.idUsuario;
            if(!expVal.validarE(expediente,out string mensajeError)){
                throw new Exception(mensajeError);
            }
            else {
                expediente.creacion= DateTime.Now;//Actualizo fecha de creacion
                expediente.ultimaModificacion=DateTime.Now;//Actualiza fecha de modificacion
                exRepo.AltaExpediente(expediente);
            }
        }

    }
}