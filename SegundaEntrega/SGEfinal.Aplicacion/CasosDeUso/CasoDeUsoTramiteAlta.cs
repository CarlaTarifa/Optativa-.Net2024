namespace SGEfinal.Aplicacion;
public class CasoDeUsoTramiteAlta(ITramiteRepositorio tRepo,IExpedienteRepositorio exRepo,TramiteValidador tramiteValidador,IServicioAutorizacion servicio ){
    public void Ejecutar (Tramite t,Usuario user){
      if(!servicio.PoseeElPermiso(user ,Permiso.TramiteAlta)){
            throw new AutorizacionException("No tiene los permisos necesario");
        } 
        else{
             t.idUsuario=user.idUsuario;
            if(!tramiteValidador.validarT(t,out string mensajeError)){
                throw new Exception(mensajeError);
            }
            else{
                 t.creacionT=DateTime.Now;
                 t.modificacionT=DateTime.Now;
                 Expediente? ex=exRepo.ConsultaPorId(t.idExpediente);//Busco expediente para agregarlo a la lista de tramites
                 if(ex!=null){
                 tRepo.AltaTramite(t);
                 //actualizar estado
                 }


            }

        } 
    }
}