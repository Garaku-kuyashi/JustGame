using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(LifeTime());
    }
    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision objectYangKena)
    {
        if (objectYangKena.transform.CompareTag("Enemy"))
        {
            objectYangKena.gameObject.GetComponent<Light>().enabled = false;
            // objectYangKena.gameObject.SetActive(false);
        }
    }
}
