using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public Transform SelectedTower;
	
	void Start ()
	{
		
	}
	
	void Update ()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit))
			{
				var position = hit.point;
				Instantiate(SelectedTower, new Vector3(position.x, SelectedTower.position.y, position.z), Quaternion.identity);
			}
		}
	}
}
