using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollider : MonoBehaviour
{
    public List<GameObject> cubes = new List<GameObject>();
    private GameObject lastBlock;

    [SerializeField] private float yOffset = 0.7f;
    [SerializeField] private float zOffset = -1.12f;
    [SerializeField] private float cubeOffset = 0.54f;



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
        gameObject.transform.localPosition = new Vector3(0, yOffset , zOffset);

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
