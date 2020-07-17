using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebClient2.Models
{
    public class TestTableRepository
    {
        private string apiUrl = "http://localhost:58255/api/testtables";
        private HttpClient _client;

        public TestTableRepository()
        {
                _client = new HttpClient();
        }

        public List<TestTable> getAllTestTable()
        {
            var result = _client.GetStringAsync(apiUrl).Result;
            List<TestTable> list = JsonConvert.DeserializeObject<List<TestTable>>(result);
            return list;
        }

        public TestTable GetTestTableById(int TTId)
        {
            var result = _client.GetStringAsync(apiUrl + "/" + TTId).Result;

            TestTable testTable = JsonConvert.DeserializeObject<TestTable>(result);
                
            return testTable;
        }

        public void AddTestTable(TestTable testTable)
        {
            string jsonTT = JsonConvert.SerializeObject(testTable);
            StringContent content = new StringContent(jsonTT,Encoding.UTF8,"application/json");
            var result = _client.PostAsync(apiUrl, content).Result;
        }

        public void UpdateTT(TestTable testTable)
        {
            string jsonTT = JsonConvert.SerializeObject(testTable);
            StringContent content = new StringContent(jsonTT, Encoding.UTF8, "application/json");

            var result = _client.PutAsync(apiUrl, content).Result;

        }

        public void DeleteTT(int id)
        {
          var Result =  _client.DeleteAsync(apiUrl + "/" + id).Result;
        }
    }

    public class TestTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
