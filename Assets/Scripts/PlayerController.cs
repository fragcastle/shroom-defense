using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	private Transform _cursorTarget;
	private int _gridSize = 6;
	
	public Transform SelectedTower;
	
	public int Life = 20;
	public int Money = 1000;
	
	void Start ()
	{
		_cursorTarget = transform.FindChild("regular-shroom");
	}
	
	void Update ()
	{
		RaycastHit hit;
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if (Physics.Raycast(ray, out hit))
		{
			var snapPosition = SnapXAndZToGrid(hit.point);
			
			_cursorTarget.position = snapPosition;
		
			if (Money >= 100 && Input.GetButtonDown("Fire1"))
			{
				var position = snapPosition;
				Instantiate(SelectedTower, new Vector3(position.x, hit.point.y, position.z), Quaternion.identity);
				
				Money -= 100;
			}
		}
	}
	
	private Vector3 SnapXAndZToGrid (Vector3 position)
	{
		return new Vector3(Mathf.Round(position.x / _gridSize) * _gridSize, position.y, Mathf.Round(position.z / _gridSize) * _gridSize);
	}
}
