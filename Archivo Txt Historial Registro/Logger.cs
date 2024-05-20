using Prac4.Verificacion_de_carpetas;

namespace Prac4.Archivo_Txt_Historial_Registro
{
    
        public sealed class Logger
        {

            private static Logger instance;
            // private static readonly object lockObject = new object();
            // private string logFilePath = Program.TxtLog;
            private readonly string logFilePath;

            private Logger(string logFilePath)
            {
                this.logFilePath = logFilePath;
            }

            public static Logger Instance
            {
                get
                {
                    if (instance == null)
                    {
                        string logFilePath = Verificacion.TxtLog;
                        instance = new Logger(logFilePath);
                    }
                    return instance;
                }
            }

            public void Log(string name, string role, string lastname, string usernmae, string mailAddress, string password, string phoneNumber)
            {
                string logEntry = $@"
< - > < - > < - > < - > < - > < - > < - > < - > 
|   Name: {name}
|   Role: {role}
|   UserName: {usernmae}                        
|   LastName: {lastname}
|   MailAddress: {mailAddress}
|   Password: {password}
|   Phonenumber: {phoneNumber}
|   Fecha: {DateTime.Now}
< - > < - > < - > < - > < - > < - > < - > < - > ";
                try
                {
                    using (StreamWriter sw = File.AppendText(logFilePath))
                    {
                        sw.WriteLine(logEntry);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al escribir en el archivo de log: {ex.Message}");
                }
            }

        ///

        public void LogReporte(string name, string lastname, string reporte, string mailAddress, string Puesto, string phoneNumber)
        {
            string logEntry = $@"
< - > < - > < - > < - > < - > < - > < - > < - > 
|   Name: {name}                     
|   LastName: {lastname}
|   Puesto: {Puesto}
|   MailAddress: {mailAddress}
|   Phonenumber: {phoneNumber}
|-----------------------------------------------------------------------------------------------
|   Reporte: {reporte}
|-----------------------------------------------------------------------------------------------
|   Fecha: {DateTime.Now}
< - > < - > < - > < - > < - > < - > < - > < - > ";
            try
            {
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine(logEntry);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el archivo de log: {ex.Message}");
            }
        }

    }
    
}

