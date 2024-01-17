using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MedalObjectPool : Singleton<MedalObjectPool>
{
    [SerializeField] private int _defaultCapacity = 100;
    [SerializeField] private GameObject[] _medalPrefabs;
    private MedalSpawnerManager _medalSpawnerManager;
    
    private ObjectPool<GameObject> _pool;
    public ObjectPool<GameObject> Pool => _pool;

    private void Start()
    {
        _pool = new ObjectPool<GameObject>(
            CreatePooledItem, // オブジェクト生成処理
            actionOnGet: target => target.SetActive(true), // オブジェクト取得時処理 
            actionOnRelease: target => target.SetActive(false), // オブジェクト解放処理
            actionOnDestroy: target => Destroy(target), // オブジェクト破棄時処理
            collectionCheck: true,
            defaultCapacity: _defaultCapacity, // 最初のプールのサイズ
            maxSize: 300
        );
    }

    private GameObject CreatePooledItem()
    {
        var spawnerPos = GameObject.FindWithTag("Spawner").GetComponent<Transform>().position;
        var random = Random.Range(0, 2);
        return Instantiate(_medalPrefabs[random], spawnerPos, Quaternion.identity);
    }
}