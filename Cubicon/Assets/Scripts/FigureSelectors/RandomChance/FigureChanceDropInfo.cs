[System.Serializable]
public class FigureChanceDropInfo : IRandomChance
{
    [UnityEngine.SerializeField] private FigureType _figureType;
    [UnityEngine.SerializeField] private float _chance;

    public FigureType FigureType => _figureType;
    public float GetChance => _chance;

    public FigureChanceDropInfo(FigureType figureType, float chance)
    {
        _figureType = figureType;
        _chance = chance;
    }
}
