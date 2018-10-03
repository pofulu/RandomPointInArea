using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
	public Color color = Color.gray;

	public Vector3 GetPoint()
	{
		float minX = transform.position.x - (transform.localScale.x / 2);
		float maxX = transform.position.x + (transform.localScale.x / 2);

		float minY = transform.position.y - (transform.localScale.y / 2);
		float maxY = transform.position.y + (transform.localScale.y / 2);

		float minZ = transform.position.z - (transform.localScale.z / 2);
		float maxZ = transform.position.z + (transform.localScale.z / 2);

		float x = Random.Range(minX, maxX);
		float y = Random.Range(minY, maxY);
		float z = Random.Range(minZ, maxZ);

		return RotatePointAroundPivot(new Vector3(x, y, z), transform.position, transform.eulerAngles);
	}

	private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
	{
		Vector3 dir = point - pivot;
		dir = Quaternion.Euler(angles) * dir;
		point = dir + pivot;
		return point;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = color;
		DrawCube(transform.position, transform.rotation, transform.localScale);
	}

	private static void DrawCube(Vector3 position, Quaternion rotation, Vector3 scale)
	{
		Matrix4x4 cubeTransform = Matrix4x4.TRS(position, rotation, scale);
		Matrix4x4 oldGizmosMatrix = Gizmos.matrix;

		Gizmos.matrix *= cubeTransform;

		Gizmos.DrawCube(Vector3.zero, Vector3.one);

		Gizmos.matrix = oldGizmosMatrix;
	}
}
