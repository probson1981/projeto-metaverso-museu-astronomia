using UnityEngine;
using UnityEngine.InputSystem;

public class SistemaSelecao : MonoBehaviour
{
    private GameObject objetoSelecionado;
    private Color corOriginal;

    private GameObject objetoAtivado;
    private Vector3 escalaOriginal;
    private bool estaAtivado = false;

    [SerializeField] private float fatorAumento = 1.15f;

    void Update()
    {
        if (Camera.main == null)
        {
            return;
        }

        if (Mouse.current == null)
        {
            return;
        }

        Vector2 posicaoMouse = Mouse.current.position.ReadValue();

        Ray ray = Camera.main.ScreenPointToRay(posicaoMouse);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject objetoAtual = hit.collider.gameObject;

            if (objetoAtual != objetoSelecionado)
            {
                if (objetoSelecionado != null)
                {
                    RemoverHighlight();
                }

                objetoSelecionado = objetoAtual;
                AplicarHighlight();
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                InteragirComObjeto(objetoAtual);
            }
        }
        else
        {
            if (objetoSelecionado != null)
            {
                RemoverHighlight();
                objetoSelecionado = null;
            }
        }
    }

    void AplicarHighlight()
    {
        Renderer renderer = objetoSelecionado.GetComponent<Renderer>();

        if (renderer != null)
        {
            corOriginal = renderer.material.color;
            renderer.material.color = Color.yellow;
        }
    }

    void RemoverHighlight()
    {
        Renderer renderer = objetoSelecionado.GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = corOriginal;
        }
    }

    void InteragirComObjeto(GameObject objeto)
    {
        AudioSource audioSource = objeto.GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.Log("O objeto selecionado não possui Audio Source: " + objeto.name);
            return;
        }

        if (objetoAtivado != objeto)
        {
            if (objetoAtivado != null)
            {
                RestaurarObjetoAnterior();
            }

            objetoAtivado = objeto;
            escalaOriginal = objeto.transform.localScale;
            estaAtivado = false;
        }

        estaAtivado = !estaAtivado;

        if (estaAtivado)
        {
            objeto.transform.localScale = escalaOriginal * fatorAumento;

            if (audioSource.clip != null)
            {
                audioSource.Play();
            }

            Debug.Log("Objeto ativado: " + objeto.name);
        }
        else
        {
            objeto.transform.localScale = escalaOriginal;

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            Debug.Log("Objeto desativado: " + objeto.name);
        }
    }

    void RestaurarObjetoAnterior()
    {
        if (objetoAtivado == null)
        {
            return;
        }

        objetoAtivado.transform.localScale = escalaOriginal;

        AudioSource audioSource = objetoAtivado.GetComponent<AudioSource>();

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}