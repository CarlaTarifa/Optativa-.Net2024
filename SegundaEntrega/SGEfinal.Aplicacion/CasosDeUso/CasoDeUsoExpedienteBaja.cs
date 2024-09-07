namespace SGEfinal.Aplicacion;
public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio exRepo,ITramiteRepositorio traRepo,IServicioAutorizacion servicio){
    public void Ejecutar(int idExpediente,Usuario user){
        if(!servicio.PoseeElPermiso(user,Permiso.ExpedienteBaja)){
            throw new AutorizacionException("No tiene los permisos necesario");
        }
        else {    
            //una vez eliminado todos los tramite , procedo a eliminar el expediente
            exRepo.BajaExpediente(idExpediente);
            traRepo.BajaTramite(idExpediente);
        }


    }
}

