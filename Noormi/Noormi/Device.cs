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

        public Device(string productName, string location)
        {
            ProductName = productName;
            Location = location;
        }
    }
}