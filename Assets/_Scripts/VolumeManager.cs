using UnityEngine;
using UnityEngine.UI;
public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Slider sliderVolume;
    private float defaultVolume = 0.5f;
    private float sliderValue;

    private void Start()
    {
        sliderVolume.value = PlayerPrefs.GetFloat(KeysPlayerPrefs.KEY_VOLUME_AUDIO, defaultVolume);
        AudioListener.volume = SetAudioListenerVolume();
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat(KeysPlayerPrefs.KEY_VOLUME_AUDIO,sliderValue);
        AudioListener.volume = SetAudioListenerVolume();
    }

    private float SetAudioListenerVolume()
    {
        return sliderVolume.value;
    }
}
