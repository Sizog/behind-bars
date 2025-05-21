using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour {
    public Transform slotsParent;    // Родительский объект для всех слотов
    public GameObject slotPrefab;    // Префаб слота
    public List<Item> items = new List<Item>();

    private List<Slot> slots = new List<Slot>();

    void Start() {
        CreateSlots();
    }

    // Создаем слоты инвентаря
    void CreateSlots() {
        for(int i = 0; i < 36; i++) { // Например, делаем 36 слотов
            GameObject go = Instantiate(slotPrefab, slotsParent);
            Slot slot = go.GetComponent<Slot>();
            slots.Add(slot);
        }
    }

    // Добавляем предмет в инвентарь
    public void AddItem(Item item) {
        bool added = false;
        foreach(Slot slot in slots) {
            if(slot.iconImage.sprite == item.Icon) { // Проверяем наличие одинаковых предметов
                slot.countText.text = (int.Parse(slot.countText.text) + item.Count).ToString();
                added = true;
                break;
            }
        }
        
        if(!added) {
            foreach(Slot emptySlot in slots) {
                if(emptySlot.iconImage.sprite == null) {
                    emptySlot.SetItem(item);
                    break;
                }
            }
        }
    }

    // Удаление предмета из инвентаря
    public void RemoveItem(Item item) {
        foreach(Slot slot in slots) {
            if(slot.iconImage.sprite == item.Icon) {
                int currentCount = int.Parse(slot.countText.text);
                
                if(currentCount <= item.Count) {
                    slot.Clear();
                } else {
                    slot.countText.text = (currentCount - item.Count).ToString();
                }
                return;
            }
        }
    }

    // Полностью очищаем инвентарь
    public void ClearInventory() {
        foreach(Slot slot in slots) {
            slot.Clear();
        }
    }
}
