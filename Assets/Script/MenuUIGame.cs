using UnityEngine;

public class MenuUIGame : MonoBehaviour
{
    public GameObject optioninner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        optioninner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        //chuyen sang scene game
        UnityEngine.SceneManagement.SceneManager.LoadScene("map");
    }
    public void Option()
    {
        optioninner.SetActive(true);
    }
}
