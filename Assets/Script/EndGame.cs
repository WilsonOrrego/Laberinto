using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;  
using TMPro; 

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI winMessageText;  //Texto en el Canvas
    public string sceneName = "MenuPlay";  //Nombre de la escena que se cargará

    void Start()
    {
        //Asegura que el mensaje no sea visible al inicio
        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Verifica que el jugador entra em contacto
        if (other.CompareTag("Player"))
        {
            //Mostrar mensaje Danaste
            if (winMessageText != null)
            {
                winMessageText.text = "¡Ganaste!";
                winMessageText.gameObject.SetActive(true); 
            }

            //Finaliza el juego 
            StartCoroutine(EndGameAfterDelay(2f)); 
        }
    }

    private IEnumerator EndGameAfterDelay(float delay)
    {
      
        yield return new WaitForSeconds(delay);

        //Carga la Scene
        SceneManager.LoadScene(sceneName);
    }
}
