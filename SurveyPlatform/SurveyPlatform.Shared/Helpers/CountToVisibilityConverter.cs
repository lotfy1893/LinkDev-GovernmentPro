using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SurveyPlatform.Helpers
{
    public class CountToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var flag = false;

            if (value == null)
                flag = false;

            else if (value is string)
                if (!string.IsNullOrEmpty(value as string))
                    flag = true;
                else flag = false;

            else if (value is int)
                if ((int)value == 0)
                    flag = false;
                else
                    flag = true;

            else if (value is double)
                if ((double)value == 0)
                    flag = false;
                else
                    flag = true;

            else if (value is IEnumerable<object>)
                if (((IEnumerable<object>)value).Count() == 0)
                    flag = false;
                else
                    flag = true;

            if (parameter != null)
                if (bool.Parse((string)parameter))
                    flag = !flag;

            if (flag)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return 0;
        }
    }
}
