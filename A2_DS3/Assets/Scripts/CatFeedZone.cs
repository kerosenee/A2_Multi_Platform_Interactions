using UnityEngine;

public class CatFeedZone : MonoBehaviour
{
    public bool HasFishInZone { get; private set; }

    private int fishCountInZone = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Fish")) return;
        fishCountInZone++;
        HasFishInZone = fishCountInZone > 0;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Fish")) return;
        fishCountInZone = Mathf.Max(0, fishCountInZone - 1);
        HasFishInZone = fishCountInZone > 0;
    }
}