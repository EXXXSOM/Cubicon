using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolInfo
{
    public string poolName;
    public GameObject prefab;
    public int poolSize;
    public bool fixedSize;
}

public class PoolManager : MonoBehaviour, IPoolService
{
    public static PoolManager Instance;
    [Header("Editing Pool Info value at runtime has no effect")]
    [SerializeField] private PoolInfo[] _poolInfo;

    //mapping of pool name vs list
    private Dictionary<string, Pool> poolDictionary = new Dictionary<string, Pool>();

    private void Awake()
    {
        Instance = this;
        CheckForDuplicatePoolNames();
        CreatePools();
    }

    public void SetupAndCreatePools(PoolInfo[] poolInfo)
    {
        _poolInfo = poolInfo;
        CheckForDuplicatePoolNames();
        CreatePools();
    }

    public void ClearPools()
    {
        foreach (var pool in poolDictionary.Values)
        {
            pool.Dispose();
        }

        poolDictionary.Clear();
        _poolInfo = null;
    }

    private void CheckForDuplicatePoolNames()
    {
        for (int index = 0; index < _poolInfo.Length; index++)
        {
            string poolName = _poolInfo[index].poolName;
            if (poolName.Length == 0)
            {
                Debug.LogError(string.Format("Pool {0} does not have a name!", index));
            }
            for (int internalIndex = index + 1; internalIndex < _poolInfo.Length; internalIndex++)
            {
                if (poolName.Equals(_poolInfo[internalIndex].poolName))
                {
                    Debug.LogError(string.Format("Pool {0} & {1} have the same name. Assign different names.", index, internalIndex));
                }
            }
        }
    }

    private void CreatePools()
    {
        foreach (PoolInfo currentPoolInfo in _poolInfo)
        {

            Pool pool = new Pool(currentPoolInfo.poolName, currentPoolInfo.prefab,
                                 currentPoolInfo.poolSize, currentPoolInfo.fixedSize, transform);

            poolDictionary[currentPoolInfo.poolName] = pool;
        }
    }


    /* Returns an available object from the pool 
    OR 
    null in case the pool does not have any object available & can grow size is false.
    */
    public GameObject GetObjectFromPool(string poolName, Vector3 position, Quaternion rotation)
    {
        GameObject result = null;

        if (poolDictionary.ContainsKey(poolName))
        {
            Pool pool = poolDictionary[poolName];
            result = pool.NextAvailableObject(position, rotation);
            //scenario when no available object is found in pool
            if (result == null)
            {
                Debug.LogWarning("No object available in pool. Consider setting fixedSize to false.: " + poolName);
            }

        }
        else
        {
            Debug.LogError("Invalid pool name specified: " + poolName);
        }

        return result;
    }

    public void ReturnObjectToPool(GameObject returnedGameObject)
    {
        PoolObject poolObject = returnedGameObject.GetComponent<PoolObject>();
        if (poolObject == null)
        {
            Debug.LogWarning("Specified object is not a pooled instance: " + returnedGameObject.name);
        }
        else
        {
            if (poolDictionary.ContainsKey(poolObject.PoolName))
            {
                Pool pool = poolDictionary[poolObject.PoolName];
                pool.ReturnObjectToPool(poolObject);
            }
            else
            {
                Debug.LogWarning("No pool available with name: " + poolObject.PoolName);
            }
        }
    }

    public Pool GetPool(string namePool)
    {
        Pool pool = null;
        poolDictionary.TryGetValue(namePool, out pool);
        return pool;
    }
}
