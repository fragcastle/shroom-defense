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
		TargetPosition = Target != null ? Target.transform.position : TargetPosition;
		
		MoveTowards(TargetPosition);
		
		if (Vector3.Distance(transform.position, TargetPosition) < HitDistance)
		{
			if (Target != null)
			{
				Target.ApplyDamage(Damage);
			}
			
			Destroy(gameObject);
		}
		else if (Target == null && Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(TargetPosition.x, TargetPosition.z)) < HitDistance)
		{
			Destroy(gameObject);
		}
	}
	
	void MoveTowards(Vector3 targetPosition)
	{
		var lookPos = targetPosition - transform.position;
		
		var rotation = Quaternion.LookRotation(lookPos);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _damping);
		
		var newPosition = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
		
		transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
	}
}
