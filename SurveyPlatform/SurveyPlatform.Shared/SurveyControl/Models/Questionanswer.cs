using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyPlatform.SurveyControl.Models
{
    public class Questionanswer
    {
        public string QuestionAnswerId { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public string QuestionId { get; set; }
    }
}
