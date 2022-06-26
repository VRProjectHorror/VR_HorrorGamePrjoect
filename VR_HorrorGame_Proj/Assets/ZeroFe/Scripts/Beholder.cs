using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ܻ� ������ �÷��̾ �ٶ󺸴� ���� ��ü
/// �÷��̾ �ٶ󺸸� ������ �������
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
        // ���� ���ֺ��� ����(cosine) ���ϱ�
        float lookAngleCos = Vector3.Dot(lookTransform.forward, _main.transform.forward);
        // ���� ���ֺ��� ������ ����
        // ������ �ü��� ���� ���� �ȿ� ������ ���ֺ��ٰ� �����Ѵ� - angleDiffDegree�� ���� ����
        if (!playerSaw && lookAngleCos < angleDiffCos)
        {
            playerSaw = true;
            print("�÷��̾ ��");
            StartCoroutine(IEFadeOut());
        }
    }

    // ���� ��ü �����
    IEnumerator IEFadeOut()
    {
        // �ʱ� ����

        // ���� ġ��
        SkyController.Instance.Thunder();
        yield return new WaitForSeconds(2.0f);

        // �� �� �� ����
        SkyController.Instance.Thunder();
        // ���� ��ü�� Fade Out �ǵ��� Material�� ����
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

        // ��۽� �� ����
        broadcastDoor.Open(1f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(lookTransform.position, lookTransform.position + lookTransform.forward * 12);
    }
}
