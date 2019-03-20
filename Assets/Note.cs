using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Note : MonoBehaviour
{
    private Rigidbody2D RGBD;
    public float Force;
    public float Penalty;
    // Start is called before the first frame update
    void Start()
    {
        RGBD = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RGBD.velocity = new Vector2(Force, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("Rep").GetComponent<Image>().fillAmount = Mathf.Clamp01(GameObject.FindGameObjectWithTag("Rep").GetComponent<Image>().fillAmount-Penalty);
        Destroy(gameObject);
    }
}
