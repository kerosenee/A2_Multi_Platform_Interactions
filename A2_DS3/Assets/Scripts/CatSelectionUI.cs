using UnityEngine;

public class CatSelectionUI : MonoBehaviour
{
    public GameObject orangeCat;
    public GameObject blackCat;
    public GameObject tabbyCat;
    public GameObject whiteCat;
    public Transform spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawnOrangeCat() {
        SpawnCat(orangeCat);
    }    

    void spawnBlackCat() {
        SpawnCat(orangeCat);
    }

    void spawnWhiteCat() {
        SpawnCat(orangeCat);
    }

    void spawnOrangeCat() {
        SpawnCat(orangeCat);
    }

    void SpawnCat(GameObject catPrefab)
    {
        if (catPrefab == null) {
            return;
        }

        Vector3 pos = spawnPoint ? spawnPoint.position : Vector3.zero;
        Quaternion rot = spawnPoint ? spawnPoint.rotation : Quaternion.identity;

        Instantiate(catPrefab, pos, rot);
    }
}
