using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMoment : MonoBehaviour
{
    public GameObject Pause;
    // Start is called before the first frame update
    void Start()
    {
      Pause.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void PauseOff()
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
}
