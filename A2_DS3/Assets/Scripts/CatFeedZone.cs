using UnityEngine;

public class CatFeedZone : MonoBehaviour
{
    private CatFeeder feeder;
    private void Awake()
    {
        feeder = GetComponentInParent<CatFeeder>();
    }

    private void OnTriggerEnter(Collider catCollider)
    {
        if (feeder == null)
        {
            return;
        }

        if(catCollider.CompareTag("Fish"))
        {
            feeder.Feed(catCollider.gameObject);
        }
    }
}
