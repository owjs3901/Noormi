# 누르미
<img src="/img/logo2.svg" width="50%" height="50%">
2020 하드웨어 해커톤

## 구성원
- **[오정민](https://github.com/owjs3901)(팀장 - HW/SW 개발자)**
> 프로젝트 매니저  
회로도 제작 및 설계  
서버 개발 및 설계  
안드로이드 앱 개발 - 로직 및 네트워킹  
타이젠 펌웨어 개발 - 네트워킹

- **소호정(팀원 - SW 개발자)**
> 안드로이드 앱 개발 - 로직 및 레이아웃

- **김희연(팀원 - HW/SW 개발자)**
> RPI4 Tizen 환경설정  
하드웨어 설계 및 제작  
타이젠 펌웨어 개발 - Pheripheral GPIO를 활용한 하드웨어 제어코드 작성
  
- **이지헌(팀원 - 디자이너)**
>APP UI/UX Design   
Product 3D modeling   
Graphic Design   

## 개요
코로나로 인한 언택트 시대, 불가피한 접촉에서의 감염을 막기위해 주변 곳곳에 손 소독제가 배치되고 있습니다.
손 소독제를 사용하기 위해서는 펌프 부분을 손으로 눌러야 하는 접촉이 불가피합니다.
이러한 접촉을 줄이기 위해 개발된 누르미는 **비접촉 손소독제 사용모듈**입니다.
누르미는 손 세정제 사용을 자동화하며 사용데이터를 관리자에게 전송하는 솔루션입니다.
또한 앱을 통하여 설치되어 있는 다수의 세정제들을 관리할 수도 있습니다.

## 구상 이미지
![Alt text](/img/3d.gif)     

## 파일 리스트
* 임베디드
> Embedded/src/controller.c   
Embedded/src/network.c   
Embedded/src/network.h   

* 어플리케이션
> Noormi/Noormi/App.xaml(.cs)  
> Noormi/Noormi/Device.cs  
> Noormi/Noormi/ItemPage.xaml(.cs)  
> Noormi/Noormi/ListPage.xaml(.cs)  
> Noormi/Noormi/MainPage.xaml(.cs)  
> Noormi/Noormi/Splash.xaml(.cs)  

## 코드 기여자
**김희연**
> Embedded/src/controller.c timer_cb   
Embedded/src/controller.c motion_interrupted_cb   
Embedded/src/controller.c service_app_create   
   
**오정민**
> Embedded/src/network.c   
> Embedded/src/network.h   
> Noormi/Noormi/App.xaml(.cs)  
> Noormi/Noormi/Device.cs  
> Noormi/Noormi/ItemPage.xaml(.cs)  
> Noormi/Noormi/ListPage.xaml(.cs)

**소호정**
> Noormi/Noormi/ItemPage.xaml(.cs)  
> Noormi/Noormi/ListPage.xaml(.cs)
> Noormi/Noormi/Splash.xaml(.cs)
> Noormi/Noormi/MainPage.xaml(.cs)

## 보드
* RPI4 : 거리감지 센서, 헬리컬기어 펌프모터 연동, https://github.com/owjs3901/Noormi/Service

## 회로도
![Alt text](/img/회로도.png)   
* GPIO PIN   
> GPIO 18 : 거리감지 센서   
GPIO 24 : 헬리컬기어 펌프모터 // V2(12V) 외부전력과 연결   

## 구현사항
* Peripheral GPIO

## 기술
- 서버
  > Nodejs + express 기반 http  서버
- 임베디드
  > RPI4 + Tizen
- 클라이언트
  > Xamarin (Android)
