using TMPro;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    public static ScenarioManager instance { get; set; }

    [SerializeField, Header("シナリオデータベース")] ScenarioDataBase _scenarioDataBase;
    [SerializeField, Header("シナリオ出力用テキスト")] TextMeshProUGUI _scenarioBox;

    ChapterNovelScenario _currentScenario;
    int _currentCommand = 0;
    int _scenarioMoveAmount = 1;
    bool _isProcessing;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    /// <summary>
    /// ゲーム開始時に対応する章のシナリオを取得
    /// </summary>
    /// <param name="chapter"></param>
    public void StartScenarioScene(int id)
    {
        _currentScenario = _scenarioDataBase.GetChapter(id);
        DisplayScenario();
    }

    /// <summary>
    /// 次のシナリオへ移行
    /// </summary>
    public void NextCommand()
    {
        if (_isProcessing) return;

        _currentCommand += _scenarioMoveAmount;
        DisplayScenario();
    }

    /// <summary>
    /// シナリオ進行度をGameManagerへ譲渡
    /// TitleSceneからScenarioSceneへの移行、ScenarioSceneからBattleSceneへの移行時に使用
    /// </summary>
    public void ScenarioProgressTransfer()
    {

    }

    /// <summary>
    /// InGameから受け取った結果に応じて指定のコマンドへジャンプ
    /// </summary>
    /// <param name="targetCommand"></param>
    public void JumpCommand(int targetCommand)
    {
        _currentCommand = targetCommand;
        DisplayScenario();
    }

    /// <summary>
    /// 現在のシナリオを表示
    /// </summary>
    void DisplayScenario()
    {
        _scenarioBox.text = _currentScenario.scenario[_currentCommand].ScenarioText;
    }

    void ExecuteScenario(Scenario command)
    {

    }
}
