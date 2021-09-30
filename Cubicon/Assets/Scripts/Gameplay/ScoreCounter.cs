using UnityEngine;
using System;

public static class ScoreCounter
{
    private static int _bestScore = 0;
    private static int _score = 0;
    public static int BestScore => _bestScore;
    public static int Score => _score;

    public static event Action OnChangeScore;

    public static void AddScore(int score)
    {
        _score += score;
        OnChangeScore?.Invoke();
    }

    public static void SetScore(int score)
    {
        _score = score;
        OnChangeScore?.Invoke();
    }

    public static void Clear()
    {
        _score = 0;
        OnChangeScore = null;
    }
}
