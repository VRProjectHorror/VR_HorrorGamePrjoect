using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// skybox 설정 및 배경 조명을 관리하는 클래스
/// </summary>
public class SkyController : MonoBehaviour
{
    public static SkyController Instance { get; private set; }

    /// <summary>
    /// 천둥 번개 효과 관련 세팅
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

    // 디버그 시 확인을 위해 public 변수로 선언했으나, 이 값은 skyController에서만 건드릴 것임
    public float _SunSize;
    public float _SunSizeConvergence;
    public float _AtmosphereThickness;
    public Color _SkyTint;
    public Color _GroundColor;
    public float _Exposure;

    public Light directionalLightA;

    [Tooltip("천둥 번개 효과 관련 설정")]
    public ThunderSetting thunderSetting;
    public AudioClip thunderSound;

    private AudioSource audioSource;

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

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // skybox 기존 값 복사
        skyboxMat = RenderSettings.skybox;
        print(skyboxMat.name);
        _SunSize = skyboxMat.GetFloat(nameof(_SunSize));
        _SunSizeConvergence = skyboxMat.GetFloat(nameof(_SunSizeConvergence));
        _AtmosphereThickness = skyboxMat.GetFloat(nameof(_AtmosphereThickness));
        _SkyTint = skyboxMat.GetColor(nameof(_SkyTint));
        _GroundColor = skyboxMat.GetColor(nameof(_GroundColor));
        _Exposure = skyboxMat.GetFloat(nameof(_Exposure));

        // Material 복사해서 이번 게임에선 새 메테리얼 쓰도록 만들기
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

    // 쪽지 진행 시 일정 단계만큼 하늘 조정


    public void Thunder()
    {
        StartCoroutine(IEThunder());
    }

    // 번개 치는 효과 - 잠깐 하늘 밝아졌다가 원래 색으로 돌아오기
    IEnumerator IEThunder()
    {
        // 소리 출력
        audioSource.PlayOneShot(thunderSound);

        // 초기화 : 기존 밝기 값 등을 저장
        float initExposure = _Exposure;
        float initIntensity = directionalLightA.intensity;

        // 번개에 맞는 밝기로 올리기
        for (float t = 0.0f; t < thunderSetting.startTime; t += Time.deltaTime)
        {
            Exposure = Mathf.Lerp(initExposure, thunderSetting.exposure, t / thunderSetting.startTime);
            directionalLightA.intensity = Mathf.Lerp(initIntensity, thunderSetting.exposure, t / thunderSetting.startTime);
            yield return 0;
        }
        Exposure = thunderSetting.exposure;
        directionalLightA.intensity = thunderSetting.lightIntensity;

        // 최대 밝기 잠시 유지
        yield return new WaitForSeconds(thunderSetting.maxLightTime);
        
        // 빠른 속도로 원 상태로 돌리기
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
