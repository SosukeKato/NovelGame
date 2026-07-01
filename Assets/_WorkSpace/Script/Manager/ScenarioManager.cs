using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    static ScenarioManager instance { get; set; }

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }
}
