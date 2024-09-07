namespace SGEfinal.Aplicacion;
public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio exRepo,IServicioAutorizacion serivicio){
    public void Ejecutar(Expediente expediente,Usuario user){
        if(!serivicio.PoseeElPermiso(user,Permiso.ExpedienteModificacion)){
            throw new AutorizacionException("No posee los permisos necesarios");
        }
        else {
            exRepo.ModificacionE(expediente,user);
        }
    }
}