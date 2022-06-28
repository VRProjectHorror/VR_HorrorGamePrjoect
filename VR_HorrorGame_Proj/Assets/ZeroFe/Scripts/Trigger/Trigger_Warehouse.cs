using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 자재 창고 방 앞 트리거
// 검은 형체 사라짐
public class Trigger_Warehouse : MonoBehaviour
{
    private bool isTriggered = false;

    public GameObject blackSilhouette;
    public float fadeOutTime = 1.5f;

    public FlashController flash;

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered)
        {
            return;
        }
        isTriggered = true;

        StartCoroutine(IEFadeOut());
    }

    // 검은 형체 사라짐
    IEnumerator IEFadeOut()
    {
        // 초기 세팅
        blackSilhouette.SetActive(true);
        var renderer = blackSilhouette.GetComponentInChildren<Renderer>();
        
        // 사라지는 소리?

        // 검은 형체만 Fade Out 되도록 Material을 복사
        renderer.material = new Material(renderer.material);
        var material = renderer.material;
        // Fade Out
        for (float t = 0.0f; t < fadeOutTime; t += Time.deltaTime)
        {
            var color = material.GetColor("_Color");
            color.a = 1 - t / fadeOutTime;
            material.SetColor("_Color", color);
            yield return 0;
        }

        Destroy(blackSilhouette);

        flash.StartFlash();
    }
}
