using UnityEngine;
using System;

public class GameplayController : MonoBehaviour
{
    private static GameplayController _instance;

    public static GameplayController Instance => _instance;
    public bool GameStarted => _gameModePlaying;

    [SerializeField] private Transform _loseWall;
    [SerializeField] private Transform _startPlatform;
    [SerializeField] private MovementController _movementController;
    [SerializeField] private FigureCreator _figureCreator;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private ArrowDrawer _arrowDrawer;

    private readonly ObjectDropper _objectDropper = new ObjectDropper();
    private TowerBuilder _towerBuilder;
    private GameObject _previousFigure;
    private GameObject _currentFigure;
    private Figure _currentFigureScript;
    private bool _touchBlocked = false;
    private bool _gameModePlaying = false;
    private SettingsClassicMode _settingsClassicMode;

    public event Action OnLoseGame;

    private void Awake()
    {
        _instance = this;
        if (GameModeSetuper.CurrentMode is SettingsClassicMode gameModeStarter)
        {
            _settingsClassicMode = gameModeStarter;
            _towerBuilder = new TowerBuilder(_settingsClassicMode.CountFigureSimulate);
            _movementController.SetupMovementPathBuilders(_settingsClassicMode.MovementCameraPathBuilders);
        }
        else
        {
            Debug.LogError("Ќастройки режима игры не подход€т! ");
        }

        _previousFigure = _startPlatform.gameObject;
    }

    public void StartGameMode()
    {
        _gameModePlaying = true;
        SetNewCurrentFigure();
    }

    private void Update()
    {
        if (!_gameModePlaying) return;

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && !_touchBlocked)
            {
                DropFigure();
            }
        }

        if (_movementController.CurrentFigureMoving)
        {
            _arrowDrawer.DrawArrow(_currentFigure.transform);
        }
    }

    public void FigureHitPreviousFigure(Figure calledFigure)
    {
        _previousFigure = _currentFigure;
        _cameraController.RaiseCamera(calledFigure.Height, calledFigure.transform);
        _figureCreator.RaiseSpawnPoint(calledFigure.Height);
        _loseWall.transform.position = calledFigure.transform.position;
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
        _movementController.StartMoveThisObject(_currentFigure.transform);
    }

    private void ActivateFigure()
    {
        //Ёффекты
        _arrowDrawer.ActiveArrow();
    }

    public void Restart()
    {
        Debug.Log("Restart!");
        ScoreCounter.Clear();
        _towerBuilder.ResetState();
        _cameraController.ResetState();
        GameplayState.Unpause();
    }

    public void LoseGame()
    {
        Debug.Log("Lose!");
        _gameModePlaying = false;
        _movementController.StopMoving();

        GameplayState.Pause();
        OnLoseGame?.Invoke();
    }
}
