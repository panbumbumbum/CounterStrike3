using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int maxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 1.5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 700f;
    private bool isReloading = false;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
    }

    public void Shoot()
    {
        if (isReloading || currentAmmo <= 0)
            return;

        // Shoot logic
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(firePoint.forward * bulletForce);

        currentAmmo--;
    }

    public void Reload()
    {
        if (!isReloading && currentAmmo < maxAmmo)
            StartCoroutine(ReloadRoutine());
    }

    private System.Collections.IEnumerator ReloadRoutine()
    {
        isReloading = true;
        // Optionally play reload animation/sound here
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
