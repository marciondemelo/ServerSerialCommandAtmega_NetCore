using CommandExecutor.models;

namespace CommandExecutor.Functions
{
    public class FunctionC : BaseFunctions
    {
        public FunctionC(int numberFunction)
        {
            ComandoModel commad = comandosC().Single(x => x.id == numberFunction);
            switch (commad.tipoInstrucao)
            {
                case TipoInstrucao.processo:
                    System.Diagnostics.Process.Start(commad.instrucao);
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
