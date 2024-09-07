namespace SGEfinal.Aplicacion;
public interface IUsuarioRepositorio{
    public void Registrar(Usuario user);
    public Usuario? Ingresar(string email,string contra);
    public void EliminarUsuario(int idUsuario);
    public void ModificarUsuario(Usuario user);
    public List<Usuario> ListarUsuarios();
    public Usuario? ConsultaUsuarioId(int idUsuario);
    public void EntregarPermiso(int idUsuario,Permiso p);
    public void QuitarPermiso(int idUsuario,Permiso p);
}