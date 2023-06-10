namespace SpotiSync.Misc
{
    public class DialogBox
    {
        public string FolderBrowser()
        {
            string folder = "";
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    folder = fbd.SelectedPath;
                }
            }
            return folder;
        }
    }
}