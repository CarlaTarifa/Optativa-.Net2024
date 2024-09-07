namespace SGEfinal.Aplicacion;
public class ServicioAutorizacion:IServicioAutorizacion{
    public bool PoseeElPermiso(Usuario user,Permiso permiso){
        if(user.idUsuario==1){// si es el administrador tiene todos los permisos
            return true;

        }
        else {
            //si es usuario comun, solo tiene permiso de lectura 
            return user.permisos.Contains(permiso);
        }
    }
}