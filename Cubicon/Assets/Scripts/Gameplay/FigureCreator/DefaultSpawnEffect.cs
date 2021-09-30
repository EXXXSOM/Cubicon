using UnityEngine;
using System;

public abstract class DefaultSpawnEffect
{
    public abstract void PlaySpawnEffect(GameObject spawnedObject, Action callbackSpawn, float durationEffect = 1);
}
