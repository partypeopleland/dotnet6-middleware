namespace ClassLibrary1
{
    public class MyService
    {
        private readonly MyWallet _myWallet;

        public MyService(MyWallet myWallet)
        {
            _myWallet = myWallet;
        }
        public int ShowMyMoney()
        {
            return _myWallet.Cash;
        }

        public int SetMyMoney(int amount)
        {
            _myWallet.Cash = amount;
            return _myWallet.Cash;
        }
    }
}
