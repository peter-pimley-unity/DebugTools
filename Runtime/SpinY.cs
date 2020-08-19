using UnityEngine;

public class SpinY : MonoBehaviour
{
	[SerializeField]
	private float m_speed = 90.0f; // degrees per second.

	// Update is called once per frame
	void Update()
	{
		float theta = m_speed * Time.deltaTime;
		transform.RotateAround(Vector3.up, theta * Mathf.Deg2Rad);
	}
}
