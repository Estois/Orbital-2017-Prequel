using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public GameObject platform;

	public float moveSpeed;

	public Transform currentPoint;

	public Transform[] points;

    public int pointSelection;

    private bool reverseCheck = false;

	// Use this for initialization
	void Start () {
        currentPoint = points[pointSelection];
	}

	// Update is called once per frame
	void Update () {
        float speed = Time.deltaTime * moveSpeed;
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, speed);
        if(platform.transform.position == currentPoint.position)
        {
            if (reverseCheck == false)
                pointSelection++;
            else if(reverseCheck == true)
                pointSelection--;
            if (pointSelection == points.Length)
            {
                pointSelection -= 2;
                reverseCheck = true;
            }
            if(pointSelection < 0)
            {
                reverseCheck = false;
                pointSelection = 0;
            }
            currentPoint = points[pointSelection];
        }
	}
}
