namespace Entrega.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio exRepo){
    public List<Expediente> Ejecutar(){
        return exRepo.ListarTodos();
    }
}