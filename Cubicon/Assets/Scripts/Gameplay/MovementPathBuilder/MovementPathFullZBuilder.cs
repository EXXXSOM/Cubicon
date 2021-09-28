using UnityEngine;

public class MovementPathFullZBuilder : MovementPathBuilder
{
    public override Vector3[] BuildPath(Transform spawnPoint, float rangeMove)
    {
        return new Vector3[] {
            new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z + rangeMove),
            new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z - rangeMove),
            spawnPoint.position
        };
    }
}
