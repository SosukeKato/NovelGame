using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/ScenarioDataBase", fileName = "NewScenarioDataBase")]
public class ScenarioDataBase : ScriptableObject
{
    [SerializeField] private ChapterNovelScenario[] _chapters;

    private Dictionary<int, ChapterNovelScenario> _chapterDictionary;

    public void InitDictionary()
    {
        _chapterDictionary = new Dictionary<int, ChapterNovelScenario>();
        foreach (ChapterNovelScenario chapter in _chapters)
        {
            _chapterDictionary[chapter.id] = chapter;
        }
    }
}
