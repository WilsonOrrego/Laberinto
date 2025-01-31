using UnityEngine;
using TMPro; 
using System.Collections; 

public class KeyPickup : MonoBehaviour
{
    private GameObject keyUI;
    private TextMeshProUGUI messageText;
    private GameObject bridge;

    public void SetKeyUI(GameObject uiKey, TextMeshProUGUI uiText, GameObject bridgeObject)
    {
        keyUI = uiKey;
        keyUI.SetActive(false); //Ocultar la llave al inicio
        messageText = uiText;
        bridge = bridgeObject;
        bridge.SetActive(false); //Ocultar puente al inicio
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Mostrar la llave
            if (keyUI != null)
                keyUI.SetActive(true);


            if (messageText != null)
            {
                messageText.text = "Sube la rampa junto al Árbol para finalizar.";
            }

            //Activar el puente
            if (bridge != null)
                bridge.SetActive(true);

            //Destruir la llave
            Destroy(gameObject);
        }
    }

}



