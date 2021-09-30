using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    private Figure _currentFigureScript;
    private bool _touchBlocked = false;

    private void Awake()
    {
        _instance = this;
        _previousFigure = _startPlatform.gameObject;
    }

    private void Start()
    {
        SetNewCurrentFigure();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && !_touchBlocked)
        {
            DropFigure();
        }

        if (_movementController.CurrentFigureMoving)
        {
            _arrowDrawer.DrawArrow(_currentFigure.transform);
        }
    }

    public void FigureHitPreviousFigure(Figure calledFigure)
    {
        _previousFigure = _currentFigure;
        _cameraController.RaiseCamera(calledFigure.Height);
        _figureCreator.RaiseSpawnPoint(calledFigure.Height);
        SetNewCurrentFigure();
        _touchBlocked = false;

        ScoreCounter.AddScore(calledFigure.Score);
    }

    private void DropFigure()
    {
        _touchBlocked = true;
        _movementController.StopMoving();
        _objectDropper.DropPhysicObject(_currentFigureScript.Rigidbody);
        _towerBuilder.AddFigure(_currentFigureScript);

        //Ёффекты
        _arrowDrawer.DisableArrow();
    }

    private void SetNewCurrentFigure()
    {
        _currentFigureScript = _figureCreator.SpawnFigure(new ChangingScaleSpawnEffect(), ActivateFigure);
        _currentFigure = _currentFigureScript.gameObject;
        _currentFigureScript.Prepare();

        _movementController.StartMoveThisObject(_currentFigure.transform); //в SetNewFigure
    }

    private void ActivateFigure()
    {
        //_movementController.StartMoveThisObject(_currentFigure.transform); //в SetNewFigure

        //Ёффекты
        _arrowDrawer.ActiveArrow();
    }

    public void Restart()
    {
        _towerBuilder.ResetState();
        _cameraController.ResetState();
    }
}
