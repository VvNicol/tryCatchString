namespace tryCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rutaArchivo = "archivo.txt";
            int numeroLinea = 3; // Número de la línea en la que deseamos escribir en el archivo
            int posicion = 15; // Posición en la que deseamos escribir en la línea
            string textoNuevo = "nuevo"; // Texto nuevo que queremos insertar en la posición específica

            try
            {
                // Leer todas las líneas del archivo
                string[] lineas = File.ReadAllLines(rutaArchivo);

                // Verificar si el número de línea deseado está dentro del rango del archivo
                if (numeroLinea >= 1 && numeroLinea <= lineas.Length)
                {
                    // Obtener la línea específica
                    string linea = lineas[numeroLinea - 1];

                    // Verificar si la posición deseada está dentro del rango de la línea
                    if (posicion >= 0 && posicion <= linea.Length)
                    {
                        // Insertar el nuevo texto en la posición deseada
                        string nuevaLinea = linea.Insert(posicion, textoNuevo);

                        // Reemplazar la línea original con la línea modificada
                        lineas[numeroLinea - 1] = nuevaLinea;

                        // Sobrescribir el archivo con las líneas actualizadas
                        File.WriteAllLines(rutaArchivo, lineas);

                        Console.WriteLine("El texto se ha escrito correctamente en la posición especificada de la línea.");
                    }
                    else
                    {
                        Console.WriteLine("La posición especificada está fuera del rango de la línea.");
                    }
                }
                else
                {
                    Console.WriteLine("El número de línea especificado está fuera del rango del archivo.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error al leer/escribir el archivo: " + e.Message);
            }
        }
    }
}
