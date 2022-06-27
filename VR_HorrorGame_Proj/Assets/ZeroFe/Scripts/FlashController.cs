using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour
{
    [SerializeField] private Vector2 flashRanges = new Vector2(1.5f, 0.1f);
    [SerializeField] private Vector2 flashAnimTime = new Vector2(0.15f, 0.05f);
    [SerializeField] private float flashWaitTime = 0.2f;

    private Light _light;
    private AudioSource _audioSource;

    private void Awake()
    {
        _light = GetComponent<Light>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartFlash()
    {
        _light.enabled = true;
        StartCoroutine(nameof(IEFlash));
    }

    IEnumerator IEFlash()
    {
        while (true)
        {
            // π‡±‚ ≥Ù¿Ã±‚
            for (float t = 0.0f; t < flashAnimTime.x; t += Time.deltaTime)
            {
                _light.range = Mathf.Lerp(flashRanges.y, flashRanges.x, t / flashAnimTime.x);
                yield return 0;
            }

            // π‡±‚ ¡Ÿ¿Ã±‚
            for (float t = 0.0f; t < flashAnimTime.y; t += Time.deltaTime)
            {
                _light.range = Mathf.Lerp(flashRanges.x, flashRanges.y, t / 0.2f);
                yield return 0;
            }
            _light.range = flashRanges.y;

            yield return new WaitForSeconds(flashWaitTime);
        }
    }

    public void StopFlash()
    {
        StopAllCoroutines();
    }
}
