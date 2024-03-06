using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject _player;
    void Start()
    {
        _player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}