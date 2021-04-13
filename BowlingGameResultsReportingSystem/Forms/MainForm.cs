using BowlingGameResultsReportingSystem.Helpers;
using System.Windows.Forms;

namespace BowlingGameResultsReportingSystem
{
    public partial class MainForm : Form
    {
        private readonly GameLoader gameSimulation;
        private readonly PathGetter pathGetter;

        public MainForm()
        {
            InitializeComponent();
            DropLanding.AllowDrop = true;
            gameSimulation = new GameLoader();
            pathGetter = new PathGetter();
        }

        private void DropLanding_DragDrop(object sender, DragEventArgs e)
        {
            var path = pathGetter.GetPathToDroppedFile(e);
            var games = gameSimulation.LoadAllGamesFromFile(path);
            foreach (var game in games)
            {
                new ResultForm(game).Show();
            }
        }

        private void DropLanding_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
