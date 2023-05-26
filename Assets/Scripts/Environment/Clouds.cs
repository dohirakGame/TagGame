using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField] private List<GameObject> clouds;

	[SerializeField] private float yHeight;

	public float GetYHeight()
	{
		return yHeight;
	}
	private void Start()
	{
		Instantiate(clouds[0], new Vector3(-1f,yHeight,170f),Quaternion.identity);
		Instantiate(clouds[1], new Vector3(-1f,yHeight,10f), Quaternion.identity);
	}
}
