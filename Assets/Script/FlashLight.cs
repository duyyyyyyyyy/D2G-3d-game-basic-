using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject light;
    public bool toggle;
    public AudioSource toggleSound;
    public AudioClip flashlighton;
    public AudioClip flashlightoff;

    void Start()
    {
        if (toggle == false)
        {
            light.SetActive(false);
        }
        if (toggle == true)
        {
            light.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            toggle = !toggle;
            //toggleSound.Play();
            if (toggle == false)
            {
                light.SetActive(false);
                toggleSound.PlayOneShot(flashlightoff);
            }
            if (toggle == true)
            {
                light.SetActive(true);
                toggleSound.PlayOneShot(flashlighton);

            }
        }

    }
}
