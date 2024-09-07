namespace Entrega.Aplicacion;

public class EspecificacionCambioEstado{

    public EstadoExpediente getEstado(EtiquetaTramite etiqueta){
        return etiqueta switch {
            EtiquetaTramite.Resolución=> EstadoExpediente.ConResolucion,
            EtiquetaTramite.PaseAEstudio=>EstadoExpediente.ParaResolver,
            EtiquetaTramite.PaseAlArchivo=>EstadoExpediente.Finalizado ,       
        } ;       
    }

}