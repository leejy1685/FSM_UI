# FSM_UI
FSM을 이용해서 UI만들어 보기

## 목차
|목차|
|:---:|
|[프로젝트 목적](#프로젝트-목적) |
|[게임 설명](#게임-설명-및-주요-기능) |
|[기술 스택](#기술-스택)|

## 🧭프로젝트 목적
FSM 인터페이스 방식을 이용해서 UI에 자연스러운 애니메이션 만들어 보기


## 📗게임 설명 및 주요 기능
_[ 프로젝트 명 - **FSM_UI** ]_

![image](https://github.com/user-attachments/assets/c12bcf30-40a6-4c23-9d85-a41a504dde3d)
</br>

#### ◇ 캐릭터 정보 확인

![image](https://github.com/user-attachments/assets/2ba8eb30-89a1-4401-9f13-084e0c82314c)

화면 왼쪽에는 캐릭터의 정보를 확인 할 수 있습니다.</br>

#### ◇ 캐릭터 스텟 확인

![image](https://github.com/user-attachments/assets/40faef04-dbdb-4bcc-8b4c-f731ff20d444)

Status 버튼을 눌러 캐릭터의 스텟을 확인할 수 있습니다. </br>

#### ◇ 인벤토리 기능

![image](https://github.com/user-attachments/assets/e20b294b-b9b6-41ac-9bf0-cad25641801f)

Inventory 버튼을 눌러 인벤토리를 확인할 수 있습니다. </br>
원하는 아이템에 좌클릭을 하면 아이템을 장착 할 수 있습니다.</br>

#### ◇ 아이템 스텟 증가 기능

![image](https://github.com/user-attachments/assets/cf7585bd-d845-4858-94dd-be8321748d81)
![image](https://github.com/user-attachments/assets/1ba22b19-853d-43c0-913b-a882e189eceb)

장착한 아이템의 능력치 만큼 캐릭터의 스텟이 증가합니다. </br>

#### ◇ UI 애니메이션 기능

![image](https://github.com/user-attachments/assets/6276c10e-2e57-4d20-a302-174d336b36af)

MainMenuUI  </br>
  Enter : 버튼만 FadeIn </br>
  Exit  : 버튼만 FadeOut</br>

![image](https://github.com/user-attachments/assets/e3a9ac6c-00eb-4533-9ef8-cc5f4b5630a0)

Status  </br>
  Enter : 캐릭터 몸에서 나오는 연출</br>
  Exit  : 캐릭터 몸으로 돌아가는 연출</br>


![image](https://github.com/user-attachments/assets/05078d68-11ee-437f-b6e5-0c2dc52a588f)
![image](https://github.com/user-attachments/assets/48f43dd1-027b-4306-a2f9-40d0410bcf5c)

Inventroy </br>
  Enter : 캐릭터가 점프해서 인벤토리 창을 가지고 내려오는 연출</br>
  Exit  : 인벤토리가 올라가는 연출</br>


## 🛠️기술 스택
### 개발 환경
- Unity 2022.3.17f1
- Windows 10 & 11

### 리소스
- 내일배움캠프 제공
- 
 
### 사용 기술

FSM :</br>
UI 상태를 인터페이스 방식으로 구현 </br>
Enter, Exit, UdateUI 메서드를 각 상태에 따라서 구현</br>

ScriptableObject : </br>
캐릭터 정보, 아이템 정보 등을 ScriptableObject로 구현하여 데이터 관리 편의성 Up





   


