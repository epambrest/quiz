using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Quiz.DAL.Entities
{
    public class SingleSelectionQuestion : Question
    {
        private List<SingleSelectionQuestionOption> _options;
        public IReadOnlyCollection<SingleSelectionQuestionOption> Options => _options.ToList();

        public SingleSelectionQuestion(string text) : base(text)
        {
            _options = new List<SingleSelectionQuestionOption>();
        }

        public SingleSelectionQuestion(string text, IList<string> options, string radioButtonValue) : base(text)
        {
            var newOptions = options
                .Where(x => options.Contains(x))
                .Select((x, i) =>
                {
                    if (!int.TryParse(radioButtonValue, out var optionInt))
                    {
                        return null;
                    }

                    return new SingleSelectionQuestionOption(x, i == optionInt);
                })
                .Where(x => x != null)
                .ToList();
            _options = new List<SingleSelectionQuestionOption>();
            _options.AddRange(newOptions);
        }

        public SingleSelectionQuestionOption GetRightAnswer()
        {
            var answer = Options.FirstOrDefault(i => i.IsAnswer == true);
            return answer;
        }

        public void InitializeOptions(IEnumerable<SingleSelectionQuestionOption> options)
        {
            if (options.Where(x => x.IsAnswer).Count() != 1)
            {
                throw new ArgumentException();
            }
            _options = options.ToList();
        }

        public void Update(string questionText, List<SingleSelectionQuestionOption> newOptions)
        {
            Text = questionText;
            _options = newOptions;
        }
    }
}
