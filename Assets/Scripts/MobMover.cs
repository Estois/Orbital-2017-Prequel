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

    private bool faceLeft = false;

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
                if (faceLeft == false)
                    pointSelection++;
                else if (faceLeft == true)
                    pointSelection--;
                if (pointSelection == points.Length)
                {
                    pointSelection -= 2;
                    faceLeft = true;
                    Flip();
                }
                if (pointSelection < 0)
                {
                    faceLeft = false;
                    pointSelection = 0;
                    Flip();
                }
                currentPoint = points[pointSelection];
            }
        }
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;

        //flip on x-axis
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
