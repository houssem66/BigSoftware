using AutoMapper;
using Data.Entities;
using Data.Models;

namespace Data.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientViewModel, Client>();
            CreateMap<BonCommandeFModel, BonDeCommandeFournisseur>();
            CreateMap<DetailsBonCommandeFModel, DetailsCommandeFournisseur>();
            CreateMap<DetailsBonReceptionModel, DetailsReceptionFournisseur>();
            CreateMap<BonReceptionModel, BonDeReceptionFournisseur>();
            CreateMap<ProduitModel, Produit>();
            //mapping models for Client Models
            CreateMap<BonLivraisonViewModel, BonLivraisonClient>();
            CreateMap<DetailsLivraisonClientViewModel, DetailsLivraisonClient>();

            CreateMap<BonCommandeCModel, BonCommandeClient>();
            CreateMap<DetailsCommandeClient, DetailsCommandeClient>();

            CreateMap<BonSortieViewModel, BonSortie>();
            CreateMap<DetailsBonSortieModel, DetailsBonSortie>();

            CreateMap<DevisViewModel, Devis>();
            CreateMap<DetailsDevisModel, DetailsDevis>();



        }
    }
}
