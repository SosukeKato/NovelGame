using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField, Header("1st")] GameObject _firstUI;
    [SerializeField, Header("2nd")] GameObject _secondUI;
    [SerializeField, Header("3rd")] GameObject _thirdUI;

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
        _secondUI.SetActive(false);
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
