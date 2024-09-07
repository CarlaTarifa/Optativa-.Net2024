namespace SGEfinal.Aplicacion;
public class CasoDeUsoTramiteConsultaPorId(ITramiteRepositorio tRepo){
    public List<Tramite> Ejecutar (int idExpediente){
        return tRepo.ConsultaPorId(idExpediente);
    }
}