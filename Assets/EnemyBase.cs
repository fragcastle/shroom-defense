using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour
{
	public int Health = 100;
	
	public Transform DeathEffect;

	public void ApplyDamage(int damage)
	{
		Health -= damage;
		
		if (Health <= 0)
		{
			Instantiate(DeathEffect, transform.position, Quaternion.identity);
            
			Destroy(gameObject);
		}
	}
}
