using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private AudioSource musicSource;

    private static Volume instance; // Singleton instance

    void Awake()
    {
        // Nếu đã tồn tại một instance, hủy instance cũ và gán instance mới
        if (instance != null)
        {
            Destroy(instance.gameObject); // Hủy đối tượng cũ
        }

        // Gán instance mới
        instance = this;
        DontDestroyOnLoad(gameObject); // Không phá hủy đối tượng khi chuyển scene
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
        }

        LoadVolume();

        // Lắng nghe thay đổi từ slider
        if (musicSlider != null)
        {
            musicSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
        }

        if (!musicSource.isPlaying)
        {
            musicSource.Play(); // Phát nhạc nếu chưa phát
        }
    }

    public void ChangeVolume()
    {
        if (musicSource != null)
        {
            musicSource.volume = musicSlider.value; // Điều chỉnh volume
        }
        SaveVolume();
    }

    private void LoadVolume()
    {
        if (musicSlider != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
        if (musicSource != null)
        {
            musicSource.volume = musicSlider.value;
        }
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefs.Save(); // Lưu ngay lập tức
    }
}
