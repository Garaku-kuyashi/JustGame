using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShotting : MonoBehaviour
{
    public GameObject bulletObject;
    public Transform bulletOut;
    public float shootForce;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bulletObject, bulletOut.position, bulletOut.rotation);
            bulletClone.GetComponent<Rigidbody>().AddForce(shootForce * bulletOut.forward);
        }
    }
}
