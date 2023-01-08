using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager manager { get; private set; }

    [SerializeField] private int round;
    
    public int Round { get { return round; } }

    private void Awake()
    {
        if (manager == null) manager = this;
    }
}
