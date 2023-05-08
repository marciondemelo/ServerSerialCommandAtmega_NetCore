using Audio = NAudio.CoreAudioApi;

namespace CommandExecutor.Functions
{
    public class FunctionEncoder : BaseFunctions
    {
        IntPtr _intPtr;
        public FunctionEncoder(IntPtr intPtr, String command)
        {
            this._intPtr = intPtr;
            String numero = command.Split('@')[1];
            numero = new string(numero.Where(char.IsLetterOrDigit).ToArray());
            float volume = float.Parse(numero);
            SetVolume(volume > 100 ? 100: volume);
        }

        private void SetVolume(float volume)
        {
            Audio.MMDeviceEnumerator enumerador = new Audio.MMDeviceEnumerator();
            Audio.MMDevice device = enumerador.GetDefaultAudioEndpoint(Audio.DataFlow.Render, Audio.Role.Multimedia);
            float vol = volume / 100;
            device.AudioEndpointVolume.MasterVolumeLevelScalar = vol;
        }
    }
}
