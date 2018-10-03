using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDemo : MonoBehaviour
{
	public GameObject demoCube;

	private void LateUpdate()
	{
		Instantiate(demoCube, GetComponent<Area>().GetPoint(), demoCube.transform.rotation);
	}
}
