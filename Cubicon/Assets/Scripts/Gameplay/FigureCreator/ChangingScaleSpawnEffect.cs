using UnityEngine;
using DG.Tweening;
using System;

public class ChangingScaleSpawnEffect : DefaultSpawnEffect
{
    public override void PlaySpawnEffect(GameObject spawnedObject, Action callbackSpawnEffect, float durationEffect = 1)
    {
        spawnedObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        spawnedObject.transform.DOScale(new Vector3(1, 1, 1), durationEffect).OnComplete(new TweenCallback(callbackSpawnEffect));
    }
}
