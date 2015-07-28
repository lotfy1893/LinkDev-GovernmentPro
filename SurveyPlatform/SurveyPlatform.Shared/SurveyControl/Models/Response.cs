using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyPlatform.SurveyControl.Models
{
    public class Response
    {
        [SQLite.PrimaryKey]
        public string ResponseId { get; set; }
        public string SurveyId { get; set; }
        public string UserId { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string ParentResponseId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string UserCoordinates { get; set; }
        [SQLite.Ignore]
        public List<ResponseAnswer> ResponseAnswers { get; set; }
    }
}
