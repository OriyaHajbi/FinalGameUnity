
using UnityEngine;

public class NewShooting : MonoBehaviour
{

    public float damage = 10f;
    public float impactForce = 30f;
    public float range = 100f;
    public float fireRate = 15f;

    private float nextTimeToFire = 0f;

    public Camera camera;
    public ParticleSystem muzzleFlash;

    public GameObject impactEffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {

        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position , camera.transform.forward , out hit, range))
        {
            Debug.Log(hit.transform.name);

            TargetShoot target = hit.transform.GetComponent<TargetShoot>();
            if ( target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
        }
    }
}
