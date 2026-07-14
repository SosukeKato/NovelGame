using TMPro;
using UnityEngine;

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

    public void DisplayText(TextMeshProUGUI box,string text)
    {
        box.text = text;
    }
}
