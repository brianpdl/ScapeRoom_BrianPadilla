using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Camera mirrorCamera;
    public Transform mirrorPlane;

    void Start()
    {
        if (mirrorCamera == null)
        {
            Debug.LogError("Mirror Camera is not assigned!");
            return;
        }
    }

    void LateUpdate()
    {
        // Calcular la posici�n reflejada
        Vector3 mirrorPosition = mirrorPlane.position;
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 reflectedPosition = mirrorPosition + Vector3.Reflect(cameraPosition - mirrorPosition, mirrorPlane.up);

        // Ajustar la c�mara del espejo
        mirrorCamera.transform.position = reflectedPosition;
        mirrorCamera.transform.LookAt(mirrorPlane.position);

        // Renderizar la c�mara del espejo
        mirrorCamera.Render();
    }
}
