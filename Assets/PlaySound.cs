using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlaySound : MonoBehaviour
{
    private AudioSource Song;
    private GameObject Note;
    public SlimeGenerator Generator;
    public string Tag;

    public float EndTime = -1f;
    public float Duration;
    public float ExtraTime;
    public float Penalty;

    public string DeathAnimation;
    public GameObject AimHelper;
    public bool Started = false;
    // Start is called before the first frame update
    void Start()
    {
        Note = GameObject.FindGameObjectWithTag("HitBox");
        
        Generator = GameObject.Find("Slimes").GetComponent<SlimeGenerator>();
        //Sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnEnable()
    {
       
    }

    private void OnDisable()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            //Sound.Play();
            StopAllCoroutines();
            Destroy(collision.gameObject);
            //Sound.mute = false;
            if (EndTime > -1f)
            {
                Note.GetComponent<PlayNote>().Hit(Tag, EndTime);
            }
            GetComponent<Animator>().Play(DeathAnimation);
            Generator.NextNote();
            Generator.Slimes.Remove(gameObject);
            //Destroy(gameObject);
            //StartCoroutine("Death");
        }
    }

    public IEnumerator Timer()
    {
        AimHelper.SetActive(true);
        Song = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        Started = true;
        for (; ; )
        {
            if(Song.time >= EndTime + ExtraTime)
            {
                Generator.NextNote();
                Generator.Slimes.Remove(gameObject);
                GetComponent<Animator>().Play("Death");
                Image Rep = GameObject.FindGameObjectWithTag("Rep").GetComponent<Image>();
                Rep.fillAmount = Mathf.Clamp01(Rep.fillAmount - Penalty);
                break;
            }
            AimHelper.GetComponent<Image>().fillAmount = 1 - ((EndTime - Song.time) / Duration);
            yield return null; 
        }

    }
   
}
