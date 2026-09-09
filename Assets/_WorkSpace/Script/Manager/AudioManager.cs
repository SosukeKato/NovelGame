using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; set; }

    [SerializeField] AudioSource _bgmSource;
    [SerializeField] AudioSource _seSource;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }

    /// <summary>
    /// BGMçƒê∂
    /// </summary>
    /// <param name="bgm"></param>
    public void PlayBGM(AudioClip bgm)
    {
        if (bgm == null) return;

        _bgmSource.clip = bgm;
        _bgmSource.Play();
    }

    /// <summary>
    /// BGMèIóπ
    /// </summary>
    /// <param name="source"></param>
    public void StopBGM()
    {
        _bgmSource.Stop();
    }

    /// <summary>
    /// SEçƒê∂
    /// </summary>
    /// <param name="_seSource"></param>
    /// <param name="se"></param>
    public void PlaySE(AudioClip se)
    {
        if (se == null) return;

        _seSource.PlayOneShot(se);
    }
}
