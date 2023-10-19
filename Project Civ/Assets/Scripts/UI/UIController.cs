using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIController : MonoBehaviour
{
   [SerializeField] private TMP_Text scoreLabel; 

   private void Update() {
    scoreLabel.text = Time.realtimeSinceStartup.ToString();
   }
   }

