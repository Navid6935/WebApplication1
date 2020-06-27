using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebClient.Models
{
    public class AppDevices
    {
        private string apiurl = "http://localhost:44332/api/AppDevices";

        //ساخت جهت ارسال درخواست به web api
        private HttpClient _client;

        public AppDevices()
        {
            _client = new HttpClient();
        }
        //تبدیل متدها به آبجکت چون جیسون هستند
        public List<AppDevices> GetAllAppDevice()
        {
            var result = _client.GetStringAsync(apiurl).Result;
            //تبدیل خروجی به لیست
            List<AppDevices> list = JsonConvert.DeserializeObject<List<AppDevices>>(result);
            return list;
        }
        public AppDevices GetAppDevicesById(int id)
        {
            var result = _client.GetStringAsync(apiurl + "/" + id).Result;
            AppDevices appDevices = JsonConvert.DeserializeObject<AppDevices>(result);
            return appDevices;
        }
        public void AddAppDevice(AppDevices appDevices)
        {
            string json = JsonConvert.SerializeObject(appDevices);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = _client.PostAsync(apiurl, content).Result;
        }
        public void UpdateAppDevice(AppDevices appDevices)
        {
            string json = JsonConvert.SerializeObject(appDevices);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = _client.PutAsync(apiurl, content).Result;
        }

        public void DeleteAppDevice(int id)
        {
            var res =  _client.DeleteAsync(apiurl + "/" + id).Result;
        }

    }
    public class AppDeviceses
    {

        public int DeviceId { get; set; }
        public string Imei { get; set; }
        public string Serial { get; set; }
        public string UserName { get; set; }
        public string DeviceName { get; set; }
        public decimal Id { get; set; }
        public string Vaziat { get; set; }
        public string Savetime { get; set; }
        public string SaveDate { get; set; }
        public string Type { get; set; }
    }
}
