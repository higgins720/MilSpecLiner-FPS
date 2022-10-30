using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime;
using System.Globalization;
using System;

 
public class EventTimer : MonoBehaviour
{

    private class Event {
        public long eventMS=0;
        public Action<String> callbackFuntion = null;
    }


    public void addTimedEvent(long eventMS, Action<String> callFunction){
    
    }

    public void checkForEvent(long eventMS) {

    
    }

     void Start() 
    {
    }

    void Update(){}
}