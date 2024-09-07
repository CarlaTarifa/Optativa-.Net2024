namespace SGEfinal.Aplicacion;
public interface ITramiteRepositorio{
    void AltaTramite(Tramite tramite);
    void BajaTramite(int idExpediente);
    void ModificarT(Tramite tramite,Usuario user);
    List<Tramite> ConsultaEtiqueta(EtiquetaTramite etiquetaT);
    List<Tramite>ConsultaPorId(int idExpediente); // listo todos los tramites de un expediente
    List<Tramite> ListarTramites();// lista todos los tamites que hay 
    Tramite? ConsultaTramite(int idTramite); //Consulto por un tramite en especial
}