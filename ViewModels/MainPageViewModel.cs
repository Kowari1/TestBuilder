using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Test_Builder.Messages;
using Test_Builder.Models;
using Test_Builder.Pages;
using Test_Builder.Services;
using static System.Net.Mime.MediaTypeNames;

namespace Test_Builder.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel(IFileService fileService)
        {
            this.fileService = fileService;
            Tests = new ObservableCollection<Test>(fileService.OpenFileDirectiry
                (System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "*.txt"));
        }
        
        private readonly IFileService fileService;

        public ObservableCollection<Test> Tests { get; set; }

        #region COMMANND
        [RelayCommand]
        private async Task GoToCreateTestPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(CreateTestPage)}?EditTest={false}", new Dictionary<string, object>
            {
                {"Test", new Test()}
            });
        }

        [RelayCommand]
        private void RemoveTest(Test test)
        {
            fileService.DeleteFile(test.PathFile);
            Tests.Remove(test);
        }

        [RelayCommand]
        private async Task EditTest(Test test)
        {
            await Shell.Current.GoToAsync($"//{nameof(CreateTestPage)}?EditTest={true}", new Dictionary<string,object>
            {
                {"Test", test}              
            });
        }
        #endregion

        #region METHODS
        #endregion
    }
}
