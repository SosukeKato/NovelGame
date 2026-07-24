using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance { get; set; }

    public int CurrentAnalysisLevel => _currentAnalysisLevel;  //BattleScene上のUI実装に使用
    public int CurrentDangerLevel => _currentDangerLevel;      //BattleScene上のUI実装に使用

    ChapterNovelScenario _chapter;
    int _currentAnalysisLevel;
    int _currentDangerLevel;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    void Update()
    {

    }

    public void BattleResultTransfer(bool isBattleWin)
    {
        if (isBattleWin) GameManager.instance.GameData.NextCommand = GameManager.instance.GameData.CurrentCommand++;
        else GameManager.instance.GameData.NextCommand = _chapter.JumpNumber;

        SceneController.instance.LoadScenario();
    }
}
