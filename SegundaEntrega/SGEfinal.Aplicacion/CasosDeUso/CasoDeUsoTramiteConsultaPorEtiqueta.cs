namespace SGEfinal.Aplicacion;
public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio tRepo){
    public List<Tramite> Ejecutar(EtiquetaTramite etiqueta){
        return tRepo.ConsultaEtiqueta(etiqueta);
    }
}