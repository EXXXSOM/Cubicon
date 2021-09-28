using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private Stack<PoolObject> _availableObjects = new Stack<PoolObject>();

    private bool _fixedSize;
    private GameObject _poolObjectPrefab;
    private int _poolSize;
    private string _poolName;
    private Transform _parent;

    public Pool(string poolName, GameObject poolObjectPrefab, int initialCount, bool fixedSize, Transform parent)
    {
        _poolName = poolName;
        _poolObjectPrefab = poolObjectPrefab;
        _poolSize = initialCount;
        _fixedSize = fixedSize;
        _parent = parent;

        for (int index = 0; index < initialCount; index++)
        {
            AddObjectToPool(NewObjectInstance());
        }
    }

    //o(1)
    private void AddObjectToPool(PoolObject poolObject)
    {
        poolObject.gameObject.SetActive(false);
        _availableObjects.Push(poolObject);
        poolObject.IsPooled = true;
    }

    private PoolObject NewObjectInstance()
    {
        GameObject createdGameObject = GameObject.Instantiate(_poolObjectPrefab, _parent);
        PoolObject poolObject = createdGameObject.AddComponent<PoolObject>();
        poolObject.PoolName = _poolName;
        return poolObject;
    }

    //o(1)
    public GameObject NextAvailableObject(Vector3 position, Quaternion rotation)
    {
        PoolObject poolObject = null;
        if (_availableObjects.Count > 0)
        {
            poolObject = _availableObjects.Pop();
        }
        else if (_fixedSize == false)
        {
            //increment size var, this is for info purpose only
            _poolSize++;
            Debug.Log(string.Format("Growing pool {0}. New size: {1}", _poolName, _poolSize));
            //create new object
            poolObject = NewObjectInstance();
        }
        else
        {
            Debug.LogWarning("No object available & cannot grow pool: " + _poolName);
        }

        GameObject result = null;
        if (poolObject != null)
        {
            poolObject.IsPooled = false;
            result = poolObject.gameObject;
            result.SetActive(true);

            result.transform.position = position;
            result.transform.rotation = rotation;
        }

        return result;
    }

    //o(1)
    public void ReturnObjectToPool(PoolObject po)
    {

        if (_poolName.Equals(po.PoolName))
        {

            /* we could have used availableObjStack.Contains(po) to check if this object is in pool.
             * While that would have been more robust, it would have made this method O(n) */
            if (po.IsPooled)
            {
                Debug.LogWarning(po.gameObject.name + " is already in pool. Why are you trying to return it again? Check usage.");
            }
            else
            {
                AddObjectToPool(po);
            }

        }
        else
        {
            Debug.LogError(string.Format("Trying to add object to incorrect pool {0} {1}", po.PoolName, _poolName));
        }
    }
}
