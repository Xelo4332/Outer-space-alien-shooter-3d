using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{ // EJ ANV�NDS, HADE INTE TID MED DET OCH PROBELM MED AI DENI
     [SerializeField] private ParticleSystem _explosionEffects;
    [SerializeField] private int _explosionDamage;
    [SerializeField] private float _delayExplosion;
    [SerializeField] private float _explosionDistance;
    private Rigidbody _enemybody;
    private Player _player;


    //Here we will override our awake method to get our Rigidbody component.
    private void Awake()
    {
        
        _enemybody = GetComponent<Rigidbody>();


    }
    //If enemy collider with player, it will turn off dessetter script, make rigidbody to static, freeze rotation and start expolosion courtine.
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            
            StartCoroutine(ZombieExplosion());

        }
    }
    //Here will we have our Explosion delay and a simple checker to play couldn't activate it twice.
    private IEnumerator ZombieExplosion()
    {
        yield return new WaitForSeconds(_delayExplosion);
        if (gameObject)
        {
            Expolode();
        }
  

    }

   
    //H�r kommer vi r�kna ut distancen med hj�lp av Vector 2 distance method som till�ter anv�nda distancer ist�llet f�r att skapa collider. 
    //Vi s�tter en distans, om distans �r st�rre distans vi har skriven in, d� kommer activeras method tryget damage.
    //Vi kommer ocks� spawna particlar fr�n v�ra prefabs och f�rst�ra sj�lva v�ran zombie objekten.
    private void Expolode()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < _explosionDistance)
        {
           //damage script;

        }
        Instantiate(_explosionEffects, transform.position, Quaternion.identity);
        Destroy(gameObject);
        

    }
}
