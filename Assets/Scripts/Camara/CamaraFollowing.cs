using UnityEngine;
using System.Collections;

public class CamaraFollowing : MonoBehaviour {

	Transform target;
	Vector3 offset;
	float smoothing = 5f;
	void Start()
	{
		offset = transform.position - target.position;
	}

	void FixedUpate()
	{
		Vector3 pos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, pos, smoothing * Time.deltaTime);

	}
}
