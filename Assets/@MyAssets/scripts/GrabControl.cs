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

        // Suscripción a eventos utilizando el sistema de interacción de XR Toolkit
        grabInteractable.selectEntered.AddListener(OnSelectEntered);
        grabInteractable.selectExited.AddListener(OnSelectExited);
    }

    // Método para manejar cuando se selecciona el objeto (al agarrar)
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        MostrarTexto();
    }

    // Método para manejar cuando se deja de seleccionar el objeto (al soltar)
    private void OnSelectExited(SelectExitEventArgs args)
    {
        OcultarTexto();
    }

    void MostrarTexto()
    {
        texto.gameObject.SetActive(true); // Muestra el texto al agarrar
    }

    void OcultarTexto()
    {
        texto.gameObject.SetActive(false); // Oculta el texto al soltar
    }

    private void OnDestroy()
    {
        // Desuscripción de los eventos
        grabInteractable.selectEntered.RemoveListener(OnSelectEntered);
        grabInteractable.selectExited.RemoveListener(OnSelectExited);
    }
}

