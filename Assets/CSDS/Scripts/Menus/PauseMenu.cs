using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject MenuCanvas;

    //private TMP_Button resume;

    public static bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        MenuCanvas.GetComponent<CanvasGroup>().alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ScoreScreenScript.menuIsEnabled) {
            
            if (Input.GetKeyDown(KeyCode.Escape) && !paused) 
            {
                ShowPauseMenu();
            } else if (Input.GetKeyDown(KeyCode.Escape) && paused) 
            {
                HidePauseMenu();
            }

            if (paused) {
                Time.timeScale = 0.0f;
                Cursor.lockState = CursorLockMode.Confined;
            } else {
                Time.timeScale = 1.0f;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void ShowPauseMenu()
    {
        MenuCanvas.GetComponent<CanvasGroup>().alpha = 1.0f;
        paused = true;
    }

    public void HidePauseMenu()
    {
        MenuCanvas.GetComponent<CanvasGroup>().alpha = 0.0f;
        paused = false;
    }

    public void Restart() {
        paused = false;
        string sceneToLoad = SceneManager.GetActiveScene().path;
            
        #if UNITY_EDITOR
        //Load the scene.
        UnityEditor.SceneManagement.EditorSceneManager.LoadSceneAsyncInPlayMode(sceneToLoad, new LoadSceneParameters(LoadSceneMode.Single));
        #else
        //Load the scene.
        SceneManager.LoadSceneAsync(sceneToLoad, new LoadSceneParameters(LoadSceneMode.Single));
        #endif
    }

    public void Quit()
    {
        paused = false;
        // Exit to main menu
        SceneManager.LoadScene(0);
    }
}
