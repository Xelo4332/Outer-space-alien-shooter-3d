
using UnityEngine;

public class Melee : MonoBehaviour
{
    public int damage;
    public float range;
    public float hitRate = 0.25f;
    private float nextTimeToHit = 0f;

    public Camera fpsCam;


    void Update()
    {
        if (Input.GetKey(KeyCode.V) && Time.time >= nextTimeToHit)
        {
            nextTimeToHit = Time.time + hitRate;
            Hit();
        }
    }

    void Hit()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Zombie target = hit.transform.GetComponent<Zombie>();
            if (target != null)
            {
                target.Damage(damage);
            }
            Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward, Color.red, range);
        }
        Debug.LogError("Mashallah man kan tro jag gokku");
    }
}
