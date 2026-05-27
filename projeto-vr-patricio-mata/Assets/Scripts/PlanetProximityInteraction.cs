using UnityEngine;

public class PlanetProximityInteraction : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform planetVisual;
    [SerializeField] private AudioSource audioSource;

    [Header("Configuração da interação")]
    [SerializeField] private float activationDistance = 3.0f;
    [SerializeField] private float enlargedScaleFactor = 1.25f;
    [SerializeField] private float scaleSpeed = 4.0f;
    [SerializeField] private bool stopAudioWhenFar = false;

    private Vector3 originalScale;
    private Vector3 targetScale;
    private bool isPlayerNear = false;

    private void Awake()
    {
        if (planetVisual == null)
        {
            planetVisual = transform;
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (playerCamera == null && Camera.main != null)
        {
            playerCamera = Camera.main.transform;
        }

        originalScale = planetVisual.localScale;
        targetScale = originalScale;

        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
            audioSource.loop = false;
        }
    }

    private void Update()
    {
        if (playerCamera == null)
        {
            if (Camera.main != null)
            {
                playerCamera = Camera.main.transform;
            }

            return;
        }

        float distance = Vector3.Distance(playerCamera.position, transform.position);

        if (distance <= activationDistance)
        {
            ActivateInteraction();
        }
        else
        {
            DeactivateInteraction();
        }

        planetVisual.localScale = Vector3.Lerp(
            planetVisual.localScale,
            targetScale,
            Time.deltaTime * scaleSpeed
        );
    }

    private void ActivateInteraction()
    {
        if (isPlayerNear)
        {
            return;
        }

        isPlayerNear = true;
        targetScale = originalScale * enlargedScaleFactor;

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void DeactivateInteraction()
    {
        if (!isPlayerNear)
        {
            return;
        }

        isPlayerNear = false;
        targetScale = originalScale;

        if (stopAudioWhenFar && audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, activationDistance);
    }
}