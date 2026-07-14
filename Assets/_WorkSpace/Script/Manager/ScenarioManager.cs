using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    public static ScenarioManager instance { get; set; }

    [SerializeField, Header("シナリオデータベース")] ScenarioDataBase _scenarioDataBase;
    [SerializeField, Header("シナリオ出力用テキスト")] TextMeshProUGUI _scenarioBox;
    [SerializeField, Header("キャラクター立ち絵出力用イメージ")] Image _characterImageBox;

    ChapterNovelScenario _currentChapter;
    int _currentScenario = 0;
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
        _currentChapter = _scenarioDataBase.GetChapter(id);
        ReflectionScenario();
    }

    /// <summary>
    /// 次のシナリオへ移行
    /// </summary>
    public void NextCommand()
    {
        if (_isProcessing) return;

        _currentScenario += _scenarioMoveAmount;
        ReflectionScenario();
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
        _currentScenario = targetCommand;
        ReflectionScenario();
    }

    /// <summary>
    /// 現在のシナリオを表示
    /// </summary>
    void ReflectionScenario()
    {
        UIManager.Instance.DisplayText(_scenarioBox, _currentChapter.scenario[_currentScenario].ScenarioText);
        UIManager.Instance.DisplayCharacterName(_scenarioBox, _currentChapter.scenario[_currentScenario].CharacterName);
        UIManager.Instance.DisplayImage(_currentChapter.scenario[_currentScenario].CharacterImage, _characterImageBox);
    }

    void ExecuteScenario(Scenario command)
    {

    }
}
