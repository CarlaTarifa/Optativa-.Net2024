namespace SGEfinal.Aplicacion;
public class CasoDeUsoUsuarioListarTodos(IUsuarioRepositorio uRepo){
    public List<Usuario> Ejecutar(){
        return uRepo.ListarUsuarios();
    }
}