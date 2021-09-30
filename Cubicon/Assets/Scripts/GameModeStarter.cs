using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameModeStarter
{
    private static GameModeBase _currentMode = null;

    public static void StartGame(GameModeBase mode)
    {
        if (_currentMode != null)
            mode.Dispose();

        if (_currentMode == mode)
        {
            mode.Restart();
        }
        else
        {
            _currentMode = mode;
            mode.Setup();
        }
    }

    public static void RestartMode()
    {
        if (_currentMode != null)
            _currentMode.Restart();
    }
}
