using UnityEngine;
using System.Collections;

public class BasicTower : TowerBase
{
	private EnemyBase _target;
	private int _damping = 4;
	
	public float FireRate = 1;
	public float FireRateDelay = 1;
	public Transform Projectile;
	
	void Start ()
	{
	
	}
	
	void Update ()
	{
		if (_target == null)
		{
			var enemies = GameObject.FindObjectsOfType(typeof(GroundEnemy));
			
			if (enemies.Length == 0)
				return;
				
			var target = enemies[Mathf.FloorToInt(Random.value * (enemies.Length - 1))];
			_target = (GroundEnemy)target;
		}
		
		if (_target != null)
		{
			var lookPos = _target.transform.position - transform.position;
			lookPos.y = 0;
			var rotation = Quaternion.LookRotation(lookPos);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _damping);
			
			// Another way of rotating towards the target
//			Vector3 targetDir = _target.transform.position - transform.position;
//			float step = 2 * Time.deltaTime;
//			Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
//			Debug.DrawRay(transform.position, newDir, Color.red);
//			transform.rotation = Quaternion.LookRotation(newDir);

			FireRateDelay -= FireRate * Time.deltaTime;
			
			if (FireRateDelay <= 0)
			{
				var projectile = (Transform)Instantiate(Projectile);
				
				projectile.position = new Vector3(transform.position.x, projectile.position.y, transform.position.z);
				projectile.GetComponent<ProjectileBase>().Target = _target;
				
				FireRateDelay = FireRate;
			}
		}
	}
}
