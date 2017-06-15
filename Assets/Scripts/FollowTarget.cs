using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	public Transform target;
	//the object we are following

	Vector3 velocity = Vector3.zero;

	//time to follow target
	public float smoothTime = .15f;

	//enable and set maximum y-value
	public bool YmaxEnabled = false;
	public float YmaxValue = 0;

	//enable and set minimum y-value
	public bool YminEnabled = false;
	public float YminValue = 0;

	//enable and set maximum x-value
	public bool XmaxEnabled = false;
	public float XmaxValue = 0;

	//enable and set minimum x-value
	public bool XminEnabled = false;
	public float XminValue = 0;

	void FixedUpdate ()
	{

		//target position
		Vector3 targetPosition = target.position;

		//vertical
		if (YminEnabled && YmaxEnabled)
			targetPosition.y = Mathf.Clamp (target.position.y, YminValue, YmaxValue);
		else if (YminEnabled)
			targetPosition.y = Mathf.Clamp (target.position.y, YminValue, target.position.y);
		else if (YmaxEnabled)
			targetPosition.y = Mathf.Clamp (target.position.y, target.position.y, YmaxValue);
	
		//horizontal
		if (XminEnabled && XmaxEnabled)
			targetPosition.x = Mathf.Clamp (target.position.x, XminValue, XmaxValue);
		else if (XminEnabled)
			targetPosition.x = Mathf.Clamp (target.position.x, XminValue, target.position.x);
		else if (XmaxEnabled)
			targetPosition.x = Mathf.Clamp (target.position.x, target.position.x, XmaxValue);
		
		//align camera and the target z position
		targetPosition.z = transform.position.z;

		//gradually change the camera transform position to the target position based on camera's transform velocity and our smooth time
		transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, smoothTime);
	}
}
