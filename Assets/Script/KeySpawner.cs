using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject keyPrefab;  //Prefab de la llave
    public Transform[] spawnPoints;  // Puntos para el spawner

    public float levitationHeight = 0.5f;  // Altura del movimiento de levitación
    public float levitationSpeed = 2f;     // Velocidad de movimiento de levitación

    private GameObject currentKey;  // Referencia a la llave generada

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

        // Iniciar levitación de la llave
        StartCoroutine(LevitatingKey(currentKey));
    }

    private System.Collections.IEnumerator LevitatingKey(GameObject key)
    {
        Vector3 startPosition = key.transform.position;

        while (true)  // Esto hará que la llave se mueva indefinidamente
        {
            float newY = Mathf.Sin(Time.time * levitationSpeed) * levitationHeight;
            key.transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
            yield return null;  // Espera al siguiente cuadro
        }
    }
}
