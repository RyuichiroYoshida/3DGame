using UnityEngine;

public class TitleSkyBoxController : MonoBehaviour
{
    [SerializeField] private float _anglePerFrame = 0.1f;
    private float _rotationValue;
    private void Update()
    {
        _rotationValue += _anglePerFrame;
        RenderSettings.skybox.SetFloat("_Rotation", _rotationValue);
    }
}