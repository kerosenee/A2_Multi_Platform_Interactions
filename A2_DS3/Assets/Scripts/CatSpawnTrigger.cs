using UnityEngine;
using UnityEngine.InputSystem;


public class CatSpawnTrigger : MonoBehaviour
{
    public GameObject catPrefab;
    public PlayerInteraction playerInteraction;

    private bool handInside = false;

    private void OnTriggerEnter(Collider other) => handInside = true;
    private void OnTriggerExit(Collider other) => handInside = false;


    private void Update()
    {
        if (!handInside) return;

        if (Keyboard.current != null && Keyboard.current.tKey.wasPressedThisFrame)
        {
            playerInteraction.RequestSpawnCat(catPrefab);
        }
    }
}
