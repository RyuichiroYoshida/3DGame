using UnityEngine;
using DG.Tweening;
public class PushController : MonoBehaviour
{
    private void Start()
    {
        transform.DOLocalMoveX(-1.5f, 1)
            .SetLoops(-1, LoopType.Yoyo);
    }
    private void Update()
    {

    }
}