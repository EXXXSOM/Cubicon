using UnityEngine;

public class Figure : MonoBehaviour
{
    public float Height = 1f;
    private bool _isHit = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isHit)
        {
            _isHit = true;
            GameplayController.Instance.FigureHitPreviousFigure(this);
        }
    }
}
