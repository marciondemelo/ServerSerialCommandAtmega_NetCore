namespace CommandExecutor
{

    public class LcdControl
    {
        public static LcdControl _singleton { get; private set; }
        public LcdControl()
        {
            OpcoesLcdNew();
        }
        public static LcdControl Singleton()
        {
            if (_singleton == null)
                return new LcdControl();
            else
                return _singleton;
        }
        public String ReturnIPageLCD(String PageLcd)
        {
            var pag = OpcoesLcdList.Where(x => x.Key == PageLcd);
            return pag.First().Value;
        }
        Dictionary<String, String> OpcoesLcdList;
        public void OpcoesLcdNew()
        {
            OpcoesLcdList = new Dictionary<String, String>();

            OpcoesLcdList.Add("pageA", String.Concat("PAG-A  1-Vol+", "@", "PAG-B  4-Home", "@", "2-Vol- 3-Mute", "@", "5-End  6-Prin"));

            OpcoesLcdList.Add("pageB", String.Concat("PAG-B   1-ComaB", "@", "PAG-B   4-ComaB", "@", "2-ComaB 3-ComaB", "@", "5-ComaB 6-ComaB"));

            OpcoesLcdList.Add("pageC", String.Concat("PAG-C   1-ComaC", "@", "PAG-B   4-ComaC", "@", "2-ComaC 3-ComaC", "@", "5-ComaC 6-ComaC"));

            OpcoesLcdList.Add("pageD", String.Concat("PAG-D   1-ComaD", "@", "PAG-B   4-ComaD", "@", "2-ComaD 3-ComaD", "@", "5-ComaD 6-ComaD"));


        }
    }

}
