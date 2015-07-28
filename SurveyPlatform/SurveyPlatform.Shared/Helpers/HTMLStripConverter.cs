using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Windows.UI.Xaml.Data;

namespace SurveyPlatform.Helpers
{
    public class HTMLStripConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((value as string) != null)
                return Windows.Data.Html.HtmlUtilities.ConvertToText(value as string);

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
