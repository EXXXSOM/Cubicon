using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Canvas LoseMenuCanvas;
    public Canvas StartMenuCanvas;
    public Canvas GameplayCanvas;

    public GameModeBase CurrentMode;

    private Canvas _currentMenuCanvas;

    private void Awake()
    {
        _currentMenuCanvas = StartMenuCanvas;
    }

    public void StartGame()
    {
        //GameModeStarter.StartGame(CurrentMode);
        _currentMenuCanvas.enabled = false;

        _currentMenuCanvas = GameplayCanvas;
        GameplayCanvas.enabled = true;
    }

    public void LoseGame()
    {
        _currentMenuCanvas.enabled = false;
        _currentMenuCanvas = LoseMenuCanvas;
        LoseMenuCanvas.enabled = true;
    }
}
