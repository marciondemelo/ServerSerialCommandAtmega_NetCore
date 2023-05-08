namespace CommandExecutor.models
{
    public class ComandoModel
    {
        public int id { get; set; }
        public string? instrucao { get; set; }
        public TipoInstrucao tipoInstrucao { get; set; }
    }
    public enum TipoInstrucao
    {
        processo,
        tecla,
        atalho
    }
}
