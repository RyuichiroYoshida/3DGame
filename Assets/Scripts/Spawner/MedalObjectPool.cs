using UnityEngine;
using UnityEngine.Pool;

public class MedalObjectPool : Singleton<MedalObjectPool>
{
    [SerializeField, Tooltip("生成するメダルの種類分プレハブを登録")] private GameObject[] _medalPrefabs;
    [SerializeField, Tooltip("生成したメダルを格納したいゲームオブジェクトを登録")] private Transform[] _medalParent;
    private ObjectPool<GameObject> _pool;
    private MedalSpawnerManager _medalSpawnerManager;

    public ObjectPool<GameObject> Pool => _pool;

    private void Start()
    {
        _pool = new ObjectPool<GameObject>(
            CreatePooledItem, // オブジェクト生成処理
            actionOnGet: target => target.SetActive(true), // オブジェクト取得時処理 
            actionOnRelease: target => target.SetActive(false), // オブジェクト解放処理
            actionOnDestroy: target => Destroy(target), // オブジェクト破棄時処理
            collectionCheck: true
        );
    }

    private GameObject CreatePooledItem()
    {
        var spawnerPos = GameObject.FindWithTag("Spawner").GetComponent<Transform>().position;
        var randomSpawnPos = new Vector3(spawnerPos.x, spawnerPos.y, spawnerPos.z + Random.Range(-8, 8));
        var randomMedal = 0;
        if (Random.Range(0, 11) == 1) // TODO 召喚するメダルのランダムロジック作成
        {
            randomMedal = 1;
        }
        return Instantiate(_medalPrefabs[randomMedal], randomSpawnPos, Quaternion.identity, _medalParent[randomMedal]);
    }
}