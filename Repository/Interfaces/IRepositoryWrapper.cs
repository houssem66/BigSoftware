using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepositoryWrapper
    {
        IBonDeCommandeFournisseurRepo BonDeCommandeFournisseurRepo { get; }
        IClientRepo ClientRepo { get; }
        IBonDeReceptionFournisseurRepo BonDeReceptionFournisseurRepo { get; }
        IFactureFournisseurRepo FactureFournisseurRepo { get; }
        IBonCommandeClientRepo CommandeClientRepo { get; }
        IBonLivraisonClientRepo BonLivraisonClientRepo { get; }
        IBonSortieClientRepo BonSortieClientRepo { get; }
        IDevisClientRepo DevisClientRepo { get; }
        IFactureClientRepo FactureClientRepo { get; }
        IStockProduitRepo StockProduitRepo { get; }
        IStockRepo StockRepo { get; }
        IProduitRepo ProduitRepo { get; }
        Task SaveAsync();
    }
}
