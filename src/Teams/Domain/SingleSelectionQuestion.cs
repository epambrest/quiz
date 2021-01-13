using System;
using System.Collections.Generic;
using System.Linq;

namespace Teams.Domain
{
    public class SingleSelectionQuestion : Question
    {
        private List<SingleSelectionQuestionOption> _options;
        public IReadOnlyCollection<SingleSelectionQuestionOption> Options => _options.ToList();

        public SingleSelectionQuestion(string text) : base(text)
        {
            _options = new List<SingleSelectionQuestionOption>();
        }

        public SingleSelectionQuestion(string text, List<string> options, string numberOfRadioButton) : base(text)
        {
            int radioNumber = Convert.ToInt32(numberOfRadioButton);
            if(options != null && radioNumber <= options.Count())
            {
                _options = new List<SingleSelectionQuestionOption>(options.Count());
                foreach (var o in options)
                {
                    if (o == options[radioNumber])
                    {
                        SingleSelectionQuestionOption option = new SingleSelectionQuestionOption(o, true);
                        _options.Add(option);
                    }
                    else if (o != options[radioNumber])
                    {
                        SingleSelectionQuestionOption option = new SingleSelectionQuestionOption(o, false);
                        _options.Add(option);
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("List of options");
            }
        }

        public SingleSelectionQuestionOption GetRightAnswer()
        {
            var answer = this.Options.FirstOrDefault(i => i.IsAnswer == true);
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
