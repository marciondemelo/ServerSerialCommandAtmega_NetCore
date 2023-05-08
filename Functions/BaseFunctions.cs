using CommandExecutor.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CommandExecutor.Functions
{
    public  class BaseFunctions
    {

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hwnd, int Msg, IntPtr wParam, IntPtr lParam);

        public const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        public const int APPCOMMAND_VOLUME_UP = 0xA0000;
        public const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        public const int WM_APPCOMMAND = 0x319;

        public List<ComandoModel> comandosA()
        {
            return ReadFileConfiguration.Comandos("a");
        }

        public List<ComandoModel> comandosB()
        {
            return ReadFileConfiguration.Comandos("b");
        }

        public List<ComandoModel> comandosC()
        {
            return ReadFileConfiguration.Comandos("c");
        }

        public List<ComandoModel> comandosD()
        {
            return ReadFileConfiguration.Comandos("d");
        }
    }
}
