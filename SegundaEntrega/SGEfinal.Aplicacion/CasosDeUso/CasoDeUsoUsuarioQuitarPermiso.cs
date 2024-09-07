namespace SGEfinal.Aplicacion;
public class CasoDeUsoUsuarioQuitarPermiso(IUsuarioRepositorio uRepo){
    public void Ejecutar(int idUsuario,Permiso p){
        uRepo.QuitarPermiso(idUsuario,p);
    }
}