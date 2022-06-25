using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �޸� ������ ����, �����ϴ� Ŭ����
/// �߰����� �ൿ ������ �Լ� ���� �����ؼ� ����� ��
/// </summary>
public abstract class Message : MonoBehaviour
{
    [TextArea(3, 3), Tooltip("���� �ȿ� �� ����")]
    public string context;

    // ���� �ִϸ��̼� ���� �� �˾����� ����
    public void OpenMessage()
    {
        gameObject.SetActive(false);
        PopupSystem.Instance.OpenPopup(context);
    }

    // �˾� �ݱ�
    public void CloseMessage()
    {
        PopupSystem.Instance.ClosePopup(Trigger);
    }

    protected abstract void Trigger();
}
