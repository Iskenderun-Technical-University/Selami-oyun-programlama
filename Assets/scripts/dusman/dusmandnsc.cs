using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusmandnsc : MonoBehaviour
{
    public GameObject dusman;

    float saniyedemaxdusmand = 5f;
    void Start()
    {

    }

    
    void Update()
    {
        
    }

    void dusmand()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


        GameObject birdusman = (GameObject)Instantiate(dusman);
        birdusman.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);


        sonrakidusmand();

        
    }

    void sonrakidusmand()
    {
        float saniyeded;

        if (saniyedemaxdusmand > 1f)
        {
            saniyeded = Random.Range(1f, saniyedemaxdusmand);
        }

        else
            saniyeded = 1f;

        Invoke("dusmand", saniyeded);
                
    }

    void doranart()
    {
        if (saniyedemaxdusmand > 1f)
            saniyedemaxdusmand--;

        if (saniyedemaxdusmand == 1f)
            CancelInvoke("doranart");
    }

    public void dusmandz()
    {
        saniyedemaxdusmand = 5f;

        Invoke("dusmand", saniyedemaxdusmand);

        InvokeRepeating("doranart", 0f, 30f);
    }
    public void sonrakidusmandd() //düþman doðumunu durdurma
    {
        CancelInvoke("dusmand");
        CancelInvoke("doranart");
    }
}
