using System.Windows.Forms;

namespace BowlingGameResultsReportingSystem.Helpers
{
    public class PathGetter
    {
        public string GetPathToDroppedFile(DragEventArgs file)
        {
            var path = (string[])file.Data.GetData(DataFormats.FileDrop);
            return path[0];
        }
    }
}
