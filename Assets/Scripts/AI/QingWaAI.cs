using UnityEngine;
using System.Collections;

public class QingWaAI :MonoBehaviour
{
	// Use this for initialization
	void Start () 
	{
		Enter ();
	}

	public float x_speed = 10f; //水平方向速度
	public float y_speed = 1f; //垂直方向速度
	public float x_a = -0.5f; //加速度
	public float moveDistance = 7f;
	
	float y_targetSpeed = 0f;
	bool stopMove = true;
	Vector3 direction = Vector3.zero;

	public void Enter() 
	{
		stopMove = false;
		x_speed = 10;
		y_speed = 1;

		x_a = (-2) * x_speed * y_speed / moveDistance; 
		y_targetSpeed = y_speed; 
	}
	
	void Update() 
	{
		if (Input.GetKeyDown (KeyCode.A)) {
			Enter();		
		}
		if (stopMove)
			return;
		
		y_speed = y_speed + x_a * Time.deltaTime;
		if (y_speed < y_targetSpeed * -1) {
			stopMove = true;
			return;
		}

		direction = (Vector3.right * x_speed + Vector3.up * y_speed) * Time.deltaTime;
		Debug.Log ("direction=" + direction);
		transform.Translate(direction);
	}
	

}
