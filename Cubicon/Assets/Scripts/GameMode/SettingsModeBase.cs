using System.Collections.Generic;
using UnityEngine;

public abstract class SettingsModeBase : ScriptableObject
{
    [SerializeField] protected PoolInfo[] _poolInfo;
    protected FigureSelector _figureSelector = new DefaultFigureSelector(FigureType.DefaultCube);
    protected MovementPathBuilder[] _movementCameraPathBuilders = { new MovementPathFullXBuilder() };

    public IEnumerable<PoolInfo> GetPoolInfo => _poolInfo;
    public FigureSelector FigureSelector => _figureSelector;
    public MovementPathBuilder[] MovementCameraPathBuilders => _movementCameraPathBuilders;

    public abstract void Setup();
    public abstract void Dispose();
}
