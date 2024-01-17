using UnityEngine;
using UnityEngine.Pool;

public class SpawnMedal : MonoBehaviour
{
    public void MedalSpawn(ObjectPool<GameObject> objectPool)
    {
        objectPool.Get();
    }
}