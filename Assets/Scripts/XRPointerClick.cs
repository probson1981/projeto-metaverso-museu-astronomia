using UnityEngine;
using UnityEngine.InputSystem;

public class XRPointerClick : MonoBehaviour
{
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private float maxDistance = 20f;

    private void Start()
    {
        Debug.Log("XRPointerClick ativo no objeto: " + gameObject.name);
    }

    private void Awake()
    {
        if (rayOrigin == null)
        {
            rayOrigin = transform;
        }
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.pKey.wasPressedThisFrame)
        {
            Debug.Log("Tecla P detectada pelo novo Input System.");
            TryInteract();
        }
    }

    private void TryInteract()
    {
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);

        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red, 2f);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            Debug.Log("Raycast acertou: " + hit.collider.name);

            AstronomyInteractable interactable =
                hit.collider.GetComponentInParent<AstronomyInteractable>();

            if (interactable != null)
            {
                Debug.Log("Objeto interagível encontrado: " + interactable.name);
                interactable.Interact();
            }
            else
            {
                Debug.Log("O objeto acertado não possui AstronomyInteractable.");
            }
        }
        else
        {
            Debug.Log("Raycast não acertou nenhum objeto.");
        }
    }
}