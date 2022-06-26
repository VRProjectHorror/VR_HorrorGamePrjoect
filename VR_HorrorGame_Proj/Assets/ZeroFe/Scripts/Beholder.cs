using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 단상 위에서 플레이어를 바라보는 검은 형체
/// 플레이어가 바라보면 서서히 사라진다
/// </summary>
public class Beholder : MonoBehaviour
{
    public Transform lookTransform;

    [SerializeField] private float angleDiffDegree = 10f;
    private float angleDiffCos;

    private bool playerSaw = false;

    public SkinnedMeshRenderer mesh;
    public float fadeOutTime = 3.0f;
    public LockerOpen broadcastDoor;

    private Camera _main;

    private void Awake()
    {
        _main = Camera.main;
        angleDiffCos = -Mathf.Cos(Mathf.Deg2Rad * angleDiffDegree);
    }

    private void Update()
    {
        // 서로 마주보는 각도(cosine) 구하기
        float lookAngleCos = Vector3.Dot(lookTransform.forward, _main.transform.forward);
        // 서로 마주보고 있으면 실행
        // 서로의 시선이 일정 각도 안에 있으면 마주본다고 판정한다 - angleDiffDegree로 각도 결정
        if (!playerSaw && lookAngleCos < angleDiffCos)
        {
            playerSaw = true;
            print("플레이어가 봄");
            StartCoroutine(IEFadeOut());
        }
    }

    // 검은 형체 사라짐
    IEnumerator IEFadeOut()
    {
        // 초기 세팅

        // 번개 치기
        SkyController.Instance.Thunder();
        yield return new WaitForSeconds(2.0f);

        // 한 번 더 번개
        SkyController.Instance.Thunder();
        // 검은 형체만 Fade Out 되도록 Material을 복사
        mesh.material = new Material(mesh.material);
        // Fade Out
        for (float t = 0.0f; t < fadeOutTime; t += Time.deltaTime)
        {
            var color = mesh.material.GetColor("_Color");
            color.a = 1 - t / fadeOutTime;
            mesh.material.SetColor("_Color", color);
            yield return 0;
        }

        Destroy(gameObject);

        // 방송실 문 열림
        broadcastDoor.Open(1f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(lookTransform.position, lookTransform.position + lookTransform.forward * 12);
    }
}
