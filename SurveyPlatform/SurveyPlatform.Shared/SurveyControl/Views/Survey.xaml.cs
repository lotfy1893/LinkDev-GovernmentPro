using SurveyPlatform.SurveyControl.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SurveyPlatform.SurveyControl.Views
{
    public sealed partial class Survey : UserControl
    {
        SurveyViewModel ViewModel = new SurveyViewModel();
        public Survey()
        {
            this.InitializeComponent();
            this.DataContext = ViewModel;
        }
        public string ID
        {
            get { return ViewModel.SurveyId; }
            set { ViewModel.SurveyId = value; }
        }

        private void MultiChoiceGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
