using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Представление одного слота инвентаря
public class Slot : MonoBehaviour, IPointerClickHandler {
    public Image iconImage;           // Отображаемое изображение предмета
    public Text countText;            // Текущее количество предмета

    public void OnPointerClick(PointerEventData eventData) {
        // Обработка клика по предмету
        if(eventData.button == PointerEventData.InputButton.Left) {
            // Здесь можно добавить взаимодействие с предметом
        }
    }

    // Устанавливаем данные предмета в слот
    public void SetItem(Item item) {
        iconImage.sprite = item.Icon;
        countText.text = item.Count.ToString();
    }

    // Очищаем слот от предмета
    public void Clear() {
        iconImage.sprite = null;
        countText.text = "";
    }
}
