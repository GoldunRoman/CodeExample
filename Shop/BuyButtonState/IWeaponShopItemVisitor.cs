public interface IWeaponShopItemVisitor
{
    void Visit(WeaponShopItem weaponItem, ButtonStates state, bool isPurchasedForAd = false);
}
