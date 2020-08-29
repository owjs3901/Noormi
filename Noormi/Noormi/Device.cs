using System;
using Newtonsoft.Json;

namespace Noormi
{
    public class Device
    {
        [JsonProperty("battery")]
        public int Battery { get; set; }
        [JsonProperty("productName")]
        public string ProductName { get; } // 디바이스 이름
        [JsonProperty("location")]
        public string Location { get; } // 디바이스 위치
        [JsonProperty("registerDate")]
        public string RegisterDate { get; } // 등록 일자
        [JsonProperty("lastDate")]
        public string LastDate { get; } // 마지막 교체 일자
        [JsonProperty("predictionDate")]
        public string PredictionDate { get; } // 예상 교체 주기
        public string NumberOfUsers { get ; } //예상 사용 인원

        public Device(string productName, string location, int battery, string registerDate, string lastDate, string predictionDate, string numberOfUsers)
        {
            ProductName = productName;
            Location = location;
            Battery = battery;
            RegisterDate = registerDate;
            LastDate = lastDate;
            PredictionDate = predictionDate;
            NumberOfUsers = numberOfUsers;

        }
    }
}