using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamEx : MonoBehaviour
{
    public Transform target;
	public Vector3 offset;
	public float smooth;

	Vector3 velocity = Vector3.zero;
	void LateUpdate()
	{
		Vector3 movePosition = target.position + offset;
		transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, smooth);
	}
}
