using UnityEngine;
using TMPro; // Asegúrate de importar este espacio de nombres

public class KeyPickup : MonoBehaviour
{
    private GameObject keyUI;
    private TextMeshProUGUI messageText; // Declaramos la referencia al texto

    // Método para recibir las referencias
    public void SetKeyUI(GameObject uiKey, TextMeshProUGUI uiText)
    {
        keyUI = uiKey;
        keyUI.SetActive(false); // Inicialmente, la llave no está visible en el Canvas
        messageText = uiText;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Mostrar la llave en el UI
            if (keyUI != null)
                keyUI.SetActive(true);

            // Cambiar el texto cuando la llave es recogida
            if (messageText != null)
                messageText.text = "¡Ve al centro del laberinto!";  // Cambiar el mensaje al ser recogida

            // Destruir la llave del mundo 3D
            Destroy(gameObject);
        }
    }
}



