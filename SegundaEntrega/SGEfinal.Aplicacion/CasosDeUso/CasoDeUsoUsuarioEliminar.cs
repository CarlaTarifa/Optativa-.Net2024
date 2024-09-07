namespace SGEfinal.Aplicacion;
public class CasoDeUsoUsuarioEliminar(IUsuarioRepositorio uRepo){
    public void Ejecutar(int idUsuario){
        uRepo.EliminarUsuario(idUsuario);
    }
}