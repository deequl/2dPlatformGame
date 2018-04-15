using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour {

    public Transform target;
    public float speed;

    private Vector3 startPosition, endPosition;

    private void Start()
    {
        if(target != null)
        {
            target.parent = null;
            startPosition = transform.position;
            endPosition = target.position;
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }

        if(transform.position == target.position)
        {
            target.position = (target.position == startPosition) ? endPosition : startPosition;
        }
    }
}
