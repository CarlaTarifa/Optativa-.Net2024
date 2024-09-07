namespace Entrega.Aplicacion;

public class TramiteValidador{
     //  El contenido del tramite no PUEDE ESTAR VACIO 
    public bool validarT(Tramite t ,out string mensajeError ){
    
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(t.contenidoT)){
          mensajeError = "El contenido de tramine no puede estar vacio.\n";
        }
        return (mensajeError == "");

        if (t.idUsuario < 0){
            mensajeError="Id del usuario es invalido.\n";
        }
    }

   
}