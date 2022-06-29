using UnityEngine;
using System.Collections.Generic;

public class HoleMovement : MonoBehaviour
{
	[Header("Ground Mesh")]
	[SerializeField] MeshFilter meshFilter;
	[SerializeField] MeshCollider meshCollider;

	[Header("Hole radius and vertices")]
	[SerializeField] Vector2 moveLimits;
	[SerializeField] float radius;
	[SerializeField] Transform holeCenter;
	


	[Space]
	[Space]
	[SerializeField] float moveSpeed;

	Mesh mesh;
	List<int> holeVertices;
	List<Vector3> offsets;
	int holeVerticesCount;

	float x, y;
	Vector3 touch, targetPos;

	void Start()
	{

		Game.isMoving = false;
		Game.isGameover = false;

		holeVertices = new List<int>();
		offsets = new List<Vector3>();

		mesh = meshFilter.mesh;

		FindHoleVertices();
	}


	void Update()
	{
		//Mouse
#if UNITY_EDITOR
		//isMoving mouse týklandýðýnda true býrakýldýðýnda false
		Game.isMoving = Input.GetMouseButton(0);

		if (!Game.isGameover && Game.isMoving)
		{
			MoveHole();
			UpdateHoleVerticesPosition();
		}


		//Touch
#else
		
		Game.isMoving = Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved;

		if (!Game.isGameover && Game.isMoving) {
		MoveHole ();
		UpdateHoleVerticesPosition ();
		}
#endif


	}

	void MoveHole()
	{
		x = Input.GetAxis("Mouse X");
		y = Input.GetAxis("Mouse Y");

		touch = Vector3.Lerp(
			holeCenter.position,
			holeCenter.position + new Vector3(x, 0f, y), 
			moveSpeed * Time.deltaTime
		);

		targetPos = new Vector3(
			//ground alanýndan çýkmamasý için clamp
			Mathf.Clamp(touch.x, -moveLimits.x, moveLimits.x),touch.y,Mathf.Clamp(touch.z, -moveLimits.y, moveLimits.y)
		);
		
		holeCenter.position = targetPos;
	}

	void UpdateHoleVerticesPosition()
	{
		//Deliðin vertexlerinin hareket ettir
		Vector3[] vertices = mesh.vertices;
		for (int i = 0; i < holeVerticesCount; i++)
		{
			vertices[holeVertices[i]] = holeCenter.position + offsets[i];
		}

		
		mesh.vertices = vertices;
		meshFilter.mesh = mesh;
		meshCollider.sharedMesh = mesh;
	}

	void FindHoleVertices()
	{
		for (int i = 0; i < mesh.vertices.Length; i++)
		{
			//deliðin merkezi ile herbir vertexin mesafesini hesapla, mesafesi küçük olan deliðin vertexi demektir
			float distance = Vector3.Distance(holeCenter.position, mesh.vertices[i]);

			if (distance < radius)
			{
				//bu vertex deliðin vertexi
				holeVertices.Add(i);
				// vertex deliðin merkezinden ne kadar uzakta
				offsets.Add(mesh.vertices[i] - holeCenter.position);
			}
		}
		//tüm vertex adeti
		holeVerticesCount = holeVertices.Count;
	}


	//Visualize
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(holeCenter.position, radius);
	}
}