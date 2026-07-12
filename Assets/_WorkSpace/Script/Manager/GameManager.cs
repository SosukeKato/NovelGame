using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    public int CurrentChapterID;
    public int CurrentScenario;
    public int CurrentCommand;
    public int NextCommand;
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set; }

    public GameData _gameData = new();

    [SerializeField] ScenarioDataBase _scenarioDataBase;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            _scenarioDataBase.InitDictionary();
        }
        else Destroy(this.gameObject);
    }

    /// <summary>
    /// シーン切り替え時に他のManagerの参照を取得し、ScenarioManagerにシナリオを譲渡する(譲渡はScenarioDataTransferで実行)
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "ScenarioScene")
            ScenarioDataTransfer();
    }

    /// <summary>
    /// 対応するシナリオをScenarioManagerに譲渡
    /// 引数にGameDataを追加して譲渡予定
    /// </summary>
    public void ScenarioDataTransfer()
    {
        if (_gameData.NextCommand != 0)
        {
            ScenarioManager.instance.JumpCommand(_gameData.NextCommand);
            _gameData.NextCommand = 0;
        }
        else ScenarioManager.instance.StartScenarioScene(_gameData.CurrentChapterID);
    }

    /// <summary>
    /// インゲームのリザルトをInGameManagerからGameManagerに譲渡
    /// </summary>
    public void InGameResultTransfer(int battleResult)
    {
        _gameData.NextCommand = battleResult;
    }
}
