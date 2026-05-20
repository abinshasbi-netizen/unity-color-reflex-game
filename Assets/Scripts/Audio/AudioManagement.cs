using Unity.VisualScripting;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public static AudioManagement Instance { get; private set; }

    [SerializeField] AudioClip backgroundclip;
    [SerializeField] AudioClip jumpclip;
    [SerializeField] AudioClip hitclip;
    [SerializeField] AudioClip collectclip;
    [SerializeField] AudioClip gameoverclip;
    [SerializeField] AudioClip bonusclip;
    [SerializeField] AudioClip bigdamageclip;

    public GameObject MusicOnIcon;
    public GameObject MusicOffIcon;
    public GameObject SFXOnIcon;
    public GameObject SFXOffIcon;

    AudioSource oneshotSource;
    AudioSource loopSource;
    private void Awake()
    {
        MusicOnIcon.SetActive(true);
        SFXOnIcon.SetActive(true);
        MusicOffIcon.SetActive(false);
        SFXOffIcon.SetActive(false);

        if (Instance != null && Instance != this)
        {

            Destroy(gameObject);

        }

        Instance = this;

        oneshotSource = gameObject.AddComponent<AudioSource>();
        loopSource = gameObject.AddComponent<AudioSource>();

        loopSource.loop = true;
        loopSource.playOnAwake = false;
    }

    public void PlayJump() => oneshotSource.PlayOneShot(jumpclip);
    public void PlayHit() => oneshotSource?.PlayOneShot(hitclip);
    public void PlayCollect() => oneshotSource.PlayOneShot(collectclip);
    public void PlayGameOver() => oneshotSource.PlayOneShot(gameoverclip);
    public void PlayBonus() => oneshotSource.PlayOneShot(bonusclip);
    public void PlayBigHit() => oneshotSource.PlayOneShot(bigdamageclip);
    public void PlayBackgroundMusic()
    {
        if (loopSource.clip == backgroundclip && loopSource.isPlaying)
            return;

        loopSource.clip = backgroundclip;
        loopSource.Play();
    }

    public void StopBackgroundMusic()
    {
        loopSource.Stop();
    }

    public void ToggleMusic()
    {
        loopSource.mute = !loopSource.mute;
        MusicOnIcon.SetActive(!loopSource.mute);
        MusicOffIcon.SetActive(loopSource.mute);
    }

    public void ToggleSFX()
    {
        oneshotSource.mute = !oneshotSource.mute;
        SFXOnIcon.SetActive(!oneshotSource.mute);
        SFXOffIcon.SetActive(oneshotSource.mute);
    }

}
