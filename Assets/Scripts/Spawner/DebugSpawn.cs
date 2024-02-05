using UnityEngine;

public class DebugSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _medal;

    private void Start()
    {
    }

    public void CheckPool()
    {
        var pool = MedalObjectPool.Instance.Pool;
        Debug.Log($"プールの合計枚数 {pool.CountAll}");
        Debug.Log($"未返却枚数 {pool.CountActive}");
        Debug.Log($"利用可能枚数 {pool.CountInactive}");
    }
    public void Spawn()
    {
        var pos = this.transform.position;
        var randomZ = Random.Range(-8, 8);
        Instantiate(_medal, new Vector3(pos.x, pos.y, pos.z + randomZ), Quaternion.identity);
    }
    public void SuperSpawn(float count)
    {
        for (int i = 0; i < count; i++)
        {
            Spawn();
        }
    }
}