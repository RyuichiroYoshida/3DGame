using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(SpawnMedalSelector))]
public class MedalSpawnerManager : MonoBehaviour
{
    [SerializeField] private float _autoSpawnSpan = 5;
    [SerializeField] private bool _isFiver = false;
    [SerializeField] private float _fiverAutoSpawnSpan = 0.1f;
    private SpawnMedalSelector _spawnMedalSelector;


    private void Start()
    {
        TryGetComponent(out _spawnMedalSelector);
        var ct = this.GetCancellationTokenOnDestroy();
        AutoSpawnAsync(ct).Forget();
    }

    private async UniTaskVoid AutoSpawnAsync(CancellationToken ct)
    {
        while (true)
        {
            if (_isFiver)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_fiverAutoSpawnSpan), cancellationToken: ct);
                _spawnMedalSelector.SelectMedal();
                continue;
            }

            await UniTask.Delay(TimeSpan.FromSeconds(_autoSpawnSpan), cancellationToken: ct);
            _spawnMedalSelector.SelectMedal();
        }
    }
}