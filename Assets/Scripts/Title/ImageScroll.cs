using UnityEngine;
public class ImageScroll : MonoBehaviour
{
	[SerializeField] float speed = default;

    private void Start()
    {
    }

    void Update()
	{
		transform.Translate(0, Time.deltaTime* speed, 0);
		if (transform.position.y > 15)
		{
			transform.position = new Vector3(0, -26, 0);
		}
	}
}
