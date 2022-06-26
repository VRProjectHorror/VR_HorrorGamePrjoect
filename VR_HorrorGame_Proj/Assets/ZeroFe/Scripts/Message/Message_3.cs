using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 세 번째 쪽지
/// </summary>
public class Message_3 : Message
{
    public Light broadcastLight;
    public AudioClip lightTurnOffSound;
    public AudioClip lightTurnOnSound;
    // 인체모형
    public PlayerFollower playerFollower;
    public LockerOpen broadcastDoor;
    public LockerOpen colliderDoor;

    public float turnOnWaitTime = 2.0f;


    protected override void Trigger()
    {
        print("세 번째 쪽지 실행");
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
