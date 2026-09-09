using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; set; }

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
    /// <param name="source"></param>
    /// <param name="bgm"></param>
    public void PlayBGM(AudioSource source, AudioClip bgm)
    {
        source.clip = bgm;
        source.Play();
    }

    /// <summary>
    /// BGMèIóπ
    /// </summary>
    /// <param name="source"></param>
    public void StopBGM(AudioSource source)
    {
        source?.Stop();
    }

    /// <summary>
    /// SEçƒê∂
    /// </summary>
    /// <param name="source"></param>
    /// <param name="se"></param>
    public void PlaySE(AudioSource source, AudioClip se)
    {
        source.PlayOneShot(se);
    }
}
