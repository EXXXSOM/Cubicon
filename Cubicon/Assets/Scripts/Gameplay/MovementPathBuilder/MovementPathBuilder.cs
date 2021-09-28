using UnityEngine;

public abstract class MovementPathBuilder
{
    public abstract Vector3[] BuildPath(Transform spawnPoint, float rangeMove);
}
