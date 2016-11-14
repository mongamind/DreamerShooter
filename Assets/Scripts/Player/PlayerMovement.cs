using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 1f;
	public float maxRaycastDistance = 100f;
	private Animator anim;

	private int floorLayermask;
	private Rigidbody playerRigidbody;
	void Awake()
	{
		playerRigidbody = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		floorLayermask = LayerMask.GetMask("Floor");
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		Move (h, v);
		Rotate ();
	}

	void Move(float h,float v)
	{
		anim.SetBool ("isWalking", h != 0 || v != 0);
		Vector3 toward = new Vector3 (h, 0f, v);
		toward.Normalize ();
		playerRigidbody.MovePosition (playerRigidbody.position +  toward * speed * Time.deltaTime);
	}

	void Rotate()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit raycastHit;

		if (Physics.Raycast (ray,out raycastHit, maxRaycastDistance, floorLayermask)) {
			Vector3 playerToMouse = raycastHit.point - transform.position;

			playerToMouse.y = 0f;
			Quaternion quaternion = Quaternion.LookRotation (playerToMouse);
			playerRigidbody.MoveRotation (quaternion);
		}
			
	}
}
