using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Image crosshairImage;
    public Color normalColor = Color.white;
    public Color interactColor = Color.green;

    public void SetInteract(bool canInteract)
    {
        crosshairImage.color = canInteract ? interactColor : normalColor;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
