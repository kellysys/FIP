using FIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FIP.Controllers
{
    public class ExchangeController
    {
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

                var result = post.country.LastOrDefault();

                return result.value;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
