using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾ �߰��ϴ� ��ü����
/// </summary>
public class PlayerFollower : MonoBehaviour
{
    public GameObject player;

    // �⺻ �ӵ�
    public float baseMoveSpeed = 1.0f;
    // �Ÿ��� ���� ��� �ӵ�
    public float distanceMultiplier = 3.0f;

    public bool isChasing = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (isChasing)
        {
            Chase();
        }
    }

    public void StartChase()
    {

    }

    private void Chase()
    {
        var diff = player.transform.position - transform.position;
        // �ּ� �ӵ� ����
        float multiplier = diff.magnitude / distanceMultiplier;
        float speed = Mathf.Max(Mathf.Pow(multiplier, 2f) * baseMoveSpeed, baseMoveSpeed);
        var dir = diff.normalized;
        transform.Translate(dir * speed * Time.deltaTime);

        // ȸ�� ó��
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
