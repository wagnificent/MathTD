using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private List<Vector3> Path = new List<Vector3>();
    private int nodeIndex = 0;
    private float speed = 1f;
    private float distanceToNextNode;
    private float interval;
    private float timer;
    

    private void Update()
    {
        if(Path.Count > 0 && nodeIndex < Path.Count)
        {
            //Move();
        }
    }

    private void Move()
    {
        
        if (transform.position == Path[nodeIndex] && nodeIndex + 1 < Path.Count)
        {
            nodeIndex++;
            distanceToNextNode = Vector3.Distance(transform.position, Path[nodeIndex]);
            interval = speed / distanceToNextNode;
            timer = interval;
        }
        else
        {
            timer += interval;
            if(timer > 1f) { timer = 1f; }
        }

        transform.position = Vector3.Lerp(transform.position, Path[nodeIndex], timer);
        //transform.position = Vector3.MoveTowards(transform.position, Path[nodeIndex], speed);
        //Debug.Log(transform.position);
    }

    private void GoToNextNode()
    {
        nodeIndex++;
        distanceToNextNode = Vector3.Distance(transform.position, Path[nodeIndex]);
        timer = distanceToNextNode / speed;
        StartCoroutine(LerpPosition(Path[nodeIndex], timer));
    }

    IEnumerator MoveProjectile()
    {
        transform.position = Vector3.MoveTowards(transform.position, Path[nodeIndex], speed);
        yield return null;
    }

    IEnumerator LerpPosition(Vector3 targetPos, float duration)
    {
        float t = 0;
        Vector3 startPos = transform.position;
        while (t < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            t += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
        GoToNextNode();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Trigger damage/explosion/etc.
        Destroy(this.gameObject);
    }

    public void SetPath(List<Vector3> path)
    {
        Path = path;
        nodeIndex = 0;
        transform.position = Path[0];
        GoToNextNode();
    }
}
