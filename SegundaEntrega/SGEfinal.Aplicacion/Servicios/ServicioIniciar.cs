namespace SGEfinal.Aplicacion;
public class ServicioIniciar{
    public Usuario userL {get;set;}= new();
    public void CerrarSesion(){
        userL= new Usuario();
    }


}