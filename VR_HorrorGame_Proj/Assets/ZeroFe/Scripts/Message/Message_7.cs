using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_7 : Message
{
    public LockerManager[] lockers;

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
    }

    private void LockerEvent()
    {
        foreach (var lockerManager in lockers)
        {
            //for
            //lockerManager.lockers
        }

        
    }

    private void DoNextEvent()
    {

    }
}
