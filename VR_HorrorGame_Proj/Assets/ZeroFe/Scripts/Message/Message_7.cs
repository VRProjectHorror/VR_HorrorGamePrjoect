using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_7 : Message
{
    public LockerManager[] lockers;

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
