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
            this.InitializeComponent();
            this.ViewModel = new RecordingViewModel();
        }
        public RecordingViewModel ViewModel { get; set; }
        public List<Recording> Groups { get; set; }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            if (slider != null)
            {
                //media.Volume = slider.Value;
            }
        }
    }

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
            return "<=" + value;
        }
    }

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
        public List<Recording> Data { get; } = new List<Recording>
        {
            new Recording{  ArtistName="1"},
                   new Recording{  ArtistName="2"},
                          new Recording{  ArtistName="3"},
        };

    }
}
