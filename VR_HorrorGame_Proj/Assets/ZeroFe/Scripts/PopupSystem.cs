using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupSystem : MonoBehaviour
{
    public static PopupSystem Instance { get; private set; }

    [SerializeField] private GameObject popup;
    [SerializeField] private TextMeshProUGUI messageText;

    private Action _trigger;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && popup.activeSelf)
        {
            EndPopup();
        }
    }

    public void Popup(string context, Action trigger)
    {
        _trigger = trigger;
        messageText.text = context;
        Invoke(nameof(OpenPopup), 0.5f);
    }

    private void OpenPopup()
    {
        popup.SetActive(true);
    }

    public void EndPopup()
    {
        _trigger?.Invoke();
        popup.SetActive(false);
    }
    
}
