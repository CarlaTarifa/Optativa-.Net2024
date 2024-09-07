namespace Entrega.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio tRepo){

    public List<Tramite> Ejecutar(EtiquetaTramite etiquetaT){
        return tRepo.ConsultaEtiqueta(etiquetaT);

    }

}