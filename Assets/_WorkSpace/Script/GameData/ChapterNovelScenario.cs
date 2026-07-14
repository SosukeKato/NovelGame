using UnityEngine;

[System.Serializable]
public class Scenario
{
    public AudioClip BGM;
    public AudioClip SE;
    public Sprite BGImage;
    public Sprite CharacterImage;
    public string CharacterName;
    public string ScenarioText;
    public bool StopBGM;
}

[System.Serializable]
public class CharacterData
{
    public Sprite CharacterIamge;
    public string CharacterInfomation;
}

[CreateAssetMenu(menuName = "GameData/Scenario",fileName = "NewScenarioData")]
public class ChapterNovelScenario : ScriptableObject
{
    public int ID;
    public CharacterData Character;
    public Scenario[] Scenario;
}
