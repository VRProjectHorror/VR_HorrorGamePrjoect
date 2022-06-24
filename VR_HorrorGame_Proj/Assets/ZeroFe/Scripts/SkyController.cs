using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// skybox ���� �� ��� ������ �����ϴ� Ŭ����
/// </summary>
public class SkyController : MonoBehaviour
{
    public static SkyController Instance { get; private set; }

    /// <summary>
    /// õ�� ���� ȿ�� ���� ����
    /// </summary>
    [System.Serializable]
    public class ThunderSetting
    {
        public float exposure = 1.5f;
        public float lightIntensity = 1.5f;

        public float startTime = 0.5f;
        public float maxLightTime = 0.7f;
        public float endTime = 0.3f;
    }

    [SerializeField] private Color _SkyTintFinal = Color.red;
    [SerializeField] private Color _GroundColorFinal = Color.magenta;

    private Material skyboxMat;

    // ����� �� Ȯ���� ���� public ������ ����������, �� ���� skyController������ �ǵ帱 ����
    public float _SunSize;
    public float _SunSizeConvergence;
    public float _AtmosphereThickness;
    public Color _SkyTint;
    public Color _GroundColor;
    public float _Exposure;

    public Light directionalLightA;

    [Tooltip("õ�� ���� ȿ�� ���� ����")]
    public ThunderSetting thunderSetting;

    public float Exposure
    {
        get => _Exposure;
        set
        {
            _Exposure = value;
            skyboxMat.SetFloat(nameof(_Exposure), _Exposure);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // skybox ���� �� ����
        skyboxMat = RenderSettings.skybox;
        print(skyboxMat.name);
        _SunSize = skyboxMat.GetFloat(nameof(_SunSize));
        _SunSizeConvergence = skyboxMat.GetFloat(nameof(_SunSizeConvergence));
        _AtmosphereThickness = skyboxMat.GetFloat(nameof(_AtmosphereThickness));
        _SkyTint = skyboxMat.GetColor(nameof(_SkyTint));
        _GroundColor = skyboxMat.GetColor(nameof(_GroundColor));
        _Exposure = skyboxMat.GetFloat(nameof(_Exposure));

        // Material �����ؼ� �̹� ���ӿ��� �� ���׸��� ������ �����
        skyboxMat = new Material(skyboxMat);
        skyboxMat.SetFloat(nameof(_SunSize), _SunSize);
        skyboxMat.GetFloat(nameof(_SunSizeConvergence));
        skyboxMat.GetFloat(nameof(_AtmosphereThickness));
        skyboxMat.GetColor(nameof(_SkyTint));
        skyboxMat.GetColor(nameof(_GroundColor));
        skyboxMat.SetFloat(nameof(_Exposure), _Exposure);
        RenderSettings.skybox = skyboxMat;
    }

    // Update is called once per frame
    void Update()
    {
        //float shininess = Mathf.PingPong(Time.time, 1.0f);
        //skyboxMat.SetFloat(nameof(_Exposure), shininess);

        if (Input.GetButtonDown("Jump"))
        {
            Thunder();
        }
    }

    // ���� ���� �� ���� �ܰ踸ŭ �ϴ� ����


    public void Thunder()
    {
        StartCoroutine(IEThunder());
    }

    // ���� ġ�� ȿ�� - ��� �ϴ� ������ٰ� ���� ������ ���ƿ���
    IEnumerator IEThunder()
    {
        // �ʱ�ȭ : ���� ��� �� ���� ����
        float initExposure = _Exposure;
        float initIntensity = directionalLightA.intensity;

        // ������ �´� ���� �ø���
        for (float t = 0.0f; t < thunderSetting.startTime; t += Time.deltaTime)
        {
            Exposure = Mathf.Lerp(initExposure, thunderSetting.exposure, t / thunderSetting.startTime);
            directionalLightA.intensity = Mathf.Lerp(initIntensity, thunderSetting.exposure, t / thunderSetting.startTime);
            yield return 0;
        }
        Exposure = thunderSetting.exposure;
        directionalLightA.intensity = thunderSetting.lightIntensity;

        // �ִ� ��� ��� ����
        yield return new WaitForSeconds(thunderSetting.maxLightTime);
        
        // ���� �ӵ��� �� ���·� ������
        for (float t = 0.0f; t < thunderSetting.endTime; t += Time.deltaTime)
        {
            Exposure = Mathf.Lerp(initExposure, thunderSetting.exposure, t / thunderSetting.endTime);
            directionalLightA.intensity = Mathf.Lerp(initIntensity, thunderSetting.exposure, t / thunderSetting.endTime);
            yield return 0;
        }
        Exposure = initExposure;
        directionalLightA.intensity = initIntensity;
    }
}
