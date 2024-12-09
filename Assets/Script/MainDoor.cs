using NUnit.Framework;
using UnityEngine;

public class MainDoor : MonoBehaviour
{
    public GameObject intText;
    public bool interactable, isOpen = false;
    public Animator doorAnim;
    public AudioSource open, close;
    public AudioClip openn, closen;

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("MainCamera"))
    //    {
    //        intText.SetActive(true);
    //        interactable = true;
    //    }
    //}
    //void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("MainCamera"))
    //    {
    //        intText.SetActive(false);
    //        interactable = false;
    //    }
    //}
    void Update()
    {
        //if (interactable == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
                
        //    }
        //}
    }
    public void AutoOpenDoor()
    {
        if (isOpen == false)
        {
            isOpen = true;
            doorAnim.ResetTrigger("close");
            doorAnim.SetTrigger("open");
            open.PlayOneShot(openn);

        }
    }
}
