using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_PlayerFollowerChaseStart : MonoBehaviour
{
    public PlayerFollower playerFollower;
    public Transform startPos;
    public float minChaseSpeed = 1.0f;

    // �߰� �� ó�� ������ ��
    [Header("In Chase Start")] 
    public bool isChaseStart = false;
    public LightController broadcastLight;
    public AudioClip chaseStartSound;

    private float height = 1.5f;

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered)
        {
            return;
        }
        isTriggered = true;

        playerFollower.transform.position = startPos.position;
        playerFollower.transform.forward = transform.forward;
        playerFollower.baseMoveSpeed = minChaseSpeed;
        playerFollower.isChasing = true;

        if (isChaseStart)
        {
            playerFollower.StartChase();
            broadcastLight.TurnOff();
            StartCoroutine(IEPlayChaseSound());
        }
    }

    // �ļҸ� ���� �� ���
    IEnumerator IEPlayChaseSound()
    {
        var sfx = SFXPlayer.Instance.GetSFX();
        sfx.spatialBlend = 1.0f;
        // ��ġ ����
        sfx.transform.position = playerFollower.transform.position + Vector3.up * height;
        sfx.clip = chaseStartSound;
        sfx.loop = false;

        for (int i = 0; i < 3; i++)
        {
            sfx.Play();
            while (sfx.isPlaying)
            {
                yield return 0;
            }
        }

        sfx.clip = null;
    }
}
