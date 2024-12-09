using UnityEngine;

public class MenuUiInnerGame : MonoBehaviour
{
    private bool check = false;
    public GameObject menu, option;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OnOffUi();
    }
    void OnOffUi()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            check = !check;//dao true hoac false
            menu.SetActive(check);//active theo check
            Time.timeScale = check ? 0 : 1;//dua theo true hoac false de dung hoac tiep tuc game
            if (check == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                option.SetActive(false);
                //Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

        }
    }
    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitOption()
    {
        option.SetActive(false);
    }
}
