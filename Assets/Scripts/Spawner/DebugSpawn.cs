using UnityEngine;

public class DebugSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _medal;
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