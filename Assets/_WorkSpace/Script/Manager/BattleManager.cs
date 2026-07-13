using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance { get; set; }

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    void Update()
    {

    }

    public void BattleResultTransfer(int battleResult)
    {
        GameManager.instance._gameData.NextCommand = battleResult;
        SceneController.instance.LoadScenario();
    }
}
