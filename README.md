# 17조 이정석 TopDown2DGame
 ## 개발환경 / 에셋소스
1. Unity Ver: 2022.3.2f1<br/><br/>
2. IDE: VS Code 2022<br/><br/>
3. Asset: <br/><br/>
2D Sci-Fi Weapons Pack(플레이어 무기, 아이템): https://assetstore.unity.com/packages/2d/textures-materials/2d-sci-fi-weapons-pack-22679
<br/><br/>
Pixel Adventure 1 (플레이어, 몬스터, 맵): https://assetstore.unity.com/packages/2d/characters/pixel-adventure-1-155360
<br/><br/>
4. 개발기간: 12월 27일 ~ 12월 29일<br/><br/>

## 필수구현/선택구현
필수구현<br/><br/>
1. 인트로 씬 구성 - 시작버튼 UI(플레이 씬으로 이동)
2. 플레이 씬 구성 - 캐릭터 만들기, 캐릭터 이동, 방 만들기, 카메라 따라가기<br/><br/>

선택구현<br/><br/>
1. 오브젝트 풀링 - 총알 생성할 때 사용(ObjectPool) 스크립트<br/><br/>
2. Instantiate 로 오브젝트 생성- 총알 생성, 몬스터 소환할 때 사용<br/><br/>
3. InputAction- 캐릭터 이동, 시선처리, 공격에서 사용<br/><br/>
4. delegate 사용 - 캐릭터 움직임 처리 및 몬스터 죽음, 아이템 사용에서 사용<br/><br/>
5. raycast - 원거리 공격 몬스터에게 적용<br/><br/>
6. Dictionary 활용 - 오브젝트 풀링 사용할 때 적용<br/><br/>
7. Queue 활용 - 오브젝트 풀링 시 사용<br/><br/>
<br/><br/>


## 오류사항
1. 몬스터, 플레이어 맞았을 때 애니메이션 효과 적용 x<br/><br/>
2. 근접몬스터와 무한으로 접촉시 1번만 데미지가 들어감 (데미지 딜레이가 적용안됨/ 원거리는 적용됨)<br/><br/>

<br/><br/>
## 수정계획
1. 몬스터를 처치하면 골드를 획득해서 플레이어를 강화하게 만드는 로직을 추가
2. 플레이어에게 레벨 변수를 주어 일정 레벨 달성 시 총외형 변경
3. 현재 플레이어가 데미지를 갖고 있고 총은 데이터가 없는 오브젝트, 총에도 데이터를 주어 총이 변경되면 플레이어 능력치 변경 적용될 수 있게 변경
4. 스테이지 난이도 조절 
