namespace Entrega.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio exRepo){
       public List<Tramite> Ejecutar(int idExpediente){
         List<Expediente> idExpedientes=exRepo.ListarTodos();
         Boolean valido=false;
         foreach(Expediente ex in idExpedientes){
             if(ex.idExpediente==idExpediente){
                 valido=true;
             }
         }
         if(!valido){
            throw new RepositorioException("No existe expediente"); 
         }
         else {
            return exRepo.ConsultaPorId(idExpediente);
         }
        }
}