using UnityEngine;

public class DebugSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _medal;
    public void Spawn()
    {
        var randomX = Random.Range(-2, 2);
        var randomY = Random.Range(1, 5);
        var randomZ = Random.Range(-2, 2);
        Instantiate(_medal, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
    }
}