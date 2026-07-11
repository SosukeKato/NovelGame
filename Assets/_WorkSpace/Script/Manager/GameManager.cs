using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set; }

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
    /// シーン切り替え時に他のManagerの参照を取得し、ScenarioManagerにシナリオを譲渡する(譲渡はScenarioDataTransferで実行)
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    public void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {

    }

    /// <summary>
    ///ゲーム開始時に選択した章に対応するシナリオを取得
    /// </summary>
    /// <param name="scenarioIndex">シナリオが入っている場所を参照(GameDataになる可能性あり)</param>
    public void StartGame(int scenarioIndex)
    {

    }

    /// <summary>
    /// シナリオの進行度をGameManagerに譲渡
    /// </summary>
    public void ScenarioProgressTransfer(int scenarioIndex, int commandIndex)
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
    public IEnumerator ScenarioDataTransfer()
    {
        yield return null;

        Debug.Log("1fまって実行");
    }

    /// <summary>
    /// インゲームのリザルトをInGameManagerからGameManagerに譲渡
    /// </summary>
    public void InGameResultTransfer(int resultIndex)
    {

    }
}
