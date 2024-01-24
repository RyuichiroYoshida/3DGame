using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class FiverManager : Singleton<FiverManager>
{
    [SerializeField] private int _fiverTime = 5;
    [SerializeField] private MedalSpawnerManager _medalSpawnerManager;
    [SerializeField] private bool _isFiver = false;
    [SerializeField, Header("フィーバー突入確率(%)")] private int _fiverChance = 10;
    [SerializeField, Header("フィーバー継続確率 == フィーバー突入確率 / this")] private int _fiverContinueChance = 3;

    public bool IsFiver => _isFiver;
    public void FiverCheck()
    {
        if (_isFiver)
        {
            return;
        }
        if (Random.Range(0, 101) <= _fiverChance)
        {
            FiverControllerAsync().Forget();
        }
    }

    private void FiverContinueCheck()
    {
        if (Random.Range(0, 101) <= _fiverContinueChance)
        {
            Debug.Log("ContinueFiver!");
            FiverControllerAsync().Forget();
        }
    }

    private async UniTaskVoid FiverControllerAsync()
    {
        Debug.Log("IsFiver!");
        _isFiver = true;
        await UniTask.Delay(TimeSpan.FromSeconds(_fiverTime));
        _isFiver = false;
        FiverContinueCheck();
    }
}