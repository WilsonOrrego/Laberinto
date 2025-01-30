using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame(string NOmbredelnivel)
    {
        // Carga una nueva escena del laberinto
        SceneManager.LoadScene(NOmbredelnivel);
    }
}