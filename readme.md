# 누르미
2020 하드웨어 해커톤
Xamarin + Tizen

## 구성원
- **[오정민](https://github.com/owjs3901)(팀장 - HW/SW 개발자)**
\n회로도 제작
  
- **소호정(팀원 - SW 개발자)**

- **김희연(팀원 - HW 개발자)**
\nRPI4 Tizen 환경설정
\n하드웨어 설계 및 제작
\nPheripheral GPIO를 활용한 하드웨어 제어코드 작성
  
- **이지헌(팀원 - 디자이너)**

## 개요
코로나로 인한 언택트 시대, 불가피한 접촉에서의 감염을 막기위해 주변 곳곳에 손 소독제가 배치되고 있습니다.
손 소독제를 사용하기 위해서는 펌프 부분을 손으로 눌러야 하는 접촉이 불가피합니다.
이러한 접촉을 줄이기 위해 개발된 누르미는 **비접촉 손소독제 사용모듈**입니다.
누르미는 손 세정제 사용을 자동화하며 사용데이터를 관리자에게 전송하는 솔루션입니다.
또한 앱을 통하여 설치되어 있는 다수의 세정제들을 관리할 수도 있습니다.

## 파일 리스트
* Service/src/controller.c
* Service/src/network.c
* Service/src/network.h

## 코드 기여자
* Service/src/controller.c timer_cb 김희연
* Service/src/network.c 오정민
* Service/src/network.h 오정민

## 보드
* RPI4 : 거리감지 센서, 헬리컬기어 펌프모터 연동, https://github.com/owjs3901/Noormi/Service

## 회로도
<img src="/img/회로도.png">
- GPIO 18 : 거리감지 센서
- GPIO 24 : 헬리컬기어 펌프모터 // V2(12V) 외부전력과 연결

## 구현사항
* Peripheral GPIO

## 기술
- 서버
  > Nodejs + express 기반 http  서버
- 임베디드
  > RPI4 + Tizen
- 클라이언트
  > Xamarin (Android)
