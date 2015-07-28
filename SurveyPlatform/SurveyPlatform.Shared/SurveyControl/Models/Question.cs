using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SurveyPlatform.SurveyControl.Models
{
    public class Question
    {
        public string QuestionId { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public QuestionTypes QuestionType { get; set; }
        public string QuestionGroupId { get; set; }
        public string DependentQuestionId { get; set; }
        public string DependentAnswers { get; set; }
        public Questionanswer[] QuestionAnswers { get; set; }

    }




}
