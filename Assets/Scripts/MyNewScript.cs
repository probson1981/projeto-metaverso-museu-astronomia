using UnityEngine;
using UnityEngine.InputSystem;

public class SistemaSelecaoAudioEscala : MonoBehaviour
{
    [SerializeField] private float fatorAumento = 1.15f;
    [SerializeField] private float distanciaMaxima = 100f;

    private GameObject objetoSelecionado;
    private Renderer rendererSelecionado;
    private Color corOriginal;

    private GameObject objetoAtivado;
    private Vector3 escalaOriginal;
    private bool estaAtivado = false;

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

        if (Physics.Raycast(ray, out hit, distanciaMaxima))
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
                rendererSelecionado = null;
            }
        }
    }

    void AplicarHighlight()
    {
        rendererSelecionado = objetoSelecionado.GetComponent<Renderer>();

        if (rendererSelecionado == null)
        {
            rendererSelecionado = objetoSelecionado.GetComponentInChildren<Renderer>();
        }

        if (rendererSelecionado != null)
        {
            corOriginal = rendererSelecionado.material.color;
            rendererSelecionado.material.color = Color.yellow;
        }
    }

    void RemoverHighlight()
    {
        if (rendererSelecionado != null)
        {
            rendererSelecionado.material.color = corOriginal;
        }
    }

    void InteragirComObjeto(GameObject objeto)
    {
        AudioSource audioSource = objeto.GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = objeto.GetComponentInParent<AudioSource>();
        }

        if (audioSource == null)
        {
            audioSource = objeto.GetComponentInChildren<AudioSource>();
        }

        if (audioSource == null)
        {
            Debug.Log("O objeto selecionado não possui Audio Source: " + objeto.name);
            return;
        }

        GameObject alvo = audioSource.gameObject;

        if (objetoAtivado != alvo)
        {
            if (objetoAtivado != null)
            {
                RestaurarObjetoAnterior();
            }

            objetoAtivado = alvo;
            escalaOriginal = alvo.transform.localScale;
            estaAtivado = false;
        }

        estaAtivado = !estaAtivado;

        if (estaAtivado)
        {
            alvo.transform.localScale = escalaOriginal * fatorAumento;

            if (audioSource.clip != null)
            {
                audioSource.Play();
            }

            Debug.Log("Objeto ativado: " + alvo.name);
        }
        else
        {
            alvo.transform.localScale = escalaOriginal;

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            Debug.Log("Objeto desativado: " + alvo.name);
        }
    }

    void RestaurarObjetoAnterior()
    {
        objetoAtivado.transform.localScale = escalaOriginal;

        AudioSource audioSource = objetoAtivado.GetComponent<AudioSource>();

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}