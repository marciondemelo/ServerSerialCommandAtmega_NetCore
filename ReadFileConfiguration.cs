using CommandExecutor.models;

namespace CommandExecutor
{
    public class ReadFileConfiguration
    {
        private static List<string> ReadFile()
        {
            string arquivo = "comandos.csv";
            return File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "parametros", arquivo)).ToList();
        }

        public static String BaudRate()
        {
            return ReadFile().Single(x => x.ToLower().StartsWith("baudrate")).Split(';')[1];
        }
        public static String PortName()
        {
            return ReadFile().Single(x => x.ToLower().StartsWith("portname")).Split(';')[1];
        }
        public static String Page(String page)
        {
            return ReadFile().Single(x => x.ToLower().StartsWith(page.ToLower())).Split(';')[1];
        }

        public static List<ComandoModel> Comandos(string letterPage)
        {
            string cmdPage = "comando" + letterPage;
            List<String> comandos = ReadFile().Where(x => x.ToLower().StartsWith(cmdPage)).ToList();
            var resultCommands = new List<ComandoModel>();
            foreach (var item in comandos)
            {
                String[] param = item.Split(';');
                resultCommands.Add(new ComandoModel
                {
                    id = Convert.ToInt32(param[1]),
                    instrucao = param[2],
                    tipoInstrucao = ConverterStringParaTipoInstrucao(param[3])
                });

            }
            return resultCommands;
        }

        private static TipoInstrucao ConverterStringParaTipoInstrucao(string tipoInstrucaoStr)
        {
            switch (tipoInstrucaoStr.ToLower())
            {
                case "processo":
                    return TipoInstrucao.processo;
                case "tecla":
                    return TipoInstrucao.tecla;
                case "atalho":
                    return TipoInstrucao.atalho;
                default:
                    throw new ArgumentException("Tipo de instrução inválido: " + tipoInstrucaoStr);
            }
        }
    }
}