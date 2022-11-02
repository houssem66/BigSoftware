using Data;
using Data.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class ProduitRepo : RepositoryBase<Produit>, IProduitRepo
    {

        public ProduitRepo(BigSoftContext _bigSoftContext) : base(_bigSoftContext)
        {

        }
       
        public async Task<IList<Produit>> UpdateAll(int id,Produit produit)
        {
            try
            {
                var query = from p in BigSoftContext.Set<Produit>()
                            where p.Id == id
                            // 
                            //       join dbs in BigSoftContext.Set<DetailsBonSortie>() on id equals dbs.IdProduit
                               join dcc in BigSoftContext.Set<DetailsCommandeClient>() on p.Id equals dcc.IdProduit into list0
                               from l in list0.DefaultIfEmpty()
                            join dbc in BigSoftContext.Set<DetailsReceptionFournisseur>() on p.Id equals dbc.IdProduit into list
                            from sub in list.DefaultIfEmpty()
                            join dd in BigSoftContext.Set<DetailsDevis>() on p.Id equals dd.IdProduit into list2
                            from t in list2.DefaultIfEmpty()
                            join dbs in BigSoftContext.Set<DetailsBonSortie>() on p.Id equals dbs.IdProduit into list3
                            from s in list3.DefaultIfEmpty()
                            select new
                            {
                                p.Id,
                                p.ProductName,
                                quantite=s.Quantite??sub.Quantite??t.Quantite??0,
                                bonR=sub.BonDeRéception??null,
                                devis=t.Devis??null,
                                bonS=s.BonSortie??null,
                                bonCommande=l.CommandeClient??null
                              
                            };
                var x = query.ToList();
                var y = x;
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }


        }
    }
}
