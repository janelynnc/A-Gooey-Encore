using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    /*public Vector3 AverageVelocity;
    
    public Vector3 LastPosition;
    public List<Vector3> Velocities;*/
    public float Force = 10f;
    public ForceMode ForceType;
    public int Samples;
    public Transform SpawnPoint;
    public LayerMask Layers;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        //HotSpot = new Vector2(CrosshairTexture.width / 2, CrosshairTexture.height / 2);
        //Cursor.SetCursor(CrosshairTexture, HotSpot, CursorMode.ForceSoftware);
        //Cursor.visible = false;
        //LastPosition = transform.position;
        //StartCoroutine("Track");
    }

    // Update is called once per frame
    void Update()
    {
        /*Cursor.visible = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 SpawnPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        gameObject.transform.localPosition = SpawnPoint;
        if (Input.GetMouseButtonDown(0))
        {
            
            Rigidbody ShootingBullet = Instantiate(Bullet,SpawnPoint, Quaternion.LookRotation(ray.direction)).GetComponent<Rigidbody>();
            ShootingBullet.AddForce(ray.direction* Force, ForceType);
        }*/
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.forward, out Hit, Mathf.Infinity, Layers))
        {
            GameObject Slime = Hit.collider.gameObject;
            Slime.GetComponent<Animator>().SetTrigger("Target");
        }
    }

    public void shoot()
    {
        if (Time.timeScale > 0)
        {
            Rigidbody ShootingBullet = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            ShootingBullet.AddForce(gameObject.transform.forward * Force, ForceType);
        }
    }

    /*
    IEnumerator Track()
    {
        yield return new WaitUntil(() => Time.timeScale > 0);
        LastPosition = transform.position;
        float LastTime = Time.time;
        for(; ; )
        {
            if (Velocities.Count > Samples)
            {
                Velocities.Clear();
            }
            Vector3 Velocity = (transform.position - LastPosition)/(LastTime - Time.time);
            Velocities.Add(Velocity);
            Vector3 Sum = Vector3.zero;
            foreach(Vector3 V in Velocities)
            {
                Sum += V;
            }
            AverageVelocity = Sum / Velocities.Count;
            LastTime = Time.time;
            LastPosition = transform.position;
            yield return new WaitForEndOfFrame();
        }
    }
    */

}
