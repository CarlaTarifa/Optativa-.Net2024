namespace SGEfinal.Aplicacion;
public class CasoDeUsoTramiteListarTramites(ITramiteRepositorio tRepo){
    public List<Tramite> Ejecutar(){
        return tRepo.ListarTramites();
    }
}