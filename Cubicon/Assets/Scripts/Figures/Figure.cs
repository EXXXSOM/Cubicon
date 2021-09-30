using UnityEngine;

public class Figure : MonoBehaviour
{
    public int Score = 1;
    public float Height = 1f;
    private bool _isHit = false;

    [SerializeField] private Rigidbody _rigidBody;
    public Rigidbody Rigidbody => _rigidBody;

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isHit)
        {
            _isHit = true;
            GameplayController.Instance.FigureHitPreviousFigure(this);
        }
    }

    public void Prepare()
    {
        _isHit = false;
    }
}
