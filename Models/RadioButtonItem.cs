
namespace Test_Builder.Models
{
    public class RadioButtonItem : IItem
    {
        private string text;
        public string Text
        {
            get => text;
            set => text = value;
        }

        private bool correctAnswer = false;
        public bool CorrectAnswer
        {
            get => correctAnswer;
            set => correctAnswer = value;
        }

        public bool Compare(object obj)
        {
            if (obj is RadioButtonItem rb)
            {
                if (correctAnswer == rb.correctAnswer)
                    return false;
            }
            return true;
        }
    }
}
