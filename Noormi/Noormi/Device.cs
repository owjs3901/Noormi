using System;

namespace Noormi
{
    public class Device
    {
        public int Battery { get; set; }
        public string ProductName { get; } // 디바이스 이름
        public string Location { get; } // 디바이스 위치
        public string RegisterDate { get; } // 등록 일자
        public string LastDate { get; } // 마지막 교체 일자
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