using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class MedalSpawnerManager : MonoBehaviour
{
    [SerializeField] private float _autoSpawnSpan = 5;
    [SerializeField] private float _fiverAutoSpawnSpan = 0.1f;
    [SerializeField] private SpawnMedal _spawnMedal;
    
    private void Start()
    {
        var ct = this.GetCancellationTokenOnDestroy();
        AutoSpawnAsync(ct).Forget();
    }

    private async UniTaskVoid AutoSpawnAsync(CancellationToken ct)
    {
        while (true)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_autoSpawnSpan), cancellationToken: ct);
            _spawnMedal.MedalSpawn(MedalObjectPool.Instance.Pool);
        }
    }
}