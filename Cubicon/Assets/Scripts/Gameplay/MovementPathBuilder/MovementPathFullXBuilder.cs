using UnityEngine;

public class MovementPathFullXBuilder : MovementPathBuilder
{
    public override Vector3[] BuildPath(Transform spawnPoint, float rangeMove)
    {
        return new Vector3[] {
            new Vector3(spawnPoint.position.x + rangeMove, spawnPoint.position.y, spawnPoint.position.z),
            new Vector3(spawnPoint.position.x - rangeMove, spawnPoint.position.y, spawnPoint.position.z),
            spawnPoint.position
        };
    }
}
