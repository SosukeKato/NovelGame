using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    public static ScenarioManager instance { get; set; }

    [SerializeField, Header("シナリオデータベース")] ScenarioDataBase _scenarioDataBase;
    [SerializeField, Header("シナリオ出力用テキスト")] TextMeshProUGUI _scenarioBox;
    [SerializeField, Header("キャラクター名出力用テキスト")] TextMeshProUGUI _nameBox;
    [SerializeField, Header("キャラクター立ち絵出力用イメージ")] Image _characterImageBox;
    [SerializeField, Header("エネミー立ち絵出力用イメージ")] Image _enemyImageBox;
    [SerializeField, Header("背景出力用イメージ")] Image _backGroundImageBox;

    ChapterNovelScenario _currentChapter;
    int _currentScenario = 0;
    bool _isProcessing;

    const int SCENARIO_MOVE_AMOUNT = 1;

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

        _currentScenario += SCENARIO_MOVE_AMOUNT;

        if (_currentChapter.Scenario[_currentScenario].MoveSceneNumber == 1) SceneController.instance.LoadTitle();
        if (_currentChapter.Scenario[_currentScenario].MoveSceneNumber == 3) SceneController.instance.LoadBattle();

        ReflectionScenario();
    }

    /// <summary>
    /// シナリオ進行度をGameManagerへ譲渡
    /// TitleSceneからScenarioSceneへの移行、ScenarioSceneからBattleSceneへの移行時に使用
    /// </summary>
    public void ScenarioProgressTransfer()
    {
        GameManager.instance.GameData.CurrentCommand = _currentScenario;
    }

    /// <summary>
    /// InGameから受け取った結果に応じて指定のコマンドへジャンプ
    /// </summary>
    /// <param name="targetCommand"></param>
    public void JumpCommand(int targetCommand)
    {
        _currentChapter = _scenarioDataBase.GetChapter(GameManager.instance.GameData.CurrentChapterID);

        _currentScenario = targetCommand;
        ReflectionScenario();
    }

    /// <summary>
    /// 現在のシナリオを表示
    /// </summary>
    void ReflectionScenario()
    {
        UIManager.Instance.DisplayImage(_currentChapter.Scenario[_currentScenario].BGImage, _backGroundImageBox);
        UIManager.Instance.DisplayEntityImage(_currentChapter.Scenario[_currentScenario].CharacterImage, _characterImageBox);
        UIManager.Instance.DisplayEntityImage(_currentChapter.Scenario[_currentScenario].EnemyImage,_enemyImageBox);
        UIManager.Instance.DisplayText(_nameBox, _currentChapter.Scenario[_currentScenario].CharacterName);
        UIManager.Instance.DisplayText(_scenarioBox, _currentChapter.Scenario[_currentScenario].ScenarioText);
    }
}
