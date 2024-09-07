namespace SGEfinal.Aplicacion;
public class CasoDeUsoTramiteConsultaTramite(ITramiteRepositorio tRepo){
    public Tramite Ejecutar (int idTramite){
        Tramite? t=tRepo.ConsultaTramite(idTramite);
        if(t==null){
            throw new RepositorioException("No existe tramite");
        }
        else {
            return t;
        }
    }
}