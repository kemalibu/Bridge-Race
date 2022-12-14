using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeCollider : MonoBehaviour
{
    [SerializeField] private float yOffset = 0.6f;
    [SerializeField] private float zOffset = -1.12f;
    [SerializeField][Range(0f, 5f)] float durationTime = 0.5f;
    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] private int numJumps = 1;

    public List<GameObject> cubes = new List<GameObject>();


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BlueCube" && gameObject.tag == "Player")
        {
            CollectCubePlayer(other.gameObject);
        }

        else if (other.tag == "RedCube" && gameObject.tag == "RedPlayer")
        {
            CollectCubePlayer(other.gameObject);
            other.tag = gameObject.tag;
        }

        else if (other.tag == "PurpleCube" && gameObject.tag == "PurplePlayer")
        {
            CollectCubePlayer(other.gameObject);
            other.tag = gameObject.tag;
        }

        else if (other.tag == "GreenCube" && gameObject.tag == "GreenPlayer")
        {
            CollectCubePlayer(other.gameObject);
            other.tag = gameObject.tag;
        }

      
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Stair")
        {
            DeliverCube(other.gameObject);
            if (gameObject.tag == "Player")
            {   
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            }

        }
    }

    private void CollectCubePlayer(GameObject gameObject)
    {
        gameObject.transform.SetParent(transform);
        cubes.Add(gameObject);
        PositionOfCube(gameObject);
    }

    void PositionOfCube(GameObject gameObject)
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            Vector3 targetPos = new Vector3(0, (i + 1) * yOffset, zOffset);
            gameObject.transform.DOLocalJump(targetPos, jumpPower, numJumps, durationTime);
        }
        gameObject.transform.localRotation = Quaternion.identity;
    }

    private void DeliverCube(GameObject gameObject)
    {  
        if(cubes.Count > 0 )
        {   
            gameObject.SetActive(true);
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;

            Destroy(cubes[cubes.Count - 1]);
            cubes.RemoveAt(cubes.Count - 1);
        }
    }
}