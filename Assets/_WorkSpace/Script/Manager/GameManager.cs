using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance { get; set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// シナリオの進行度をGameManagerに譲渡
    /// ScenarioManagerに移動予定
    /// </summary>
    public void ScenarioProgressTransfer()
    {
        
    }

    /// <summary>
    /// セーブデータとして現在の進行度を譲渡する
    /// </summary>
    public void SaveScenarioProgress()
    {

    }

    /// <summary>
    /// 対応するシナリオをScenarioManagerに譲渡
    /// 引数にGameDataを追加して譲渡予定
    /// </summary>
    void ScenarioDataTransfer()
    {

    }
}
