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

        // Suscribir a los eventos de agarrar y soltar usando los nuevos tipos de eventos
        grabInteractable.selectEntered.AddListener(OnSelectEntered);
        grabInteractable.selectExited.AddListener(OnSelectExited);
    }

    // Método para manejar el evento de agarrar (encender la luz)
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        TurnOnLight();
    }

    // Método para manejar el evento de soltar (apagar la luz)
    private void OnSelectExited(SelectExitEventArgs args)
    {
        TurnOffLight();
    }

    // Encender la luz
    private void TurnOnLight()
    {
        spotLight.enabled = true;
    }

    // Apagar la luz
    private void TurnOffLight()
    {
        spotLight.enabled = false;
    }

    private void OnDestroy()
    {
        // Desuscribir los eventos
        grabInteractable.selectEntered.RemoveListener(OnSelectEntered);
        grabInteractable.selectExited.RemoveListener(OnSelectExited);
    }
}
