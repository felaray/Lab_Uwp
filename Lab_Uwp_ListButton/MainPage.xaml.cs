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
                        slider.Foreground = GetSolidColorBrush("#c1ff87");
                        break;
                    case 2:
                        slider.Foreground = GetSolidColorBrush("#e6ff6d");
                        break;
                    case 3:
                        slider.Foreground = GetSolidColorBrush("#fffb1e");
                        break;
                    case 4:
                        slider.Foreground = GetSolidColorBrush("#ffaf0f");
                        break;
                    case 5:
                        slider.Foreground = GetSolidColorBrush("#ff0000");
                        break;
                }
            }
        }

        /// <summary>
        /// Hex to RGB
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public SolidColorBrush GetSolidColorBrush(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            //Disable Alpha
            //byte a = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte r = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, r, g, b));
            return myBrush;
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
}
