using UnityEngine;
using UnityEngine.InputSystem;

public class CatSelectionUI : MonoBehaviour
{
    public GameObject orangeCat;
    public GameObject blackCat;
    public GameObject tabbyCat;
    public GameObject whiteCat;
    public Transform spawnPoint;
    public InputActionReference triggerAction;
    private GameObject hoveredCat;

    private void OnEnable() {
        if(triggerAction != null)
        {
            triggerAction.action.Enable();
            triggerAction.action.performed += OnTriggerPressed;
        }
    }

    private void OnDisable() {
        if(triggerAction != null)
        {
            triggerAction.action.performed -= OnTriggerPressed;
        }
    }

    private void OnTriggerPressed(InputAction.CallbackContext context)
    {
        if (hoveredCat != null)
        {
            SpawnCat(hoveredCat);
        }
    }

    public void spawnOrangeCat() {
        SpawnCat(orangeCat);
    }    

    public void spawnBlackCat() {
        SpawnCat(blackCat);
    }

    public void spawnWhiteCat() {
        SpawnCat(whiteCat);
    }

    public void spawnTabbyCat() {
        SpawnCat(tabbyCat);
    }

    public void setHoveredCat(GameObject catPrefab) {
        hoveredCat = catPrefab;
    }

    public void clearHoveredCat(GameObject catPrefab) {
        if(hoveredCat == catPrefab) {
            hoveredCat = null;
        }
    }

    private void SpawnCat(GameObject catPrefab)
    {
        if (catPrefab == null) {
            return;
        }

        Vector3 pos = spawnPoint ? spawnPoint.position : Vector3.zero;
        Quaternion rot = spawnPoint ? spawnPoint.rotation : Quaternion.identity;

        Instantiate(catPrefab, pos, rot);
    }
}
