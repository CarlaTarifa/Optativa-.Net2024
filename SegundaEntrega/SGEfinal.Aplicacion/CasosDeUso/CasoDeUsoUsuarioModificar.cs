namespace SGEfinal.Aplicacion;
public class CasoDeUsoUsuarioModificar(IUsuarioRepositorio uRepo,IServicioHash servicioHash){
    public void Ejecutar(Usuario user){
        user.contra= servicioHash.funcionHash(user.contra);
        uRepo.ModificarUsuario(user);
        
    }
}