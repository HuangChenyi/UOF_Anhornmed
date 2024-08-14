using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "http://192.168.101.31:49780/datasnap/rest/TdmServerMethodsOT/ImpWD2SU01";
            string AToken = "0A807910-5050-452F-8B7D-9B48E293ED28";
            string AUpdateType = "0";
            string ADataSet = @"{
            ""SU01001"":""20240730"", // *供應商代號  PK
            ""SU01002"":1,
            ""SU01003"":""0730測試API廠商"",// *供應商簡稱
            ""SU01004"":""0730測試API廠商"", // *供應商全稱
            ""SU01007"":""20240730"",  //統一編號
            ""SU01010"":""台北市信義區松仁路10號"", // 發票地址
            ""SU01011"":""台北市信義區松仁路11號"", // 聯絡地址
            ""SU01012"":""台北市信義區松仁路12號"", // 送貨地址
            ""SU01013"":""02-01013"", //發票地址電話
            ""SU01014"":""02-01014"", //聯絡地址電話
            ""SU01015"":""02-01015"", //送貨地址電話
            ""SU01016"":""02-01016"", //傳真
            ""SU01019"":""09-01019"", //業務行動電話
            ""SU01082"":""20240730"", // *請款客戶 同供應商代號
            ""SU01050"":25,  // 對帳日期
            ""SU01051"":1,   // 對帳後幾個月付款
            ""SU01052"":5,  // 對帳後付款日期
            ""SU01090"":25, // 結帳終止日
            ""SU01092"":""2"", // 結帳方式  0:日結 1:週結 2:月結
            ""SU01040"":""8220000"", // 匯款行庫
            ""SU01041"":""149586754487"", // 匯款帳號
            ""SU01022"":""彭于晏"", // 聯絡人
            ""SU01096"":""test@email.com"", // Email Address
            ""SU01100"":""月結45天"" // 收款付款方式(描述)
        }";

            BodyData bodyData = new BodyData
            {
                aToken = AToken,
                aUpdateType = AUpdateType,
                aDataSet = ADataSet
            };

            //do post api
            string result = PostApi(url, bodyData);
            Console.WriteLine(result);
            Console.WriteLine("按任意鍵結束");
            Console.ReadKey();
        }

        private static string PostApi(string url, BodyData bodyData)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(bodyData);
                Console.WriteLine(json);
                StringContent content = new StringContent(json,
                    Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(url, content).Result;
                string result = response.Content.ReadAsStringAsync().Result;



                return result;
            }
        }

        public class BodyData
        {
            public string aToken { get; set; }
            public string aUpdateType { get; set; }
            public string aDataSet { get; set; }
        }
    }
}
