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
얼마 전 어린아이가 눈높이에 위치해있던 손소독제를 사용하던 중 펌프에서 손소독제가 발사되어 아이 눈에 손상을 입힌 사례가 있었습니다. 
또한, 손 소독제를 사용하기 위해서는 펌프 부분을 만져야 하기 때문에 바이러스 전파 위험이 있습니다. 
어린아이도 안전하게 사용할 수 있고, 불필요한 접촉을 방지할 수 있는 손소독제를 위해 저희는 누르미를 개발하였습니다.

## 구상 이미지
![Alt text](/img/3d.gif)     

# 파일 리스트

## 임베디드

파일명 |
:---- |
Embedded/src/controller.c   |
Embedded/src/network.c   |
Embedded/src/network.h   |

## 어플리케이션

파일명 |
:---- |
Noormi/Noormi/App.xaml(.cs)|  
Noormi/Noormi/Device.cs  |
Noormi/Noormi/ItemPage.xaml(.cs)|  
Noormi/Noormi/ListPage.xaml(.cs) | 
Noormi/Noormi/MainPage.xaml(.cs)  |
Noormi/Noormi/Splash.xaml(.cs)  |

## 서버

파일명 |
:---- |
server/src/*   |

## 코드 기여자
**김희연**
파일명 |
:---- |
Embedded/src/controller.c timer_cb   |
Embedded/src/controller.c motion_interrupted_cb|   
Embedded/src/controller.c service_app_create   |

**오정민**
파일명 |
:---- |
Embedded/src/network.c|  
Embedded/src/network.c   |
Embedded/src/network.h   |
Noormi/Noormi/App.xaml(.cs)  |
Noormi/Noormi/Device.cs  |
Noormi/Noormi/ItemPage.xaml(.cs)  |
Noormi/Noormi/ListPage.xaml(.cs)  |
server/src/*   |

**소호정**
파일명 |
:---- |
Noormi/Noormi/ItemPage.xaml(.cs)|  
Noormi/Noormi/ListPage.xaml(.cs) | 
Noormi/Noormi/Splash.xaml(.cs)  |
Noormi/Noormi/MainPage.xaml(.cs)|

## 보드
* RPI4 : 거리감지 센서, 헬리컬기어 펌프모터 연동, https://github.com/owjs3901/Noormi/Service

## 아키텍처
![Alt text](/img/아키텍처.png) 

## 회로도
![Alt text](/img/회로도.png)   
PIN NUM | 설명 |
---- | :----: |
GPIO 18 | 거리감지 센서
GPIO 24 | 헬리컬기어 펌프모터 컨트롤

## 구현사항
* Peripheral GPIO

## 기술
- 서버
  > Nodejs + express 기반 http  서버
- 임베디드
  > RPI4 + Tizen (C Native Application)
- 클라이언트
  > Xamarin (Android)
