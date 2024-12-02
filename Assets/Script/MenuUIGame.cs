using UnityEngine;

public class MenuUIGame : MonoBehaviour
{
    [SerializeField]
     GameObject optioninner;
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
        Debug.Log("da vo game");
        UnityEngine.SceneManagement.SceneManager.LoadScene("map");
    }
    public void Option()
    {
        optioninner.SetActive(true);
    }
    public void ExitOption()
    {
        optioninner.SetActive(false);
    }
    public void Exit()
    {
        Debug.Log("da thoat game");
        Application.Quit();
    }
}
