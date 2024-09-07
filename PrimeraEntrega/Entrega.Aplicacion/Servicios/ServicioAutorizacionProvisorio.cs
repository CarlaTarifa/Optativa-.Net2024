namespace Entrega.Aplicacion;

public class ServicioAutorizacionProvisorio:IServicioAutorizacion{
    public bool PoseeElPermiso(int IdUsuario,Permiso permiso){
        if(IdUsuario <0){
            return false;
        }
        else return true;
    }

}