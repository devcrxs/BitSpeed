using UnityEngine;
public class ChangeBackgroundMusic : MonoBehaviour
{
    public static ChangeBackgroundMusic instance;
    [SerializeField] private bool isMainMenu;
    [SerializeField] private AudioClip audioClipBackgroundMainMenu;
    [SerializeField] private AudioClip audioClipLevel;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        CheckScene();
    }

    private void CheckScene()
    {
        if (isMainMenu)
        {
            BackgroundMainMenu();
            return;
        }
        BackgroundLevel();
    }

    public void BackgroundMainMenu()
    {
        SoundsManager.instance.AudioSource.clip = audioClipBackgroundMainMenu;
        SoundsManager.instance.AudioSource.Play();
    }

    public void BackgroundLevel()
    {
        SoundsManager.instance.AudioSource.clip = audioClipLevel;
        SoundsManager.instance.AudioSource.Play();
    }
}
