using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




    public abstract class ItemData : ScriptableObject
    {
        public int ID => _id;
        public string Name => _name;
        public string Tooltip => _tooltip;
        public Sprite IconSprite => _iconSprite;
        public int price;
        public bool isEquiped;
        //public Sprite image;

        [SerializeField] private int      _id;
        [SerializeField] private string   _name;    // 아이템 이름
        [Multiline]
        [SerializeField] private string   _tooltip; // 아이템 설명
        public Sprite   _iconSprite; // 아이템 아이콘
        

        /// <summary> 타입에 맞는 새로운 아이템 생성 </summary>
        public abstract Item CreateItem();
    }
