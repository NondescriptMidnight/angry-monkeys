using UnityEngine;

public class Flowwerwork : MonoBehaviour
{

    public GameObject[] formationPrefabs;

    void FixedUpdate()
    {
        if (AllMembersDead())
        {
            RespawnItems();
        }
    }
    void RespawnItems()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {

            GameObject formations = formationPrefabs[Random.Range(0, formationPrefabs.Length)];
            GameObject formSpawn = Instantiate(formations, transform.position, Quaternion.identity) as GameObject;
            formSpawn.transform.parent = freePosition;
        }
    }
    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }
    bool AllMembersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }
}
