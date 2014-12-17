using UnityEngine;
using System.Collections;

public class Cannonball : ProjectileBase
{
	private int _damping = 4;

	public float Speed = 1;
	public float HitDistance = 2;
	
	void Start ()
	{
	
	}
	
	void Update ()
	{
		var targetPosition = Target != null ? Target.transform.position : TargetPosition;
		
		MoveTowards(targetPosition);
		
		if (Vector3.Distance(transform.position, targetPosition) < 2)
		{
			if (Target != null)
			{
				Target.ApplyDamage(Damage);
			}
			
			Destroy(gameObject);
		}
		
		TargetPosition = targetPosition;
	}
	
	void MoveTowards(Vector3 targetPosition)
	{
		var lookPos = targetPosition - transform.position;
		lookPos.y = 0;
		var rotation = Quaternion.LookRotation(lookPos);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _damping);
		
		var newPosition = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
		
		transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
	}
}
