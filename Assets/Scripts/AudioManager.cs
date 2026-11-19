using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioSource; //reference to audioSource

    [SerializeField] AudioClip meow;
    [SerializeField] AudioClip uiClick;
    [SerializeField] AudioClip clueFound;
    [SerializeField] AudioClip gunShot;
    [SerializeField] AudioClip win;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(audioSource == null)
        {
            Debug.LogWarning("No Audio Source was found");
        }
        
    }

    public void PlayClip(AudioClip clip)
    {
        if(clip == null)
        {
            Debug.LogWarning(clip + " is missing an audioClip");
            return;
        }

        audioSource.PlayOneShot(clip);
    }

    public void PlayMeow()
    {
        PlayClip(meow);
    }

    public void PlayUIClick()
    {
        PlayClip(uiClick);
    }

    public void PlayClueFound()
    {
        PlayClip(clueFound);
    }

    public void PlayGunShot()
    {
        PlayClip(gunShot);
    }

    public void PlayWin()
    {
        PlayClip(win);
    }
}
