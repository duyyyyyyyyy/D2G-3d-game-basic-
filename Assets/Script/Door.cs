using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject intText;
    public bool interactable, toggle;
    public Animator doorAnim;
    public AudioSource open, close;
    public AudioClip openn, closen;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                if (toggle == true)
                {
                    doorAnim.ResetTrigger("close");
                    doorAnim.SetTrigger("open");
                    open.PlayOneShot(openn);
                    
                }
                if (toggle == false)
                {
                    doorAnim.ResetTrigger("open");
                    doorAnim.SetTrigger("close");
                    close.PlayOneShot(closen);
                }
                intText.SetActive(false);
                interactable = false;
            }
        }
    }
}
