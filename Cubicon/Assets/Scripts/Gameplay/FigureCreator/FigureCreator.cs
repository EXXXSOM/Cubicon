using UnityEngine;
using System;

public class FigureCreator : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    
    public Figure SpawnFigure(DefaultSpawnEffect defaultSpawnEffect, Action callbackSpawn)
    {
        GameObject figure = PoolManager.Instance.GetObjectFromPool(Figures.DefaultCube.ToString(), _spawnPoint.position, _spawnPoint.rotation);
        if (defaultSpawnEffect != null)
        {
            defaultSpawnEffect.PlaySpawnEffect(figure, callbackSpawn, 0.2f);
        }
        else
        {
            callbackSpawn.Invoke();
        }

        return figure.GetComponent<Figure>();
    }

    public void RaiseSpawnPoint(float heightSize)
    {
        Vector3 newPosition = _spawnPoint.position;
        newPosition.y += heightSize;
        _spawnPoint.position = newPosition;
    }
}
