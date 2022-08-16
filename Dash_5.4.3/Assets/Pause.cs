using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public GameObject Menu;
    public static bool gameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & gameIsPaused == false)
        {
            Menu.SetActive(true);
            gameIsPaused = true;
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) & gameIsPaused == true)
        {
            Menu.SetActive(false);
            gameIsPaused = false;
            Time.timeScale = 1f;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
        Menu.SetActive(false);
    }
    public void Resume()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void quit()
    {
        Application.Quit();
    }
}
