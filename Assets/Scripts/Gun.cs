using UnityEngine;

public class Gun : MonoBehaviour
{
	public GameObject bulletPrefab;
	public float fireInterval = 0.5f;

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		GameObject obj = Instantiate( bulletPrefab, transform.position, transform.rotation );
		obj.GetComponent<Bullet>().owner = gameObject;
	}
}