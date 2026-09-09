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
        if (box == null) return;
        if (text == null)
        {
            box.gameObject.SetActive(false);
            return;
        }

        box.gameObject.SetActive(true);
        box.text = text;
    }

    /// <summary>
    /// イメージにキャラクターの見た目を表示
    /// 何も入っていない場合も描画を継続したい場合に使用(背景など)
    /// </summary>
    /// <param name="image"></param>
    /// <param name="imageBox"></param>
    public void DisplayImage(Sprite image, Image imageBox)
    {
        if (imageBox == null || image == null) return;

        imageBox.sprite = image;
    }

    /// <summary>
    /// イメージにキャラクターの見た目を表示
    /// 何も入っていない場合は描画するboxごと見えなくしたい場合に使用(EnemyImageなど)
    /// </summary>
    /// <param name="image"></param>
    /// <param name="imageBox"></param>
    public void DisplayEntityImage(Sprite image, Image imageBox)
    {
        if (imageBox == null) return;
        if (image == null)
        {
            imageBox.gameObject.SetActive(false);
            return;
        }

        float imageWidth = image.textureRect.width;
        float imageHeight = image.textureRect.height;
        imageBox.rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
        imageBox.gameObject.SetActive(true);
        imageBox.sprite = image;
    }

    /// <summary>
    /// UIのゲージを更新する
    /// </summary>
    /// <param name="gauge"></param>
    /// <param name="amount"></param>
    public void UpdateGauge(Image gauge ,int amount)
    {
        gauge.fillAmount = amount;
    }
}
