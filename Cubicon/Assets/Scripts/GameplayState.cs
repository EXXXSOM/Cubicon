using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameplayState
{
    private static float _savedtimeSacle;

    public static void Pause()
    {
        _savedtimeSacle = Time.timeScale;
        Time.timeScale = 0;
    }

    public static void Unpause()
    {
        Time.timeScale = _savedtimeSacle;
    }
}
