namespace Inventory.Currency
{
    [CreateAssetMenu(menuName = "Essence/Essence", fileName = "New Essence")]
    public class Essence : IAccruable
    {
        public EssenceType essenceType;
        public string name => $"{essenceType} Essence";
        public Sprite icon => essenceType.icon;
    }
}