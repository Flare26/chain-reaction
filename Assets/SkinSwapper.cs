using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkinSwapper : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] skins;
    int m_skin;
    void Awake()
    {
        foreach (GameObject s in skins)
        {
            s.SetActive(false);
        }
        ChangeSkin();
    }

    public void ChangeSkin()
    {

        skins[m_skin].SetActive(false);

        m_skin = Random.Range(0, skins.Length);
        skins[m_skin].SetActive(true);

    }

    public void ChangeSkin(int idx)
    {
        skins[m_skin].SetActive(false);
        m_skin = idx;
        skins[m_skin].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
