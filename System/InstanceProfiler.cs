using ABI.CCK.Components;
using ABI_RC.Core.Networking;
using ABI_RC.Core.Player;
using ABI_RC.Core.Savior;
using ABI_RC.Systems.IK;
using ABI_RC.Systems.MovementSystem;
using ABI_RC.Systems.UI;
using Dissonance.Integrations.DarkRift2;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityEngine;

namespace XCVRClient.System
{
    public static class InstanceProfiler
    {
        public static XmetaPort xmeta;

        public static Localplayer player;

        /// <summary>
        /// Get local player and local instance
        /// </summary>
        public static void OnStart()
        {
            xmeta = new XmetaPort(GameObject.Find("ABI_MetaPort"));

            var localplayer = GameObject.Find("_PLAYERLOCAL");

            if(localplayer != null) player = new Localplayer(localplayer);
        }

        public static bool isInstanceOnline()
        {
            if(xmeta != null)
            {
                if(xmeta.currentWorldId.Length > 0)
                {
                    return true;
                }        
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public enum EInstance
        {
            online,
            offline
        }
    }

    public class XmetaPort
    {
        public string accessKey;

        public string currentAvatarGuid;

        public string currentInstanceId;

        public string currentInstanceName;

        public string currentInstancePrivacy;

        public string currentWorldId;

        public XmetaPort(GameObject metaport)
        {
            var meta = metaport.GetComponent<MetaPort>();

            this.accessKey = meta.accessKey;
            this.currentAvatarGuid = meta.currentAvatarGuid;
            this.currentInstanceId = meta.CurrentInstanceId;
            this.currentInstanceName = meta.CurrentInstanceName;
            this.currentInstancePrivacy = meta.CurrentInstancePrivacy;
            this.currentWorldId = meta.CurrentWorldId;
        }
    }

    public class Localplayer
    {
        public Transform playerTransform;

        public PlayerSetup playerSetup;

        public VRTrackerManager VRTracker;

        public PlayerDescriptor playerDescriptor;

        public InputManager inputManager;

        public HudOperations hudOperations;

        public MovementSystem movementSystem;

        public WorldTransitionSystem worldTransitionSystem;

        public IKSystem iKSystem;

        public Animator animator;

        private bool isInit = false;

        public Localplayer(GameObject player)
        {
            if(player != null && isInit == false) 
            {
                playerSetup = player.GetComponent<PlayerSetup>();
                VRTracker = player.GetComponent<VRTrackerManager>();
                playerDescriptor = player.GetComponent<PlayerDescriptor>();
                inputManager = player.GetComponent<InputManager>();
                hudOperations = player.GetComponent<HudOperations>();
                movementSystem = player.GetComponent<MovementSystem>();
                worldTransitionSystem = player.GetComponent<WorldTransitionSystem>();
                iKSystem = player.GetComponent<IKSystem>();
                animator = player.GetComponentInChildren<Animator>();

                playerTransform = player.transform; 

                isInit = true;
            }
        }
    }
}
