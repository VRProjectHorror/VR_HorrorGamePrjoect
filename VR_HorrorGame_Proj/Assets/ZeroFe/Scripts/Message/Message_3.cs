using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_3 : Message
{
    // ���� ��ü Ȱ��ȭ
    public GameObject black;

    // ������ ���� �� 

    protected override void Trigger()
    {
        print("�� ��° ���� ����");
        black.SetActive(true);
    }
}
