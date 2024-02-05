using UnityEngine;
using UnityEngine.UI;

namespace ColorController
{
    public class RainbowHSVImage : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _speed;
        [SerializeField] private bool _isUse;
        private Color _defaultColor;

        private void Start()
        {
            _defaultColor = Color.white;
        }

        private void Update()
        {
            if (!_isUse)
            {
                _image.material.SetColor("_Color", _defaultColor);
                return;
            }
            RainbowLight();
        }

        private void RainbowLight()
        {
            Color.RGBToHSV(_image.material.color, out var h, out var s, out var v);
            if (h >= 1)
            {
                h = 0;
            }
            _image.material.SetColor("_Color", Color.HSVToRGB(h + _speed, s, v));
        }
    }
}