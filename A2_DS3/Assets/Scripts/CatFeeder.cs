using System.Collections;
using UnityEngine;

public class CatFeeder : MonoBehaviour
{
    public GameObject heartPopup;
    public float popupDuration = 1.5f;

    public AudioSource audioSource;
    public AudioClip meowAudio;

    public void Feed(GameObject fish)
    {
        if (fish != null)
        {
            Destroy(fish);
        }
        if(audioSource != null && meowAudio != null)
        {
            audioSource.PlayOneShot(meowAudio);
        }
        if (heartPopup != null)
        {
            StartCoroutine(ShowHeart());
        }
    }

    private IEnumerator ShowHeart()
    {
        heartPopup.SetActive(true);
        yield return new WaitForSeconds(popupDuration);
        heartPopup.SetActive(false);
    }
}
