using Lottery;
using UnityEngine;

namespace ColorController
{
    public class FiverLightController : MonoBehaviour
    {
        [SerializeField] private float _fiverLightTime = 2;
        [SerializeField] private float _speed = 1;
        [SerializeField] private ChanceManager _chanceManager;
        [SerializeField] private bool _isFiverLightEnd;
        
        [Header("デバッグ用SerializeField")]
        [SerializeField] private bool _isUse;
        [SerializeField] private float _h;
        [SerializeField] private float _s;
        [SerializeField] private float _v;
        private Light _light;
        private Color _defaultColor;
        private float _time;

        public bool IsFiverLightEnd => _isFiverLightEnd;
        private void Start()
        {
            _light = GetComponent<Light>();
            _defaultColor = _light.color;
        }

        private void Update()
        {
            if (!_chanceManager.IsFiver || !_isUse)
            {
                _time = 0;
                _light.color = _defaultColor;
                _isFiverLightEnd = false;
                return;
            }

            _time += Time.deltaTime;
            RainbowLight();
        }

        private void RainbowLight()
        {
            if (_fiverLightTime <= _time)
            {
                _light.color = _defaultColor;
                _isFiverLightEnd = true;
                return;
            }
            Color.RGBToHSV(_light.color, out _h, out _s, out _v);
            if (_h >= 1)
            {
                _h = 0;
            }
            _light.color = Color.HSVToRGB(_h + _speed, 1, 1);
        }
    }
}