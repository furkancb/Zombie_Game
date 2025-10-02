using UnityEngine;
using System.Collections;

public class LookY : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 500f;
    [SerializeField] float _alt = -30f;
    [SerializeField] float _ust = 60f;
    private float _rot = 0f; // Dikey açýyý takip etmek için

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        // Dikey rotasyonu güncelle
        _rot -= mouseY; // "-" iþareti çünkü Mouse Y ters çalýþýyor
        _rot = Mathf.Clamp(_rot, _alt, _ust); // -60 ile +60 arasýnda sýnýrla

        // Transformun rotasyonunu sýfýrdan baþlayarak ayarla
        transform.localEulerAngles = new Vector3(_rot, 0f, 0f);
    }
}