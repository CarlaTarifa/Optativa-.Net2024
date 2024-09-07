namespace Entrega.Aplicacion;

public interface ITramiteRepositorio{
    void AltaTramite(Tramite tramite,int idExpediente,int idUsuario);
    void BajaTramite(int idExpediente);
    void BajaTramite(Tramite tramite);
    void ModificarT(Tramite tramite);
    List<Tramite> ConsultaEtiqueta(EtiquetaTramite etiquetaT);
    List<Tramite> ListarTramites(int idExpediente);
}