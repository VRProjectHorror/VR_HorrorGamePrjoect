using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_PlayerFollowerChaseEnd : MonoBehaviour
{
    public PlayerFollower playerFollower;

    private bool isTriggered = false;

    // 반대편 복도에 도달해서 추격이 끝났을 때
    [Header("In Chase End")] 
    public bool isChaseEnd = false;
    public LockerOpen door;
    public AudioClip doorHitSound;

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered)
        {
            return;
        }
        isTriggered = true;

        playerFollower.isChasing = false;

        if (isChaseEnd)
        {
            playerFollower.EndChase();
            playerFollower.gameObject.SetActive(false);
            BGMPlayer.Instance.Rollback();
            StartCoroutine(IEPlayDoorHitSound());
        }
    }
    
    // 문 두들기는 소리 여러 번 재생
    IEnumerator IEPlayDoorHitSound()
    {
        door.Close();
        yield return new WaitForSeconds(0.7f);

        var sfx = SFXPlayer.Instance.GetSFX();
        sfx.spatialBlend = 1.0f;
        sfx.transform.position = door.transform.position;
        sfx.clip = doorHitSound;
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
