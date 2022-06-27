using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� â�� �� �� Ʈ����
// ���� ��ü �����
public class Trigger_Warehouse : MonoBehaviour
{
    private bool isTriggered = false;

    public GameObject blackSilhouette;
    public float fadeOutTime = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered)
        {
            return;
        }
        isTriggered = true;

        StartCoroutine(IEFadeOut());
    }

    // ���� ��ü �����
    IEnumerator IEFadeOut()
    {
        // �ʱ� ����
        blackSilhouette.SetActive(false);
        var renderer = blackSilhouette.GetComponentInChildren<Renderer>();
        
        // ������� �Ҹ�?

        // ���� ��ü�� Fade Out �ǵ��� Material�� ����
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

        Destroy(gameObject);
    }
}
