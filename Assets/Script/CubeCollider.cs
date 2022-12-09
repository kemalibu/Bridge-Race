using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollider : MonoBehaviour
{
    public List<GameObject> cubes = new List<GameObject>();
    private GameObject lastBlock;

    //private float yOffset = 0.18f;
    //private float zOffset = 3.4f;
    private float cubeOffset = 0.54f;



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerCube")
        {
            CollectCubePlayer(other.gameObject);
            other.GetComponentInParent<BoxCollider>().enabled = false;
        }
    }

    private void CollectCubePlayer(GameObject gameObject)
    {
        gameObject.transform.SetParent(transform);

        PositionOfCube(gameObject);

        gameObject.transform.tag = "Player";
        cubes.Add(gameObject);
        LastBlockUpdate();
    }

    void PositionOfCube(GameObject gameObject)
    {
        gameObject.transform.localPosition = new Vector3(0, 0.7f, -1.12f);

        for (int i = 0; i < cubes.Count; i++)
        {
            cubes[i].transform.localPosition = new Vector3(cubes[i].transform.localPosition.x,
                                            cubes[i].transform.localPosition.y + cubeOffset,
                                            cubes[i].transform.localPosition.z);

          
        }

        Quaternion objectRotation = transform.rotation;
        gameObject.transform.rotation = objectRotation;
    }

    private void LastBlockUpdate()
    {
        lastBlock = cubes[cubes.Count - 1];
    }
}
