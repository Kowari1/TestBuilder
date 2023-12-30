using System.Collections.ObjectModel;

namespace Test_Builder.Models
{
    public class Question : ObservableCollection<IItem>
    {
        public Question() { }

        public Question(IEnumerable<IItem> items) : base(items)
        {
            
        }

        private string questionName;
        public string QuestionName
        {
            get => questionName;
            set => questionName = value;
        }     
    }
}
