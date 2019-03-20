using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNote : MonoBehaviour
{
    [SerializeField] private AudioSource Sound;
    public List<float> NoteTimes;

    public List<float> StartTimes;
    public List<float> EndTimes;
    public List<string> EventType;

    public GameObject prefabA,prefabB,prefabC;
    public string CurrentKeyDown;

    public KeyCode key;
    public int Current = 0;
    public bool creating;
    public List<GameObject> Monsters;
    private int wake = 0;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GetComponent<AudioSource>();
        foreach(GameObject slime in Monsters)
        {
           // slime.SetActive(false);
        }
        /* if (creating)
         {
             StartTimes.Clear();
             EndTimes.Clear();
             EventType.Clear();
         }
         */
       // Monsters[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(!creating && Sound.time>= EndTimes[Current] && Current<EndTimes.Count-1)
        {
            print("beat");
            Current++;
            //Monsters[0].GetComponent<PlaySound>().Length = EndTimes[Current];
        }
        /*
        if (!creating && Sound.time >= EndTimes[Current])
        {
            if (Current < EndTimes.Count - 1)
            {
                if (Monsters[wake].activeInHierarchy)
                {
                    //Sound.mute = true;
                }
                Monsters[wake].SetActive(false);
                wake = Random.Range(0, Monsters.Count);
                Monsters[wake].SetActive(true);
                Monsters[wake].GetComponent<PlaySound>().Length = EndTimes[Current];
                Current++;

                //print(NoteTimes[Current]);
            }
        }
        else if (creating)
        {
            if (Sound.time >= EndTimes[Current])
            {
                Instantiate(prefab, transform.position, Quaternion.identity);
                Current++;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                EventType.Add(Input.inputString);
                StartTimes.Add(Sound.time);
                Monsters[0].SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                EndTimes.Add(Sound.time);
                Monsters[0].SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                EventType.Add(Input.inputString);
                StartTimes.Add(Sound.time);
                Monsters[1].SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                EndTimes.Add(Sound.time);
                Monsters[1].SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                EventType.Add(Input.inputString);
                StartTimes.Add(Sound.time);
                Monsters[2].SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                EndTimes.Add(Sound.time);
                Monsters[2].SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                EventType.Add(Input.inputString);
                StartTimes.Add(Sound.time);
                Monsters[3].SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {
                EndTimes.Add(Sound.time);
                Monsters[3].SetActive(false);
            }
        }*/
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Sound.Play();
            Instantiate(prefabA,transform.position,Quaternion.identity);
        }else if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(prefabB, transform.position, Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(prefabC, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Sound.Play();
    }
}
