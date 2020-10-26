namespace StoreLib
{
    public interface ICart
    {
        int Count {get;}
         void AddItem(Item item, int numOfItem);

         void Write();
    }
}