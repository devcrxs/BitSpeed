using UnityEngine;
public class SoundsManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioSource audioSourceText;
    public static SoundsManager instance;
    [SerializeField] private AudioClip audioClipShoot;
    [SerializeField] private AudioClip audioClipHurt;
    [SerializeField] private AudioClip audioClipUI;
    [SerializeField] private AudioClip audioClipInteraction;
    [SerializeField] private AudioClip audioClipGetContract;
    [SerializeField] private AudioClip audioClipTouchGround;

    public AudioSource AudioSource => audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayTextSound()
    {
        if (audioSourceText == null)
        {
            audioSourceText = GameObject.FindWithTag(Constans.TAG_CANVAS_TUTORIAL).GetComponent<AudioSource>();
        }
        audioSourceText.Play();
    }

    public void StopTextSound()
    {
        audioSourceText.Stop();
    }
    public void PlayShootSound()
    {
        audioSource.PlayOneShot(audioClipShoot);
    }

    public void PlayHurtSound()
    {
        audioSource.PlayOneShot(audioClipHurt);
    }

    public void PlayUISound()
    {
        audioSource.PlayOneShot(audioClipUI);
    }

    public void PlayInteractionSound()
    {
        audioSource.PlayOneShot(audioClipInteraction);
    }

    public void PlayGetContract()
    {
        audioSource.PlayOneShot(audioClipGetContract);
    }

    public void PlayTouchGround()
    {
        audioSource.PlayOneShot(audioClipTouchGround);
    }
}
