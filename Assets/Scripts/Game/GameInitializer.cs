using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public static GameInitializer instance;
    public Character character;
    public ProgressBar progressBar;
    public Announce announce;
    public Player player;
    public Wallet wallet;
    public Camera MainCamera;
    public Canvas MainCanvas;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        player.Init();
        progressBar.Init();
        announce.Init();
        wallet.Init();
    }
}
