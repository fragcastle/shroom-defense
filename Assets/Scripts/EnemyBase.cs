using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour
{
	public int Health = 100;
	public float MoveSpeed = 1;
	public int Reward = 20;
	
	public Transform DeathEffect;

	public void ApplyDamage(int damage)
	{
		Health -= damage;
		
		if (Health <= 0)
		{
			var playerController = GameObject.Find("PlayerController");
			
			playerController.GetComponent<PlayerController>().Money += Reward;
		
			Instantiate(DeathEffect, transform.position, Quaternion.identity);
            
			Destroy(gameObject);
		}
	}
}
