using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_7 : Message
{
    public LockerManager[] lockers;
    public LockerOpen fittingRoomDoor;
    public LockerOpen fittingRoomEntranceDoor;
    public Trigger_Exit exitTrigger;

    // 디버그용. 테스트 후 VR에서 PlayerCellPhone으로 맞춤
    public PlayerCellPhone messenger;

    protected override void Trigger()
    {
        //1. * *첫번째 쪽지 ui가 뜨는 순간 플레이어 뒤에 두번째 쪽지를 생성한다 * *
        //    2. * *동성 친구와의 문자 대화 이벤트**
        //    -**대화 내용 * *

        //    (추가 예정 )

        //3. * *대화 이벤트가 끝나면 사물함들이 거칠게 닫히며 큰 소리를 낸다**
        //    4. * *여자 친구의 문자 대화 이벤트**
        //    -**대화 내용 * *

        //    (추가 예정 )

        //5. * *중간 세기의 글리치 일시적 발생**
        //    -**참고 이미지 * *

        PlayerCellPhone.instance.action = LockerEvent;
        PlayerCellPhone.instance.StartPhoneCoroutine(2);
    }

    private void LockerEvent()
    {
        foreach (var lockerManager in lockers)
        {
            lockerManager.ActiveDoor();
        }

        Invoke(nameof(MessageEvent), 5.0f);
    }

    private void MessageEvent()
    {
        PlayerCellPhone.instance.action = Glitch;
        PlayerCellPhone.instance.StartPhoneCoroutine(3);
    }

    private void Glitch()
    {
        StartCoroutine(IEGlitch());
    }

    IEnumerator IEGlitch()
    {
        Player_Glitch.instance.SetGlitch(0.5f);

        yield return new WaitForSeconds(0.5f);

        // 글리치 끝나고 문 열기
        fittingRoomDoor.Open(0.5f);
        fittingRoomEntranceDoor.Open(0.5f);
        exitTrigger.triggable = true;
    }
}
