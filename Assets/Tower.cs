using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] float XIncrement = 0.2f;

    [SerializeField] private float Slope = 1f;
    [SerializeField] private float Curve = 0f;
    [SerializeField] private float Offset = 0f;

    private float X = 0f;
    private float Z = 0f;

    private bool isXnegative = false;

    [SerializeField] private List<Vector3> ProjectilePath = new List<Vector3>();

    public void SetProjectilePath()
    {
        //Create a list of equidistant points along the projectile path

        ProjectilePath = new List<Vector3>();
        
        X = 0;
        Z = (Curve * X * X) + (Slope * X) + Offset;

        ProjectilePath.Add(new Vector3(X, transform.position.y, Z));

        while (ProjectilePath.Count < 100)
        {
            if (isXnegative)
            {
                X -= XIncrement;
            }
            else
            {
                X += XIncrement;
            }

            Z = (Curve * X * X) + (Slope * X) + Offset;

            Vector3 newPoint = new Vector3(X, transform.position.y, Z);

            ProjectilePath.Add(newPoint);
        }

        CeaseFire();
        InvokeRepeating("Fire", 1f, 1f);
    }

    private void Fire()
    {
        GameObject g = Instantiate(ProjectilePrefab);
        g.transform.position = this.transform.position;
        Projectile p = g.GetComponent<Projectile>();
        p.SetPath(ProjectilePath);
    }

    public void CeaseFire()
    {
        CancelInvoke();
    }

    public List<Vector3> GetProjectilePath()
    {
        return ProjectilePath;
    }

    public void SetSlope(float slope)
    {
        Slope = slope;
    }

    public void SetCurve(float curve)
    {
        Curve = curve;
    }

    public void SetOffset(float offset)
    {
        Offset = offset;
    }

    public void SetNegative(bool b)
    {
        isXnegative = b;
    }
}
