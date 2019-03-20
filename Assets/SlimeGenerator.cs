using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlimeGenerator : MonoBehaviour
{
    public NoteList Music;
    public List<GameObject> Slimes;
    public List<GameObject> A;
    public List<GameObject> B;
    public List<GameObject> C;
    public List<GameObject> SlimeTypes;
    public Text ACounter;
    public Text BCounter;
    public Text CCounter;
    public PlayNote PlayNote;

    // Start is called before the first frame update
    void Awake()
    {
        /*for (int i = 0; i < transform.childCount; i++)
        {
            Slimes.Add(transform.GetChild(i).gameObject);
        }*/

        foreach(GameObject Slime in Slimes)
        {
            Slime.SetActive(true);
        }
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        ACounter.text = A.Count.ToString();
        BCounter.text = B.Count.ToString();
        CCounter.text = C.Count.ToString();
    }

    public IEnumerator Spawn()
    {
        yield return new WaitUntil(() => Music.Notes.Count>1);
        NextNote();
        yield return null;
        
    }

    public void NextNote()
    {
        int LookAhead = (int)Mathf.Min(4, Music.Notes.Count - Music.Cursor);
        List<GameObject> FutureNotes = Music.Notes.GetRange(Music.Cursor, LookAhead);
        foreach (GameObject note in FutureNotes)
        {

            if (Slimes.Find(Slime => Slime != null && Slime.tag == note.tag) == null)
            {
                if (note.tag == "A")
                {
                    Spawn(A);
                }
                else if (note.tag == "B")
                {
                    Spawn(B);
                }
                else
                {
                    Spawn(C);
                }
            }
        }
        Slimes.TrimExcess();
    }
    public void Spawn(List<GameObject> SlimeType)
    {
        if(SlimeType.Count <= 0)
        {
            PlayNote.Lose();
            return;
        }

        
        
        SlimeType[SlimeType.Count - 1].SetActive(true);
        Slimes.Add(SlimeType[SlimeType.Count - 1]);
        SlimeType.RemoveAt(SlimeType.Count - 1);
        SlimeType.TrimExcess();
    }
}
