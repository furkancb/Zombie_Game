using UnityEngine;
using System.Collections;
public class PlayerGui1 : MonoBehaviour
{

    [SerializeField] Texture2D _crosshair;
    PHealth _playerHealth;

    void Start()
    {
        _playerHealth = GetComponent<PHealth>();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(5, 5, 100, 100), "Health: " + _playerHealth);

        float x = (Screen.width - _crosshair.width) / 2;
        float y = (Screen.height - _crosshair.height) / 2;
        GUI.DrawTexture(new Rect(x, y, _crosshair.width, _crosshair.height), _crosshair);
    }
}


