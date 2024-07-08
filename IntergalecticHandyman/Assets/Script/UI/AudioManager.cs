using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer theMixer;

    [SerializeField] private TMP_Text mastLabel, musicLabel, sfxLabel;
    [SerializeField] private Slider mastSlider, musicSlider, sfxSlider;
    
    private void Start()
    {
        InitialValues();
    }

    private void InitialValues()
    {
        var volume = 0f;
        theMixer.GetFloat("MasterVol", out volume);
        mastSlider.value = volume;
        theMixer.GetFloat("MusicVol", out volume);
        musicSlider.value = volume;
        theMixer.GetFloat("SFXVol", out volume);
        sfxSlider.value = volume;


        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 80).ToString();
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
    }
    

    public void SetMastVol()
    {
        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 80).ToString();

        theMixer.SetFloat("MasterVol", mastSlider.value);

        PlayerPrefs.SetFloat("MasterVol", mastSlider.value);
    }

    public void SetMusicVol()
    {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();

        theMixer.SetFloat("MusicVol", musicSlider.value);

        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }

    public void SetSFXVol()
    {
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();

        theMixer.SetFloat("SFXVol", sfxSlider.value);

        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
}
