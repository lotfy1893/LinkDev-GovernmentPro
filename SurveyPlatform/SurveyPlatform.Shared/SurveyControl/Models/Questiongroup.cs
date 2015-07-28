using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SurveyPlatform.SurveyControl.Models
{
    public class Questiongroup
    {
        public string QuestionGroupId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string SurveyId { get; set; }
        public Question[] Questions { get; set; }

    }
}
