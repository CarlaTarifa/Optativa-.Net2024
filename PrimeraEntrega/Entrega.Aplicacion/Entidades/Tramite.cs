namespace Entrega.Aplicacion;

public class Tramite{
    public int idTramite{get;set;}
    public int idExpediente{get;set;}
    public EtiquetaTramite etiqueta{get;set;}
    public string? contenidoT{get;set;}
    public DateTime creacionT{get;set;}
    public DateTime modificacionT{get;set;}
    public int idUsuario{get;set;}
    public override string ToString()
        {
            string info = $"Id Tramite: {idTramite}\n id Expediente:{idExpediente} \n Etiqueta: {etiqueta}\n ContenidoT:{contenidoT}\ncreacion: {creacionT} \nFecha modificacion: {modificacionT}\nID de usuario: {idUsuario} \n";
            return info;
        }

}