namespace Spreadsheet2JsonConverter.Services.OpenFileDialog
{
    public sealed class GetFilePathOpenDialogService : IGetFilePathService
    {
        public string GetFilePath(string folder)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog { InitialDirectory = folder, Filter = "*.xlsx" };

            return dialog.ShowDialog() == true ? dialog.FileName : null;
        }
    }

}
