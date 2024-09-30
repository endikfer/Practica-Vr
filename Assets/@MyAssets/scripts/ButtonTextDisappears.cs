using UnityEngine;
using UnityEngine.UI; // Para trabajar con botones de UI

public class CanvasDisappears : MonoBehaviour
{
    public Canvas canvas; // Referencia al Canvas que desaparecerá
    private Button uiButton; // Referencia al componente Button de Unity UI

    void Start()
    {
        // Obtiene el componente de Button en este GameObject
        uiButton = GetComponent<Button>();

        // Suscribir el evento de click
        uiButton.onClick.AddListener(OnButtonPressed);
    }

    // Método llamado cuando se presiona el botón
    private void OnButtonPressed()
    {
        // Desactivar el Canvas
        canvas.gameObject.SetActive(false);
    }
}
