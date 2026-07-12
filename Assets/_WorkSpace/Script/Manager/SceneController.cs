using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance { get; set; }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += GameManager.instance.OnSceneLoaded;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// ScenarioSceneをロード
    /// </summary>
    public void LoadScenario()
    {
        SceneManager.LoadScene("ScenarioScene");
    }

    /// <summary>
    /// InGameSceneをロード
    /// </summary>
    public void LoadBattle()
    {
        SceneManager.LoadScene("BattleScene");
    }

    /// <summary>
    /// TitleSceneをロード
    /// </summary>
    public void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
