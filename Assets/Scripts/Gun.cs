using UnityEngine;

public class Gun : MonoBehaviour
{
	public GameObject bulletPrefab;

	public int maxAmmo = 10;
	public int currentAmmo;

	public bool isAutomatic = true;
	public float fireInterval = 0.5f;
	public float fireCooldown;

	AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		currentAmmo = maxAmmo;
	}

	void Update()
	{
		if (!isAutomatic &&Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}

		if (isAutomatic &&Input.GetButton("Fire1") && fireCooldown <= 0)
		{
			Shoot();
			fireCooldown = fireInterval;
		}

		fireCooldown -= Time.deltaTime;
	}

	void Shoot()
	{
		if(currentAmmo <= 0) return;
		currentAmmo--;

		GameObject obj = Instantiate( bulletPrefab, transform.position, transform.rotation );
		obj.GetComponent<Bullet>().owner = gameObject;

		audioSource.PlayOneShot(audioSource.clip);
	}
}