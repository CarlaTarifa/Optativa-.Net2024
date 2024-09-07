using SGEfinal.Aplicacion;
using System.Text;
using System.Security.Cryptography;
namespace SGEfinal.Repositorios;


public class RepositorioUsuario:IUsuarioRepositorio {
    public void Registrar(Usuario user){
        using var db= new BaseContext();
        Usuario? urepe=db.Usuarios.Where(x=> x.email==user.email).SingleOrDefault();
        
        //Si es el admin osea el id=1 tiene todos los permisos
        if(user.idUsuario==1){
            user.permisos.Add(Permiso.ExpedienteAlta);
            user.permisos.Add(Permiso.ExpedienteBaja);
            user.permisos.Add(Permiso.ExpedienteModificacion);
            user.permisos.Add(Permiso.TramiteAlta);
            user.permisos.Add(Permiso.TramiteBaja);
            user.permisos.Add(Permiso.TramiteModificacion);
            user.permisos.Add(Permiso.UsuarioBaja);
            user.permisos.Add(Permiso.UsuarioModificacion);
            user.permisos.Add(Permiso.UsuarioListar);
        }
        else {
            user.permisos.Add(Permiso.Lectura);
        }
        if(urepe==null){
            db.Usuarios.Add(user);
            db.SaveChanges();
        }

    }
    public Usuario? Ingresar(string email,string contra){
        using var db=new BaseContext();
        Usuario? user= db.Usuarios.Where(u => u.email == email).SingleOrDefault();
        if(user != null){
            return user;
        }
        return null;

    }
    public void EliminarUsuario(int idUsuario){
        using var db=new BaseContext();
        Usuario? user= db.Usuarios.Where(u => u.idUsuario==idUsuario).SingleOrDefault();
        if(user != null){
            db.Usuarios.Remove(user);
        }
        db.SaveChanges();
    }
    public void ModificarUsuario(Usuario user){
        using var db=new BaseContext();
        Usuario? userM= db.Usuarios.Where(u => u.idUsuario== user.idUsuario).SingleOrDefault();
        if( userM!=null){
            userM.nombre=user.nombre;
            userM.apellido=user.apellido;
            userM.email=user.email;
            userM.contra=user.contra;
        }
        db.SaveChanges();
    }
    public List<Usuario> ListarUsuarios(){
        using var db= new BaseContext();
        return db.Usuarios.ToList();
    }
    public Usuario? ConsultaUsuarioId(int idUsuario){
        using var db= new BaseContext();
        return db.Usuarios.Where(u=>u.idUsuario== idUsuario).SingleOrDefault();
        
    }

    public void EntregarPermiso( int idUsuario,Permiso permiso){
        using var db=new BaseContext();
        Usuario? user= db.Usuarios.Where(u=> u.idUsuario== idUsuario).SingleOrDefault();
        if ( user != null){
            user.permisos.Add(permiso);
        }
        db.SaveChanges();
    }

    public void QuitarPermiso( int idUsuario,Permiso permiso){
        using var db=new BaseContext();
        Usuario? user= db.Usuarios.Where(u=> u.idUsuario== idUsuario).SingleOrDefault();
        if ( user != null){
            user.permisos.Remove(permiso);
        }
        db.SaveChanges();
    }



    

}