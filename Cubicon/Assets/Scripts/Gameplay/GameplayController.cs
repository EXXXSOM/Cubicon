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
    [SerializeField] private TowerBuilder _towerBuilder;
    [SerializeField] private ArrowDrawer _arrowDrawer;

    private readonly ObjectDropper _objectDropper = new ObjectDropper();
    private GameObject _previousFigure;
    private GameObject _currentFigure;
    private bool _touchBlocked = false;
    private bool _currentFigureMoving = false;

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
        if (Input.touchCount > 0 && !_touchBlocked)
        {
            DropFigure();
        }

        if (_currentFigureMoving)
        {
            _arrowDrawer.DrawArrow(_currentFigure.transform);
        }
    }

    public void FigureHitPreviousFigure(Figure calledFigure)
    {
        _previousFigure = _currentFigure;
        _cameraController.RaiseCamera(calledFigure.Height);
        SetNewFigure();

        _touchBlocked = false;
    }

    private void DropFigure()
    {
        _touchBlocked = true;
        _currentFigureMoving = false;

        _movementController.StopMoving();

        Figure figureScript = _currentFigure.GetComponent<Figure>();
        _objectDropper.DropPhysicObject(figureScript.Rigidbody);
        _towerBuilder.AddFigure(figureScript);
        _arrowDrawer.DisableArrow();
    }

    private void SetNewFigure()
    {
        _currentFigure = _figureCreator.SpawnFigure();
        _movementController.MoveThisObject(_currentFigure.transform);
        _currentFigureMoving = true;
        _arrowDrawer.ActiveArrow();
    }
}
