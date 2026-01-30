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

    private void onEnable() {
        if(triggerAction != null)
        {
            triggerAction.action.Enable();
            triggerAction.action.performed += OnTriggerPressed;
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
