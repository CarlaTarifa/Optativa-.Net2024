using SGEfinal.Aplicacion;
namespace SGEfinal.Repositorios;
public class RepositorioTramite: ITramiteRepositorio {
public void AltaTramite(Tramite t){
        using var db=new BaseContext();
        {
            db.Tramites.Add(t);
            db.SaveChanges();

        }

    }
    public void BajaTramite(int idExpediente){
        using var db= new BaseContext();
        {
            //busco expediente a borrar
            Tramite? tramiteBorrar=db.Tramites.Where(d => d.idExpediente == idExpediente).SingleOrDefault();
            //si encontre el tramite
            if(tramiteBorrar!=null){
                db.Remove(tramiteBorrar);
            }
            //guardo los cambios efectuados
            db.SaveChanges();
            
        }    
    }
    public void ModificarT(Tramite t,Usuario user){
        using var db= new BaseContext();
        {
            Tramite? tramiteModificar= db.Tramites.Where(tramiteModificar=> tramiteModificar.idTramite==t.idTramite).SingleOrDefault();
            if(tramiteModificar!=null){
              tramiteModificar.etiqueta=t.etiqueta;
              tramiteModificar.contenidoT=t.contenidoT;
              tramiteModificar.modificacionT= DateTime.Now;
              tramiteModificar.idUsuario=user.idUsuario;
            }

            db.SaveChanges();
        }
    }
    /**********************Devuelve los tramites bajo una misma etiqueta**************/
   public List<Tramite> ConsultaEtiqueta(EtiquetaTramite etiquetaT){
    using var db= new BaseContext();
    return db.Tramites.Where(t=>t.etiqueta==etiquetaT).ToList();

   }
   /***********************Muestra los tramites de un mismo expediente******/
   public List<Tramite> ConsultaPorId(int idExpediente){
    using var db= new BaseContext();
    return  db.Tramites.Where(t=>t.idExpediente==idExpediente).ToList();
        
   }
   /**********Lista todos los tramites *******/
   
   public List<Tramite> ListarTramites(){
    using var db= new BaseContext();
    return db.Tramites.ToList();
   }

   /***********Consulto por un tramite en especial ********/

   public Tramite? ConsultaTramite( int idTramite){
     using var db=new BaseContext();
     return db.Tramites.Where(t=>t.idTramite==idTramite).SingleOrDefault();
   }


}