using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public RotisonToMouse rotateMouse;


    private GameObject effectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        //GameObject vfx;
        if (firePoint != null)
        {
            GameObject spawnedEffect = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            //vfx.Add(spawnedEffect);

            if(rotateMouse != null)
            {
                spawnedEffect.transform.localRotation = rotateMouse.getRotation();

            }
        }
        else
        {
            Debug.Log("Khong co dan");
        }
    }
}
