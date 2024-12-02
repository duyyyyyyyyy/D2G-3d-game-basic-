using UnityEngine;

public class pickupFlashLight : MonoBehaviour
{
    public GameObject inttext, flashlight_table, flashlight_hand;
    private GameObject flash;
    public AudioSource pickup;
    public bool interactable;
    private GameObject check;
     void Start()
    {
        interactable = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inttext.SetActive(false);
                interactable = false;
                //pickup.Play();
                flashlight_hand.SetActive(true);
                flashlight_table.SetActive(false);
            }
        }
        if(check == true)
        {
            gameObject.GetComponent<Core>().coree();
        }
        Debug.Log(check);
    }
}
