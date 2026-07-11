using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/ScenarioDataBase", fileName = "NewScenarioDataBase")]
public class ScenarioDataBase : ScriptableObject
{
    [SerializeField] private ChapterNovelScenario[] _chapters;

    private Dictionary<int, ChapterNovelScenario> _chapterDictionary;

    /// <summary>
    /// ChapterDictionary‰Šú‰»ˆ—
    /// </summary>
    public void InitDictionary()
    {
        _chapterDictionary = new Dictionary<int, ChapterNovelScenario>();
        foreach (ChapterNovelScenario chapter in _chapters)
        {
            _chapterDictionary[chapter.id] = chapter;
        }
    }

    /// <summary>
    /// w’è‚µ‚½ID‚ÌChapter‚ğæ“¾
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ChapterNovelScenario GetChapter(int id)
    {
        return _chapterDictionary.TryGetValue(id, out ChapterNovelScenario chapter) ? chapter : null;
    }
}
