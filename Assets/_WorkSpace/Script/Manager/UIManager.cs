using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; set; }


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
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
        if (box == null || text == null) return;

        box.text = text;
    }

    /// <summary>
    /// イメージにキャラクターの見た目を表示
    /// </summary>
    /// <param name="image"></param>
    /// <param name="imageBox"></param>
    public void DisplayImage(Sprite image, Image imageBox)
    {
        if (image == null || imageBox == null) return;

        imageBox.sprite = image;
    }
}
