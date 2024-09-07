namespace SGEfinal.Aplicacion;
public enum Permiso{
    ExpedienteAlta,// Puede realizar altas de expedientes
    ExpedienteBaja,//Puede realizar bajas de expedientes
    ExpedienteModificacion,//Puede realizar modificaciones de expedientes
    TramiteAlta,//Puede realizar altas de tramites
    TramiteBaja,//Puede realizar bajas de tramites
    TramiteModificacion,// Puede realizar modificaciones de tramites
    UsuarioListar, //puede listar todos los usuarios registrados
    UsuarioBaja,
    UsuarioModificacion,
    Lectura,//Para los usuarios que no son admin
}