using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class PushController : MonoBehaviour
{
    [SerializeField] private float _value = -3.5f;
    [SerializeField] private float _time = 1;
    [SerializeField] private float _waitTime = 1f;

    private void Start()
    {
        var token = this.GetCancellationTokenOnDestroy();
        MoveAsync(token).Forget();
    }

    private async UniTaskVoid MoveAsync(CancellationToken token)
    {
        while (true)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_waitTime), cancellationToken: token);
            transform.DOMoveX(_value, _time / 2)
                .SetRelative(true)
                .SetLink(this.gameObject);
            await UniTask.Delay(TimeSpan.FromSeconds(_waitTime), cancellationToken: token);
            transform.DOMoveX(-_value, _time / 2)
                .SetRelative(true)
                .SetLink(this.gameObject);
        }
    }
}