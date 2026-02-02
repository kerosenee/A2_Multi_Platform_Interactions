using UnityEngine;


public class FeedZoneTrigger : MonoBehaviour
{
    private CatFeeder feeder;

    void Awake()
    {
        feeder = GetComponentInParent<CatFeeder>();
    }

    private void OnTriggerEnter(Collider fishCollider)
    {
        Debug.Log("FeedZone entered by: " + fishCollider.name + " tag=" + fishCollider.tag);

        if (!fishCollider.CompareTag("Fish"))
        {
            return;
        }

        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab = fishCollider.GetComponentInParent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        if(grab != null && grab.isSelected)
        {
            return;
        }

        if(feeder !=null)
        {
            feeder.Feed(fishCollider.gameObject);
        }
        else
        {
            Destroy(fishCollider.gameObject);
        }
    }
}
