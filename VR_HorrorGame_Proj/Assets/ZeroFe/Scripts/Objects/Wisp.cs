using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾ ���� â������ �ȳ��� �������
/// </summary>
public class Wisp : MonoBehaviour
{
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

    // �÷��̾���� �Ÿ��� ����ؼ� �����Ÿ� ���ϸ� ��ǥ����(���� â���)���� �̵��Ѵ�
    void Update()
    {
        // y�� ������
        currentTime += Time.deltaTime;
        float newY = initPosY + Mathf.Sin(currentTime) * sinAmplitude;
        
        // x�� ������
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

        // ��ġ �缳��
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

        // ũ�� ���̱�
        for (float t = 0.0f; t < 0.2f; t += Time.deltaTime)
        {
            mainLight.range = Mathf.Lerp(arrivedLightRanges.x, startLightRanges.x, t / 0.2f);
            subLight.range = Mathf.Lerp(arrivedLightRanges.y, startLightRanges.y, t / 0.2f);
            yield return 0;
        }

        // ����
        Destroy(gameObject);
    }
}
