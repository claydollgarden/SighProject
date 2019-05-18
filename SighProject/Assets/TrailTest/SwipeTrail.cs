using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwipeTrail : MonoBehaviour {

    public GameObject trailPrefab;
    public Plane objPlane;
    public List<GameObject> thisTrail = new List<GameObject>();
    Vector3 startPos;
    int vectorCount = 0;

    void Start()
    {
        objPlane = new Plane(Camera.main.transform.forward*-1f, this.transform.position);
    }

    void Update () 
    {
        if (ApplicationManager.instance.SetSignMode)
        {
            if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) ||
                Input.GetMouseButtonDown(0))
            {
                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDistance;
                if (objPlane.Raycast(mRay, out rayDistance))
                    startPos = mRay.GetPoint(rayDistance);
                
                thisTrail.Add((GameObject) Instantiate(trailPrefab, 
                    startPos, 
                    Quaternion.identity));
            }
            else if(((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) 
                || Input.GetMouseButton(0)))
            {
                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDistance;
                if (objPlane.Raycast(mRay, out rayDistance))
                    thisTrail[vectorCount].transform.position = mRay.GetPoint(rayDistance);
            }
            else if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) ||
                Input.GetMouseButtonUp(0))
            {
                    vectorCount++;
            }
        }
    }

    public void EndSighMode()
    {
        for (int i = 0; i < thisTrail.Count; i++)
        {
            thisTrail[i].SetActive(false);
        }

    }
}
