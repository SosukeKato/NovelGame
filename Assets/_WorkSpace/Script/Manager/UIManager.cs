using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; set; }

    [SerializeField] ScenarioDataBase _scenarioDataBase;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            _scenarioDataBase.InitDictionary();
        }
        else Destroy(this.gameObject);
    }

    /// <summary>
    /// 画面にテキストを表示
    /// </summary>
    /// <param name="box"></param>
    /// <param name="text"></param>
    public void DisplayText(TextMeshProUGUI box,string text)
    {
        box.text = text;
    }

    /// <summary>
    /// イメージにキャラクターの見た目を表示
    /// </summary>
    /// <param name="character"></param>
    /// <param name="imageBox"></param>
    public void DisplayImage(Sprite character, Image imageBox)
    {
        imageBox.sprite = character;
    }
}
