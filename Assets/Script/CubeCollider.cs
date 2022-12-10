using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeCollider : MonoBehaviour
{
    public List<GameObject> cubes = new List<GameObject>();

    [SerializeField] private float yOffset = 0.6f;
    [SerializeField] private float zOffset = -1.12f;
    [SerializeField][Range(0f, 5f)] float durationTime = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerCube")
        {
            CollectCubePlayer(other.gameObject);
        }
    }

    private void CollectCubePlayer(GameObject gameObject)
    {
        gameObject.transform.SetParent(transform);
        cubes.Add(gameObject);
        gameObject.transform.tag = "Player";
        PositionOfCube(gameObject);
    }

    void PositionOfCube(GameObject gameObject)
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            Vector3 targetPos = new Vector3(0, (i + 1) * yOffset, zOffset);
            gameObject.transform.DOLocalMove(targetPos, durationTime, snapping: false);
        }

        Quaternion objectRotation = transform.rotation;
        gameObject.transform.rotation = objectRotation;
    }
}
