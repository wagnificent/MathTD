using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] GameObject ProjectilePrefab;

    public float M1 = 0f;
    public float M2 = 0f;
    public float B = 0.1f;

    private float X;
    private float Z;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 1f, 1f);
        X = Time.time;
    }

    private void SetProjectilePath()
    {
        //Create a list of equidistant points along the projectile path
        Z = (M2 * X * X) + (M1 * X) + B;
        transform.position += new Vector3(X, 0f, Z);
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(ProjectilePrefab);
        projectile.transform.position = this.transform.position;
        //pass the path to the projectile
    }

    public List<Vector3> GetProjectilePath()
    {
        return null;
    }
}
