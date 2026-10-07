using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; set; }

    [SerializeField] AudioSource _bgmSource;
    [SerializeField] AudioSource _seSource;
    [SerializeField, Header("タイトルのBGM")] AudioClip _titleBGM;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
        PlayBGM(_titleBGM);
    }

    /// <summary>
    /// BGM再生
    /// </summary>
    /// <param name="bgm"></param>
    public void PlayBGM(AudioClip bgm)
    {
        if (bgm == null) return;

        _bgmSource.clip = bgm;
        _bgmSource.Play();
    }

    /// <summary>
    /// BGM終了
    /// </summary>
    /// <param name="source"></param>
    public void StopBGM()
    {
        _bgmSource.Stop();
    }

    /// <summary>
    /// SE再生
    /// </summary>
    /// <param name="_seSource"></param>
    /// <param name="se"></param>
    public void PlaySE(AudioClip se)
    {
        if (se == null) return;

        _seSource.PlayOneShot(se);
    }
}
