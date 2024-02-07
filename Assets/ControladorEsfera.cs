using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorEsfera : MonoBehaviour
{
	
    public float speed;

    private int count;

    public TextMeshProUGUI text;

    public TextMeshProUGUI win;

    void Start(){
    
        count = 0;
    
    	updateCounter();
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
      float horizontal = Input.GetAxis("Horizontal");
      float vertical = Input.GetAxis("Vertical");
      
      Vector3 direction = new Vector3(horizontal, 0, vertical);
      
      GetComponent<Rigidbody>().AddForce(direction * speed);
        
    }
    
    void OnTriggerEnter(Collider other){
    
    	if(other.tag == "Moneda"){
    	
    	    Destroy(other.gameObject);

	        count++;
	        
    	    updateCounter();
    	
    	}
    
    }
    
    void updateCounter() {
    
   	text.text = "Puntos : " + count;

    int numPicks = GameObject.FindGameObjectsWithTag("Moneda").Length;

    if (numPicks == 1) {

	    win.text = "Has Ganado!";

    }

    }
    
}
