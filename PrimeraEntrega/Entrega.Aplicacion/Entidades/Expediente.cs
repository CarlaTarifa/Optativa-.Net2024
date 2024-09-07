namespace Entrega.Aplicacion;


public class Expediente{
    public  int idExpediente{get;set;}

    public int idTramite{get;set;}
    public string? caratula{get;set;}
    
    public DateTime creacion{get;set;}
    public DateTime ultimaModificacion{get;set;}
    public int idUsuario{get;set;}
    
    public EstadoExpediente estadoE{get;set;}// estado es publico para evitar errores . Preguntar de ultima como unificarla
     public override string ToString()
        {
            string info = $"ID Expediente: {idExpediente} \n idTramite: { idTramite}\n Caratula: {caratula}\nFecha creacion: {creacion} \nFecha modificacion: {ultimaModificacion}\nID de usuario: {idUsuario} \nEstado del expediente: {estadoE}\n";
            return info;
        }


}