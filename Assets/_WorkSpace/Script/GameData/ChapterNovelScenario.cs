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

[CreateAssetMenu(menuName = "GameData/Scenario",fileName = "NewScenarioData")]
public class ChapterNovelScenario : ScriptableObject
{
    public int id;
    public Scenario[] scenario;
}
