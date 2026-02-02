using UnityEngine;
using UnityEngine.InputSystem;

public class ModeSwitch : MonoBehaviour
{
    public GameObject desktopPlayer;
    public GameObject vrPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnableDesktop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            EnableDesktop();
        }

        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            EnableVR();
        }
    }

    void EnableDesktop()
    {
        desktopPlayer.SetActive(true);
        vrPlayer.SetActive(false);
    }

    void EnableVR()
    {
        vrPlayer.SetActive(true);
        desktopPlayer.SetActive(false);
    }
}
