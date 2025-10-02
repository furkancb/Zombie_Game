using UnityEngine;

public class RW3 : MonoBehaviour
{
    private Camera playerCamera;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Player'ın child'ındaki kamerayı bul
        playerCamera = GetComponentInChildren<Camera>();
        if (playerCamera == null)
        {
            Debug.LogError("Child objelerde kamera bulunamadı!");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            Ray mouseRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(mouseRay, out hitInfo, 100f))
            {
                Health1 enemyHealth = hitInfo.transform.GetComponent<Health1>();
                if (enemyHealth != null)
                {
                    enemyHealth.Damage(25);
                }
                //Debug.Log("Çarpılan nesne: " + hitInfo.transform.name);
            }
        }
    }
}
