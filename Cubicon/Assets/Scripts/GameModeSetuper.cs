public static class GameModeSetuper
{
    private static bool _modInstalled = false;
    private static SettingsModeBase _currentMode = null;
    private static GameplayController _gameplayController = null;

    public static bool ModInstalled => _modInstalled;
    public static SettingsModeBase CurrentMode => _currentMode;
    public static GameplayController GameplayController => _gameplayController;

    public static void SetupGameModeSettings(SettingsModeBase mode, GameplayController gameplayController)
    {
        if (mode == null) return;

        _gameplayController = gameplayController;
        _currentMode = mode;
        _currentMode.Setup();
        _modInstalled = true;
    }

    public static void PlayMode()
    {
        if (_gameplayController != null && _modInstalled)
            _gameplayController.StartGameMode();
    }

    public static void RestartMode()
    {
        if (_gameplayController != null && _modInstalled)
            _gameplayController.Restart();
    }
}
