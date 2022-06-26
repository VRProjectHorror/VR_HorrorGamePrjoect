using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어를 추격하는 인체모형
/// </summary>
public class PlayerFollower : MonoBehaviour
{
    public GameObject player;

    // 기본 속도
    public float baseMoveSpeed = 1.0f;
    // 거리에 따른 비례 속도
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
        // 복도처럼 평평한 곳만 이동하기 때문에 y축으론 움직이지 않음
        diff.y = 0;
        var dir = diff.normalized;
        // 최소 속도 보장
        float multiplier = diff.magnitude / distanceMultiplier;
        float speed = Mathf.Max(Mathf.Pow(multiplier, 2f) * baseMoveSpeed, baseMoveSpeed);
        transform.position += dir * (speed * Time.deltaTime);
    }
}
