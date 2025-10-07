using MohawkTerminalGame;

namespace Travis
{
    public class GameManager
    {

        //Variables
        //Text Speed in Milliseconds
        public int slowTextSpeed = 100;
        public int fastTextSpeed = 25;
        public int defaultTextSpeed = 50;
        public int blackoutTextSpeed = 200;

        //Script References
        new ASCII ascii = new ASCII();

       public void Setup()
        {
            Program.TerminalExecuteMode = TerminalExecuteMode.ExecuteOnce;
            Program.TerminalInputMode = TerminalInputMode.KeyboardReadAndReadLine;

            Terminal.SetTitle("Junior's");
            Terminal.UseRoboType = true;
            Terminal.RoboTypeIntervalMilliseconds = defaultTextSpeed;
            Terminal.WriteWithWordBreaks = true;
            Terminal.WordBreakCharacter = ' ';
        }

        public void Execute()
        {
            Terminal.WriteLine("This is what regular text will look like!");
            Terminal.WriteLine("This is what our ascii can look like!");
            ascii.DrawTest();
            Terminal.RoboTypeIntervalMilliseconds = fastTextSpeed;
            Terminal.WriteLine("This is what F A S T text will look like!");
            Terminal.RoboTypeIntervalMilliseconds = slowTextSpeed;
            Terminal.WriteLine("This is what sloooow text will look like...");
        }
    
    
    
    }

}