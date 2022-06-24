using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ���������� ������ �����ϴ� Ŭ����
/// �׽�Ʈ ���Ǹ� ���� �� Ŭ�������� ����� ��� ����
/// </summary>
public class MessageManager : MonoBehaviour
{
    public GameObject[] messages;
    // ���� ���õ� ���� ��ġ
    // �������ڸ��� ActiveCurrentMessage()�� ȣ���ؼ� pos�� 0�� �ǵ��� ����� ���� -1�� ����
    public int pos = -1;

    // ����׿�
    public GameObject player;

    private void Start()
    {
        // For Debug
        player = GameObject.Find("Player");

        // ������ ������ �� ��Ȱ��ȭ
        foreach (var message in messages)
        {
            message.SetActive(false);
        }

        ActiveCurrentMessage();
    }

    private void Update()
    {
        // ����� ��� : ���� ���� ��ġ�� ����
        if (Input.GetKeyDown(KeyCode.O))
        {
            TestNextMessage();
        }
    }

    // ���� ���� �ҷ�����
    public void ActiveCurrentMessage()
    {
        Debug.Assert(pos < messages.Length - 1, "Error : Next Message is Invalid");
        // ���� ���� �ҷ�
        messages[++pos].SetActive(true);
    }

#if UNITY_EDITOR
    // ����� ��� : �÷��̾ ���� ���� ��ġ�� �̵�
    public void TestNextMessage()
    {
        // ���� ���� �ҷ�����
        ActiveCurrentMessage();

        // �ش� ���� ��ġ�� �÷��̾� ��ġ �ҷ���
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = messages[pos].transform.position + messages[pos].transform.forward;
        player.GetComponent<CharacterController>().enabled = true;
    }
#endif
}