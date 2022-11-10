using Data;
using Repository.Interfaces;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BigSoftContext _repoContext;
        private IBonDeCommandeFournisseurRepo _BonDeCommandeFournisseurRepo;
        private IClientRepo _ClientRepo;
        private IBonDeReceptionFournisseurRepo _BonDeReceptionFournisseurRepo;
        private IFactureFournisseurRepo _FactureFournisseurRepo;
        private IBonCommandeClientRepo _BonCommandeClientRepo;
        private IBonLivraisonClientRepo _BonLivraisonClientRepo;
        private IBonSortieClientRepo _BonSortieClientRepo;
        private IDevisClientRepo _DevisClientRepo;
        private IFactureClientRepo _FactureClientRepo;
        private IStockProduitRepo _StockProduitRepo;
        private IStockRepo _StockRepo;
        private IProduitRepo _ProduitRepo;
        private IFournisseurRepo _FournisseurRepo;
        public IBonDeCommandeFournisseurRepo BonDeCommandeFournisseurRepo
        {
            get
            {
                if (_BonDeCommandeFournisseurRepo == null)
                {
                    _BonDeCommandeFournisseurRepo = new BonDeCommandeFournisseurRepo(_repoContext);
                }
                return _BonDeCommandeFournisseurRepo;
            }
        }
        public IFournisseurRepo FournisseurRepo
        {
            get
            {
                if (_FournisseurRepo == null)
                {
                    _FournisseurRepo = new FournisseurRepo(_repoContext);
                }
                return _FournisseurRepo;
            }
        }
        public IClientRepo ClientRepo
        {
            get
            {
                if (_ClientRepo == null)
                {
                    _ClientRepo = new ClientRepo(_repoContext);
                }
                return _ClientRepo;
            }
        }
        public IBonDeReceptionFournisseurRepo BonDeReceptionFournisseurRepo
        {
            get
            {
                if (_BonDeReceptionFournisseurRepo == null)
                {
                    _BonDeReceptionFournisseurRepo = new BonDeReceptionFournisseurRepo(_repoContext);
                }
                return _BonDeReceptionFournisseurRepo;
            }
        }
        public IFactureFournisseurRepo FactureFournisseurRepo {
            get
            {
                if (_FactureFournisseurRepo == null)
                {
                    _FactureFournisseurRepo = new FactureFournisseurRepo(_repoContext);
                }
                return _FactureFournisseurRepo;
            }
        }
        public IBonCommandeClientRepo CommandeClientRepo
        {
            get
            {
                if (_BonCommandeClientRepo == null)
                {
                    _BonCommandeClientRepo = new BonCommandeClientRepo(_repoContext);
                }
                return _BonCommandeClientRepo;
            }
        }
        public IBonLivraisonClientRepo BonLivraisonClientRepo
        {
            get
            {
                if (_BonLivraisonClientRepo == null)
                {
                    _BonLivraisonClientRepo = new BonLivraisonClientRepo(_repoContext);
                }
                return _BonLivraisonClientRepo;
            }
        }
        public IBonSortieClientRepo BonSortieClientRepo
        {
            get
            {
                if (_BonSortieClientRepo == null)
                {
                    _BonSortieClientRepo = new BonSortieClientRepo(_repoContext);
                }
                return _BonSortieClientRepo;
            }
        }
        public IDevisClientRepo DevisClientRepo
        {
            get
            {
                if (_DevisClientRepo == null)
                {
                    _DevisClientRepo = new DevisClientRepo(_repoContext);
                }
                return _DevisClientRepo;
            }
        }
        public IFactureClientRepo FactureClientRepo
        {
            get
            {
                if (_FactureClientRepo == null)
                {
                    _FactureClientRepo = new FactureClientRepo(_repoContext);
                }
                return _FactureClientRepo;
            }
        }
        public IStockProduitRepo StockProduitRepo
        {
            get
            {
                if (_StockProduitRepo == null)
                {
                    _StockProduitRepo = new StockProduitRepo(_repoContext);
                }
                return _StockProduitRepo;
            }
        }
        public IStockRepo StockRepo
        {
            get
            {
                if (_StockRepo == null)
                {
                    _StockRepo = new StockRepo(_repoContext);
                }
                return _StockRepo;
            }
        }
        public IProduitRepo ProduitRepo
        {
            get
            {
                if (_ProduitRepo == null)
                {
                    _ProduitRepo = new ProduitRepo(_repoContext);
                }
                return _ProduitRepo;
            }
        }
        public RepositoryWrapper(BigSoftContext bigSoftContext)
        {
            _repoContext = bigSoftContext;
        }
        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
