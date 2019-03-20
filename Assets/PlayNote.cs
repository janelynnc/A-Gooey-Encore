using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayNote : MonoBehaviour
{
    
   
    public float Reward;
    [SerializeField] private float Realtime;
    public AudioSource Song;
    public bool Setup;
    public string LoseScene, WinScene;
    public Animator Curtains;
    public float Offset;

    public SlimeGenerator generator;
    public NoteList Notes;

    public List<float> HitTimes;
    private int Index = 0;

    private GameObject Target;
    public GameObject AimHelper;

    
    public float Penalty;
    private float duration;
    
    // Start is called before the first frame update
    void Start()
    {
        Target = generator.Slimes.Find(Slime => Slime.tag == Notes.Notes[Index].tag);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Realtime = Time.timeSinceLevelLoad;
       



        if (GameObject.FindGameObjectWithTag("Rep") != null && GameObject.FindGameObjectWithTag("Rep").GetComponent<Image>().fillAmount <= 0f)
        {
            Lose();
        }
        if (Song.time >= Song.clip.length)
        {
            Win();
        }

        if (Song.time > HitTimes[Index] && Index < HitTimes.Count - 1)
        {
            generator.NextNote();
            Target = generator.Slimes.Find(Slime => Slime != null && Slime.tag == Notes.Notes[Index].tag);
            if(Target == null)
            {
                return;
            }
            PlaySound TargetSlime = Target.GetComponent<PlaySound>();
            Index++;
            Notes.Cursor = Index;
            TargetSlime.EndTime = HitTimes[Index];
            TargetSlime.Duration = HitTimes[Index] - Song.time;
            TargetSlime.Penalty = Penalty;
            TargetSlime.StartCoroutine(TargetSlime.Timer());
        }

    }

    public void Win()
    {
        //SceneManager.LoadScene(WinScene);
        Song.Stop();
        Stats Stat = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
        Stat.Rep = GameObject.FindGameObjectWithTag("Rep").GetComponent<Image>().fillAmount;
        Curtains.Play("Win");
    }

    public void Lose()
    {
        Song.Stop();
        Curtains.Play("Lose");
        //SceneManager.LoadScene(LoseScene);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Note = collision.gameObject;
        //HitTimes.Add(Song.time);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*Note = null;
        if (Setup)
        {
            Time.timeScale = 0;
        }*/
    }

    public bool Hit(string Tag,float EndTime)
    {
        if(EndTime < 0)
        {
            return false;
        }

        float Multiplier = 0;    
        float accuracy = Mathf.Abs(Song.time - EndTime);
        if (accuracy < .15f)
        {
            print("Great");
            Multiplier = 1.25f;
        }
        else if(accuracy < .25f)
        {
            print("good");
            Multiplier = 1f;
        }
        else if(accuracy < .35f)
        {
            print("ok");
            Multiplier = .75f;
        }
        else
        {
            print("bad");
            Multiplier = -.25f;
        }
        print(accuracy);
            GameObject.FindGameObjectWithTag("Rep").GetComponent<Image>().fillAmount = Mathf.Clamp01(GameObject.FindGameObjectWithTag("Rep").GetComponent<Image>().fillAmount + (Reward*Multiplier));
        return true;
    }

   
}
