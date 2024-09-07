namespace SGEfinal.Aplicacion;
public class ServicioActualizacionEstado(IEspecificacionCambioEstado especificacionCambioEstado):IActualizacionEstado{
    public void ActualizarEstado(Expediente expediente){
        if(expediente.tramites!=null){
            int cantTramite=expediente.tramites.Count();//cantidad de tramites en un expediente
            Tramite tramite=expediente.tramites[cantTramite-1];
            EstadoExpediente? nuevoEstado= especificacionCambioEstado.getEstado(tramite.etiqueta);
            if(nuevoEstado !=null){
                expediente.estadoE=nuevoEstado.Value;//actualiza estado
                
            }

        }
    }
    
}