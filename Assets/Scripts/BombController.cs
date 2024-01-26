using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BombController : Singleton<BombController>
{
    [SerializeField] private Slider _gaugeSlider;
    [SerializeField] private float _gaugeMaxValue = 100;
    [SerializeField] private float _tweenTime = 1;
    [SerializeField] private Explosion _explosion;
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