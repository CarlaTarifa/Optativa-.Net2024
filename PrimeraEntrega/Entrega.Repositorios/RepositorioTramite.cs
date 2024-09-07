namespace Entrega.Repositorios;
using Entrega.Aplicacion;
public class RepositorioTramite: ITramiteRepositorio{
    readonly string _nombreArch = "Tramite.txt";
    private RepositorioTramite repoT;

    /* ----------------Alta de un tramite --------------- */
    public void AltaTramite(Tramite tramite,int idExpediente,int idUsuario){
        tramite.idExpediente=idExpediente;
        tramite.idUsuario=idUsuario;
        tramite.creacionT=DateTime.Now;
        tramite.modificacionT=DateTime.Now;
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(tramite.idTramite);
        sw.WriteLine(tramite.idExpediente);
        sw.WriteLine(tramite.etiqueta);
        sw.WriteLine(tramite.contenidoT);
        sw.WriteLine(tramite.creacionT);
        sw.WriteLine(tramite.modificacionT);
        sw.WriteLine(tramite.idUsuario);    
    }
    /*----------------Baja de un tramite----------------------------------*/
     public void BajaTramite(Tramite tramite){
         List<Tramite> tramitesNoEliminados= new List<Tramite>();
         var lines = File.ReadAllLines(_nombreArch);
         for (int i = 0; i < lines.Length; i += 7)
         { if (int.Parse(lines[i]) != tramite.idTramite)
                {
                    Tramite tramiteActual=new Tramite();
                   tramiteActual.idTramite=int.Parse(lines[i]); 
                    tramiteActual.idExpediente=int.Parse(lines[i+1]);
                 tramiteActual.etiqueta=Enum.Parse<EtiquetaTramite>(lines[i+2]);
                 tramiteActual.contenidoT=lines[i+3];
                 tramiteActual.creacionT=DateTime.Parse(lines[i+4]);
                 tramiteActual.modificacionT=DateTime.Parse(lines[i+5]);
                 tramiteActual.idUsuario=int.Parse(lines[i+6]);
                 tramitesNoEliminados.Add(tramiteActual);
                }
            }

         //Reescribo el archivo tramite
         using var sw= new StreamWriter(_nombreArch, true);
         foreach(var tram in tramitesNoEliminados){
             sw.WriteLine(tram.idExpediente);
             sw.WriteLine(tram.idTramite);
             sw.WriteLine(tram.etiqueta);
             sw.WriteLine(tram.contenidoT);
             sw.WriteLine(tram.creacionT);
             sw.WriteLine(tram.modificacionT);
             sw.WriteLine(tram.idUsuario);
          }
     }
    

    /* ---------------Baja de un tramite cuando se elimina expediente ------------------ */

    public void BajaTramite(int idExpediente){
        List<Tramite> tramitesNoEliminados= new List<Tramite>();
        var lines = File.ReadAllLines(_nombreArch);
         for (int i = 0; i < lines.Length; i += 7)
         { if (int.Parse(lines[i]) != idExpediente)
                {
                    Tramite tramiteActual=new Tramite();
                   tramiteActual.idTramite=int.Parse(lines[i]); 
                    tramiteActual.idExpediente=int.Parse(lines[i+1]);
                 tramiteActual.etiqueta=Enum.Parse<EtiquetaTramite>(lines[i+2]);
                 tramiteActual.contenidoT=lines[i+3];
                 tramiteActual.creacionT=DateTime.Parse(lines[i+4]);
                 tramiteActual.modificacionT=DateTime.Parse(lines[i+5]);
                 tramiteActual.idUsuario=int.Parse(lines[i+6]);
                 tramitesNoEliminados.Add(tramiteActual);
                }
            }


        //Reescribo el archivo tramite
         using var sw= new StreamWriter(_nombreArch, true);
        foreach(var tram in tramitesNoEliminados){
            sw.WriteLine(tram.idExpediente);
            sw.WriteLine(tram.idTramite);
            sw.WriteLine(tram.etiqueta);
            sw.WriteLine(tram.contenidoT);
            sw.WriteLine(tram.creacionT);
            sw.WriteLine(tram.modificacionT);
            sw.WriteLine(tram.idUsuario);
        }

    }

    /*-------------------Modifico un tramite -------------------- */

    public void ModificarT(Tramite tramite){
     List<Tramite> tramiteActualizados = new List<Tramite>();
     using StreamReader sr = new StreamReader(_nombreArch);
     string linea;
     while ((linea = sr.ReadLine()) != null){
         Tramite tramiteActual = new Tramite();
         tramiteActual.idExpediente = int.Parse(linea);
         tramiteActual.idTramite=int.Parse(sr.ReadLine());
         tramiteActual.etiqueta=Enum.Parse<EtiquetaTramite>(sr.ReadLine() ?? "");
         tramiteActual.contenidoT=sr.ReadLine() ?? "";
         tramiteActual.creacionT=DateTime.Parse(sr.ReadLine());
         tramiteActual.modificacionT=DateTime.Parse(sr.ReadLine());
         tramiteActual.idUsuario=int.Parse(sr.ReadLine());
         // Verifico si tramite actual es el que voy a modificar
         if (tramiteActual.idExpediente == tramite.idExpediente) {
             tramite.modificacionT=DateTime.Now;
             tramiteActualizados.Add(tramite);
         }
         else{
             tramiteActualizados.Add(tramiteActual);
         }
     }
     //Reescribo el archivo tramite
     using var sw= new StreamWriter(_nombreArch, true);
     foreach(var tram in tramiteActualizados){
         sw.WriteLine(tram.idExpediente);
         sw.WriteLine(tram.idTramite);
         sw.WriteLine(tram.etiqueta);
         sw.WriteLine(tram.contenidoT);
         sw.WriteLine(tram.creacionT);
         sw.WriteLine(tram.modificacionT);
         sw.WriteLine(tram.idUsuario);
        }
    }

    /* ----------------Muestro todos los tramites que corresponde a un expediente -----------------*/
    
    public List<Tramite> ListarTramites(int idExpediente){
        List<Tramite> result= new List<Tramite>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream){
           Tramite tramiteAct = new Tramite();
            tramiteAct.idExpediente=int.Parse(sr.ReadLine());
            if(tramiteAct.idExpediente==idExpediente){
                tramiteAct.idTramite=int.Parse(sr.ReadLine());
                tramiteAct.contenidoT=sr.ReadLine();
                tramiteAct.creacionT=DateTime.Parse(sr.ReadLine());
                tramiteAct.modificacionT=DateTime.Parse(sr.ReadLine());
                tramiteAct.idUsuario=int.Parse(sr.ReadLine());            
                result.Add(tramiteAct);
            }
        }
        return result;
    }

    /*---------------------------------Devuelvo todos los tramites bajo una misma etiqueta ---------------------*/
    public List<Tramite> ConsultaEtiqueta(EtiquetaTramite etiquetaT){
        List<Tramite> result= new List<Tramite>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream){
           Tramite tramiteAct = new Tramite();
            if(tramiteAct.etiqueta==etiquetaT){
                tramiteAct.idExpediente=int.Parse(sr.ReadLine());
                tramiteAct.idTramite=int.Parse(sr.ReadLine());
                tramiteAct.contenidoT=sr.ReadLine();
                tramiteAct.creacionT=DateTime.Parse(sr.ReadLine());
                tramiteAct.modificacionT=DateTime.Parse(sr.ReadLine());
                tramiteAct.idUsuario=int.Parse(sr.ReadLine());            
                result.Add(tramiteAct);
            }
        }
        return result;
    }
    

}
