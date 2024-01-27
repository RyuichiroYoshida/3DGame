using UnityEngine;

public class FiverLightController : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private Light _light;
    private void Update()
    {
        if (FiverManager.Instance.IsFiver == false)
        {
            return;
        }
        Color.RGBToHSV(_light.color, out var h, out var s, out var v);
        if (h >= 360)
        {
            h = 0;
        }
        _light.color = Color.HSVToRGB(h + _speed * Time.deltaTime, s, v);
    }
}