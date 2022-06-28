using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_7 : Message
{
    public LockerManager[] lockers;
    public LockerOpen fittingRoomDoor;
    public LockerOpen fittingRoomEntranceDoor;
    public Trigger_Exit exitTrigger;

    // ����׿�. �׽�Ʈ �� VR���� PlayerCellPhone���� ����
    public PlayerCellPhone messenger;

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

        // �۸�ġ ������ �� ����
        fittingRoomDoor.Open(0.5f);
        fittingRoomEntranceDoor.Open(0.5f);
        exitTrigger.triggable = true;
    }
}
