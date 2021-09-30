using UnityEngine;

[CreateAssetMenu(fileName = "GameClassicMode", menuName = "Modes/GameClassicMode", order = 1)]
public class GameClassicMode : GameModeBase
{
    public override void Setup()
    {
        PoolManager.Instance.SetupAndCreatePools(_poolInfo);
    }

    public override void Restart()
    {

    }

    public override void Dispose()
    {

    }
}
