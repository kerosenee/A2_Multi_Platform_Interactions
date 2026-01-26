using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject VrControls;
    public GameObject DesktopControls;

    public TextMeshProUGUI controlsText;
    public InputActionReference pauseAction;
    private bool isGamePaused = false;
    private bool isVRControls = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
        VrControls.SetActive(true);
        DesktopControls.SetActive(false);
        controlsText.text = "Switch to Desktop Controls";
    }
    
    private void OnEnable()
    {
        pauseAction.action.performed += TogglePause;
        pauseAction.action.Enable();
    }

    private void OnDisable()
    {
        pauseAction.action.performed -= TogglePause;
        pauseAction.action.Disable();
    }

    private void TogglePause(InputAction.CallbackContext context)
    {
        if (isGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isGamePaused = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isGamePaused = true;
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void SwitchControls()
    {
        if(isVRControls == false)
        {
            VrControls.SetActive(true);
            isVRControls = true;
            DesktopControls.SetActive(false);
            controlsText.text = "Switch to Desktop Controls";
        }
        else if(isVRControls == true)
        {
            VrControls.SetActive(false);
            isVRControls = false;
            DesktopControls.SetActive(true);
            controlsText.text = "Switch to VR Controls";
        }
    }
}