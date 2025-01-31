using UnityEngine;
using System.Collections;
using TMPro;

public class KeySpawner : MonoBehaviour
{
    public GameObject keyPrefab;  //llave
    public Transform[] spawnPoints;  //Puntos para el spawner
    public GameObject keyUI; // Img del canvas
    public TextMeshProUGUI messageText; //Texto en el Canvas
    public GameObject bridge;

    public float levitationHeight = 0.5f;  //Altura del movimiento de levitación
    public float levitationSpeed = 2f;     //Velocidad de levitación

    private GameObject currentKey;  //llave generada
    private Coroutine levitationCoroutine; //Guarda la corrutina de levitación

    void Start()
    {
        SpawnKey();
    }

    void SpawnKey()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No se han asignado puntos.");
            return;
        }

        //Selecciona un punto aleatorio
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[randomIndex].position;

        //Crear la llave en la posición aleatoria
        currentKey = Instantiate(keyPrefab, spawnPosition, Quaternion.identity);

        //Asignar la UI de la llave y el puente
        KeyPickup keyScript = currentKey.GetComponent<KeyPickup>();
        if (keyScript != null)
        {
            keyScript.SetKeyUI(keyUI, messageText, bridge);
        }

        //Iniciar levitación
        levitationCoroutine = StartCoroutine(LevitatingKey(currentKey));
    }

    private IEnumerator LevitatingKey(GameObject key)
    {
        Vector3 startPosition = key.transform.position;

        while (key != null) //Verifica la existencia de la llave
        {
            float newY = Mathf.Sin(Time.time * levitationSpeed) * levitationHeight;
            key.transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
            yield return null;
        }
    }
}

