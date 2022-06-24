using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject player;

    // 기본 속도
    public float baseMoveSpeed = 1.0f;
    // 거리에 따른 비례 속도
    public float distanceMultiplier = 3.0f;

    public bool followStart = false;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    private void Chase()
    {
        var diff = player.transform.position - transform.position;
        // 최소 속도 보장
        float multiplier = diff.magnitude / distanceMultiplier;
        float speed = Mathf.Max(Mathf.Pow(multiplier, 2f) * baseMoveSpeed, baseMoveSpeed);
        var dir = diff.normalized;
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
