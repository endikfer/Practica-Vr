using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAttach : MonoBehaviour
{
    public Transform attachPointRightHand; // Asigna el attach point para la mano derecha
    public Transform attachPointLeftHand;  // Asigna el attach point para la mano izquierda

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Suscribimos el evento de agarre
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        // Hacemos un casting explícito de interactorObject a XRBaseInteractor
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;

        if (interactor != null)
        {
            // Detectamos con qué mano está agarrando
            if (interactor.CompareTag("Right"))
            {
                grabInteractable.attachTransform = attachPointRightHand;
            }
            else if (interactor.CompareTag("Left"))
            {
                grabInteractable.attachTransform = attachPointLeftHand;
            }
        }
    }

    void OnDestroy()
    {
        // Eliminamos el listener cuando el objeto es destruido
        grabInteractable.selectEntered.RemoveListener(OnGrab);
    }
}

