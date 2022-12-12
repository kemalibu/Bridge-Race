using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FindClosestCube : MonoBehaviour
{
    public GameObject FindClosestTarget(string trgt)
    {
        Vector3 position = transform.position;
        return GameObject.FindGameObjectsWithTag(trgt)
            .OrderBy(o => (o.transform.position - position).sqrMagnitude)
            .FirstOrDefault();
    }

}
