using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어를 자재 창고방까지 안내할 도깨비불
/// </summary>
public class Wisp : MonoBehaviour
{
    public Transform playerTr;
    public Transform targetTr;
    public float targetDistanceDiff = 3.0f;
    public float moveSpeed = 1.5f;
    public float sinAmplitude = 0.3f;

    private float initPosY;
    private float currentTime = 0.0f;

    [Header("Light Animation")]
    public Vector2 startLightRanges = new Vector2(0.3f, 0.2f);
    public Vector2 normalLightRanges = new Vector2(1.0f, 0.5f);
    public Vector2 arrivedLightRanges = new Vector2(1.5f, 0.7f);
    public float startLightAnimTime = 0.5f;
    public float arrivedLightAnimTime = 1.0f;

    private Light mainLight;
    private Light subLight;

    private bool arrived = false;

    private void Awake()
    {
        mainLight = GetComponent<Light>();
        subLight = transform.GetChild(0).GetComponent<Light>();
    }

    private void Start()
    {
        initPosY = transform.position.y;
        StartCoroutine(IEStartLightAnim());
    }

    // 플레이어와의 거리를 계산해서 일정거리 이하면 목표지점(자재 창고방)까지 이동한다
    void Update()
    {
        // Billboard
        Vector3 to =  playerTr.position - transform.position;
        transform.forward = new Vector3(to.x, 0, to.z).normalized;

        // y축 움직임
        currentTime += Time.deltaTime;
        float newY = initPosY + Mathf.Sin(currentTime) * sinAmplitude;
        
        // x축 움직임
        float newX = transform.position.x;
        if (Mathf.Abs(newX - targetTr.position.x) > targetDistanceDiff)
        {
            newX = transform.position.x + moveSpeed * Time.deltaTime;
        }
        else
        {
            if (!arrived)
            {
                arrived = true;
                StartCoroutine(IEArriveLightAnim());
            }
        }

        // 위치 재설정
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    IEnumerator IEStartLightAnim()
    {
        for (float t = 0.0f; t < startLightAnimTime; t += Time.deltaTime)
        {
            mainLight.range = Mathf.Lerp(startLightRanges.x, normalLightRanges.x, t / startLightAnimTime);
            subLight.range = Mathf.Lerp(startLightRanges.y, normalLightRanges.y, t / startLightAnimTime);
            yield return 0;
        }

        mainLight.range = normalLightRanges.x;
        subLight.range = normalLightRanges.y;
    }

    IEnumerator IEArriveLightAnim()
    {
        for (float t = 0.0f; t < arrivedLightAnimTime; t += Time.deltaTime)
        {
            mainLight.range = Mathf.Lerp(normalLightRanges.x, arrivedLightRanges.x, t / arrivedLightAnimTime);
            subLight.range = Mathf.Lerp(normalLightRanges.y, arrivedLightRanges.y, t / arrivedLightAnimTime);
            yield return 0;
        }

        mainLight.range = arrivedLightRanges.x;
        subLight.range = arrivedLightRanges.y;

        // 크기 줄이기
        for (float t = 0.0f; t < 0.2f; t += Time.deltaTime)
        {
            mainLight.range = Mathf.Lerp(arrivedLightRanges.x, startLightRanges.x, t / 0.2f);
            subLight.range = Mathf.Lerp(arrivedLightRanges.y, startLightRanges.y, t / 0.2f);
            yield return 0;
        }

        // 삭제
        Destroy(gameObject);
    }
}
