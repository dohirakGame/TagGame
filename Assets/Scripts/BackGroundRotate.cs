using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRotate : MonoBehaviour
{
    [SerializeField] private float speedRotate;

	private void Update()
	{
		this.gameObject.transform.localEulerAngles += new Vector3(0f, 1f, 0f) * speedRotate * Time.deltaTime;
	}
}
