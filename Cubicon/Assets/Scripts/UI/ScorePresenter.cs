using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] private Text _score;
    public Vector3 ScaleScoreEffect;
    public float DurationEffect;
    public int Vibratio = 10;
    public float Elastic = 1;
    public Color ColorEffect;

    private void Awake()
    {
        ScoreCounter.OnChangeScore += OutScore;
    }

    private void OutScore()
    {
        _score.text = ScoreCounter.Score.ToString();
        _score.color = ColorEffect;
        _score.rectTransform.DOPunchScale(ScaleScoreEffect, DurationEffect, Vibratio, Elastic).OnComplete(ClearTextEffect);
    }

    private void ClearTextEffect()
    {
        _score.color = Color.white;
    }
}
