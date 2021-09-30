using UnityEngine;
using DG.Tweening;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _fullPathTime = 3;
    [Range(1f, 5), SerializeField] private float _rangeMove = 4f;
    [Range(1f, 10f), SerializeField] private float _minSpeed = 1f;
    [Range(1f, 10f), SerializeField] private float _maxSpeed = 2f;

    private Transform _currentTarget;
    private Tween _tween;
    private MovementPathBuilder[] _movementPathBuilders;
    private Vector3[] _currentPath = new Vector3[0];
    private bool _currentFigureMoving = false;

    public bool CurrentFigureMoving => _currentFigureMoving;

    private void Awake()
    {
        if (_minSpeed > _maxSpeed)
        {
            _maxSpeed = _minSpeed + 0.1f;
        }

        _movementPathBuilders = new MovementPathBuilder[2];
        _movementPathBuilders[0] = new MovementPathFullXBuilder();
        _movementPathBuilders[1] = new MovementPathFullZBuilder();
    }

    public void StartMoveThisObject(Transform transformObject)
    {
        _currentTarget = transformObject;
        _currentPath = _movementPathBuilders[0].BuildPath(transformObject, _rangeMove);

        RecalculatePath();
        _currentFigureMoving = true;
    }

    private void RecalculatePath()
    {
        _currentPath = _movementPathBuilders[Random.Range(0, _movementPathBuilders.Length)].BuildPath(_currentTarget, _rangeMove);
        _tween = _currentTarget
            .DOPath(_currentPath, _fullPathTime, PathType.Linear, PathMode.Ignore)
            .SetEase(Ease.Linear)
            .OnComplete(RecalculatePath);

        //Debug.Log("RecalculatePath!");
    }

    public void StopMoving()
    {
        _tween.Pause();
        _currentFigureMoving = false;
    }

    public void SetSpeed(int minSpeed, int maxSpeed)
    {
        _minSpeed = minSpeed;
        _maxSpeed = maxSpeed;
    }
}
