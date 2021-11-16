namespace ClassLibrary1
{
    public class MyWallet
    {
        public MyWallet(int amount)
        {
            this.Cash = amount;
            this.Name = "我的皮包";
        }
        public int Cash { get; set; }
        public string Name { get; private set; }
    }
}
