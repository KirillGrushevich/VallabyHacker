using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicObject : MonoBehaviour 
{
	[SerializeField]
	private bool DontDestroy;

	public static MusicObject Instance;

    // Use this for initialization
    void Start()
    {
        if (DontDestroy)
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
			Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
