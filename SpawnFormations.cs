using UnityEngine;

public class SpawnFormations : MonoBehaviour
{
    public float width = 10f;
    public float height = 5f;
    public GameObject[] formationPrefabs;

    // Use this for initialization
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }


    void Start()
    {

        SpawnItems();
    }

    void SpawnItems()
    {
        GameObject formations = formationPrefabs[Random.Range(0, formationPrefabs.Length)];
        GameObject formSpawn = Instantiate(formations, transform.position, Quaternion.identity) as GameObject;

    }
}



