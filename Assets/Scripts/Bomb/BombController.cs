using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BombController : Singleton<BombController>
{
    [SerializeField] private Slider _gaugeSlider;
    [SerializeField] private float _gaugeMaxValue = 100;
    [SerializeField] private float _tweenTime = 1;
    [SerializeField] private Explosion _explosion;
    [Header("ゲージ消費時のシェイクパラメータ")]
    [SerializeField] private float _shakeTime = 1;
    [SerializeField] private float _shakePower = 2;
    [SerializeField] private int _shakeCount = 30;
    [SerializeField] private int _handShakeValue = 1;
    
    private float _bombGauge = 0;

    private void Start()
    {
        _gaugeSlider.maxValue = _gaugeMaxValue;
        _gaugeSlider.value = 0;
    }

    private void UseBombExplosion()
    {
        _explosion.Fire();
        _bombGauge = 0;
        _gaugeSlider.DOValue(0, _tweenTime);
        _gaugeSlider.transform.DOShakePosition(_shakeTime, _shakePower, _shakeCount, _handShakeValue, false, true);
    }

    public void AddBombGauge(int addValue)
    {
        _bombGauge += addValue;
        _gaugeSlider.value = _bombGauge;
        if (_bombGauge >= _gaugeMaxValue)
        {
            UseBombExplosion();
        }
    }
}