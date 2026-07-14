using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField, Header("ディクショナリ")] ScenarioDataBase _scenarioDataBase;
    [SerializeField, Header("1st")] GameObject _firstUI;
    [SerializeField, Header("2nd")] GameObject _secondUI;
    [SerializeField, Header("3rd")] GameObject _thirdUI;
    [SerializeField, Header("キャラクターの見た目反映用Image")] Image _characterImageBox;
    [SerializeField, Header("キャラクターの説明反映用Text")] TextMeshProUGUI _characterInfomationBox;

    /// <summary>
    /// チャプターセレクトへ移行
    /// </summary>
    /// <param name="before"></param>
    /// <param name="after"></param>
    public void ProceedChapterSelect()
    {
        _firstUI.SetActive(false);
        _secondUI.SetActive(true);
    }
    
    /// <summary>
    /// スタート画面へ移行
    /// </summary>
    /// <param name="before"></param>
    /// <param name="after"></param>
    /// <param name="id"></param>
    public void ProceedWaitStart(int id)
    {
        CharacterData characterData = _scenarioDataBase.GetChapter(id).Character;
        _secondUI.SetActive(false);
        _characterInfomationBox.text = characterData.CharacterInfomation;
        _characterImageBox.sprite = characterData.CharacterIamge;
        _thirdUI.SetActive(true);
    }

    /// <summary>
    /// Chapterを開始する
    /// </summary>
    /// <param name="id"></param>
    public void ProceedScenarioScene(int id)
    {
        GameManager.instance.GameData.CurrentChapterID = id;
        SceneController.instance.LoadScenario();
    }
}
