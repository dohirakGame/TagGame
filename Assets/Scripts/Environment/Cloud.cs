using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
	[SerializeField] private float speed;

	private void Update()
	{
		gameObject.transform.Translate(new Vector3(0f, 0f, -2f) * speed * Time.deltaTime);

		if (gameObject.transform.position.z < 4.5f) gameObject.transform.position = new Vector3(-1f, -15f, 329f);
	}
}
