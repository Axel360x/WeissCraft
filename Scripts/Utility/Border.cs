using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {
    public bool place = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GameObject.Find("World").GetComponent<ModifyTerrain>().Placeholding = place;
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            place = false;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
            place = false;
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
            place = true;
    }
}
