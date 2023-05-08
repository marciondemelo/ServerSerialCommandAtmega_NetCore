using CommandExecutor.Functions;
using System.Diagnostics;
using System.IO.Ports;

namespace CommandExecutor
{
    public partial class Form1 : Form
    {
        SerialPort serialPort1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connect();
            configLcd("PageA");
        }

        private void Connect()
        {
            try
            {
                serialPort1 = new SerialPort(ReadFileConfiguration.PortName(), Convert.ToInt32(ReadFileConfiguration.BaudRate()));

                serialPort1.Open();

                if (serialPort1.IsOpen)
                {
                    Thread.Sleep(1000);
                    MessageBox.Show("conectado");
                    serialPort1.DataReceived += serialPort1_DataReceived;
                }
                else
                {
                    MessageBox.Show("falha na conexao");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseConnection()
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        String serialDataIn;
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            serialDataIn = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(ShowData));
        }
        String dado = "";
        private void ShowData(object sender, EventArgs e)
        {
            dado += serialDataIn;
            Debug.WriteLine(dado);
            //link abaixo conte a tabela de teclas usadas via c#
            //https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys?redirectedfrom=MSDN&view=windowsdesktop-7.0
            if (dado.Contains("\r\n"))
            {

                if (dado.StartsWith("vol@"))
                {
                    new ManagerFunctions(this.Handle, dado);
                }
                else
                {
                    string key = new string(dado.Where(char.IsLetterOrDigit).ToArray());
                    if (buttons.Any(x => x == key))
                    {
                        new ManagerFunctions(this.Handle, key);
                    }
                    else if (pages.Any(x => x == key))
                    {
                        configLcd(key);
                    }
                }

                dado = "";
            }
        }
        public void configLcd(String Page)
        {
            String dadoLinhaLcd = String.Concat(ReadFileConfiguration.Page(Page), "#");

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(dadoLinhaLcd);

            serialPort1.Write(bytes, 0, bytes.Length);
            Debug.WriteLine(dadoLinhaLcd);
            Thread.Sleep(500);
        }

        List<String> pages = new List<String>() { "pageA", "pageB", "pageC", "pageD" };
        List<String> buttons = new List<string>() { "A1", "A2", "A3", "A4", "A5", "A6",
                                                    "B1", "B2", "B3", "B4", "B5", "B6",
                                                    "C1", "C2", "C3", "C4", "C5", "C6",
                                                    "D1", "D2", "D3", "D4", "D5", "D6",
                                                    "vol","volU", "volD", "volmute"};

    }
}