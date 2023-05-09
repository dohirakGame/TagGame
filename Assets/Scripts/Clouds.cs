using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField] private List<GameObject> clouds;
	private void Start()
	{
		Instantiate(clouds[0], new Vector3(-1f,-15f,170f),Quaternion.identity);
		Instantiate(clouds[1], new Vector3(-1f,-15f,10f), Quaternion.identity);
	}
}
