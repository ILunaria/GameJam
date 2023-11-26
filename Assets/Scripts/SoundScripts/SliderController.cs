using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSFX;

    private string masterVolumePlayerPrefsKey = "MasterVolume";
    private string musicVolumePlayerPrefsKey = "MusicVolume";
    private string sfxVolumePlayerPrefsKey = "SFXVolume";

    private void Start()
    {

        float masterSavedVolume = PlayerPrefs.GetFloat(masterVolumePlayerPrefsKey, sliderMaster.value);
        float musicSavedVolume = PlayerPrefs.GetFloat(musicVolumePlayerPrefsKey, sliderMusic.value);
        float sfxSavedVolume = PlayerPrefs.GetFloat(sfxVolumePlayerPrefsKey, sliderSFX.value);

        SetMasterVolume(masterSavedVolume);
        SetMusicVolume(musicSavedVolume);
        SetSFXVolume(sfxSavedVolume);
    }
    void Awake()
    {

        sliderMaster.onValueChanged.AddListener(SetMasterVolume);
        sliderMusic.onValueChanged.AddListener(SetMusicVolume);
        sliderSFX.onValueChanged.AddListener(SetSFXVolume);

        float masterSavedVolume = PlayerPrefs.GetFloat(masterVolumePlayerPrefsKey, sliderMaster.value);
        float musicSavedVolume = PlayerPrefs.GetFloat (musicVolumePlayerPrefsKey, sliderMusic.value);
        float sfxSavedVolume = PlayerPrefs.GetFloat(sfxVolumePlayerPrefsKey, sliderSFX.value);

        sliderMaster.value = masterSavedVolume;
        sliderMusic.value = musicSavedVolume;
        sliderSFX.value = sfxSavedVolume;
    }
    void SetMasterVolume(float value)
    {
        audioManager.ChangeMasterVolume(value);

        PlayerPrefs.SetFloat(masterVolumePlayerPrefsKey,value);
        PlayerPrefs.Save();
    }
    void SetMusicVolume(float value)
    {
        audioManager.ChangeMusicVolume(value);

        PlayerPrefs.SetFloat(musicVolumePlayerPrefsKey, value);
        PlayerPrefs.Save();
    }
    void SetSFXVolume(float value)
    {
        audioManager.ChangeSFXVolume(value);

        PlayerPrefs.SetFloat(sfxVolumePlayerPrefsKey, value);
        PlayerPrefs.Save();
    }

}
