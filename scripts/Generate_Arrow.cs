using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Arrow : MonoBehaviour
{
    public GameObject arrowNew;

    private bool isArrow = false;
    private bool isPlatform = false;

    private void FixedUpdate()
    {
        // to-do: for the condition that certain goal was achieved == serialized field? List? Array? Smth like that
        if (Input.GetKeyDown(KeyCode.W))
        {
            Collider[] areaArrows = Physics.OverlapSphere(transform.position, 0.5f);

            foreach (var pltObject in areaArrows)
            {
                // this two are the main problem == it should always detect them
                // and turn true to make sure they are not present
                if (pltObject.tag == "arrow")
                {
                    isArrow = true;
                }
                else if (pltObject.tag == "platform")
                {
                    isPlatform = true;
                }
                // this two if-statements for handling when arrow shows up
                else if (pltObject.name == this.gameObject.name) // skips its own collider
                {
                    continue;
                }
                else if (pltObject.tag == this.gameObject.tag && pltObject.name != this.gameObject.tag) // detects center collider of the empty object
                {
                    isArrow = true;
                }
            }

            // if-statement for handling when to create the arrow
            if (!isPlatform && !isArrow)
            {
                Invoke("SpawnArrow", 0f);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    // spawning new arrows at the position of the empty objects
    void SpawnArrow()
    {
        Instantiate(arrowNew, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}
