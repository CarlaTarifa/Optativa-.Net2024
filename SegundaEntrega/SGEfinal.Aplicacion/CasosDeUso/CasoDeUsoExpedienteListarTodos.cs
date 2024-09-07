namespace SGEfinal.Aplicacion;
public class CasoDeUsoExpedienteListarTodos(IExpedienteRepositorio exRepo){
    public List<object> Ejecutar(int idExpediente){
        return exRepo.ListarTodos(idExpediente);

    }
}