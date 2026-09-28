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

    private int centralActual = 0;
    private int azulActual = 0;
    private int rojaActual = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ActualizarTexto();
    }

    public void RegistrarBandera(string zona)
    {
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
}