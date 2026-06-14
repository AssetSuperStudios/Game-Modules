using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioChange : MonoBehaviour
{
    [SerializeField] Slider sliderMaster;
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSfx;
    [SerializeField] AudioMixer audiomixerSounds;

    void Awake()
    {
        sliderMaster.onValueChanged.AddListener(value => SetVolume(value, "Volume_Master", "volumeSoundMaster"));
        sliderMusic.onValueChanged.AddListener(value => SetVolume(value, "Volume_Music", "volumeSoundMusic"));
        sliderSfx.onValueChanged.AddListener(value => SetVolume(value, "Volume_SFX", "volumeSoundSfx"));
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("volumeSoundMaster"))
        {
            LoadVolume(sliderMaster, "Volume_Master", "volumeSoundMaster");
        } else
        {
            SetVolume(sliderMaster.value, "Volume_Master", "volumeSoundMaster");
        }
        
        if (PlayerPrefs.HasKey("volumeSoundMusic"))
        {
            LoadVolume(sliderMusic, "Volume_Music", "volumeSoundMusic");
        } else
        {
            SetVolume(sliderMusic.value, "Volume_Music", "volumeSoundMusic");
        }
        
        if (PlayerPrefs.HasKey("volumeSoundSfx"))
        {
            LoadVolume(sliderSfx, "Volume_SFX", "volumeSoundSfx");
        } else
        {
            SetVolume(sliderSfx.value, "Volume_SFX", "volumeSoundSfx");
        }
    }

    void SetVolume(float sliderValue, string audioMixer, string prefString)
    {
        audiomixerSounds.SetFloat(audioMixer, Mathf.Log10(sliderValue) * 20);

        PlayerPrefs.SetFloat(prefString, sliderValue);
    }

    void LoadVolume(Slider slider, string audioString, string keyString)
    {
        slider.value = PlayerPrefs.GetFloat(keyString);
        // possible issue :: Does not trigger the onValueChanged function of the sliders. If it does not, add a manual Set_Volume after this
        // It does
    }
}
