using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ColorController
{
    public class RainbowHSVImage : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _speed;
        [SerializeField] private bool _isUse;
        private AudioSource _audioSource;
        private bool _isAudioEnd;

        private void Start()
        {
            _image.material.SetColor("_Color", Color.white);
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (!_isUse)
            {
                return;
            }
            RainbowLight();
        }

        private void OnDisable()
        {
            _isAudioEnd = false;
        }

        private void RainbowLight()
        {
            Color.RGBToHSV(_image.material.color, out var h, out var s, out var v);
            if (h >= 1)
            {
                h = 0;
            }
            _image.material.SetColor("_Color", Color.HSVToRGB(h + _speed, s, v));
            if (!_isAudioEnd)
            {
                PlayAudioAsync().Forget();
                _isAudioEnd = true;
            }
        }

        private async UniTaskVoid PlayAudioAsync()
        {
            for (var i = 0; i < 6; i++)
            {
                _audioSource.Play();
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
            }
        }
    }
}