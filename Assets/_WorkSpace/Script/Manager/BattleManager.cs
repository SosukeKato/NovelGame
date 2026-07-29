using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance { get; set; }

    public int CurrentAnalysisLevel => _currentAnalysisLevel;  //BattleScene上のUI実装に使用
    public int CurrentDangerLevel => _currentDangerLevel;      //BattleScene上のUI実装に使用

    [SerializeField] ScenarioDataBase _scenarioDataBase;

    [SerializeField] Image _analysisLevelGauge;
    [SerializeField] Image _dangerLevelGauge;

    ChapterNovelScenario _chapter;
    int _currentAnalysisLevel;
    int _currentDangerLevel;
    int _currentBattleTurn;

    const int PARAMETER_MAX = 100;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    void Update()
    {

    }

    /// <summary>
    /// バトル開始時にチャプターの情報の取得や変数の初期化等を行う
    /// </summary>
    /// <param name="id"></param>
    public void StartBattle(int id)
    {
        _chapter = _scenarioDataBase.GetChapter(id);
        _currentAnalysisLevel = 0;
        _currentDangerLevel = 0;
        _currentBattleTurn = 0;
    }

    /// <summary>
    /// 選択肢を選んだ時に呼ばれる
    /// </summary>
    public void OnSelectOption(bool isAccept)
    {
        BattleData data = _chapter.Battle[_currentBattleTurn];
        bool isCorrect = data.IsAcceptCorrect == isAccept;

        if (isCorrect)
        {
            _currentAnalysisLevel += data.AnalysisUpAmount;
            UIManager.Instance.UpdateGauge(_analysisLevelGauge, _currentAnalysisLevel);
        }
        else
        {
            _currentDangerLevel += data.DangerUpAmount;
            UIManager.Instance.UpdateGauge(_dangerLevelGauge, _currentDangerLevel);
        }

        if (_currentAnalysisLevel >= PARAMETER_MAX) BattleResultTransfer(true);
        else if (_currentDangerLevel >= PARAMETER_MAX) BattleResultTransfer(false);
        else _currentBattleTurn++;
    }

    /// <summary>
    /// バトル結果をGameManagerのStashGameDataへ譲渡
    /// </summary>
    /// <param name="isBattleWin"></param>
    public void BattleResultTransfer(bool isBattleWin)
    {
        if (isBattleWin) GameManager.instance.GameData.NextCommand = GameManager.instance.GameData.CurrentCommand + 1;
        else GameManager.instance.GameData.NextCommand = _chapter.JumpNumber;

        SceneController.instance.LoadScenario();
    }
}
