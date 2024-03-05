using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int maxHealth;
    [SerializeField] private GameObject _bar;

    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject GameOver;

    private Animator anim;

    [SerializeField] GameObject __start;
    [SerializeField] Dissolve _dissolve;


   
    int currentHealth;
    public HealthBar healthBar;

    public UnityEvent OnDeath;

  



    private void OnEnable(){
        OnDeath.AddListener(animDeath);
        OnDeath.AddListener(destroyHeartBar);
 
        //OnDeath.AddListener(Death);
        
        
    }

    // private void OnDisable(){
    //     OnDeath.RemoveListener(Death);
    // }
    
    public int _currentHealth(){
        return currentHealth;
    }

    private void Start(){
        currentHealth = maxHealth;

        healthBar.UpdateBar(currentHealth, maxHealth);

        anim = _player.GetComponent<Animator>();



    }
    public void TakeDamage(int damage){
        currentHealth -= damage; 
        if(currentHealth <= 0){
            //anim.SetBool("death", res);
            currentHealth = 0;
            StartCoroutine(_dissolve.Vanis(false, true));
            OnDeath.Invoke(); 
            Invoke("Death", 0.5f);
    
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void Death(){
        //Destroy(gameObject); 
        GameOver.SetActive(true);
        _player.SetActive(false);
        Time.timeScale = 0;
        //__start.SetActive(true);
    }

   


    public void animDeath(){
        anim.SetTrigger("death");
    }
    
    public void destroyHeartBar(){
     _bar.SetActive(false);
    }
    // private void Update(){
    //     if(Input.GetKeyDown(KeyCode.Space)){
    //         TakeDamage(1);
    //     }
    // }
    
    
}
