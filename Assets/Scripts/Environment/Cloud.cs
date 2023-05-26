using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
	[SerializeField] private float speed;
	private float _yHeight;
	private void Start()
	{
		_yHeight = FindObjectOfType<Clouds>().GetYHeight();
	}
	private void Update()
	{
		gameObject.transform.Translate(new Vector3(0f, 0f, -2f) * speed * Time.deltaTime);

		if (gameObject.transform.position.z < 4.5f) gameObject.transform.position = new Vector3(-1f, _yHeight, 329f);
	}
}
