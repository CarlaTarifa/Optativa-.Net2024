namespace SGEfinal.Aplicacion;
public class CasoDeUsoUsuarioOtorgarPermiso(IUsuarioRepositorio uRepo){
    public void Ejecutar(int idUsuario,Permiso p){
        uRepo.EntregarPermiso(idUsuario,p);
    }
}