using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    //[SerializeField] private AudioSource audio;
    [SerializeField] private Slider musicSlider;
    public static float volume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //musicSlider.value = 0.8f;
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }

    }
    public void ChangeVolume()
    {
        AudioListener.volume = musicSlider.value;
    }
    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }

}
