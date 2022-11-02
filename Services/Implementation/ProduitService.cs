using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ProduitService : IProduitService
    {
        private readonly IRepositoryWrapper repository;
        private readonly BigSoftContext bigSoftContext;

        public ProduitService(IRepositoryWrapper repository, BigSoftContext bigSoftContext)
        {
            this.repository = repository;
            this.bigSoftContext = bigSoftContext;
        }
        public async Task UpdateAll(Produit produit)
        {
            try
            {
                #region query_join
                var query = from p in bigSoftContext.Set<Produit>()
                            where p.Id == produit.Id
                            //Fournisseur left joins
                            join drc in bigSoftContext.Set<DetailsReceptionFournisseur>().Include(x => x.BonDeRéception) on p.Id equals drc.IdProduit into listdbc
                            from drc2 in listdbc.DefaultIfEmpty()
                            join dcf in bigSoftContext.Set<DetailsCommandeFournisseur>().Include(x => x.BonDeCommandeFournisseur) on p.Id equals dcf.IdProduit into listdcf
                            from dcf2 in listdcf.DefaultIfEmpty()
                            join dff in bigSoftContext.Set<DetailsFactureFournisseur>().Include(x => x.FactureFournisseur) on p.Id equals dff.IdProduit into listdff
                            from dff2 in listdff.DefaultIfEmpty()
                                // Client left joins
                            join dcc in bigSoftContext.Set<DetailsCommandeClient>().Include(x => x.CommandeClient) on p.Id equals dcc.IdProduit into listdcc
                            from dcc2 in listdcc.DefaultIfEmpty()
                            join dbl in bigSoftContext.Set<DetailsLivraisonClient>().Include(x => x.BonLivraison) on p.Id equals dbl.IdProduit into listdbl
                            from dbl2 in listdbl.DefaultIfEmpty()
                            join dd in bigSoftContext.Set<DetailsDevis>().Include(x => x.Devis) on p.Id equals dd.IdProduit into listdd
                            from dd2 in listdd.DefaultIfEmpty()
                            join dbs in bigSoftContext.Set<DetailsBonSortie>().Include(x => x.BonSortie) on p.Id equals dbs.IdProduit into listdbs
                            from dbs2 in listdbs.DefaultIfEmpty()
                            join dfc in bigSoftContext.Set<DetailsFactureClient>().Include(x => x.FactureClient) on p.Id equals dfc.IdProduit into lsitdfc
                            from dfc2 in lsitdfc.DefaultIfEmpty()
                                //Stock
                            join stp in bigSoftContext.Set<StockProduit>() on p.Id equals stp.IdProduit into liststp
                            from stp2 in liststp.DefaultIfEmpty()
                            select new
                            {
                                //Fournisseur

                                bonReception = drc2 ?? null,
                                BonCommandeFournisseur = dcf2 ?? null,
                                factureFournisseur = dff2 ?? null,

                                //Client
                                bonCommandeClient = dcc2 ?? null,
                                bonLivraisonClient = dbl2 ?? null,
                                devis = dd2 ?? null,
                                bonSortie = dbs2 ?? null,
                                factureClient = dfc2 ?? null,

                                //Stock
                                stock = stp2 ?? null,
                            };
                #endregion
                #region old Details initialisation
                var list = query.ToList();
                //Fournisseur
                var oldBonReception = new DetailsReceptionFournisseur();
                var oldBonCommandeFournisseur = new DetailsCommandeFournisseur();
                var oldFactureFournisseur = new DetailsFactureFournisseur();
                //Client
                var oldBonCommandeClient = new DetailsCommandeClient();
                var oldBonLivraisonClient = new DetailsLivraisonClient();
                var oldDevis = new DetailsDevis();
                var oldBonSortie = new DetailsBonSortie();
                var oldFactureClient = new DetailsFactureClient();
                //Stock
                var oldStock = new StockProduit();
                #endregion

                #region foreach
                foreach (var item in list)
                {
                    #region fournisseur Conditions
                    if (item.bonReception != oldBonReception && item.bonReception != null)
                    {
                        item.bonReception.BonDeRéception.PrixTotaleHt -= item.bonReception.MontantHt;
                        item.bonReception.BonDeRéception.PrixTotaleTTc -= item.bonReception.MontantTTc;
                        item.bonReception.MontantHt = item.bonReception.Quantite * produit.PriceHt;
                        item.bonReception.MontantTTc = item.bonReception.Quantite * produit.PriceTTc;
                        item.bonReception.BonDeRéception.PrixTotaleHt += item.bonReception.MontantHt;
                        item.bonReception.BonDeRéception.PrixTotaleTTc += item.bonReception.MontantTTc;
                        oldBonReception = item.bonReception;
                    }
                    if (item.BonCommandeFournisseur != null && item.BonCommandeFournisseur != oldBonCommandeFournisseur)
                    {
                        item.BonCommandeFournisseur.BonDeCommandeFournisseur.PrixTotaleHt -= item.BonCommandeFournisseur.MontantHt;
                        item.BonCommandeFournisseur.BonDeCommandeFournisseur.PrixTotaleTTc -= item.BonCommandeFournisseur.MontantTTc;
                        item.BonCommandeFournisseur.MontantHt = item.BonCommandeFournisseur.Quantite * produit.PriceHt;
                        item.BonCommandeFournisseur.MontantTTc = item.BonCommandeFournisseur.Quantite * produit.PriceTTc;
                        item.BonCommandeFournisseur.BonDeCommandeFournisseur.PrixTotaleHt += item.BonCommandeFournisseur.MontantHt;
                        item.BonCommandeFournisseur.BonDeCommandeFournisseur.PrixTotaleTTc += item.BonCommandeFournisseur.MontantTTc;
                        oldBonCommandeFournisseur = item.BonCommandeFournisseur;
                    }
                    if (item.factureFournisseur != null && oldFactureFournisseur != item.factureFournisseur)
                    {
                        item.factureFournisseur.FactureFournisseur.PrixTotaleHt -= item.factureFournisseur.MontantHt;
                        item.factureFournisseur.FactureFournisseur.PrixTotaleTTc -= item.factureFournisseur.MontantTTc;
                        item.factureFournisseur.MontantTTc = item.factureFournisseur.Quantite * produit.PriceTTc;
                        item.factureFournisseur.MontantHt = item.factureFournisseur.Quantite * produit.PriceHt;
                        item.factureFournisseur.FactureFournisseur.PrixTotaleHt += item.factureFournisseur.MontantHt;
                        item.factureFournisseur.FactureFournisseur.PrixTotaleTTc += item.factureFournisseur.MontantTTc;
                        oldFactureFournisseur = item.factureFournisseur;
                    }
                    #endregion
                    #region client conditions
                    if (item.bonCommandeClient != oldBonCommandeClient && item.bonCommandeClient != null)
                    {
                        item.bonCommandeClient.CommandeClient.PrixTotaleHt -= item.bonCommandeClient.MontantHt;
                        item.bonCommandeClient.CommandeClient.PrixTotaleTTc -= item.bonCommandeClient.MontantTTc;
                        item.bonCommandeClient.MontantHt = item.bonCommandeClient.Quantite * produit.PriceHt;
                        item.bonCommandeClient.MontantTTc = item.bonCommandeClient.Quantite * produit.PriceTTc;
                        item.bonCommandeClient.CommandeClient.PrixTotaleHt += item.bonCommandeClient.MontantHt;
                        item.bonCommandeClient.CommandeClient.PrixTotaleTTc += item.bonCommandeClient.MontantTTc;
                        oldBonCommandeClient = item.bonCommandeClient;
                    }
                    if (item.bonLivraisonClient != oldBonLivraisonClient && item.bonLivraisonClient != null)
                    {
                        item.bonLivraisonClient.BonLivraison.PrixTotaleTTc -= item.bonLivraisonClient.MontantTTc;
                        item.bonLivraisonClient.BonLivraison.PrixTotaleHt -= item.bonLivraisonClient.MontantHt;
                        item.bonLivraisonClient.MontantHt = item.bonLivraisonClient.Quantite * produit.PriceHt;
                        item.bonLivraisonClient.MontantTTc = item.bonLivraisonClient.Quantite * produit.PriceTTc;
                        item.bonLivraisonClient.BonLivraison.PrixTotaleTTc += item.bonLivraisonClient.MontantTTc;
                        item.bonLivraisonClient.BonLivraison.PrixTotaleHt += item.bonLivraisonClient.MontantHt;
                        oldBonLivraisonClient = item.bonLivraisonClient;
                    }
                    if (item.bonSortie != oldBonSortie && item.bonSortie != null)
                    {
                        item.bonSortie.BonSortie.PrixTotaleHt -= item.bonSortie.MontantHt;
                        item.bonSortie.BonSortie.PrixTotaleTTc -= item.bonSortie.MontantTTc;
                        item.bonSortie.MontantHt = item.bonSortie.Quantite * produit.PriceHt;
                        item.bonSortie.MontantTTc = item.bonSortie.Quantite * produit.PriceTTc;
                        item.bonSortie.BonSortie.PrixTotaleHt += item.bonSortie.MontantHt;
                        item.bonSortie.BonSortie.PrixTotaleTTc += item.bonSortie.MontantTTc;
                        oldBonSortie = item.bonSortie;
                    }
                    if (item.devis != oldDevis && item.devis != null)
                    {
                        item.devis.Devis.PrixTotaleHt -= item.devis.MontantHt;
                        item.devis.Devis.PrixTotaleTTc -= item.devis.MontantTTc;
                        item.devis.MontantHt = item.devis.Quantite * produit.PriceHt;
                        item.devis.MontantTTc = item.devis.Quantite * produit.PriceTTc;
                        item.devis.Devis.PrixTotaleHt += item.devis.MontantHt;
                        item.devis.Devis.PrixTotaleTTc += item.devis.MontantTTc;
                        oldDevis = item.devis;
                    }
                    if (item.factureClient != oldFactureClient && item.factureClient != null)
                    {
                        item.factureClient.FactureClient.PrixTotaleHt -= item.factureClient.MontantHt;
                        item.factureClient.FactureClient.PrixTotaleTTc -= item.factureClient.MontantTTc;
                        item.factureClient.MontantHt = item.factureClient.Quantite * produit.PriceHt;
                        item.factureClient.MontantTTc = item.factureClient.Quantite * produit.PriceTTc;
                        item.factureClient.FactureClient.PrixTotaleHt += item.factureClient.MontantHt;
                        item.factureClient.FactureClient.PrixTotaleTTc += item.factureClient.MontantTTc;
                        oldFactureClient = item.factureClient;
                    }
                    #endregion
                    #region stock conditions
                    if (item.stock != null && oldStock != item.stock)
                    {
                        item.stock.PrixTotaleHt = item.stock.Quantite * produit.PriceHt;
                        item.stock.PrixTotaleTTc = item.stock.Quantite * produit.PriceTTc;
                        oldStock = item.stock;
                    }
                    #endregion
                }
                #endregion


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
