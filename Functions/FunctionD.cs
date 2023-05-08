using CommandExecutor.models;

namespace CommandExecutor.Functions
{
    public class FunctionD : BaseFunctions
    {
        public FunctionD(int numberFunction)
        {
            ComandoModel commad = comandosD().Single(x => x.id == numberFunction);
            switch (commad.tipoInstrucao)
            {
                case TipoInstrucao.processo:
                    _ = System.Diagnostics.Process.Start(commad.instrucao);
                    break;
                case TipoInstrucao.tecla:
                    SendKeys.Send(commad.instrucao);
                    break;
                case TipoInstrucao.atalho:
                    SendKeys.SendWait(commad.instrucao);
                    break;
                default:
                    break;
            }
        }

    }
}
