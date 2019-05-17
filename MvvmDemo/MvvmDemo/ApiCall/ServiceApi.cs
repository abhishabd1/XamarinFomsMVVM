using MvvmDemo.Common;
using MvvmDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDemo.ApiCall
{
   public class ServiceApi
    {
        public static ObservableCollection<Emlpoyee> emplyee;
        public static async Task<ObservableCollection<Emlpoyee>> GetEmplyee()
        {
            emplyee = new ObservableCollection<Emlpoyee>();
            var client = new HttpClient();
            string urlFomrate = ConstantsValue.BaseAddress + ConstantsValue.Emplyeelist;
            string requestContent = urlFomrate;
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, requestContent);
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    emplyee = JsonConvert.DeserializeObject<ObservableCollection<Emlpoyee>>(result);

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                return null;
            }
            return emplyee;
        }
    }
}
