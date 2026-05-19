using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AstronomyInteractable : MonoBehaviour
{
    [SerializeField] private float scaleMultiplier = 1.15f;

    private Vector3 originalScale;
    private AudioSource audioSource;
    private bool isActive = false;

    private void Awake()
    {
        originalScale = transform.localScale;

        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    public void Interact()
    {
        isActive = !isActive;

        if (isActive)
        {
            transform.localScale = originalScale * scaleMultiplier;

            if (audioSource.clip != null)
            {
                audioSource.Play();
            }

            Debug.Log("Marte ativado: aumentou e tocou áudio.");
        }
        else
        {
            transform.localScale = originalScale;

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            Debug.Log("Marte desativado: voltou ao normal.");
        }
    }
}   