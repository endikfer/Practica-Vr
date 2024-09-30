using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlashlightController : MonoBehaviour
{
    public Light spotLight; // Referencia al componente Light de tipo SpotLight
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Asegúrate de que la luz esté apagada al inicio
        spotLight.enabled = false;

        // Suscribir a los eventos de agarrar y soltar
        grabInteractable.onSelectEntered.AddListener(TurnOnLight);
        grabInteractable.onSelectExited.AddListener(TurnOffLight);
    }

    private void TurnOnLight(XRBaseInteractor interactor)
    {
        spotLight.enabled = true;  // Encender la luz
    }

    private void TurnOffLight(XRBaseInteractor interactor)
    {
        spotLight.enabled = false;  // Apagar la luz
    }
}
