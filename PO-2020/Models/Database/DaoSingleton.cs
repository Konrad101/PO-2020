namespace PO_implementacja_StudiaPodyplomowe.Models.Database
{
    public sealed class DaoSingleton
    {
        private static DaoSingleton _singleton;
        public IDao Dao { get; private set; }

        private DaoSingleton(IDao dao)
        {
            Dao = dao;
        }

        public static DaoSingleton GetInstance()
        {
            if (_singleton == null)
            {
                _singleton = new DaoSingleton(new DatabaseManager());
            }

            return _singleton;
        }
    }
}
