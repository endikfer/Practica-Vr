using UnityEngine;
using UnityEngine.Video;

public class VideoStart : MonoBehaviour
{
    public GameObject videoSphere;  // Esfera que contiene el video 360
    public VideoPlayer videoPlayer; // Reproductor de video

    void Start()
    {
        // Desactivar el Mesh Renderer para hacer la esfera invisible
        videoSphere.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activar el Mesh Renderer para hacer visible la esfera
            videoSphere.GetComponent<MeshRenderer>().enabled = true;
            videoPlayer.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            videoPlayer.Stop();
            // Desactivar el Mesh Renderer para hacer invisible la esfera
            videoSphere.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}



