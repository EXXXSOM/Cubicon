using UnityEngine;

public class ClassicModeSetup : SetupConfig
{
    [SerializeField] private SettingsModeBase _classicModeSettings;

    public override void OnAwake()
    {
        GameModeStarter.SetupGameModeSettings(_classicModeSettings);
    }
}
