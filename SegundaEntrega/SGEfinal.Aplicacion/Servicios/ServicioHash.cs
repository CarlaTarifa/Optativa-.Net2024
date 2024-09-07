namespace SGEfinal.Aplicacion;
using System.Security.Cryptography;
using System.Text;

public class ServicioHash:IServicioHash {
    public string funcionHash(string contra)
    {
        using SHA256 sha256Hash = SHA256.Create();
        {
            // Computar el hash - retorna un array de bytes
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contra));

            // Convertir el array de bytes a una cadena hexadecimal
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
