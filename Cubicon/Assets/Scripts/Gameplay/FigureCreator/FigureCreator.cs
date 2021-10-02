using System;
using UnityEngine;

public class FigureCreator : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    private readonly DefaultSpawnEffect _defaultSpawnEffect = new DefaultSpawnEffect();
    private const float SPAWN_EFFECT_DURATION = 0.2f;
    private FigureSelector _figureSelector;

    private void Awake()
    {
        _figureSelector = GameModeStarter.CurrentMode.FigureSelector;
    }

    public Figure SpawnFigure(DefaultSpawnEffect spawnEffect, Action callbackSpawn)
    {
        GameObject figure = PoolManager.Instance.GetObjectFromPool(_figureSelector.GetFigureType().ToString(), _spawnPoint.position, _spawnPoint.rotation);
        if (spawnEffect != null)
        {
            spawnEffect.PlaySpawnEffect(figure, callbackSpawn, SPAWN_EFFECT_DURATION);
        }
        else
        {
            _defaultSpawnEffect.PlaySpawnEffect(figure, callbackSpawn, SPAWN_EFFECT_DURATION);
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
