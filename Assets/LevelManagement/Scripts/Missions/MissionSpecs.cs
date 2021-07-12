using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LevelManagement.Missions
{
    [Serializable]
    public class MissionSpecs
    {
        [SerializeField]
        protected string _name;
        public string Name => _name;


        [SerializeField]
        [Multiline]
        protected string _description;
        public string Description => _description;


        [SerializeField]
        protected string _sceneName;
        public string SceneName => _sceneName;


        [SerializeField]
        protected string _id;
        public string Id => _id;


        [SerializeField]
        protected Sprite _image;
        public Sprite Image => _image;

    }
}
