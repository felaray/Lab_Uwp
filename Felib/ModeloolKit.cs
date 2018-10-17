using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace UwpToolkit
{
    public class ModelToolKit
    {
        /// <summary>
        /// JsonTxt To Class
        /// </summary>
        public async Task<T> JsonConverterAsync<T>(Uri filePath)
        {
            //string filePath = @"./Assets/test.txt";
            try
            {
                var file = await StorageFile.GetFileFromApplicationUriAsync(filePath);
                string text = await FileIO.ReadTextAsync(file);

                T items = JsonConvert.DeserializeObject<T>(text);
                return items;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
