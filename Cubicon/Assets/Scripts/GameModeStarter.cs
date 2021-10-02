public static class GameModeStarter
{
    private static SettingsModeBase _currentMode = null;
    public static SettingsModeBase CurrentMode => _currentMode;

    public static void StartGame(SettingsModeBase mode)
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

    public static void SetupGameModeSettings(SettingsModeBase mode)
    {
        if (mode == null) return;

        _currentMode = mode;
        _currentMode.Setup();
    }

    public static void RestartMode()
    {
        if (_currentMode != null)
            _currentMode.Restart();
    }
}
