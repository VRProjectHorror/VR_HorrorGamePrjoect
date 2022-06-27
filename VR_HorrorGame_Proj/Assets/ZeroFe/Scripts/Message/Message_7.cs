using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_7 : Message
{
    public LockerManager[] lockers;
    public LockerOpen fittingRoomDoor;

    // ����׿�. �׽�Ʈ �� VR���� PlayerCellPhone���� ����
    public Kakaotalk messenger;

    protected override void Trigger()
    {
        //1. * *ù��° ���� ui�� �ߴ� ���� �÷��̾� �ڿ� �ι�° ������ �����Ѵ� * *
        //    2. * *���� ģ������ ���� ��ȭ �̺�Ʈ**
        //    -**��ȭ ���� * *

        //    (�߰� ���� )
        
        //3. * *��ȭ �̺�Ʈ�� ������ �繰�Ե��� ��ĥ�� ������ ū �Ҹ��� ����**
        //    4. * *���� ģ���� ���� ��ȭ �̺�Ʈ**
        //    -**��ȭ ���� * *

        //    (�߰� ���� )
        
        //5. * *�߰� ������ �۸�ġ �Ͻ��� �߻�**
        //    -**���� �̹��� * *

        Kakaotalk.Instance.action = LockerEvent;
        Kakaotalk.Instance.AlarmOn(2);
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
        Kakaotalk.Instance.action = Glitch;
        Kakaotalk.Instance.AlarmOn(3);
    }

    private void Glitch()
    {

        // �۸�ġ ������ �� ����
        fittingRoomDoor.Open(0.5f);
    }
}
