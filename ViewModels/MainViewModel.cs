using Spreadsheet2JsonConverter.Services.OpenFileDialog;
using System;
using System.IO;
using System.Windows.Input;

namespace Spreadsheet2JsonConverter.ViewModels
{
    public class MainViewModel : Base.ViewModel
    {
        public MainViewModel()
        {
            OpenFileCommand = new RelayCommand.Command(openFileCOmmandMethod);
            OpenFileService = new GetFilePathOpenDialogService();
        }
        public IGetFilePathService OpenFileService { get; private set; }

        private ICommand openFileCommand;

        public ICommand OpenFileCommand
        {
            get { return openFileCommand; }
            set { openFileCommand = value; OnPropertyChanged(); }
        }

        private void openFileCOmmandMethod(object parameter)
        {
            try
            {
                var basePath = string.IsNullOrWhiteSpace(FilePath) || !File.Exists(FilePath)
                    ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    : Path.GetDirectoryName(FilePath);

                FilePath = OpenFileService.GetFilePath(basePath);

                if (string.IsNullOrWhiteSpace(FilePath) || !File.Exists(FilePath)) return;

                using (var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                    using (var reader = new StreamReader(stream))
                        FileContent = reader.ReadToEnd();
            }
            catch (Exception ex)
            {   //Sample quality error handling
                //obviously you're not supposed to handle exceptions like this in production!
                FileContent = ex.Message;
            }
        }

        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; OnPropertyChanged(); }
        }

        private string fileContent;

        public string FileContent
        {
            get { return fileContent; }
            set { fileContent = value; OnPropertyChanged(); }
        }
    }
}
