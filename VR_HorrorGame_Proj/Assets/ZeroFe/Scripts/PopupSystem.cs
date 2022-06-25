using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 쪽지 팝업 띄우는 클래스
/// </summary>
public class PopupSystem : MonoBehaviour
{
    public static PopupSystem Instance { get; private set; }

    [SerializeField] private GameObject popup;
    [SerializeField] private TextMeshProUGUI messageText;

    [Header("OpenPopup Animation")] 
    [SerializeField, Tooltip("쪽지 열기 / 닫기 애니메이션 시간")]
    private float animationTime = 0.5f;
    [SerializeField, Tooltip("쪽지 열 때 날아오는 상대적 위치")] 
    private float translateRelativeStartPosY = -100;
    // 쪽지 UI 초기 위치 저장
    private Vector3 popupInitLocalPosition;

    [SerializeField, Tooltip("쪽지 펼 때 소리")] 
    private AudioClip messageOpenSound;
    [SerializeField, Tooltip("쪽지 치울 때 소리")]
    private AudioClip messageCloseSound;

    // 쪽지 UI 보여주고 있는지 저장하는 변수
    // popup.activeSelf는 popup 애니메이션 중일 때 EndPopup이 중복 실행되지 못하는 문제가 있다
    public bool IsShowingPopup { get; private set; } = false;

    private AudioSource audioSource;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();

        canvasGroup = popup.GetComponent<CanvasGroup>();
        popupInitLocalPosition = transform.localPosition;
    }

    public void OpenPopup(string context)
    {
        messageText.text = context;
        IsShowingPopup = true;
        StartCoroutine(IEFadeIn());
    }

    IEnumerator IEFadeIn()
    {
        // 초기 세팅
        popup.SetActive(true);
        Vector3 popupAnimStartPos = popupInitLocalPosition + Vector3.up * translateRelativeStartPosY;
        popup.transform.localPosition = popupAnimStartPos;
        canvasGroup.alpha = 0;

        audioSource.PlayOneShot(messageOpenSound);

        for (float t = 0; t < animationTime; t += Time.deltaTime)
        {
            // 선형 보간 외 다른 방식으로 애니메이션 적용하고 싶다면 ratio 공식만 수정하면 됨
            // 단, ratio에 0 ~ 1 사이 값이 들어가야 한다
            float ratio = t / animationTime;

            popup.transform.localPosition = Vector3.Lerp(popupAnimStartPos, popupInitLocalPosition, ratio);
            canvasGroup.alpha = ratio;
            yield return 0;
        }

        canvasGroup.alpha = 1;
        popup.transform.localPosition = popupInitLocalPosition;
    }

    public void ClosePopup(Action trigger)
    {
        IsShowingPopup = false;
        StartCoroutine(IEFadeOut(trigger));
    }

    IEnumerator IEFadeOut(Action trigger)
    {
        Vector3 popupAnimEndPos = popupInitLocalPosition + Vector3.up * translateRelativeStartPosY;
        popup.transform.localPosition = popupInitLocalPosition;
        canvasGroup.alpha = 1;

        audioSource.PlayOneShot(messageCloseSound);

        for (float t = 0; t < animationTime; t += Time.deltaTime)
        {
            // 선형 보간 외 다른 방식으로 애니메이션 적용하고 싶다면 ratio 공식만 수정하면 됨
            // 단, ratio에 0 ~ 1 사이 값이 들어가야 한다
            float ratio = t / animationTime;

            popup.transform.localPosition = Vector3.Lerp(popupAnimEndPos, popupInitLocalPosition, 1 - ratio);
            canvasGroup.alpha = 1 - ratio;
            yield return 0;
        }

        canvasGroup.alpha = 0;
        popup.transform.localPosition = popupInitLocalPosition;
        popup.SetActive(false);
        trigger?.Invoke();
    }
}
