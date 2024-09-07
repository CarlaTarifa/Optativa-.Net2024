namespace SGEfinal.Aplicacion;
public class CasoDeUsoTramiteBaja(ITramiteRepositorio tRepo,IServicioAutorizacion servicio){
    public void Ejecutar(int idExpediente,Usuario user){
        if(!servicio.PoseeElPermiso(user ,Permiso.TramiteBaja)){
            throw new AutorizacionException("No tiene los permisos necesario");
        }
        else {
            tRepo.BajaTramite(idExpediente);
        }
    }
}