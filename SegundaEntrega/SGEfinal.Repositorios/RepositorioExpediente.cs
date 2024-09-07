using SGEfinal.Aplicacion;
namespace SGEfinal.Repositorios;
public class RepositorioExpediente:IExpedienteRepositorio
{
    public void AltaExpediente(Expediente e){
        using var db=new BaseContext();
        {
            db.Expedientes.Add(e);
            db.SaveChanges();

        }

    }
    public void BajaExpediente(int idExpediente){
        using var db= new BaseContext();
        {
            //busco expediente a borrar
            Expediente? expedienteBorrar=db.Expedientes.Where(e => e.idExpediente == idExpediente).SingleOrDefault();
            //si encontre el expediente
            if(expedienteBorrar!=null){
                db.Remove(expedienteBorrar);
            }
            //guardo los cambios efectuados
            db.SaveChanges();
            
        }    
    }
    public void ModificacionE(Expediente e,Usuario user){
        using var db= new BaseContext();
        {
            Expediente? expedienteModificar= db.Expedientes.Where(d=> d.idExpediente==e.idExpediente).SingleOrDefault();
            if(expedienteModificar!=null){
                if(expedienteModificar.caratula!= e.caratula && e.caratula!=" "){
                    expedienteModificar.caratula=e.caratula;
                }
                if(expedienteModificar.estadoE!= e.estadoE && e.estadoE.Equals("")){
                    expedienteModificar.estadoE=e.estadoE;                    
                }
                expedienteModificar.ultimaModificacion=DateTime.Now;
                expedienteModificar.idUsuario=user.idUsuario;
            }
            db.SaveChanges();
        }
    }
    /**********************Muestro todos los expedientes**************/
   public List<Expediente> ListarExpedientes(){
    using var db= new BaseContext();
    {
        return db.Expedientes.ToList();
    }
   }

    /***********Busca Expediente por ID**********/
    public Expediente? ConsultaPorId(int idExpediente){
        using var db=new BaseContext();
        return db.Expedientes.Where(t=> t.idExpediente==idExpediente).SingleOrDefault();
    }

    /**********Muestro expediente junto con sus tramites ********/
    public List<object> ListarTodos(int idExpediente){
        List<object> lista= new List<object>();// para guardar tanto el expediente como los tramites
        using var db=new BaseContext();
        //busco expediente 
       // var exp= db.Expedientes.Where(e => e.idExpediente==idExpediente).SingleOrDefault();
        //if(exp!=null){
          //  lista.Add(exp);
            //busco su lista de tramites
            //var trami=db.Tramites.Where(t => t.idExpediente==idExpediente).ToList();
            //lista.AddRange(trami);//agrego toda la lista de tramites a lalista
        //}
        return lista;

    }

}