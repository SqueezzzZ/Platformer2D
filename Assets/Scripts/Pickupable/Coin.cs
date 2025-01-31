public class Coin : Pickupable
{
    public int Price { get; private set; } = 1;

    public override void Collect()
    {
        base.Collect();
    }
}