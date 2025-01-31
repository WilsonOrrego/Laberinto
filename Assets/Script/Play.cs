using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame(string NOmbredelnivel)
    {
        //Carga la escena del laberinto
        SceneManager.LoadScene(NOmbredelnivel);
    }
}