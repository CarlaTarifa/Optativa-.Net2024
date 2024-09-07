namespace SGEfinal.Aplicacion;
public class EspecificacionCambioEstado:IEspecificacionCambioEstado{

    public EstadoExpediente? getEstado(EtiquetaTramite etiqueta){
        return etiqueta switch {
            EtiquetaTramite.Resolución=> EstadoExpediente.ConResolucion,
            EtiquetaTramite.PaseAEstudio=>EstadoExpediente.ParaResolver,
            EtiquetaTramite.PaseAlArchivo=>EstadoExpediente.Finalizado , 
            _ =>null,      
        } ;       
    }

}