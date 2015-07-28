using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SurveyPlatform.SurveyControl.Models
{
    public class SurveyData
    {
        public string SurveyId { get; set; }
        public string Name { get; set; }
        public object ParentSurveyId { get; set; }
        public object ParentSurveyRelation { get; set; }
        public Questiongroup[] QuestionGroups { get; set; }

    }
    public class SurveyDBModel
    {
        [SQLite.PrimaryKey]
        public string ID { get; set; }
        public string SurveyData { get; set; }
        public DateTime Date { get; set; }
    }
}
