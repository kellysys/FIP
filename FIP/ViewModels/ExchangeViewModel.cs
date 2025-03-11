using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Font = Microsoft.Maui.Font;
using System.Diagnostics;

namespace FIP.ViewModels
{
    public partial class ExchangeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string money1 = "1";

        [ObservableProperty]
        private string from1 = "CNY";

        [ObservableProperty]
        private string to1 = "KRW";

        [ObservableProperty]
        private string result1 = string.Empty;


        [ObservableProperty]
        private string money2 = "1";

        [ObservableProperty]
        private string from2 = "USD";

        [ObservableProperty]
        private string to2 = "KRW";

        [ObservableProperty]
        private string result2 = string.Empty;


        [ObservableProperty]
        private string money3 = "1";

        [ObservableProperty]
        private string from3 = "USD";

        [ObservableProperty]
        private string to3 = "CNY";

        [ObservableProperty]
        private string result3 = string.Empty;


        [ObservableProperty]
        private string money4 = "10000";

        [ObservableProperty]
        private string from4 = "KRW";

        [ObservableProperty]
        private string to4 = "USD";

        [ObservableProperty]
        private string result4 = string.Empty;


        [ObservableProperty]
        private string money5 = "10000";

        [ObservableProperty]
        private string from5 = "KRW";

        [ObservableProperty]
        private string to5 = "CNY";

        [ObservableProperty]
        private string result5 = string.Empty;


        private async Task<string> GetDataAsync(string from, string to, string money)
        {
            using HttpClient client = new HttpClient();

            try
            {
                string url1 = $"https://m.search.naver.com/p/csearch/content/qapirender.nhn?key=calculator&pkid=141&q=%ED%99%98%EC%9C%A8&where=m&u1=keb&u6=standardUnit&u7=0&u3={from}&u4={to}&u8=down&u2={money}";

                HttpResponseMessage response1 = await client.GetAsync(url1);
                response1.EnsureSuccessStatusCode();

                string json = await response1.Content.ReadAsStringAsync();
                var post = JsonSerializer.Deserialize<ResultModel>(json);
                var result = post?.country.LastOrDefault();
                
                return result.value;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private bool onGetRate;
        [RelayCommand(CanExecute = nameof(GetExchangeRateCanExecute))]
        async Task GetExchangeRate()
        {
            onGetRate = true;
            Result1 = await GetDataAsync(From1, To1, Money1);
            Result2 = await GetDataAsync(From2, To2, Money2);
            Result3 = await GetDataAsync(From3, To3, Money3);
            Result4 = await GetDataAsync(From4, To4, Money4);
            Result5 = await GetDataAsync(From5, To5, Money5);
            onGetRate = false;

        }

        bool GetExchangeRateCanExecute()
        {
            return !onGetRate;
        }
    }
}
