using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsClassicMode", menuName = "ModeSettings/SettingsClassicMode", order = 1)]
public class SettingsClassicMode : SettingsModeBase
{
    [Header("Настройки режима:")]
    [SerializeField] private int _countFigureSimulate = 5;

    public int CountFigureSimulate => _countFigureSimulate;
    [SerializeField] protected List<FigureChanceDropInfo> _figuresChanceDropInfo;

    public override void Setup()
    {
        _figureSelector = new DefaultFigureSelector(FigureType.DefaultCube);

        _movementCameraPathBuilders = new MovementPathBuilder[2];
        _movementCameraPathBuilders[0] = new MovementPathFullXBuilder();
        _movementCameraPathBuilders[1] = new MovementPathFullZBuilder();
    }

    public override void Dispose()
    {

    }

    public virtual FigureType[] RetunrUsedFigures()
    {
        FigureType[] usedFigures = new FigureType[_poolInfo.Length];
        for (int i = 0; i < _poolInfo.Length; i++)
        {
            usedFigures[i] = (FigureType)Enum.Parse(typeof(FigureType), _poolInfo[i].poolName);
        }
        return usedFigures;
    }

    enum State
    {
        Playing,
        BonusPlaying,
        Lose
    }
}
