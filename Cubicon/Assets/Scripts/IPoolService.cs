using UnityEngine;

public interface IPoolService
{
    GameObject GetObjectFromPool(string poolName, Vector3 position, Quaternion rotation);
    void ReturnObjectToPool(GameObject returnedGameObject);
    Pool GetPool(string namePool);
}
