using System.Collections.Generic;

public class RandomFigureSelector : FigureSelector
{
    public readonly ChanceRandomer<FigureChanceDropInfo> _chanceRandomer;

    public RandomFigureSelector(List<FigureChanceDropInfo> figureChanceDropInfoList)
    {
        _chanceRandomer = new ChanceRandomer<FigureChanceDropInfo>(figureChanceDropInfoList);
    }

    public override FigureType GetFigureType()
    {
        return _chanceRandomer.RandomByChanceInList().FigureType;
    }
}
