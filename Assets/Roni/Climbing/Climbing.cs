using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Climbing : MonoBehaviour
{
    // Start is called before the first frame update
    private int vaultLayer;
    public Camera cam;
    private float playerHeight = 2f;
    private float playerRadius = 0.5f;

    [SerializeField]
    private GameObject gameObject;

    void Start()
    {
        vaultLayer = LayerMask.NameToLayer("VaultLayer");
        vaultLayer = ~vaultLayer;
    }

    // Update is called once per frame
    void Update()
    {
        Vault();
    }
    private void Vault()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out var firstHit, 2f, vaultLayer))
            {
                print("vaultable in front");
                gameObject.SetActive(true);
                if (Physics.Raycast(firstHit.point + (cam.transform.forward * playerRadius) + (Vector3.up * 1f * playerHeight), Vector3.down, out var secondHit, playerHeight))
                {
                    print("found place to land");
                    gameObject.SetActive(false);
                    StartCoroutine(LerpVault(secondHit.point, 0.5f));
                }
            }
        }

    }
    IEnumerator LerpVault(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}