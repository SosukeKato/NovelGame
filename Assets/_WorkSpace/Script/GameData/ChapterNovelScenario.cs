using UnityEngine;

[System.Serializable]
public class Scenario
{
    public AudioClip BGM;
    public AudioClip SE;
    public Sprite BGImage;
    public Sprite CharacterImage;
    public Sprite EnemyImage;
    public string CharacterName;
    [TextArea(3, 10)] public string ScenarioText;
    public bool StopBGM;
    public int MoveSceneNumber;
}

[System.Serializable]
public class CharacterData
{
    public Sprite CharacterIamge;
    [TextArea(5, 10)] public string CharacterInfomation;
}

[System.Serializable]
public class BattleData
{
    public AudioClip BattleBGM;
    public Sprite BattleEnemyImage;
    public Sprite CharacterImage;
    public Sprite BackGroundImage;
    [TextArea(3, 10)] public string CharacterAction;
    [TextArea(3, 10)] public string AcceptText;
    [TextArea(3, 10)] public string DeclineText;
    public int AnalysisUpAmount;
    public int DangerUpAmount;
    public bool IsAcceptCorrect;
}

[CreateAssetMenu(menuName = "GameData/Scenario", fileName = "NewScenarioData")]
public class ChapterNovelScenario : ScriptableObject
{
    public int ID;
    public int JumpNumber;
    public CharacterData Character;
    public BattleData[] Battle;
    public Scenario[] Scenario;
}
