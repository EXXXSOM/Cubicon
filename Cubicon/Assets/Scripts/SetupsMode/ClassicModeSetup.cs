using UnityEngine;

public class ClassicModeSetup : SetupConfig
{
    [SerializeField] private SettingsModeBase _classicModeSettings;
    [SerializeField] private GameplayController _gameplayController;

    public override void OnAwake()
    {
        GameModeSetuper.SetupGameModeSettings(_classicModeSettings, _gameplayController);
    }
}
