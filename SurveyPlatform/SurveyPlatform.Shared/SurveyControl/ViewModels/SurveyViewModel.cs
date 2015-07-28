using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Windows.Networking.Connectivity;
using Windows.Web.Http;
using SurveyPlatform.SurveyControl.Models;
using SurveyPlatform.Common;

namespace SurveyPlatform.SurveyControl.ViewModels
{
    public class SurveyViewModel : BindableBase
    {
        private const string ServiceUrl = "http://iteam.linkdev.com/survey/api/";
        SQLite.SQLiteConnection DB;
        bool IsOnline { get; set; }
        public SurveyViewModel()
        {
            SetupDB();
            SetupInternetConnection();

        }

        private string _SurveyId;
        public string SurveyId
        {
            get { return _SurveyId; }
            set
            {
                _SurveyId = value;
                GetSurveyData();
            }
        }


        private SurveyData _CurrentSurvey;
        public SurveyData CurrentSurvey
        {
            get { return _CurrentSurvey; }
            set { SetProperty(ref _CurrentSurvey, value); }
        }
        private void SetupDB()
        {
            string DBPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Survey.db");
            DB = new SQLite.SQLiteConnection(DBPath);
            DB.CreateTable<SurveyDBModel>();
            
        }
        public async void GetSurveyData()
        {
            if (IsOnline)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    try
                    {
                        var surveyjson = await httpClient.GetStringAsync(new Uri(ServiceUrl + "SurveysApi/" + SurveyId));
                        if (!string.IsNullOrEmpty(surveyjson))
                        {
                            CurrentSurvey = Newtonsoft.Json.JsonConvert.DeserializeObject<SurveyData>(surveyjson);
                            var surveyDB = new SurveyDBModel { ID = Guid.NewGuid().ToString(), SurveyData = surveyjson, Date = DateTime.Now };
                            DB.Insert(surveyDB);
                            while (DB.Table<SurveyDBModel>().Count() > 5)
                                DB.Delete(DB.Table<SurveyDBModel>().First());

                        }

                    }
                    catch (Newtonsoft.Json.JsonException)
                    {
#if DEBUG
                        if (System.Diagnostics.Debugger.IsAttached)
                            System.Diagnostics.Debugger.Break();
#endif
                        var index = DB.Table<SurveyDBModel>().Count() - 1;
                        if (index >= 0)
                            TrySurveyItem(index);
                    }

                }
            }
            else
            {
                var index = DB.Table<SurveyDBModel>().Count() - 1;
                if (index >= 0)
                    TrySurveyItem(index);
            }

        }

        private void TrySurveyItem(int index)
        {
            try
            {
                var surveyData = DB.Table<SurveyDBModel>().ElementAt(index);
                if (surveyData != null)
                    CurrentSurvey = Newtonsoft.Json.JsonConvert.DeserializeObject<SurveyData>(surveyData.SurveyData);

            }
            catch
            {
                if ((index - 1) >= 0)
                    TrySurveyItem(index - 1);
            }
        }
        private void SetupInternetConnection()
        {
            try
            {
                NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;
                ConnectionProfile InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();

                if (InternetConnectionProfile == null)
                    IsOnline = false;

                else if (InternetConnectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
                    IsOnline = true;

                else IsOnline = false;
            }
            catch
            {
                IsOnline = false;
            }
        }
        private void NetworkInformation_NetworkStatusChanged(object sender)
        {
            try
            {
                ConnectionProfile InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();

                if (InternetConnectionProfile == null)
                    IsOnline = false;

                else if (InternetConnectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
                    IsOnline = true;

                else IsOnline = false;
            }
            catch
            {
                IsOnline = false;
            }

        }

    }
}
