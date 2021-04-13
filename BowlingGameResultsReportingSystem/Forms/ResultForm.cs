using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BowlingGameResultsReportingSystem
{
    public partial class ResultForm : Form
    {
        readonly Game _game;
        readonly string throwsDelimiter = " | ";

        public ResultForm(Game game)
        {
            InitializeComponent();
            _game = game;
            Text = _game.Player.Name;
        }

        private void ResultForm_Load(object sender, System.EventArgs e)
        {
            FillUpRollingResultLabels();
            FillUpThrowLabels();
        }

        private void FillUpRollingResultLabels()
        {
            var rollingLabels = new List<Label>() { RS0, RS1, RS2, RS3, RS4, RS5, RS6, RS7, RS8, RS9 };
            for (var i = 0; i < rollingLabels.Count(); i++)
            {
                rollingLabels.ElementAt(i).Text = _game.RollingResult.ElementAt(i).ToString();
            }
        }

        private void FillUpThrowLabels()
        {
            var throws = new List<Label>() { TS0, TS1, TS2, TS3, TS4, TS5, TS6, TS7, TS8, TS9 };
            var frames = _game.Frames;
            for (var currentFrame = 0; currentFrame < throws.Count(); currentFrame++)
            {
                if (IsLastFrame(currentFrame) && frames.ElementAt(currentFrame).IsStrike)
                {
                    throws.ElementAt(currentFrame).Text = frames.ElementAt(currentFrame).FirstThrow.ToString() +
                        throwsDelimiter + frames.ElementAt(NextFrame(currentFrame)).FirstThrow.ToString() +
                        throwsDelimiter + frames.ElementAt(NextFrame(currentFrame)).SecondThrow.ToString();
                }
                else if (IsLastFrame(currentFrame) && frames.ElementAt(currentFrame).IsSpare)
                {
                    throws.ElementAt(currentFrame).Text = frames.ElementAt(currentFrame).FirstThrow.ToString() +
                        throwsDelimiter + frames.ElementAt(currentFrame).SecondThrow.ToString() +
                        throwsDelimiter + frames.ElementAt(NextFrame(currentFrame)).FirstThrow.ToString();
                }
                else if (frames.ElementAt(currentFrame).IsStrike)
                {
                    throws.ElementAt(currentFrame).Text = frames.ElementAt(currentFrame).FirstThrow.ToString();
                }
                else
                {
                    throws.ElementAt(currentFrame).Text = frames.ElementAt(currentFrame).FirstThrow.ToString() +
                        throwsDelimiter + frames.ElementAt(currentFrame).SecondThrow.ToString();
                }
            }
        }

        private int NextFrame(int index)
        {
            return index + 1;
        }

        private bool IsLastFrame(int frame)
        {
            return frame == 9;
        }
    }
}
