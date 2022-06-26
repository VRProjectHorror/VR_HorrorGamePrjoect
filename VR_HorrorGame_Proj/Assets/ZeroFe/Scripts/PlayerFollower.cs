using System;
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

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

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
        _animator.SetBool("Walking", true);
        isChasing = true;
    }

    public void EndChase()
    {
        _animator.SetBool("Walking", false);
        isChasing = false;
    }

    private void Chase()
    {
        var diff = player.transform.position - transform.position;
        // ����ó�� ������ ���� �̵��ϱ� ������ y������ �������� ����
        diff.y = 0;
        var dir = diff.normalized;
        // �ּ� �ӵ� ����
        float multiplier = diff.magnitude / distanceMultiplier;
        float speed = Mathf.Max(Mathf.Pow(multiplier, 2f) * baseMoveSpeed, baseMoveSpeed);
        transform.position += dir * (speed * Time.deltaTime);
    }
}
