using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; set; }

    public void DisplayText(TextMeshProUGUI box,string text)
    {
        box.text = text;
    }
}
