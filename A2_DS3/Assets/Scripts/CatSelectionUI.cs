using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatSelectionUI : MonoBehaviour
{
    public int maxCats = 4;
    public GameObject catLimitPopup;
    public GameObject orangeCat;
    public GameObject blackCat;
    public GameObject tabbyCat;
    public GameObject whiteCat;
    public Transform spawnPoint;

    public Collider orangeButton;
    public Collider blackButton;
    public Collider tabbyButton;
    public Collider whiteButton;


    public void CatSelector(Collider hitCollider)
    {
        int catCount = GameObject.FindGameObjectsWithTag("Cat").Length;
        if (catCount >= maxCats)
        {
            Debug.Log("Cat limit reached. Not spawning.");
            return;
        }
        
        if (hitCollider == orangeButton)
        {
            SpawnCat(orangeCat);
        }
        else if (hitCollider == blackButton)
        {
            SpawnCat(blackCat);
        }
        else if (hitCollider == tabbyButton)
        {
            SpawnCat(tabbyCat);
        }
        else if (hitCollider == whiteButton)
        {
            SpawnCat(whiteCat);
        }
    }

    private void SpawnCat(GameObject catPrefab)
    {
        if (catPrefab == null)
        {
            return;
        }

        Vector3 pos = spawnPoint ? spawnPoint.position : Vector3.zero;
        Quaternion rot = spawnPoint ? spawnPoint.rotation : Quaternion.identity;

        Instantiate(catPrefab, pos, rot);

    }
}
