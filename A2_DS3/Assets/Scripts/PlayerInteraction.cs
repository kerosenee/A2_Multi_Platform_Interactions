using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 5f;
    public Camera playerCamera;
    public Crosshair crosshairScript;

    public float holdDistance = 2f;
    public float holdDownOffset = 0.5f;
    public float feedDistance = 1.2f;

    private GameObject heldFish;
    private Rigidbody heldFishRB;
    private Collider heldFishCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (crosshairScript != null)
        {
            bool canInteract =
                Physics.Raycast(ray, out hit, interactRange) &&
                (hit.collider.CompareTag("Fish") ||
                 hit.collider.CompareTag("Cat") ||
                 hit.collider.CompareTag("Interactable"));

            crosshairScript.SetInteract(canInteract);
        }

        if (heldFish != null)
        {
            Vector3 targetPos =
                playerCamera.transform.position +
                playerCamera.transform.forward * holdDistance +
                playerCamera.transform.up * -holdDownOffset;

            heldFish.transform.position = targetPos;
        }

        if (Keyboard.current == null || !Keyboard.current.eKey.wasPressedThisFrame)
            return;

        if (heldFish != null)
        {
            if (Physics.Raycast(ray, out hit, interactRange) && hit.collider.CompareTag("Cat"))
            {
                Vector3 closest = hit.collider.ClosestPoint(heldFish.transform.position);
                float dist = Vector3.Distance(heldFish.transform.position, closest);

                if (dist <= feedDistance)
                {
                    FeedCat(hit.collider.gameObject);
                    return;
                }
            }

            DropFish();
            return;
        }

        if (!Physics.Raycast(ray, out hit, interactRange))
            return;

        if (hit.collider.CompareTag("Fish"))
        {
            PickupFish(hit.collider.gameObject);
            return;
        }

        if (hit.collider.CompareTag("Interactable"))
        {
            CatSelectionUI menu = hit.collider.GetComponentInParent<CatSelectionUI>();
            if (menu != null)
            {
                menu.CatSelector(hit.collider);
            }
            return;
        }

    }

    void PickupFish(GameObject fish)
    {
        if (fish == null) return;

        Rigidbody rb = fish.GetComponent<Rigidbody>();
        if (rb == null) return;

        heldFish = fish;
        heldFishRB = rb;

        heldFishCollider = fish.GetComponent<Collider>();
        if (heldFishCollider != null)
            heldFishCollider.enabled = false;

        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        heldFish.transform.position =
                    playerCamera.transform.position +
                    playerCamera.transform.forward * holdDistance +
                    playerCamera.transform.up * -holdDownOffset;
    }

    void DropFish()
    {
        if (heldFishCollider != null)
            heldFishCollider.enabled = true;

        if (heldFishRB != null)
        {
            heldFishRB.useGravity = true;
            heldFishRB.linearVelocity = Vector3.zero;
            heldFishRB.angularVelocity = Vector3.zero;
        }

        heldFish = null;
        heldFishRB = null;
        heldFishCollider = null;
    }

    void FeedCat(GameObject catObject)
    {
        if (heldFish == null) return;

        GameObject fishToDestroy = heldFish;

        heldFish = null;
        heldFishRB = null;

        CatFeeder feeder = catObject.GetComponentInParent<CatFeeder>();
        if (feeder != null)
            feeder.Feed(fishToDestroy);
        else
            Destroy(fishToDestroy);
    }
}
