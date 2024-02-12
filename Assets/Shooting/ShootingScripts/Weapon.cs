
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{
    public Text ammoText;

    public int damage;
    public float range;
    public float fireRate = 0.25f;
    protected float nextTimeToFire = 0f;

    public bool singleOrAuto = false;
    public bool burst = false;

    public int bulletsPerBurst = 3;
    public int currentBurst;

    public float spreadIntensity;

    public float verticalRecoil;
    public float horizontalRecoil;

    public float reloadTime;
    public int magazineSize, bulletsLeft;
    public bool isReloading;

    public Camera fpsCam;
    private Collision raycastHit;
    [SerializeField]
    public GameObject bulletImpactEffectPrefab;

    public ParticleSystem muzzleEffect;
    private Animator animator;

    public bool isSprinting = false;
    //Deni gör audio
    [SerializeField] private AudioClip _shoootingSound;
    [SerializeField] private AudioClip _reloadingSound;
    private AudioSource _weaponSource;

    private void Start()
    {
        bulletsLeft = magazineSize;
        isReloading = false;
        animator = GetComponent<Animator>();
        _weaponSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(singleOrAuto == true && isReloading == false && isSprinting == false && Input.GetButton("Fire1") && Time.time >= nextTimeToFire && bulletsLeft > 0)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
        else if(burst == true && isReloading == false && isSprinting == false && Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentBurst == 0 && bulletsLeft > 0)
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
                animator.SetTrigger("Reload");
                print("Reloading");
            }
            
        }

        ammoText.text = bulletsLeft.ToString() + " / 30";
    }

    void Shoot()
    {
        muzzleEffect.Play();
        animator.SetTrigger("Recoil");
        _weaponSource.clip = _shoootingSound;
        _weaponSource.Play();

        Vector3 shootingDirection = calculateDirectionAndSpread().normalized;
        RaycastHit hit;
        fpsCam.transform.forward = shootingDirection;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Zombie target = hit.transform.GetComponent<Zombie>();
            if(target != null)
            {
                target.Damage(damage);
            }

            bulletsLeft--;
        }
        print("Shooting");
    }

    private void Reload()
    {
        
        isReloading = true;
        Invoke("ReloadCompleted", reloadTime);
        _weaponSource.clip = _reloadingSound;

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
