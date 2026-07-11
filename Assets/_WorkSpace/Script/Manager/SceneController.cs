using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance { get; set; }

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

        SceneManager.sceneLoaded += GameManager.instance.OnSceneLoaded;
    }

    /// <summary>
    /// ScenarioSceneをロード
    /// </summary>
    public void LoadScenario()
    {

    }

    /// <summary>
    /// InGameSceneをロード
    /// </summary>
    public void LoadInGame()
    {

    }

    /// <summary>
    /// TitleSceneをロード
    /// </summary>
    public void LoadTitle()
    {

    }
}
