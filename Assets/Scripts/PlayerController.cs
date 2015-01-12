using UnityEngine;
using System.Collections;

public class PlayerController : BaseBehavior
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
		if (!IsMobile())
		{
			RaycastHit hit;
			
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit))
			{
				var snapPosition = SnapXAndZToGrid(hit.point);
				
				_cursorTarget.position = snapPosition;
			}
		}
		
		if (Input.GetButtonDown("Fire1") || (Input.touchCount > 0))
		{
			if (Money >= 100)
			{
				RaycastHit hit;
				
				var position = IsMobile() ? new Vector3(Input.touches[0].position.x, Input.touches[0].position.y) : Input.mousePosition;
				
				var ray = Camera.main.ScreenPointToRay(position);
				
				if (Physics.Raycast(ray, out hit))
				{
					var snapPosition = SnapXAndZToGrid(hit.point);
					Instantiate(SelectedTower, new Vector3(snapPosition.x, hit.point.y, snapPosition.z), Quaternion.identity);
					
					Money -= 100;
				}
			}
		}
	}
	
	private Vector3 SnapXAndZToGrid (Vector3 position)
	{
		return new Vector3(Mathf.Round(position.x / _gridSize) * _gridSize, position.y, Mathf.Round(position.z / _gridSize) * _gridSize);
	}
}
