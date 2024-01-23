using Cysharp.Threading.Tasks;
using UnityEngine;

public class FiverManager : Singleton<FiverManager>
{
    [SerializeField, Header("フィーバー突入確率(%)")] private int _fiverChance = 10;
    [SerializeField, Header("フィーバー突入確率 / this")] private int _fiverContinueChance = 3;
    [SerializeField] private int _fiverTime = 5;
    [SerializeField] private MedalSpawnerManager _medalSpawnerManager;

    public void FiverCheck()
    {
        if (Random.Range(0, 101) <= _fiverChance)
        {
            FiverControllerAsync().Forget();
        }
    }

    // TODO フィーバー継続抽選ロジック
    private async UniTaskVoid FiverControllerAsync()
    {
        _medalSpawnerManager.IsFiver = true;
        await UniTask.Delay(_fiverTime);
        _medalSpawnerManager.IsFiver = false;
    }
}