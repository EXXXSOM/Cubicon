using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    private static GameplayController _instance;
    public static GameplayController Instance => _instance;

    [SerializeField] private Transform _startPlatform;
    [SerializeField] private MovementController _movementController;
    [SerializeField] private FigureCreator _figureCreator;
    [SerializeField] private CameraController _cameraController;

    private Queue<Rigidbody> _droppedFigureRigidBody = new Queue<Rigidbody>(10);
    private readonly ObjectDropper _objectDropper = new ObjectDropper();
    private GameObject _previousFigure;
    private GameObject _currentFigure;

    private void Awake()
    {
        _instance = this;
        _previousFigure = _startPlatform.gameObject;
    }

    private void Start()
    {
        SetNewFigure();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            DropFigure();
        }
    }

    public void FigureHitPreviousFigure(Figure calledFigure)
    {
        _previousFigure = _currentFigure;
        _cameraController.RaiseCamera(calledFigure.Height);
        SetNewFigure();
    }

    private void DropFigure()
    {
        _movementController.StopMoving();

        Rigidbody rigidbody = _currentFigure.GetComponent<Rigidbody>();
        _objectDropper.DropPhysicObject(rigidbody);
    }

    private void SetNewFigure()
    {
        _currentFigure = _figureCreator.SpawnFigure();
        _movementController.MoveThisObject(_currentFigure.transform);
    }
}
