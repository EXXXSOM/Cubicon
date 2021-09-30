using UnityEngine;

public abstract class GameModeBase : ScriptableObject
{
    [SerializeField] protected PoolInfo[] _poolInfo;

    public abstract void Setup();
    public abstract void Restart();
    public abstract void Dispose();
}
