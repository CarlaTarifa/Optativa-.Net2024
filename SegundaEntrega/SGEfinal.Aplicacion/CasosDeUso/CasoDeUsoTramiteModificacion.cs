namespace SGEfinal.Aplicacion;
public class CasoDeUsoTramiteModificacion(ITramiteRepositorio tRepo,IServicioAutorizacion servicio)
{
    public void Ejecutar(Tramite t,Usuario user){
        if(!servicio.PoseeElPermiso(user,Permiso.TramiteModificacion)){
            throw new AutorizacionException("No posee los permisos necesarios");
        }
        else {
            tRepo.ModificarT(t,user);
        }
    }

}