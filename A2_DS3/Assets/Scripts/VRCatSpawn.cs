using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRCatSpawn : MonoBehaviour
{
    public GameObject catPrefab;
    public PlayerInteraction playerInteraction; // drag reference

    private void Awake()
    {
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelect);
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
            Debug.Log("VRCatSpawn selected by: " + args.interactorObject.transform.name, this);

        if (catPrefab == null || playerInteraction == null) return;
        playerInteraction.RequestSpawnCat(catPrefab);
    }
}
