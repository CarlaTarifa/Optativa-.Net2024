namespace Entrega.Aplicacion;

public class ExpedienteValidador{
     // CARATULA NO PUEDE ESTAR VACIA 
    public bool validarE(Expediente ex,out string mensajeError ){
    
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(ex.caratula)){
          mensajeError = "Caratula no puede estar vacia\n";
        }
        
        if ( ex.idUsuario< 0){
            mensajeError="Id del usuario es invalido.\n";
        }
        return (mensajeError == "");
    }

   
}
