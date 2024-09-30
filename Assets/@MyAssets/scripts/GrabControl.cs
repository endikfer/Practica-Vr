using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro; // Asegúrate de importar esto

public class GrabControl : MonoBehaviour
{
    public TextMeshProUGUI texto; // Asigna el componente TextMeshPro desde el Inspector
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        texto.gameObject.SetActive(false); // Asegúrate de que el texto esté oculto al inicio
        grabInteractable.onSelectEntered.AddListener(MostrarTexto);
        grabInteractable.onSelectExited.AddListener(OcultarTexto);
    }

    void MostrarTexto(XRBaseInteractor interactor)
    {
        texto.gameObject.SetActive(true); // Muestra el texto al agarrar
    }

    void OcultarTexto(XRBaseInteractor interactor)
    {
        texto.gameObject.SetActive(false); // Oculta el texto al soltar
    }

    private void OnDestroy()
    {
        grabInteractable.onSelectEntered.RemoveListener(MostrarTexto);
        grabInteractable.onSelectExited.RemoveListener(OcultarTexto);
    }
}
