namespace Spreadsheet2JsonConverter.Services.OpenFileDialog
{
    public sealed class GetFilePathOpenDialogService : IGetFilePathService
    {
        public string GetFilePath(string folder)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog { InitialDirectory = folder, Filter = "Excel files (*.xlsx) | *.xlsx;" };//Excel files (*.xlsx, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png

            return dialog.ShowDialog() == true ? dialog.FileName : null;
        }
    }
}
