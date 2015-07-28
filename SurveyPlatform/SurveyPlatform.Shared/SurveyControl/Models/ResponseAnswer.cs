using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyPlatform.SurveyControl.Models
{
    public class ResponseAnswer
    {
        public string ResponseAnswerId { get; set; }
        public string ResponseId { get; set; }
        public string QuestionId { get; set; }
        public string QuestionAnswerId { get; set; }
        public string AnswerValue { get; set; }
        public DateTime AnswerTime { get; set; }
    }
}
