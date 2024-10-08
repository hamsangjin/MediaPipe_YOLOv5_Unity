# 다인원 포즈 렌더링 프로그램(MultiPerson Pose Rendering Program)

> 2023 BRIGHT MAKERS EXPO 제15회 캡스톤디자인 경진대회 - 대상 </br>
> 최종 발표 영상 : [YouTube](https://youtu.be/E6Gg7EKbIuw)
<div align="center">

![결과 사진](https://github.com/hamsangjin/MediaPipe_YOLOv5_Unity/assets/103736614/56ecf3b7-792e-44ba-94c8-a4e27e8cbc5d)

</div>

# 목차
- [프로젝트 정보](#프로젝트-정보)
- [팀원 구성](#팀원-구성)
- [개발 기간 및 개발 환경](#개발-기간-및-개발-환경)
- [개발 과정](#개발-과정)
- [동작 순서](#동작-순서)
- [성능 개선](#성능-개선)
----

## 프로젝트 정보

### 프로젝트 배경
- 기존 프로그램 같은 경우 표정과 머리 움직임을 제외하고는 인식이 어렵고 한 명밖에 인식이 안 된다는 단점
- 프로그램이 아닌 장비를 사용해 머리와 손 움직임 정도만 인식하려 해도 50만원 가량의 가격적인 부담

### 프로젝트 소개
인공지능 자세 추정 모델 **MediaPipe**와 객체 탐지 모델 **Yolov5**를 통해 두 명 이상의 자세를 추정하고, 추정한 결과를 **Unity**에서 실시간 렌더링할 수 있는 프로그램이다.
이 프로그램은 고가의 VR 장비 없이 웹캠을 이용해 두 명 이상의 자세 추정이 가능하다.

---

## 팀원 구성

<div align="center">

| **유규빈** | **함상진** |
| :------: |  :------: |
| [<img width="225" alt="유규빈" src="https://github.com/hamsangjin/MediaPipe_YOLOv5_Unity/assets/103736614/87092c56-b1fc-4703-9a18-88ba20adbbaf"> </br> @Yookyubin](https://github.com/YooKyubin) | [<img width="189" alt="함상진" src="https://github.com/hamsangjin/MediaPipe_YOLOv5_Unity/assets/103736614/39e3e68e-d50a-4b5c-9bf5-812842c683a0"> </br> @hamsangjin](https://github.com/hamsangjin) |
| 데이터 전처리 </br> 아바타 렌더링  | 자세추정 </br> 객체 탐지 </br> 소켓 통신 |
</div>

---

## 개발 기간 및 개발 환경

**프로젝트 기간**  : 2023. 02. 20 ~ 2023. 11. 14

**개발 기간** : 2023. 05. 25 ~ 2023. 11. 14

- **자세 추정(Python)** : [MediaPipe](https://github.com/google/mediapipe)
- **객체 탐지(Python)** : [YOLOv5](https://github.com/ultralytics/yolov5)
- **아바타 렌더링(C#)** : Unity
- **작업 관리** : Github

---

## 개발 과정
- [1. 프로젝트 주제 제안서](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/1.%20%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8%20%EC%A3%BC%EC%A0%9C%20%EC%A0%9C%EC%95%88%EC%84%9C.pdf)
- [2. 자세 추정 프로그램 자료](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/2.%20%EC%9E%90%EC%84%B8%20%EC%B6%94%EC%A0%95%20%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%A8%20%EC%9E%90%EB%A3%8C.pdf)
- [3. 자세추정 모델 조사 보고서](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/3.%20%EC%9E%90%EC%84%B8%EC%B6%94%EC%A0%95%20%EB%AA%A8%EB%8D%B8%20%EC%A1%B0%EC%82%AC%20%EB%B3%B4%EA%B3%A0%EC%84%9C.pdf)
- [4. 논문 번역](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/4.%20%EB%85%BC%EB%AC%B8%20%EB%B2%88%EC%97%AD.pdf)
- [5. 알파포즈 사용(Mac)](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/5.%20%EC%95%8C%ED%8C%8C%ED%8F%AC%EC%A6%88%20%EC%82%AC%EC%9A%A9(Mac).pdf)
- [6. 알파포즈 사용(Windows)](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/6.%20%EC%95%8C%ED%8C%8C%ED%8F%AC%EC%A6%88%20%EC%82%AC%EC%9A%A9(Windows).pdf)
- [7. 알파포즈 사용(Linux)](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/7.%20%EC%95%8C%ED%8C%8C%ED%8F%AC%EC%A6%88%20%EC%82%AC%EC%9A%A9(Linux).pdf)
- [8. 웹캠 사용과 모델 비교](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/8.%20%EC%9B%B9%EC%BA%A0%20%EC%82%AC%EC%9A%A9%EA%B3%BC%20%EB%AA%A8%EB%8D%B8%20%EB%B9%84%EA%B5%90.pdf)
- [9. 2D to 3D](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/9.%202D%20to%203D.pdf)
- [10. 2D to 3D](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/10.%202D%20to%203D.pdf)
- [11. mediapipe](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/11.%20mediapipe.pdf)
- [12. 조별 학기 보고서](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/12.%20%EC%A1%B0%EB%B3%84%20%ED%95%99%EA%B8%B0%20%EB%B3%B4%EA%B3%A0%EC%84%9C.pdf)
- [13. 방학 중 성과 발표](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/13.%20%EB%B0%A9%ED%95%99%20%EC%A4%91%20%EC%84%B1%EA%B3%BC%20%EB%B0%9C%ED%91%9C.pdf)
- [14. 성능 개선1](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/14.%20%EC%84%B1%EB%8A%A5%20%EA%B0%9C%EC%84%A01.pdf)
- [15. 성능 개선2](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/15.%20%EC%84%B1%EB%8A%A5%20%EA%B0%9C%EC%84%A02.pdf)
- [16. 다인원 포즈 렌더링 프로그램](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/16.%20%EB%8B%A4%EC%9D%B8%EC%9B%90%20%ED%8F%AC%EC%A6%88%20%EB%A0%8C%EB%8D%94%EB%A7%81%20%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%A8.pdf)
- [17. 제15회 캡스톤디자인 경진대회 패널](https://github.com/hamsangjin/MultiPerson-Pose-Rendering-Program/blob/main/Docs/17.%20%EC%A0%9C15%ED%9A%8C%20%EC%BA%A1%EC%8A%A4%ED%86%A4%EB%94%94%EC%9E%90%EC%9D%B8%20%EA%B2%BD%EC%A7%84%EB%8C%80%ED%9A%8C%20%ED%8C%A8%EB%84%90.pdf)

---

## 동작 순서
<div align="center">

<img width="712" alt="동작 순서" src="https://github.com/hamsangjin/MediaPipe_YOLOv5_Unity/assets/103736614/aa557593-e460-4e2a-998e-df5f50c7c05f">

</div>

1. 웹캠 입력
2. 화면 상에 나타난 객체(사람)을 탐지한다. 이때, Bounding Box가 일정 크기 이상인 경우에만 탐지하게 제한
3. Bounding Box마다 존재하는 사람의 자세를 추정해 Landmarks를 추출한다.
4. Landmarks를 아바타 좌표에 맞게 데이터 전처리 후 소켓통신을 통해 Unity에 넘긴다.
5. 전처리된 Landmarks를 이용해 아바타를 실시간 렌더링한다.

---

## 성능 개선

- MediaPipe와 YOLOv5를 함께 사용하다보니 성능이 떨어졌는데 아래 두 방법을 통해 성능을 개선시켰다.
1. **객체 탐지 제한** : 사람은 특수한 상황이 아니면 서있는 위치가 많이 바뀌지 않는다. 그 점을 이용해 한 프레임마다 객체 탐지하던 걸 세 프레임마다 탐지하는 것으로 변경해 YOLOv5의 사용을 제한했다.
2. **멀티 스레딩** : YOLOv5에서 탐지한 인원 수만큼 반복하여 MesdiaPipe를 사용해야 한다. 이때, 시간비용이 많이 들어 멀티스레딩으로 불필요한 시간을 줄였다.

> **초기 성능 : 6.98fps** </br>
> **객체 탐지 제한 : 7.5fps** </br>
> **객체 탐지 제한 + 멀티스레딩 : 10.26fps**
