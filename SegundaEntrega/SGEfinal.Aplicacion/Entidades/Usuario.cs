namespace SGEfinal.Aplicacion;
public class Usuario {
    public int idUsuario{get;set;}
    public string nombre{get;set;}="";
    public string apellido{get;set;}="";
    public string email{get;set;}="";
    public string contra{get;set;}="";
    public List<Permiso> permisos{get;set;}= new List<Permiso>(); // son 6 posibles permisos 


}