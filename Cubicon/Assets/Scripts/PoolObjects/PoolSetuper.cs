using UnityEngine;

public class PoolSetuper : MonoBehaviour
{
    public PoolManager PoolManager;

    private void Awake()
    {
        PoolManager.SetupAndCreatePools(GameModeStarter.CurrentMode.GetPoolInfo);
    }
}
