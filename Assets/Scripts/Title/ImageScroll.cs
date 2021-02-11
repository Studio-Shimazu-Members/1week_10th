using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;
using System;
using System.Text;
public class ImageScroll : MonoBehaviour
{
	[SerializeField] float speed = default;

    private void Start()
    {
    }

    void Update()
	{
		transform.Translate(0, Time.deltaTime* speed, 0);
		Debug.Log(transform.position.y);
		if (transform.position.y > 15)
		{
			transform.position = new Vector3(0, -26, 0);
		}
	}
}
