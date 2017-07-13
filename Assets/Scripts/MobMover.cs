using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMover : MonoBehaviour {

    Animator anim;

    public GameObject mob;

    public float moveSpeed;

    public Transform currentPoint;

    public Transform[] points;

    public int pointSelection;

    private bool reverseCheck = false;

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
        currentPoint = points[pointSelection];
        anim.SetBool("isMoving", true);
    }
	
	// Update is called once per frame
	void Update () {
        if (anim.GetBool("isDead") == false)
        {
            float speed = Time.deltaTime * moveSpeed;
            mob.transform.position = Vector3.MoveTowards(mob.transform.position, currentPoint.position, speed);
            if (mob.transform.position == currentPoint.position)
            {
                if (reverseCheck == false)
                    pointSelection++;
                else if (reverseCheck == true)
                    pointSelection--;
                if (pointSelection == points.Length)
                {
                    pointSelection -= 2;
                    reverseCheck = true;
                }
                if (pointSelection < 0)
                {
                    reverseCheck = false;
                    pointSelection = 0;
                }
                currentPoint = points[pointSelection];
            }
        }
    }
}
