using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Position; // Kameran�n ula�mak istedi�i hedef pozisyon
    public Transform LookPosition; // Kameran�n bakmas�n� istedi�i hedef pozisyon

    public float positionLerpSpeed = 5.0f; // Pozisyon ge�i�inin h�z�
    public float rotationLerpSpeed = 5.0f; // Rotasyon ge�i�inin h�z�

    void LateUpdate()
    {
        // Hedef pozisyona hareket
        Vector3 desiredPosition = Position.position;

        // Mevcut pozisyondan hedef pozisyona daha kararl� bir ge�i�
        transform.position = Vector3.Lerp(transform.position, desiredPosition, positionLerpSpeed * Time.deltaTime);

        // Hedef rotasyona bakma
        Quaternion desiredRotation = Quaternion.LookRotation(LookPosition.position - transform.position);

        // Mevcut rotasyondan hedef rotasyona daha kararl� bir ge�i�
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, rotationLerpSpeed * Time.deltaTime);
    }
}
