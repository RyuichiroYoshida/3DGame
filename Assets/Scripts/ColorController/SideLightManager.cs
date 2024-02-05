using Lottery;
using UnityEngine;

namespace ColorController
{
    public class SideLightManager : MonoBehaviour
    {
        [SerializeField] private ChanceManager _chanceManager;
        [SerializeField] private FiverLightController _fiverLightController;
        [SerializeField] private float _speed = 0.1f;
        [SerializeField] private bool _isUse;
        private Light _light;
        private Color _defaultColor;

        private void Start()
        {
            _light = GetComponent<Light>();
            _defaultColor = _light.color;
            _light.enabled = false;
        }

        private void Update()
        {
            if (!_fiverLightController.IsFiverLightEnd || !_chanceManager.IsFiver || !_isUse)
            {
                _light.enabled = false;
                _light.color = _defaultColor;
                return;
            }
            RainbowLight();
        }

        private void RainbowLight()
        {
            _light.enabled = true;
            Color.RGBToHSV(_light.color, out var h, out var s, out var v);
            if (v <= 0)
            {
                v = 1;
            }
            _light.color = Color.HSVToRGB(0.15f, 1f, v - _speed);
        }
    }
}