using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using Test_Builder.Models;
using Test_Builder.Pages;
using Test_Builder.Services;

namespace Test_Builder.ViewModels
{
    [QueryProperty(nameof(EditTest), "EditTest")]
    [QueryProperty(nameof(Test), "Test")]
    public partial class CreateTestPageViewModel : ObservableObject
    {
        public CreateTestPageViewModel(IFileService fileService)
        {
            this.fileService = fileService;
            Test = new Test();
        }

        [ObservableProperty]
        private Test test;

        [ObservableProperty]
        private bool editTest;

        [ObservableProperty]
        private Question selectedQestion;

        [ObservableProperty]
        private IItem selectedItem;

        private readonly IFileService fileService;

        #region COMMANND
        [RelayCommand]
        private void CreateQuestionCheckBoxItems() => AddAnyQuestion(new CheckBoxItem());

        [RelayCommand]
        private void CreateQuestionRadioButtomItems() => AddAnyQuestion(new RadioButtonItem());

        [RelayCommand]
        private void CreateQuestionTextItems() => AddAnyQuestion(new TextItem());

        [RelayCommand]
        private void RemoveQuestion(Question question) => Test.Questions.Remove(question);

        [RelayCommand]
        private void SelectiondItemChange(Question question)
        {
            SelectedQestion = question;
            SelectedQestion.Remove(selectedItem);
        }

        [RelayCommand]
        private void AddItem(Question question)
        {
            SelectedQestion = question;
            var item = (IItem)Activator.CreateInstance(question[0].GetType());            
            question.Add(item);
        }

        [RelayCommand]
        private void RemoveItem(IItem item)
        {
            var check = Test.Questions.Where(x => x.Contains(item)).Select(x => x.Remove(item));
        }

        [RelayCommand]
        private void RadioButtonChekced(RadioButtonItem item)
        {
            Test.Questions.Where(x => x.Contains(item)).Select(x => x.Select(x => (RadioButtonItem)x).Select(x => x.CorrectAnswer = false));
            item.CorrectAnswer = true;
        }

        [RelayCommand]
        private void CreateTest()
        {
            AddTest();
            Shell.Current.GoToAsync(nameof(MainPage));           
        }
        #endregion

        #region METHODS
        private void AddAnyQuestion<T>(T item)
            where T : IItem, new()
        {
            Question question = new Question(new ObservableCollection<IItem>() {item});
            Test.Questions.Add(question);
        }

        private void AddTest()
        {
            if(EditTest)
            {
                fileService.DeleteFile(Test.PathFile);
                Test.PathFile = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + $"/{Test.Name}.txt";
                fileService.Save(Test);
            }
            else
            {
                Test.PathFile = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + $"/{Test.Name}.txt";
                fileService.Save(Test);
            }
        }
        #endregion
    }
}
