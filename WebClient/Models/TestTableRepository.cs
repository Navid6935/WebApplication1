using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebClient.Models
{
    public class TestTableRepository
    {
        private string apiurl = "http://http://localhost:58255/api/TestTables";
        //ساخت جهت ارسال درخواست به web api
        private HttpClient _client;

        public TestTableRepository()
        {
                _client=new HttpClient();
        }
        //تبدیل متدها به آبجکت چون جیسون هستند
        public List<TestTeble> GetAllTest()
        {
            var result = _client.GetStringAsync(apiurl).Result;
            //تبدیل خروجی به لیست
            List<TestTeble> list = JsonConvert.DeserializeObject<List<TestTeble>>(result);
            return list;
        }
        public TestTeble GetTestTableById(int id)
        {
            var result = _client.GetStringAsync(apiurl+"/"+id).Result;
            TestTeble testTeble = JsonConvert.DeserializeObject<TestTeble>(result);
            return testTeble;
        }

        public void AddTest(TestTeble testteble)
        {
            string jsontest = JsonConvert.SerializeObject(testteble);
            StringContent content = new StringContent(jsontest,Encoding.UTF8,"application/json");
            var res = _client.PostAsync(apiurl, content).Result;
        }
    }

    public class TestTeble
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
