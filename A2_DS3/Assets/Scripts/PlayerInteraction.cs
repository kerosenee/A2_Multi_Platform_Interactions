using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public int maxCats = 4;
    public float interactRange = 5f;
    public Camera playerCamera;
    public Crosshair crosshairScript;

    public Transform spawnPoint;
    public GameObject catLimitPopup;
    private readonly Queue<GameObject> spawnedCats = new Queue<GameObject>();
    private bool waitingForInput = false;
    private GameObject newCatPrefab;

    public Transform holdPoint;
    private GameObject heldFish;
    private Rigidbody heldFishRB;

    public static PlayerInteraction Instance;
    private void Awake()
    {
        Instance = this;
        Debug.Log("PlayerInteraction Instance set by: " + gameObject.name);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (waitingForInput)
        {
            HandlePopupInput();
            return;
        }

        bool canInteract = false;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            bool aimingAtCatButton = hit.collider.CompareTag("Interactable");
            bool aimingAtFish = hit.collider.CompareTag("Fish");
            bool aimingAtCat = hit.collider.CompareTag("Cat");

            canInteract = aimingAtCatButton || aimingAtFish || aimingAtCat;

            if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                if (heldFish != null && aimingAtCat)
                {
                    FeedCat(hit.collider.gameObject);
                    return;
                }

                // PICK UP FISH
                if (heldFish == null && aimingAtFish)
                {
                    PickupFish(hit.collider.gameObject);
                    return;
                }

                // SPAWN CAT FROM MENU
                if (aimingAtCatButton)
                {
                    CatPrefab cat = hit.collider.GetComponent<CatPrefab>();
                    if (cat != null)
                    {
                        spawnCatAttempt(cat.catPrefab);
                    }
                    return;
                }
            }
        }

        if (crosshairScript != null)
        {
            crosshairScript.SetInteract(canInteract);
        }
    }


    private void spawnCatAttempt(GameObject catPrefab)
    {
        if (spawnedCats.Count < maxCats)
        {
            spawnCat(catPrefab);
            return;
        }
        newCatPrefab = catPrefab;
        waitingForInput = true;

        if (catLimitPopup != null)
        {
            catLimitPopup.SetActive(true);
        }
    }

    private void HandlePopupInput()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            if (spawnedCats.Count > 0)
            {
                GameObject oldestCat = spawnedCats.Dequeue();
                if (oldestCat != null)
                {
                    Destroy(oldestCat);
                }
            }

            if (newCatPrefab != null)
            {
                spawnCat(newCatPrefab);
            }

            ClosePopup();
        }

        else if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            ClosePopup();
        }
    }

    private void ClosePopup()
    {
        waitingForInput = false;
        newCatPrefab = null;

        if (catLimitPopup != null)
        {
            catLimitPopup.SetActive(false);
        }
    }

    private void spawnCat(GameObject catPrefab)
    {
        Vector3 pos = spawnPoint ? spawnPoint.position : Vector3.zero;
        Quaternion rot = spawnPoint ? spawnPoint.rotation : Quaternion.identity;

        GameObject cat = Instantiate(catPrefab, pos, rot);
        spawnedCats.Enqueue(cat);
    }

    private void FeedCat(GameObject catObject)
    {
        if (heldFish == null) return;

        CatFeeder feeder = catObject.GetComponentInParent<CatFeeder>();
        if (feeder != null)
        {
            feeder.Feed(heldFish);
            heldFish = null;
            heldFishRB = null;
        }
    }

    private void PickupFish(GameObject fishObject)
    {
        heldFish = fishObject;

        heldFishRB = heldFish.GetComponent<Rigidbody>();
        if (heldFishRB != null)
            heldFishRB.isKinematic = true;

        heldFish.transform.SetParent(holdPoint);
        heldFish.transform.localPosition = Vector3.zero;
        heldFish.transform.localRotation = Quaternion.identity;
    }

    public void RequestSpawnCat(GameObject catPrefab)
    {
        spawnCatAttempt(catPrefab);
    }

}
