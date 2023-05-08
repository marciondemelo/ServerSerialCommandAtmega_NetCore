using CommandExecutor.models;

namespace CommandExecutor.Functions
{
    public class FunctionB : BaseFunctions
    {
        public FunctionB(int numberFunction)
        {
            ComandoModel commad = comandosB().Single(x => x.id == numberFunction);
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
