namespace Inventory.Currency
{
    public class Essence : Currency
    {
        public EssenceType essenceType;

        protected override void HandlePickUp()
        {
            base.HandlePickUp();
            // add the value to the correct essence type
            Destroy(gameObject);
        }
    }
}