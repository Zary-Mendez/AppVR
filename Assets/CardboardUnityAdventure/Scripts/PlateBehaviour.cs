using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehaviour : MonoBehaviour
{
    GrabManager grabManager;

    [Header("Punto donde se coloca la bandera")]
    [SerializeField] GameObject holder;

    [Header("Rotación de la bandera colocada")]
    [SerializeField] float rotationSpeed = 80f;

    [Header("Zona del barril")]
    [SerializeField] private string zona = "Central";

    public GameObject heldObject;

    private bool banderaYaContada = false;

    void Start()
    {
        grabManager = GameObject.Find("GrabManager").GetComponent<GrabManager>();
    }

    void FixedUpdate()
    {
        if (heldObject != null)
        {
            heldObject.transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
        }
    }

    public void OnPointerClickXR()
    {
        if (grabManager.heldItem != null)
        {
            if (heldObject != null)
            {
                heldObject.GetComponent<GrabObject>().Respawn();
            }

            heldObject = grabManager.heldItem;
            grabManager.heldItem.GetComponent<GrabObject>().Place(holder.transform.position);

            if (!banderaYaContada)
            {
                GameProgressManager.Instance.RegistrarBandera(zona);
                banderaYaContada = true;
            }
        }
        else
        {
            if (heldObject != null)
            {
                heldObject.GetComponent<GrabObject>().Grab();
                heldObject = null;
            }
        }
    }
}