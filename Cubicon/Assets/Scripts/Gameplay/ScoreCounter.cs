using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour
{
    private static int _score = 0;
    public static int Score => _score;

    public static event Action OnChangeScore;

    public void AddScore(int score)
    {
        _score += score;
        OnChangeScore?.Invoke();
    }

    public void SetScore(int score)
    {
        _score += score;
        OnChangeScore?.Invoke();
    }

    public void Clear()
    {
        _score = 0;
        OnChangeScore = null;
    }
}
