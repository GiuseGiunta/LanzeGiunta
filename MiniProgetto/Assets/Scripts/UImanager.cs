using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public GameObject magWarning;

    #region Singletone
    public static UImanager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public  IEnumerator magwarning()
   {
        magWarning.SetActive(true);
        yield return new WaitForSeconds(3);
        magWarning.SetActive(false);
   }

    public void MagWarning()
    {
        StartCoroutine(magwarning());
    }

}
