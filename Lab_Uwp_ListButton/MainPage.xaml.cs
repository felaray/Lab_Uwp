using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UwpToolkit;
using Windows.Storage;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Toolkit.Uwp.Helpers;


// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace Lab_Uwp_ListButton
{

    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            var info = OperatingSystemVersion;
            InitializeComponent();
            ViewModel = new RecordingViewModel();
            //bool isFilePathValid = StorageFileHelper.IsFilePathValid("Assets/TextFile1.txt");
            //string loadedText = StorageFileHelper.ReadTextFromLocalCacheFileAsync("Assets/TextFile1.txt").Result;
            //var result = TestAsync<Rootobject>("Assets/TextFile1.txt");
            var file = "Assets/TextFile1.txt";
            var result =new ModelToolKit().JsonConverterAsync<Rootobject>(new Uri(BaseUri,file));
        }



        public OSVersion OperatingSystemVersion => SystemInformation.OperatingSystemVersion;

        #region Test
        public class Rootobject
        {
            public string No { get; set; }
            public string User { get; set; }
            public Question[] Question { get; set; }
        }

        public class Question
        {
            public string Title { get; set; }
            public string Result1 { get; set; }
            public string Result2 { get; set; }
            public string Result3 { get; set; }
            public string Result4 { get; set; }
            public string Result5 { get; set; }
            public int Result { get; set; }
        }

        #endregion


        public RecordingViewModel ViewModel { get; set; }
        public List<Recording> Groups { get; set; }

        /// <summary>
        /// 滑桿數值變動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            if (slider != null)
            {
                //media.Volume = slider.Value;
                switch (e.NewValue)
                {
                    default:
                    case 1:
                        slider.Foreground = new ColorToolKit().GetSolidColorBrush("#c1ff87");
                        break;
                    case 2:
                        slider.Foreground = new ColorToolKit().GetSolidColorBrush("#e6ff6d");
                        break;
                    case 3:
                        slider.Foreground = new ColorToolKit().GetSolidColorBrush("#fffb1e");
                        break;
                    case 4:
                        slider.Foreground = new ColorToolKit().GetSolidColorBrush("#ffaf0f");
                        break;
                    case 5:
                        slider.Foreground = new ColorToolKit().GetSolidColorBrush("#ff0000");
                        break;
                }
            }
        }


    }



    /// <summary>
    /// 滑桿數值轉為文字並輸出至toolkit
    /// </summary>
    public class SecondsToTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (int.Parse(value.ToString()))
            {
                case 1:
                default:
                    return "無";
                case 2:
                    return "輕微";
                case 3:
                    return "中等";
                case 4:
                    return "頻繁";
                case 5:
                    return "嚴重";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    #region DataModel

    public class Recording
    {
        public string ArtistName { get; set; }
        public string CompositionName { get; set; }
        public DateTime ReleaseDateTime { get; set; }
        public int Value { get; set; } = 1;
        public Recording()
        {
            this.ArtistName = "Wolfgang Amadeus Mozart";
            this.CompositionName = "Andante in C for Piano";
            this.ReleaseDateTime = new DateTime(1761, 1, 1);
        }
        public string OneLineSummary
        {
            get
            {
                return $"{this.CompositionName} by {this.ArtistName}, released: "
                    + this.ReleaseDateTime.ToString("d");
            }
        }
    }
    public class RecordingViewModel
    {
        public Recording DefaultRecording { get; } = new Recording();
        //public List<Recording> Data { get; } = new List<Recording>
        //{
        //    new Recording{  ArtistName="1"},
        //           new Recording{  ArtistName="2"},
        //                  new Recording{  ArtistName="3"},
        //};

        public List<Recording> Data
        {
            get
            {
                List<Recording> Result = new List<Recording> { };
                for (int i = 0; i <= 20; i++)
                {
                    Result.Add(new Recording { ArtistName = " Item " + i });
                }
                return Result;
            }
        }

    }

    #endregion
}
