using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_PlayerFollowerChaseStart : MonoBehaviour
{
    public PlayerFollower playerFollower;
    public Transform startPos;
    public float minChaseSpeed = 1.0f;

    // 추격 맨 처음 시작할 때
    [Header("In Chase Start")] 
    public bool isChaseStart = false;
    public LightController broadcastLight;
    public AudioClip chaseStartSound;
    public AudioClip chaseStartBGM;

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
            BGMPlayer.Instance.Change(chaseStartBGM);
            StartCoroutine(IEPlayChaseSound());
        }
    }

    // 뼛소리 여러 번 재생
    IEnumerator IEPlayChaseSound()
    {
        var sfx = SFXPlayer.Instance.GetSFX();
        sfx.spatialBlend = 1.0f;
        // 위치 보정
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

            yield return new WaitForSeconds(0.2f);
        }

        sfx.clip = null;
    }
}
