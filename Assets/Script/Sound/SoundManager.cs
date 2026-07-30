using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource SFX;

    [SerializeField] private AudioClip bgmMusic;
    public AudioClip cardSummon;
    public AudioClip successProduction;
    public AudioClip successBuy;
    public AudioClip openShop;

    private void Start()
    {
        PlayBGM(bgmMusic);
    }

    public void PlayBGM(AudioClip clip)
    {
        BGM.clip = clip;
        BGM.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }

}
