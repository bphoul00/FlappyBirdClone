using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour
{

    private GameObject[] backgrounds;
    private GameObject[] grounds;

    private float lastBGX;
    private float lastGroundX;

    // Start is called before the first frame update
    void Awake()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        grounds = GameObject.FindGameObjectsWithTag("Ground");

        lastBGX = getLastXPositionGameObjects(backgrounds);
        lastGroundX = getLastXPositionGameObjects(grounds);

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Background") {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;

            temp.x = lastBGX + width;

            target.transform.position = temp;

            lastBGX = temp.x;
        } else if (target.tag == "Ground") {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;

            temp.x = lastGroundX + width;

            target.transform.position = temp;

            lastGroundX = temp.x;
        }
    }

    private float getLastXPositionGameObjects(GameObject[] gameObjects)
    {
        float lastGameObjectX = gameObjects[0].transform.position.x;

        for (int i = 1; i < gameObjects.Length; i++)
        {
            if (lastGameObjectX < gameObjects[i].transform.position.x)
            {
                lastGameObjectX = gameObjects[i].transform.position.x;
            }
        }
        return lastGameObjectX;
    }
}
