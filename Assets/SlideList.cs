using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SlideList : MonoBehaviour
{
    public List<GameObject> Slides;
    private int index = 0;
    public GameObject Headphones;
    public GameObject Next;
    public GameObject Prev;

    public string LevelToLoad;
    public void Awake()
    {
        StartCoroutine(SpawnNext());
    }

    IEnumerator SpawnNext()
    {
        yield return new WaitUntil(() => Headphones.activeInHierarchy == false);
        Next.SetActive(true);
    }

    public void NextSlide()
    {
        if (index < Slides.Count - 1)
        {
            foreach (GameObject Slide in Slides)
            {
                Slide.SetActive(false);
            }
            index++;
            Slides[index].SetActive(true);
            if (index > 0)
            {
                Prev.SetActive(true);
            }
        }
        else
        {
            SceneManager.LoadScene(LevelToLoad);
            
        }
    }

    public void PrevSlide()
    {
        if (index > 0)
        {
            foreach (GameObject Slide in Slides)
            {
                Slide.SetActive(false);
            }
            index--;
            Slides[index].SetActive(true);
            if (index == 0)
            {
                Prev.SetActive(false);
            }
        }
    }
}
