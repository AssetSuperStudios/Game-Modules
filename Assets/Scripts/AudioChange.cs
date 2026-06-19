using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AudioChange : MonoBehaviour
{
    // Serialized objects
    [SerializeField] Slider sliderMaster;
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSfx;
    [SerializeField] AudioMixer audiomixerSounds;

    // The following are the exposed parameters of the audio mixer
    // "Volume_Master", "Volume_Music", "Volume_SFX"
    // The following are the names of the PlayerPrefs used in this script
    // "volumeSoundMaster", "volumeSoundMusic", "volumeSoundSfx"
    
    void Awake()
    {
        // Adds an on value changed listener to each slider and binds the corresponding function to them
        sliderMaster.onValueChanged.AddListener(value => SetVolume(value, "Volume_Master", "volumeSoundMaster"));
        sliderMusic.onValueChanged.AddListener(value => SetVolume(value, "Volume_Music", "volumeSoundMusic"));
        sliderSfx.onValueChanged.AddListener(value => SetVolume(value, "Volume_SFX", "volumeSoundSfx"));
    }

    void Start()
    {
        // Get the PlayerPrefs for the respective sound value, with a default of 1 or max volume
        // Then set the slider and the volume to the acquired value
        sliderMaster.value = PlayerPrefs.GetFloat("volumeSoundMaster", (float)1);
        SetVolume(sliderMaster.value, "Volume_Master", "volumeSoundMaster");

        sliderMusic.value = PlayerPrefs.GetFloat("volumeSoundMusic", (float)1);
        SetVolume(sliderMusic.value, "Volume_Music", "volumeSoundMusic");

        sliderSfx.value = PlayerPrefs.GetFloat("volumeSoundSfx", (float)1);
        SetVolume(sliderSfx.value, "Volume_SFX", "volumeSoundSfx");
    }

    void SetVolume(float sliderValue, string audioMixer, string prefString)
    {
        // Converts the linear 0.1 to 1 value of the slider to the logarithmic change of the audio (multiplied by 20)
        // Then change the corresponding PlayerPref to the new value
        audiomixerSounds.SetFloat(audioMixer, Mathf.Log10(sliderValue) * 20);

        PlayerPrefs.SetFloat(prefString, sliderValue);
    }

    // Used by Button_Save's OnClick Component
    // Another option, find a way to get an OnPointerUp event listener for sliders then trigger this function with that
    public void ButtonSave() {
        // Permanently saves all changed PlayerPrefs to the registry instead of doing it temporarily
        PlayerPrefs.Save();
    }
}
