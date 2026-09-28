using UnityEngine;

public class OcultarDespuesDeTiempo : MonoBehaviour
{
    [SerializeField] private float tiempoVisible = 6f;

    void Start()
    {
        Invoke("Ocultar", tiempoVisible);
    }

    void Ocultar()
    {
        gameObject.SetActive(false);
    }
}