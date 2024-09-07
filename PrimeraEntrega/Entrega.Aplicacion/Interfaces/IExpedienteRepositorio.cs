namespace Entrega.Aplicacion;

public interface IExpedienteRepositorio {
   void AltaExpediente(Expediente expediente);
   void BajaExpediente(int idExpedientexpediente);
   void ModificacionE(Expediente expediente,int idUsuario); 
   List<Expediente> ListarTodos();
   List<Tramite> ConsultaPorId(int idExpediente);
}