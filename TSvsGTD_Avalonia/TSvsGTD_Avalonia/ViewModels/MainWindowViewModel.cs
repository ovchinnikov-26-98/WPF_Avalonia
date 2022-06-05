using ReactiveUI;
using System;
using System.Windows.Input;
using TSvsGTD_Avalonia.Models;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;
using System.IO;
using System.Reactive;
using TSvsGTD_Avalonia.Views;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;

namespace TSvsGTD_Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private DateTimeOffset beginDate = DateTime.Today;
        private DateTimeOffset endDate = DateTime.Today;

        //public string DirPath => "Файл находится:" + $"\n{Path.Combine(Environment.CurrentDirectory, "xlsx")}";
        public DateTimeOffset BeginDate
        {
            get => beginDate;
            set => this.RaiseAndSetIfChanged(ref beginDate, value);
        }


        public DateTimeOffset EndDate
        {
            get => endDate;
            set => this.RaiseAndSetIfChanged(ref endDate, value);
        }
        public ICommand ImportDataCommand { get; set; }
        public ReactiveCommand<Unit, Unit>  OpenViewInfo { get; }
        public MainWindowViewModel()
        {
            ImportDataCommand = ReactiveCommand.Create(OnImportData);
            //OpenViewInfo = ReactiveCommand.Create(OpenInfoWindowMethod);
        }

        public void OnImportData()
        {            
            ExportExcel.WriteExcel(BeginDate, EndDate);
            //OpenInfoWindowMethod();
        }

        //private void OpenInfoWindowMethod()

        //{
        //    var messageBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow("Info", /*DirPath,*/ ButtonEnum.Ok);
        //    messageBoxStandardWindow.Show();
        //}

        //private void OpenInfoWindowMethod()
        //{
        //    var InfoWindow = new InfoWindow();
        //    InfoWindow.Show();
        //}
    }

        
}
