using UnityEngine;
using System.Collections; 
using TMPro; // Importar TextMeshPro

public class KeySpawner : MonoBehaviour
{
    public GameObject keyPrefab;  // Prefab de la llave
    public Transform[] spawnPoints;  // Puntos para el spawner
    public GameObject keyUI; // Referencia a la imagen de la llave en el Canvas
    public TextMeshProUGUI messageText; // Referencia al texto en el Canvas (debe ser public)

    public float levitationHeight = 0.5f;  // Altura del movimiento de levitación
    public float levitationSpeed = 2f;     // Velocidad de levitación

    private GameObject currentKey;  // Referencia a la llave generada
    private Coroutine levitationCoroutine; // Guarda la corrutina de levitación

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

        // Seleccionar punto aleatorio
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[randomIndex].position;

        // Crear la llave en la posición aleatoria
        currentKey = Instantiate(keyPrefab, spawnPosition, Quaternion.identity);

        // Asignar la UI de la llave al nuevo objeto
        KeyPickup keyScript = currentKey.GetComponent<KeyPickup>();
        if (keyScript != null)
        {
            keyScript.SetKeyUI(keyUI, messageText); // Pasar la UI de la llave y el texto al script de la llave
        }

        // Iniciar levitación de la llave
        levitationCoroutine = StartCoroutine(LevitatingKey(currentKey));
    }

    private IEnumerator LevitatingKey(GameObject key)
    {
        Vector3 startPosition = key.transform.position;

        while (key != null) // Verifica que la llave aún existe
        {
            float newY = Mathf.Sin(Time.time * levitationSpeed) * levitationHeight;
            key.transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
            yield return null;
        }
    }
}
