public class DefaultFigureSelector : FigureSelector
{
    public readonly FigureType _figureType;

    public DefaultFigureSelector(FigureType figureType)
    {
        _figureType = figureType;
    }

    public override FigureType GetFigureType()
    {
        return _figureType;
    }
}
