using UnityEngine;

public class FiverLightController : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [Header("Debug")]
    [SerializeField] private bool _isUse;
    [SerializeField] private float _h;
    [SerializeField] private float _s;
    [SerializeField] private float _v;
    private Light _light;
    private Color _defaultColor;
    private void Start()
    {
        _light = GetComponent<Light>();
        _defaultColor = _light.color;
    }

    private void Update()
    {
        if (FiverManager.Instance.IsFiver == false || !_isUse)
        {
            _light.color = _defaultColor;
            return;
        }
        RainbowLight();
    }

    private void RainbowLight()
    {
        Color.RGBToHSV(_light.color, out _h, out _s, out _v);
        if (_h >= 360)
        {
            _h = 0;
        }
        _s = 200;
        _light.color = Color.HSVToRGB(_h + _speed * Time.deltaTime, _s, _v);
    }
}