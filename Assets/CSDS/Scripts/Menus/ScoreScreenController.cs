using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ScoreScreenController : MonoBehaviour
{

    #region FIELDS SERIALIZED

    [Title(label: "Animations")]

    [Tooltip("Canvas to play animations on.")]
    [SerializeField]
    private GameObject animatedCanvas;

    [Tooltip("Animation played when showing this menu.")]
    [SerializeField]
    private AnimationClip animationShow;

    [Tooltip("Animation played when hiding this menu.")]
    [SerializeField]
    private AnimationClip animationHide;

    #endregion

    #region FIELDS
        
        /// <summary>
        /// Animation Component.
        /// </summary>
        private Animation animationComponent;
        /// <summary>
        /// If true, it means that this menu is enabled and showing properly.
        /// </summary>
        private bool menuIsEnabled;

        private PlayerInput fpsControls;

    #endregion

    #region UNITY
    
    // Start is called before the first frame update
    void Start()
    {
        //Hide pause menu on start.
        animatedCanvas.GetComponent<CanvasGroup>().alpha = 0;
        //Get canvas animation component.
        animationComponent = animatedCanvas.GetComponent<Animation>();
        // Get player controls component to deactivate when menu appears
        fpsControls = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
    }

    
    
    #endregion

    #region METHODS

    /// <summary>
    /// Hides the menu by playing an animation.
    /// </summary>
        private void Hide()
        {
            //Disabled.
            menuIsEnabled = false;

            //Play Clip.
            animationComponent.clip = animationHide;
            animationComponent.Play();
        }

    /// <summary>
    /// Shows the menu by playing an animation.
    /// </summary>
    public void Show()
    {
        //Enabled.
        menuIsEnabled = true;

        fpsControls.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

            //Play Clip.
            animationComponent.clip = animationShow;
            animationComponent.Play();
        }

        public void Restart()
        {

            fpsControls.enabled = true;

            //Path.
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
            // Exit to main menu
            //SceneManager.LoadScene(0);
            
            Application.Quit();
        }

    #endregion
}
