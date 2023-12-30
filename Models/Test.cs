using System.Collections.ObjectModel;

namespace Test_Builder.Models
{
    public class Test
    {
        public Test(string name, ObservableCollection<Question> questions)
        {
            Name = name;
            Questions = questions;
            createTestDate = DateTime.Now;            
        }

        public Test()
        {
            createTestDate = DateTime.Now;
        }

        public ObservableCollection<Question> Questions { get; set; }
        = new ObservableCollection<Question>();

        private int timerValue;
        public int TimerValue
        {
            get => timerValue;
            private set => timerValue = value;
        }

        private DateTime createTestDate;
        public DateTime CreateTestDate
        {
            get => createTestDate;
            private set => createTestDate = value;
        }

        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }

        private string pathFile;
        public string PathFile
        {
            get => pathFile;
            set => pathFile = value;
        }
    }
}
