using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMenager : MonoBehaviour
{
    public Text timerText;

    bool isGamePaused;
    [SerializeField] GameObject PausePanel;

    // Start is called before the first frame update
    private void Start()
    {
        PausePanel.SetActive(false);
        isGamePaused = false;
    }

    // Update is called once per frame
    public void Update()
    {
      

        if (Input.GetKeyUp(KeyCode.P) && isGamePaused == false)
        {
            PausePanel.SetActive(true);
            OnClickPause(true);
            isGamePaused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        if (Input.GetKeyUp(KeyCode.P) && isGamePaused == true)
        {
            PausePanel.SetActive(false);
            OnClickPause(false);
            isGamePaused = false;
            MouseReset();
        }
    }
   

    public void OnClickPause(bool enablePause)
    {
        if (enablePause) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
    public void OnClickExitGame()
    {
        Application.Quit();
    }

    public void MouseReset()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
