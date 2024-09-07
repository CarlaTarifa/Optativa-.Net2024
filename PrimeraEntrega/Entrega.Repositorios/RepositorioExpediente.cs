namespace Entrega.Repositorios;

using System.Xml.XPath;
using Entrega.Aplicacion;

public class RepositorioExpediente: IExpedienteRepositorio{
    readonly string _nombreArch = "Expedientes.txt";
   private static int idExpediente=1; // para incrementar automatica el id del expediente
   private RepositorioTramite repoT; // para poder llamar a los metodos cuando necesite

   /*------------------------Alta de un expediente--------------------------------------*/
    public void AltaExpediente(Expediente expediente){
     expediente.idExpediente=idExpediente++;//incremento en id de expediente
     expediente.creacion=DateTime.Now;//Fecha de creacion del archivo
     expediente.ultimaModificacion=DateTime.Now;//Fecha de modificacion
     using var sw = new StreamWriter(_nombreArch, true);
     sw.WriteLine(expediente.idExpediente);
     sw.WriteLine(expediente.idTramite);
     sw.WriteLine(expediente.caratula);
     sw.WriteLine(expediente.creacion);
     sw.WriteLine(expediente.ultimaModificacion);
     sw.WriteLine(expediente.idUsuario);
      sw.WriteLine(expediente.estadoE);     
    }
   
   /*------------------------Baja de un expediente-------------------------------------------*/
    public void BajaExpediente(int idEx){
     List<Expediente> expedientesNoEliminados= new List<Expediente>();
     var lines = File.ReadAllLines(_nombreArch);
     for (int i = 0; i < lines.Length; i += 7)
        { if (int.Parse(lines[i]) != idEx)
                {
                    Expediente expActual=new Expediente();
                    expActual.idExpediente=int.Parse(lines[i]);
                    expActual.idTramite=int.Parse(lines[i+1]);
                    expActual.caratula=lines[i+2];
                    expActual.creacion=DateTime.Parse(lines[i+3]);
                    expActual.ultimaModificacion=DateTime.Parse(lines[i+4]);
                   expActual.idUsuario=int.Parse(lines[i+5]);
                   expActual.estadoE=Enum.Parse<EstadoExpediente>(lines[i+6]);
                   expedientesNoEliminados.Add(expActual);
                }
            }
    
        // Abrir el archivo para escribir
     using StreamWriter sw = new StreamWriter(_nombreArch);
     // Escribo cada expediente actualizado en el archivo
     foreach (Expediente exp in expedientesNoEliminados) {
         sw.WriteLine(exp.idExpediente);
         sw.WriteLine(exp.idTramite);
         sw.WriteLine(exp.caratula);
         sw.WriteLine(exp.creacion);
         sw.WriteLine(exp.ultimaModificacion);
         sw.WriteLine(exp.idUsuario);
         sw.WriteLine(exp.estadoE);
      }

    }

    /*-------------------------------Modificacion de un expediente----------------------------*/
     public void ModificacionE(Expediente expediente,int idUsuario){
     List<Expediente> expedientesActualizados = new List<Expediente>();
     var lines = File.ReadAllLines(_nombreArch);
     for (int i = 0; i < lines.Length; i += 6)
        { if (int.Parse(lines[i]) != expediente.idExpediente)
                {
                    Expediente expActual=new Expediente();
                    expActual.idExpediente=int.Parse(lines[i]);
                    expActual.idTramite=int.Parse(lines[i+1]);
                    expActual.caratula=lines[i+2];
                    expActual.creacion=DateTime.Parse(lines[i+3]);
                    expActual.ultimaModificacion=DateTime.Parse(lines[i+4]);
                   expActual.idUsuario=int.Parse(lines[i+5]);
                   expActual.estadoE=Enum.Parse<EstadoExpediente>(lines[i+6]);
                   expedientesActualizados.Add(expActual);
                }
              
         else {
             // Si encontre expediente a modificar
             expediente.ultimaModificacion=DateTime.Now;
             expedientesActualizados.Add(expediente);
         }
     }

     // Abrir el archivo para escribir
     using StreamWriter sw = new StreamWriter(_nombreArch);
     // Escribo cada expediente actualizado en el archivo
     foreach (Expediente exp in expedientesActualizados) {
         sw.WriteLine(exp.idExpediente);
         sw.WriteLine(exp.idTramite);
         sw.WriteLine(exp.caratula);
         sw.WriteLine(exp.creacion);
         sw.WriteLine(exp.ultimaModificacion);
         sw.WriteLine(exp.idUsuario);
         sw.WriteLine(exp.estadoE);
      }
    }

/*------------Muestro todos los expediente sin sus tramites ----------------------------------*/

    public List<Expediente> ListarTodos(){
        List<Expediente> result= new List<Expediente>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream){
           var expediente = new Expediente();
               expediente.idExpediente=int.Parse(sr.ReadLine());
               expediente.idTramite = int.Parse(sr.ReadLine() ?? "");
               expediente.caratula = sr.ReadLine() ?? "";
               expediente.creacion= DateTime.Parse(sr.ReadLine());
               expediente.ultimaModificacion=DateTime.Parse(sr.ReadLine());
               expediente.idUsuario = int.Parse(sr.ReadLine() );
               expediente.estadoE=Enum.Parse<EstadoExpediente>(sr.ReadLine() ?? "");
              result.Add(expediente);
         }
        return result;
    }

/*--------------Muestro un expediente con sus tramites -----------------------------------------*/
   public List<Tramite> ConsultaPorId(int idExpediente){
     List<Tramite> result=new List<Tramite>();
     using var sr = new StreamReader(_nombreArch);
     while (!sr.EndOfStream){
         var expediente = new Expediente();
         expediente.idExpediente=int.Parse(sr.ReadLine());
         if(expediente.idExpediente==idExpediente){
            result=repoT.ListarTramites(idExpediente);
         }
     }
     return result;
   }

   
   
}