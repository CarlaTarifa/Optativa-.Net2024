namespace SGEfinal.Aplicacion;
public class CasoDeUsoExpedienteListarExpedientes(IExpedienteRepositorio exRepo){
    public List<Expediente> Ejecutar(){
        return exRepo.ListarExpedientes();

    }
}