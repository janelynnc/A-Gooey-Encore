using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class NoteList : MonoBehaviour
{
    public SlimeGenerator generator;
    public List<GameObject> Notes;
    public GameObject Target;
    public GameObject AimHelper;
    public int Cursor;
    // Start is called before the first frame update
    void Start()
    {
        for(int i= 0;i < transform.childCount; i++)
        {
            Notes.Add(transform.GetChild(i).gameObject);
        }
        Notes = Notes.OrderBy(obj => obj.transform.localPosition.x).ToList<GameObject>();
        //Target = generator.Slimes.Find(Slime => Slime.tag == Notes[Cursor].tag);
        
    }
}
