using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSelectCatHitbox : MonoBehaviour
{
    public CatSelectionUI menu;
    private Collider catCollider;
    
    void Awake()
    {
        catCollider = GetComponent<Collider>();
    }

    public void OnSelectCatCollider(SelectEnterEventArgs args)
    {
        if(menu != null && catCollider != null)
        {
            menu.CatSelector(catCollider);
            Debug.Log("RAY SELECT HIT: " + gameObject.name);

        }
    }
}
