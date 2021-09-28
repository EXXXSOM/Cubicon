using System.Collections.Generic;
using UnityEngine;

public class FigureCreator : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    
    private void Start()
    {
        
    }

    public GameObject SpawnFigure()
    {
        GameObject figure = PoolManager.Instance.GetObjectFromPool(Figures.DefaultCube.ToString(), _spawnPoint.position, _spawnPoint.rotation);
        return figure;
    }
}
