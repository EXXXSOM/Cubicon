using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Canvas LoseMenuCanvas;
    public Canvas StartMenuCanvas;
    public Canvas GameplayCanvas;

    private Canvas _currentMenuCanvas;

    private GameplayController _gameplayController;

    private void Awake()
    {
        _currentMenuCanvas = StartMenuCanvas;
        _gameplayController = GameplayController.Instance;
        _gameplayController.OnLoseGame += LoseGame;
    }

    public void StartGame()
    {
        _currentMenuCanvas.enabled = false;
        _currentMenuCanvas = GameplayCanvas;
        GameplayCanvas.enabled = true;

        GameModeSetuper.PlayMode();
    }

    public void RestartGame()
    {
        _currentMenuCanvas.enabled = false;
        _currentMenuCanvas = GameplayCanvas;
        GameplayCanvas.enabled = true;

        GameModeSetuper.RestartMode();
    }

    public void LoseGame()
    {
        _currentMenuCanvas.enabled = false;
        _currentMenuCanvas = LoseMenuCanvas;
        LoseMenuCanvas.enabled = true;
    }
}
