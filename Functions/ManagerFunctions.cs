namespace CommandExecutor.Functions
{
    public class ManagerFunctions
    {
        public ManagerFunctions(IntPtr intPtr, String KeyFunction)
        {
            if (KeyFunction.StartsWith("vol"))
            {
                new FunctionEncoder(intPtr, KeyFunction);
            }
            else
            {
                char page = KeyFunction.ToList()[0];
                int numberFunction = Convert.ToInt32(KeyFunction.ToList()[1].ToString());

                switch (page)
                {
                    case 'A':
                        {
                            new FunctionA(numberFunction);
                            break;
                        }
                    case 'B':
                        {
                            new FunctionB(numberFunction);
                            break;
                        }
                    case 'C':
                        {
                            new FunctionC(numberFunction);
                            break;
                        }
                    case 'D':
                        {
                            new FunctionD(numberFunction);
                            break;
                        }
                }
            }
        }

    }
}
