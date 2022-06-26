using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 두 번째 쪽지 - 단상 위
/// </summary>
public class Message_2 : Message
{
    public Light platformSpotLight;
    public Light broadcastRoomLight;
    [Tooltip("검은 형체")]
    public GameObject blackSilhouette;

    public AudioClip lightTurnOffSound;
    public AudioClip lightTurnOnSound;

    protected override void Trigger()
    {
        print("두 번째 쪽지 실행");

        StartCoroutine(IETriggerSequence());
    }

    IEnumerator IETriggerSequence()
    {
        platformSpotLight.enabled = false;
        SFXPlayer.Instance.PlaySpatialSound(platformSpotLight.transform.position, lightTurnOffSound);

        yield return new WaitForSeconds(0.3f);

        broadcastRoomLight.enabled = true;
        SFXPlayer.Instance.PlaySpatialSound(broadcastRoomLight.transform.position, lightTurnOnSound);

        blackSilhouette.SetActive(true);
    }
}
