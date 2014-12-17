using UnityEngine;
using System.Collections;

public class GroundEnemy : EnemyBase
{
	public float MoveSpeed = 1;
	
	void Start ()
	{
	
	}
	
	void Update ()
	{
		var moveSpeed = MoveSpeed * Time.deltaTime;
		
		transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
	}
}
