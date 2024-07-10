using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Position; // Kameranýn ulaþmak istediði hedef pozisyon
    public Transform LookPosition; // Kameranýn bakmasýný istediði hedef pozisyon

    public float positionLerpSpeed = 5.0f; // Pozisyon geçiþinin hýzý
    public float rotationLerpSpeed = 5.0f; // Rotasyon geçiþinin hýzý

    void LateUpdate()
    {
        // Hedef pozisyona hareket
        Vector3 desiredPosition = Position.position;

        // Mevcut pozisyondan hedef pozisyona daha kararlý bir geçiþ
        transform.position = Vector3.Lerp(transform.position, desiredPosition, positionLerpSpeed * Time.deltaTime);

        // Hedef rotasyona bakma
        Quaternion desiredRotation = Quaternion.LookRotation(LookPosition.position - transform.position);

        // Mevcut rotasyondan hedef rotasyona daha kararlý bir geçiþ
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, rotationLerpSpeed * Time.deltaTime);
    }
}
