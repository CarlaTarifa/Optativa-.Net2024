namespace SGEfinal.Aplicacion;
public interface IExpedienteRepositorio {
   void AltaExpediente(Expediente expediente);
   void BajaExpediente(int idExpedientexpediente);
   void ModificacionE(Expediente expediente,Usuario user); 
   List<Expediente> ListarExpedientes();
   List<object> ListarTodos(int idExpediente);
   Expediente? ConsultaPorId(int idExpediente);
}