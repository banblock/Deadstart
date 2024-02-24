using UnityEngine;

namespace InventorySystem
{
    //Author: Jaxon Schauer
    /// <summary>
    /// 게임이 실행될 때 아이템을 초기화하기 위해 입력을 받습니다.
    /// </summary>
    [System.Serializable]
    public class ItemInitializer
    {
        private int amount = 1;

        // 아이템 속성
        [Header("========[ 아이템 속성 ]========")]

        [Tooltip("아이템의 유형/분류를 생성합니다.")]
        [SerializeField]
        private string itemType;

        [Tooltip("아이템의 시각적 표현입니다.")]
        [SerializeField]
        private Sprite itemImage;

        [Tooltip("한 번에 함께 쌓을 수 있는 이 아이템의 최대 수량입니다.")]
        [SerializeField]
        private int maxStackAmount;

        [Tooltip("아이템 아이콘에 수량/양을 표시합니다.")]
        [SerializeField]
        private bool displayItemAmount;

        // 선택적 아이템 구성
        [Header("========[ 선택적 설정 ]========")]
        [Tooltip("인벤토리 내에서 아이템을 끌어다 놓을 수 있는지 여부를 결정합니다.")]
        [SerializeField]
        private bool draggable;

        [Tooltip("선택 시 아이템을 강조할 수 있는지 여부를 결정합니다.")]
        [SerializeField]
        private bool pressable;

        [Tooltip("이 아이템에 관련된 게임 오브젝트의 구현을 설정할 수 있습니다.")]
        [SerializeField]
        private GameObject RelatedGameObject;

        [Tooltip("이 아이템과 관련된 이벤트를 트리거합니다.")]
        [SerializeField]
        private InventoryItemEvent itemAction;

        [SerializeField, HideInInspector]
        private bool isNull = false;

        public ItemInitializer(bool isNull)
        {
            this.isNull = isNull;
        }
        public void SetIsNull(bool isNull)
        {
            this.isNull = isNull;
        }
        public bool GetIsNull()
        {
            return isNull;
        }
        public string GetItemType()
        {
            return itemType;
        }
        public Sprite GetItemImage()
        {
            return itemImage;
        }
        public int GetItemStackAmount()
        {
            return maxStackAmount;
        }
        public bool GetPressable()
        {
            return pressable;
        }
        public bool GetDraggable()
        {
            return draggable;
        }
        public int GetAmount()
        {
            return amount;
        }
        public void SetAmount(int amount)
        {
            this.amount = amount;
        }
        public InventoryItemEvent GetEvent()
        {
            return itemAction;
        }
        public GameObject GetRelatedGameObject()
        {
            return RelatedGameObject;
        }
        public bool GetDisplayAmount()
        {
            return displayItemAmount;
        }
    }

}
