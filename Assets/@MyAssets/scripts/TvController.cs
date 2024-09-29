using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class TVController : MonoBehaviour
{
    public VideoPlayer tvVideoPlayer;  // Asigna el VideoPlayer de la televisión
    public XRGrabInteractable grabInteractable;  // Asigna el móvil que se agarra
    public ActionBasedController controller;  // Asigna el controlador basado en acciones (Right/Left)
    public InputHelpers.Button toggleButton = InputHelpers.Button.PrimaryButton;  // Botón a detectar

    public Material tvScreenMaterial;  // Asigna el material que utilizas para el video
    public Color onColor = Color.white;  // Color cuando la televisión está encendida
    public Color offColor = Color.black;  // Color cuando la televisión está apagada

    private bool isVideoPlaying = false;

    void Start()
    {
        // Establecer la pantalla de la televisión como apagada inicialmente
        SetScreenColor(offColor);
    }

    void Update()
    {
        if (grabInteractable.isSelected)  // Verifica si el móvil está agarrado
        {
            // Verifica si el botón ha sido presionado en el controlador
            if (controller.activateAction.action.ReadValue<float>() > 0.1f)
            {
                ToggleVideo();
            }
        }
    }

    // Método para encender o apagar el video
    private void ToggleVideo()
    {
        if (isVideoPlaying)
        {
            // Apagar el video y cambiar el color a negro
            tvVideoPlayer.Pause();
            tvVideoPlayer.time = 0;  // Reinicia el video al inicio
            SetScreenColor(offColor);
        }
        else
        {
            // Encender el video y cambiar el color a blanco
            tvVideoPlayer.Play();
            SetScreenColor(onColor);
        }
        isVideoPlaying = !isVideoPlaying;
    }
    private void SetScreenColor(Color color)
    {
        if (tvScreenMaterial != null)
        {
            tvScreenMaterial.color = color;
        }
    }
}