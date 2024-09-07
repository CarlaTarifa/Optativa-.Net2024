namespace SGEfinal.Aplicacion;
public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio exRepo){
    public Expediente Ejecutar (int idExpediente){
        Expediente? exp=exRepo.ConsultaPorId(idExpediente);
        if(exp==null){
            throw new RepositorioException("No existe expediente");
        }
        else {
            return exp;
        }
    }
}