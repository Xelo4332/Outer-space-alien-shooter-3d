
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    public float range;
    public float fireRate = 0.25f;
    private float nextTimeToFire = 0f;

    public bool singleOrAuto = false;
    public bool burst = false;

    public int bulletsPerBurst = 3;
    public int currentBurst;

    public float spreadIntensity;

    public float reloadTime;
    public int magazineSize, bulletsLeft;
    public bool isReloading;

    public Camera fpsCam;
    private Collision raycastHit;
    [SerializeField]
    public GameObject bulletImpactEffectPrefab;

    private void Start()
    {
        bulletsLeft = magazineSize;
        isReloading = false;
    }

    void Update()
    {
        if(singleOrAuto == true && isReloading == false && Input.GetButton("Fire1") && Time.time >= nextTimeToFire && bulletsLeft > 0)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
        else if(burst == true && isReloading == false && Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentBurst == 0 && bulletsLeft > 0)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
            Shoot();
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize)
        {
            if(isReloading == false)
            {
                Reload();
                print("Reloading");
            }
            
        }
    }

    void Shoot()
    {
        Vector3 shootingDirection = calculateDirectionAndSpread().normalized;
        RaycastHit hit;
        fpsCam.transform.forward = shootingDirection;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            bulletsLeft--;
        }
        print("Shooting");
    }

    private void Reload()
    {
        isReloading = true;
        Invoke("ReloadCompleted", reloadTime);
        print("Reloading...");
    }

    private void ReloadCompleted()
    {
        bulletsLeft = magazineSize;
        isReloading = false;
        print("Reload Completed");
    }

    public Vector3 calculateDirectionAndSpread()
    {
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if(Physics.Raycast(ray,out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100);
        }

        Vector3 direction = targetPoint - fpsCam.transform.position;

        float x = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);
        float y = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);

        return direction + new Vector3(x, y, 0);
    }

    void CreateBulletImpactHole(Collision raycastHit)
    {
        ContactPoint contact = raycastHit.contacts[0];

        GameObject hole = Instantiate(bulletImpactEffectPrefab, 
            contact.point,Quaternion.LookRotation(contact.normal));

        hole.transform.SetParent(raycastHit.gameObject.transform);
    }
}
