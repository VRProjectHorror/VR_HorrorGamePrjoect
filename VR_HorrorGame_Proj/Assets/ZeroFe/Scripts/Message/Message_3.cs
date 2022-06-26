using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� ��° ����
/// </summary>
public class Message_3 : Message
{
    public Light broadcastLight;
    public AudioClip lightTurnOffSound;
    public AudioClip lightTurnOnSound;
    // ��ü����
    public PlayerFollower playerFollower;
    public LockerOpen broadcastDoor;
    public LockerOpen colliderDoor;

    public float turnOnWaitTime = 2.0f;


    protected override void Trigger()
    {
        print("�� ��° ���� ����");
        StartCoroutine(IETriggerSequence());
    }

    IEnumerator IETriggerSequence()
    {
        broadcastLight.enabled = false;
        var sfx = SFXPlayer.Instance.GetSFX();
        sfx.transform.position = broadcastLight.transform.position;
        sfx.spatialBlend = 1.0f;
        sfx.PlayOneShot(lightTurnOffSound);

        yield return new WaitForSeconds(turnOnWaitTime);

        playerFollower.gameObject.SetActive(true);
        broadcastLight.enabled = true;
        sfx.PlayOneShot(lightTurnOffSound);
        
        broadcastDoor.Open(0.5f);
        colliderDoor.Open(0.5f);
    }
}
