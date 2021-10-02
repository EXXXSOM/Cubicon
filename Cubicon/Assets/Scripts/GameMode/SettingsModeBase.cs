using UnityEngine;

public abstract class SettingsModeBase : ScriptableObject
{
    [SerializeField] protected PoolInfo[] _poolInfo;
    protected FigureSelector _figureSelector;

    public PoolInfo[] GetPoolInfo => (PoolInfo[])_poolInfo.Clone();
    public FigureSelector FigureSelector => _figureSelector;

    public abstract void Setup();
    public abstract void Restart();
    public abstract void Dispose();
}
