using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class RTSController : MonoBehaviour
{
[SerializeField] private Transform selectedArea;
    private Vector3 startPos; 
    private Vector3 worldPos; 

    private List<UnionSol> selectedUnits;

    private void Awake() {
        selectedUnits = new List<UnionSol>();
        selectedArea.transform.gameObject.SetActive(false);

    }
 
 private void Update() {

    //Left Mouse Button Press. Calculate WorldPosition and set to startPosition 
    if(Input.GetMouseButtonDown(0)) {
     selectedArea.transform.gameObject.SetActive(true);
    startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    startPos.z = 0f;
    }

    if(Input.GetMouseButton(0)){
        Vector3 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentMousePos.z = 0f; 

        Vector3 lowerLeft = new Vector3(
            Mathf.Min(startPos.x,currentMousePos.x), Mathf.Min(startPos.y,currentMousePos.y));

         Vector3 upperRight = new Vector3( Mathf.Max(startPos.x,currentMousePos.x),Mathf.Max(startPos.y,currentMousePos.y));

        selectedArea.position = lowerLeft;
        selectedArea.localScale = upperRight - lowerLeft;


    }


    //Left Mouse Release
    if(Input.GetMouseButtonUp(0)) {
        selectedArea.transform.gameObject.SetActive(false);
        worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0f;

        //deselect all units
        foreach (UnionSol unionsoldier in selectedUnits) {
            unionsoldier.SetSelectedVisible(false);
        }
       
       selectedUnits.Clear();

       Collider2D[] collider2DArray =  Physics2D.OverlapAreaAll(startPos,worldPos);

       foreach(Collider2D collider2d in collider2DArray ){
        UnionSol unionSoldier = collider2d.GetComponent<UnionSol>();

        if(unionSoldier!=null) {
            unionSoldier.SetSelectedVisible(true);
            selectedUnits.Add(unionSoldier);
        }
       }


    }



    if (Input.GetMouseButtonDown(1)){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; 

        List<Vector3> movePositionsList = GetPositionList(mousePos, 0.5f ,selectedUnits.Count, 5);

        int movePositionIndex = 0;

        foreach(UnionSol unionsoldier in selectedUnits) {
            unionsoldier.MoveOrder(movePositionsList[movePositionIndex]);
            movePositionIndex = (movePositionIndex +1) % selectedUnits.Count;
        }
    }
 }


 private List<Vector3> GetPositionList (Vector3 mousePos, float distance, int unitCount, int modNumber) {

    List<Vector3> movePositionList = new List<Vector3>();
    int Yoffset = 0;
    int Xoffset= 0;

    for(int i =0; i <unitCount; i ++) {
        Xoffset = i%modNumber;
        
        if (i!= 0 && i%modNumber==0) {
         Yoffset += 1; 
        }

        Vector3 movePos = mousePos + new Vector3(0 + distance * Xoffset ,0 - distance * Yoffset);
        movePositionList.Add(movePos);
    }

    foreach(Vector3 vector in movePositionList){
        Debug.Log(vector);
    }


    return movePositionList;
 }
}
