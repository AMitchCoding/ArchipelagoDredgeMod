﻿using ArchipelagoDredge.Game.Managers;
using ArchipelagoDredge.Utils;
using UnityEngine;

namespace ArchipelagoDredge
{
    public class Loader
    {
        /// <summary>
        /// This method is run by Winch to initialize your mod
        /// </summary>
        public static void Initialize()
        {
            var gameObject = new GameObject(nameof(ArchipelagoDredge));
            gameObject.AddComponent<ArchipelagoDredge>();
            GameObject.DontDestroyOnLoad(gameObject);

            GameManager.Instance.OnGameStarted += OnGameStarted;

            if (GameObject.Find("MainThreadDispatcher") == null)
            {
                GameObject dispatcherObj = new GameObject("MainThreadDispatcher");
                dispatcherObj.AddComponent<MainThreadDispatcher>();
                UnityEngine.Object.DontDestroyOnLoad(dispatcherObj);
            }

        }

        private static void OnGameStarted()
        {
            ArchipelagoItemManager.Initialize();
        }
    }
}