using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    public GameObject jumpscare;  // Assign in Inspector
    public int live = 2;  // Initialize directly
    private bool isReloading = false;  // Prevent multiple reloads
    public AudioClip jumpscareClip;
    public AudioSource AudioSource;

    void Start()
    {
        jumpscare.SetActive(false);
        Time.timeScale = 1f;  // Ensure time runs normally on start
        AudioSource.Stop();
    }

    void Update()
    {
        if (live <= 0 && !isReloading)
        {
            Time.timeScale = 0f;
            // Game over logic here (optional), but do not set Time.timeScale to 0 if you want to reload
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && live > 0 && !isReloading)
        {

            jumpscare.SetActive(true);
            //gameObject.GetComponent<EnemyAI1>().stop();
            AudioSource.PlayOneShot(jumpscareClip);
            StartCoroutine(ReloadScene(2f));  // Start coroutine safely
        }
    }

    IEnumerator ReloadScene(float delay)
    {
        isReloading = true;  // Prevent multiple calls
        yield return new WaitForSecondsRealtime(delay);  // Use WaitForSecondsRealtime to bypass Time.timeScale issues
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
