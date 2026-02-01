using UnityEngine;

public class CatSelectionHover : MonoBehaviour
{
    public CatSelectionUI catSelectionUI;
    public GameObject catPrefab;

    private void OnTriggerEnter(Collider handCollider)
    {
        Debug.Log($"[CatHoverZone] ENTER '{gameObject.name}' hit by '{handCollider.name}'  tag={handCollider.tag}");

        if(handCollider.CompareTag("Hand"))
        {
            Debug.Log($"[CatHoverZone] Hand detected. Setting hovered cat = {catPrefab?.name}");

            catSelectionUI.setHoveredCat(catPrefab);
        }
    }

    private void OnTriggerExit(Collider handCollider)
    {
        Debug.Log($"[CatHoverZone] EXIT '{gameObject.name}' by '{handCollider.name}' tag={handCollider.tag}");

        if(handCollider.CompareTag("Hand"))
        {
            Debug.Log($"[CatHoverZone] Clearing hovered cat = {catPrefab?.name}");
            catSelectionUI.clearHoveredCat(catPrefab);
        }
    }
}
