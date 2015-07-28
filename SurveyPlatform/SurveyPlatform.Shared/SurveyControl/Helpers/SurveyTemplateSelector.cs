using SurveyPlatform.SurveyControl.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SurveyPlatform.SurveyControl.Helpers
{
    public class SurveyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate InputText { get; set; }
        public DataTemplate MultipleChoice { get; set; }
        public DataTemplate InputNumber { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            switch ((item as Question).QuestionType)
            {
                case QuestionTypes.MultipleChoice:
                    return MultipleChoice;
                case QuestionTypes.InputText:
                    return InputText;
                case QuestionTypes.InputNumber:
                    return InputNumber;
                default:
                    return null;
            }


        }
    }
}
