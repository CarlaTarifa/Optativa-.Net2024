namespace SGEfinal.Aplicacion;
public class CasoDeUsoUsuarioIngresar(IUsuarioRepositorio uRepo,IServicioHash servicioHash){
    public Usuario? Ejecutar(string email,string contra){
        string c= servicioHash.funcionHash(contra);
        Usuario? user = uRepo.Ingresar(email,c);
        if(user==null){
            throw new UsuarioException("El usuario no existe");
        }
        else {
        return uRepo.Ingresar(email,contra);
        }
    }
}