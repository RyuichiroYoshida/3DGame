using UnityEngine;
using DG.Tweening;
public class PushController : MonoBehaviour
{
    [SerializeField] private float _value = -3.5f;
    [SerializeField] private float _time = 1;
    private void Start()
    {
        transform.DOMoveX(_value, _time)
            .SetRelative(true)
            .SetLink(this.gameObject)
            .SetLoops(-1, LoopType.Yoyo);
    }
}