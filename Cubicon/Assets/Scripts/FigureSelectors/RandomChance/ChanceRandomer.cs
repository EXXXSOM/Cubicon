using System.Collections.Generic;

public class ChanceRandomer<T> where T : IRandomChance
{
    private readonly System.Random _random = new System.Random();
    private List<T> _elemensWithRandomChance;
    private float _total = 0f;
    private float[] _probs;

    public ChanceRandomer(List<T> elemensWithRandomChance)
    {
        _elemensWithRandomChance = elemensWithRandomChance;

        _probs = new float[_elemensWithRandomChance.Count];
        for (int i = 0; i < _probs.Length; i++)
        {
            _probs[i] = _elemensWithRandomChance[i].GetChance;
            _total += _probs[i];
        }
    }

    public T RandomByChanceInList()
    {
        float randomPoint = (float)_random.NextDouble() * _total;

        for (int i = 0; i < _probs.Length; i++)
        {
            if (randomPoint < _probs[i])
            {
                return _elemensWithRandomChance[i];
            }

            randomPoint -= _probs[i];
        }

        return _elemensWithRandomChance[0];
    }
}
