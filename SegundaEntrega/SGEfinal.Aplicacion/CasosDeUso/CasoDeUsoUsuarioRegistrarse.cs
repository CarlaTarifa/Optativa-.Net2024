namespace SGEfinal.Aplicacion;
public class CasoDeUsoUsuarioRegistrarse(IUsuarioRepositorio uRepo,IServicioHash servicioHash){
    public void Ejecutar(Usuario user){
        if(user.contra!=null)
             user.contra= servicioHash.funcionHash(user.contra);
        uRepo.Registrar(user);
    }
}