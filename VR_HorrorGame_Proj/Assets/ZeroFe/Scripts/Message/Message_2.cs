using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� ��° ���� - �ܻ� ��
/// </summary>
public class Message_2 : Message
{
    public Light platformSpotLight;
    public Light broadcastRoomLight;
    [Tooltip("���� ��ü")]
    public GameObject blackSilhouette;

    public AudioClip lightTurnOffSound;
    public AudioClip lightTurnOnSound;

    protected override void Trigger()
    {
        print("�� ��° ���� ����");

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
