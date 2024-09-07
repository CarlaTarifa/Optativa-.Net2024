namespace SGEfinal.Aplicacion;
public class CasoDeUsoUsuarioConsultaId(IUsuarioRepositorio uRepo){
    public Usuario Ejecutar(int idUsuario){
        Usuario? user= uRepo.ConsultaUsuarioId( idUsuario);
        if(user == null){
            throw new RepositorioException("No existe Usuario");

        }
        else{
            return user;
        }
    }
}