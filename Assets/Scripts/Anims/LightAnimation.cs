using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnimation : MonoBehaviour
{
    [SerializeField] private float _animationInterval;
    private Light _lightComponent;
    private float _defaultIntensity;

    private void Awake()
    {
        _lightComponent = GetComponent<Light>();
        _defaultIntensity = _lightComponent.intensity;
    }

    private void OnEnable()
    {
        DOTween.KillAll();

        DOTween.Sequence()
            .AppendInterval(2f)
            .Append(_lightComponent.DOIntensity(_defaultIntensity * 0.5f, 0.5f).SetEase(Ease.OutQuint))
            .Append(_lightComponent.DOIntensity(_defaultIntensity * 0.6f, 0.4f).SetEase(Ease.InOutSine))
            .Append(_lightComponent.DOIntensity(_defaultIntensity * 0.8f, 0.1f).SetEase(Ease.InOutSine))
            .Append(_lightComponent.DOIntensity(_defaultIntensity * 0.6f, 0.1f).SetEase(Ease.OutQuint))
            .Append(_lightComponent.DOIntensity(_defaultIntensity, 2f).SetEase(Ease.OutQuint))
            .AppendInterval(_animationInterval)
            .SetLoops(-1);
    }
}
