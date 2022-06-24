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
    public void EarnMessage(System.Action endPopupAction)
    {
        gameObject.SetActive(false);
        PopupSystem.Instance.Popup(context, Trigger + endPopupAction);
    }

    protected abstract void Trigger();
}
