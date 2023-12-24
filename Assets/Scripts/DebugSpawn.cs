using UnityEngine;

public class DebugSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _medal;
    public void Spawn()
    {
        var randomX = Random.Range(-4, 4);
        var randomY = Random.Range(1, 5);
        var randomZ = Random.Range(-4, 4);
        Instantiate(_medal, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
    }
    public void SuperSpawn(float count)
    {
        for (int i = 0; i < count; i++)
        {
            var randomX = Random.Range(-4, 4);
            var randomY = Random.Range(1, 5);
            var randomZ = Random.Range(-4, 4);
            Instantiate(_medal, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
        }
    }
}