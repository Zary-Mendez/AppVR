using UnityEngine;
using TMPro;

public class GameProgressManager : MonoBehaviour
{
    public static GameProgressManager Instance;

    [Header("Texto del contador")]
    public TMP_Text textoContador;

    [Header("Totales por zona")]
    public int totalCentral = 3;
    public int totalAzul = 5;
    public int totalRoja = 5;

    [Header("Canvas que aparece al completar")]
    public GameObject canvasFinalJuego;

    private int centralActual = 0;
    private int azulActual = 0;
    private int rojaActual = 0;

    private bool juegoCompletado = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (canvasFinalJuego != null)
        {
            canvasFinalJuego.SetActive(false);
        }

        ActualizarTexto();
    }

    public void RegistrarBandera(string zona)
    {
        if (juegoCompletado) return;

        if (zona == "Central")
        {
            centralActual++;
        }
        else if (zona == "Azul")
        {
            azulActual++;
        }
        else if (zona == "Roja")
        {
            rojaActual++;
        }

        ActualizarTexto();
        RevisarVictoria();
    }

    private void ActualizarTexto()
    {
        int totalActual = centralActual + azulActual + rojaActual;
        int totalGeneral = totalCentral + totalAzul + totalRoja;

        textoContador.text =
            "PROGRESO\n\n" +
            "Total: " + totalActual + "/" + totalGeneral + "\n" +
            "Central: " + centralActual + "/" + totalCentral + "\n" +
            "Azul: " + azulActual + "/" + totalAzul + "\n" +
            "Roja: " + rojaActual + "/" + totalRoja;
    }

    private void RevisarVictoria()
    {
        int totalActual = centralActual + azulActual + rojaActual;
        int totalGeneral = totalCentral + totalAzul + totalRoja;

        if (totalActual >= totalGeneral)
        {
            juegoCompletado = true;

            if (canvasFinalJuego != null)
            {
                canvasFinalJuego.SetActive(true);
            }
        }
    }
}