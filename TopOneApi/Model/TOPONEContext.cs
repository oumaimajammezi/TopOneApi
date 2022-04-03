using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace TopOneApi.Model
{
    public partial class TOPONEContext : DbContext
    {
        public TOPONEContext()
        {
        }

        public TOPONEContext(DbContextOptions<TOPONEContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Param> Params { get; set; }
        public virtual DbSet<AdresseClient> AdresseClients { get; set; }
        public virtual DbSet<Association> Associations { get; set; }
        public virtual DbSet<AssociationProd> AssociationProds { get; set; }
        public virtual DbSet<Attribut> Attributs { get; set; }
        public virtual DbSet<AttributProduit> AttributProduits { get; set; }
        public virtual DbSet<CategorieProduit> CategorieProduits { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        //public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<Composition> Compositions { get; set; }
        public virtual DbSet<CompositionProduit> CompositionProduits { get; set; }
        public virtual DbSet<DeclinaisonProduit> DeclinaisonProduits { get; set; }
        public virtual DbSet<Depstock> Depstocks { get; set; }
        public virtual DbSet<DetCommandeClient> DetCommandeClients { get; set; }
        public virtual DbSet<DetPanier> DetPaniers { get; set; }
        public virtual DbSet<DetailCommande> DetailCommandes { get; set; }
        public virtual DbSet<DetailTva> DetailTvas { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentCommande> DocumentCommandes { get; set; }
        public virtual DbSet<EntCommandeClient> EntCommandeClients { get; set; }
        public virtual DbSet<EntPanier> EntPaniers { get; set; }
        public virtual DbSet<Etat> Etats { get; set; }
        public virtual DbSet<EtatCommande> EtatCommandes { get; set; }
        public virtual DbSet<EtatPiece> EtatPieces { get; set; }
        public virtual DbSet<EtatProduit> EtatProduits { get; set; }
        public virtual DbSet<Fabriquant> Fabriquants { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Gouvernorat> Gouvernorats { get; set; }
        public virtual DbSet<GroupeClient> GroupeClients { get; set; }
        public virtual DbSet<HistoriqueConnexion> HistoriqueConnexions { get; set; }
        public virtual DbSet<ImageDeclinaisonProduit> ImageDeclinaisonProduits { get; set; }
        public virtual DbSet<ImageProduit> ImageProduits { get; set; }
        public virtual DbSet<Impact> Impacts { get; set; }
        public virtual DbSet<MarqueProduit> MarqueProduits { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessageCommande> MessageCommandes { get; set; }
        public virtual DbSet<Pay> Pays { get; set; }
        public virtual DbSet<Payement> Payements { get; set; }
        public virtual DbSet<PieceJointeProduit> PieceJointeProduits { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<ProprieteProduit> ProprieteProduits { get; set; }
        public virtual DbSet<Proprite> Proprites { get; set; }
        public virtual DbSet<ReductionGroupe> ReductionGroupes { get; set; }
        public virtual DbSet<Style> Styles { get; set; }
        public virtual DbSet<StyleProduit> StyleProduits { get; set; }
        public virtual DbSet<Transporteur> Transporteurs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Valeur> Valeurs { get; set; }
        public virtual DbSet<ValeurProduit> ValeurProduits { get; set; }
        public virtual DbSet<Ville> Villes { get; set; }
        public virtual DbSet<VisibiliteProduit> VisibiliteProduits { get; set; }
        public virtual DbSet<Visibility> Visibilities { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //    optionsBuilder.UseSqlServer("Server=196.179.220.15,1415;Database=TOPONE;user id=sa;Password=an123");
             
                    var configuration = GetConfiguration();
                    string db = configuration.GetConnectionString("DB");
                    string usr = configuration.GetConnectionString("Usr");
                    string serveur = configuration.GetConnectionString("Serveur");
                    string pwd = configuration.GetConnectionString("Pwd");
                    optionsBuilder.UseSqlServer("Server=" + serveur + ";Database=" + db + ";user id=" + usr + ";Password=" + pwd + ";persist security info=False;MultipleActiveResultSets=True");
                
            }
        }



        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            return builder.Build();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1256_CI_AS");

            modelBuilder.Entity<AdresseClient>(entity =>
            {
                entity.ToTable("AdresseClient");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.CodePostal)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Idclient)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDClient");

                entity.Property(e => e.Idville)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDVille");

                entity.Property(e => e.TelFix)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TelGsm)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TelGSM");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Association>(entity =>
            {
                entity.ToTable("Association");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AssociationProd>(entity =>
            {
                entity.HasKey(e => new { e.IdAssociation, e.IdProd });

                entity.ToTable("AssociationProd");

                entity.Property(e => e.IdAssociation).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdProd).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Attribut>(entity =>
            {
                entity.ToTable("Attribut");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AttributProduit>(entity =>
            {
                entity.ToTable("AttributProduit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Designation).IsRequired();
            });

            modelBuilder.Entity<CategorieProduit>(entity =>
            {
                entity.ToTable("CategorieProduit");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Idpere).HasColumnName("IDPere");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("ID");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Cin)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("CIN");

                entity.Property(e => e.CodePostal)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateInscription).HasColumnType("datetime");

                entity.Property(e => e.DateNaissance).HasColumnType("datetime");

                entity.Property(e => e.DerniereVisite).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Idgroupe).HasColumnName("IDGroupe");

                entity.Property(e => e.Idparain)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDParain");

                entity.Property(e => e.IdpieceCinrecto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDPieceCINRecto");

                entity.Property(e => e.IdpieceCinverso)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDPieceCINVerso");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MatriculeFiscal)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.MotPasse)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Pays)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Scredit).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Sdebit).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Sexe).HasMaxLength(2);

                entity.Property(e => e.Societe)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TelFixe)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TelGsm)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TelGSM");

                entity.Property(e => e.Ville)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            //modelBuilder.Entity<Commande>(entity =>
            //{
            //    //entity.HasNoKey();
            //    entity.HasKey(e => e.Id);
            //    entity.ToTable("commande");

            //    entity.Property(e => e.Id)
            //        .HasColumnType("numeric(18, 0)")
            //        .ValueGeneratedOnAdd();

            //    entity.Property(e => e.IdClient).HasColumnType("numeric(18, 0)");

            //    entity.Property(e => e.IdEtatCmd).HasColumnType("numeric(18, 0)");
            //});

            modelBuilder.Entity<Composition>(entity =>
            {
                entity.ToTable("Composition");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CompositionProduit>(entity =>
            {
                entity.ToTable("CompositionProduit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<DeclinaisonProduit>(entity =>
            {
                entity.ToTable("DeclinaisonProduit");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("ID");

                entity.Property(e => e.DateDisponibilite).HasColumnType("datetime");

                entity.Property(e => e.Idattribut).HasColumnName("IDAttribut");

                entity.Property(e => e.IdimageDeclinaison)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("IDImageDeclinaison");

                entity.Property(e => e.IdimpactPrixVente).HasColumnName("IDImpactPrixVente");

                entity.Property(e => e.Idproduit)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDProduit");

                entity.Property(e => e.Idvaleur).HasColumnName("IDValeur");

                entity.Property(e => e.PrixAchat).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PrixAuImpactPrixVente)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("PRixAU_ImpactPrixVente");

                entity.Property(e => e.PrixDuImpactPrixVente)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("PRixDU_ImpactPrixVente");

                entity.Property(e => e.PrixFinalImpactPrixVente)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("PRixFinal_ImpactPrixVente");

                entity.Property(e => e.QuantiteMinimal).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.QuantiteStock).HasColumnType("decimal(18, 3)");
            });

            modelBuilder.Entity<Depstock>(entity =>
            {
                entity.HasKey(e => new { e.Coddep, e.Idproduit, e.Lot });

                entity.ToTable("Depstock");

                entity.Property(e => e.Coddep)
                    .HasMaxLength(20)
                    .HasColumnName("coddep");

                entity.Property(e => e.Idproduit)
                    .HasMaxLength(20)
                    .HasColumnName("IDProduit");

                entity.Property(e => e.Lot).HasMaxLength(30);

                entity.Property(e => e.DatPiece).HasColumnType("datetime");

                entity.Property(e => e.NumPiece)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Priinv)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("priinv");

                entity.Property(e => e.Pu)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("PU");

                entity.Property(e => e.Qte)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("qte");

                entity.Property(e => e.Qte0)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("qte0");

                entity.Property(e => e.Stkdep)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("stkdep");

                entity.Property(e => e.Stkdep0)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("stkdep0");

                entity.Property(e => e.Stkrel)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("stkrel");

                entity.Property(e => e.Stkrel0)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("stkrel0");

                entity.Property(e => e.TypPiece)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<DetCommandeClient>(entity =>
            {
                entity.HasKey(e => e.NumPiece);

                entity.ToTable("DetCommandeClient");

                entity.Property(e => e.NumPiece).HasMaxLength(20);

                entity.Property(e => e.CodTva)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CodeDepot)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DatePiece).HasColumnType("datetime");

                entity.Property(e => e.DesignationArticle)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Idproduit)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDProduit");

                entity.Property(e => e.Lot)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MargeArticle).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.MntHt)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("MntHT");

                entity.Property(e => e.MntTtc)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("MntTTC");

                entity.Property(e => e.PrixU).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PrixUarticle)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("PrixUArticle");

                entity.Property(e => e.Qte).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.QteLivre).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Remise).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Tva)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TVA");

                entity.Property(e => e.TypePiece)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<DetPanier>(entity =>
            {
                entity.HasKey(e => new { e.NumPiece, e.Idproduit });

                entity.ToTable("DetPanier");

                entity.Property(e => e.NumPiece).HasMaxLength(20);

                entity.Property(e => e.Idproduit)
                    .HasMaxLength(20)
                    .HasColumnName("IDProduit");

                entity.Property(e => e.CodTva)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CodeDepot)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DatePiece).HasColumnType("datetime");

                entity.Property(e => e.DesignationArticle)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Lot)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MntHt)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("MntHT");

                entity.Property(e => e.MntTtc)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("MntTTC");

                entity.Property(e => e.PrixU).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Qte).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.QteLivre).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Remise).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Tva)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TVA");

                entity.Property(e => e.TypePiece)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<DetailCommande>(entity =>
            {
                entity.HasKey(e => new { e.IdCmd, e.IdProd, e.Iddoc });

                entity.ToTable("DetailCommande");

                entity.Property(e => e.IdCmd).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdProd).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Iddoc).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<DetailTva>(entity =>
            {
                entity.HasKey(e => e.NumPiece);

                entity.ToTable("DetailTVA");

                entity.Property(e => e.NumPiece).HasMaxLength(20);

                entity.Property(e => e.Assiette).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.CodeTva)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("CodeTVA");

                entity.Property(e => e.DesTva)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("DesTVA");

                entity.Property(e => e.Montant).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TypPiece)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.IdDoc);

                entity.Property(e => e.IdDoc)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extention)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<DocumentCommande>(entity =>
            {
                entity.HasKey(e => new { e.IdDoc, e.IdCommande });

                entity.ToTable("DocumentCommande");

                entity.Property(e => e.IdDoc).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdCommande).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<EntCommandeClient>(entity =>
            {
                entity.HasKey(e => e.NumPiece);

                entity.ToTable("EntCommandeClient");

                entity.Property(e => e.NumPiece).HasMaxLength(20);

                entity.Property(e => e.DatPiece).HasColumnType("datetime");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateSystem).HasColumnType("datetime");

                entity.Property(e => e.Depot)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EtatMail)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.IdadresseFacturationClient).HasColumnName("IDAdresseFacturationClient");

                entity.Property(e => e.IdadresseLivraiconClient).HasColumnName("IDAdresseLivraiconClient");

                entity.Property(e => e.Idbl)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDBL");

                entity.Property(e => e.Idclient)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDClient");

                entity.Property(e => e.Idfacture)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDFacture");

                entity.Property(e => e.IdpieceJointe)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDPieceJointe");

                entity.Property(e => e.TmntHt)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("TMntHT");

                entity.Property(e => e.TmntTtc)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("TMntTTC");

                entity.Property(e => e.TmntTva)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("TMntTVA");

                entity.Property(e => e.Tremise)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("TRemise");

                entity.Property(e => e.TypPiece)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserCreation)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<EntPanier>(entity =>
            {
                entity.HasKey(e => e.NumPiece);

                entity.ToTable("EntPanier");

                entity.Property(e => e.NumPiece).HasMaxLength(20);

                entity.Property(e => e.DatPiece).HasColumnType("datetime");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.DateSystem).HasColumnType("datetime");

                entity.Property(e => e.Depot)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EtatMail)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EtatPiece)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IdadresseFacturationClient).HasColumnName("IDAdresseFacturationClient");

                entity.Property(e => e.IdadresseLivraiconClient).HasColumnName("IDAdresseLivraiconClient");

                entity.Property(e => e.Idclient)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDClient");

                entity.Property(e => e.Idcommande)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDCommande");

                entity.Property(e => e.IdpieceJointe)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDPieceJointe");

                entity.Property(e => e.TmntHt)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("TMntHT");

                entity.Property(e => e.TmntTtc)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("TMntTTC");

                entity.Property(e => e.TmntTva)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("TMntTVA");

                entity.Property(e => e.Tremise)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("TRemise");

                entity.Property(e => e.TypPiece)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserCreation)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Etat>(entity =>
            {
                entity.ToTable("Etat");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EtatCommande>(entity =>
            {
                entity.ToTable("EtatCommande");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdType).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<EtatPiece>(entity =>
            {
                entity.ToTable("EtatPiece");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("ID");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<EtatProduit>(entity =>
            {
                entity.ToTable("EtatProduit");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Designation).IsRequired();
            });

            modelBuilder.Entity<Fabriquant>(entity =>
            {
                entity.ToTable("Fabriquant");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Resume)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Fournisseur>(entity =>
            {
                entity.ToTable("Fournisseur");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.AttestationSuspention)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.CodeTva).HasColumnName("CodeTVA");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.RaisonSocial)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.SoldeCredit).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.SoldeDebit).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Gouvernorat>(entity =>
            {
                entity.ToTable("Gouvernorat");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("ID");

                entity.Property(e => e.DesGouv)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Idpays)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDPays");
            });
            modelBuilder.Entity<Param>(entity =>
            {
                entity.HasKey(e => e.Code);


                entity.ToTable("param");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Valeur)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("valeur");
            });

            modelBuilder.Entity<GroupeClient>(entity =>
            {
                entity.ToTable("GroupeClient");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Actif).HasColumnName("actif");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("designation")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<HistoriqueConnexion>(entity =>
            {
                entity.ToTable("HistoriqueConnexion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdresseIp)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("AdresseIP");

                entity.Property(e => e.DateConnexion).HasColumnType("datetime");

                entity.Property(e => e.Idclient)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDClient");

                entity.Property(e => e.Origine)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PageVue)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ImageDeclinaisonProduit>(entity =>
            {
                entity.HasKey(e => new { e.Idimage, e.Iddeclinaison });

                entity.ToTable("ImageDeclinaisonProduit");

                entity.Property(e => e.Idimage)
                    .HasMaxLength(20)
                    .HasColumnName("IDImage");

                entity.Property(e => e.Iddeclinaison)
                    .HasMaxLength(20)
                    .HasColumnName("IDDeclinaison");

                entity.Property(e => e.Extention)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ImageProduit>(entity =>
            {
                entity.HasKey(e => new { e.Idimage, e.Idproduit });

                entity.ToTable("ImageProduit");

                entity.Property(e => e.Idimage)
                    .HasMaxLength(20)
                    .HasColumnName("IDImage");

                entity.Property(e => e.Idproduit)
                    .HasMaxLength(20)
                    .HasColumnName("IDProduit");

                entity.Property(e => e.Extention)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Impact>(entity =>
            {
                entity.ToTable("Impact");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<MarqueProduit>(entity =>
            {
                entity.ToTable("MarqueProduit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AffichagePrix)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.AfficherPrix)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Remise).HasColumnType("decimal(18, 3)");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdCommande).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<MessageCommande>(entity =>
            {
                entity.HasKey(e => new { e.Idcommande, e.Idmessage });

                entity.ToTable("MessageCommande");

                entity.Property(e => e.Idcommande)
                    .HasMaxLength(20)
                    .HasColumnName("IDCommande");

                entity.Property(e => e.Idmessage).HasColumnName("IDMessage");

                entity.Property(e => e.DescriptionMessage)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Pay>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(200)
                    .HasColumnName("ID");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Payement>(entity =>
            {
                entity.ToTable("Payement");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdCommande).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<PieceJointeProduit>(entity =>
            {
                entity.HasKey(e => new { e.Iddocument, e.Idproduit });

                entity.ToTable("PieceJointeProduit");

                entity.Property(e => e.Iddocument)
                    .HasMaxLength(20)
                    .HasColumnName("IDDocument");

                entity.Property(e => e.Idproduit)
                    .HasMaxLength(20)
                    .HasColumnName("IDProduit");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Extention)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.NomDocument)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.ToTable("Produit");

                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.Acessoire).IsRequired();
                
                entity.Property(e => e.AfficherPrix).HasColumnName("Afficher_Prix");

                entity.Property(e => e.QteStk).HasColumnName("QteStk");

                entity.Property(e => e.CaracteristiqueHauteur)
                    .IsRequired()
                    .HasColumnName("Caracteristique_Hauteur");

                entity.Property(e => e.CaracteristiqueIdcomposition).HasColumnName("Caracteristique_IDComposition");

                entity.Property(e => e.CaracteristiqueIdpropriete).HasColumnName("Caracteristique_IDPropriete");

                entity.Property(e => e.CaracteristiqueIdstyle).HasColumnName("Caracteristique_IDStyle");

                entity.Property(e => e.CaracteristiqueLargeur)
                    .IsRequired()
                    .HasColumnName("Caracteristique_Largeur");

                entity.Property(e => e.CaracteristiquePoids)
                    .IsRequired()
                    .HasColumnName("Caracteristique_Poids");

                entity.Property(e => e.CaracteristiqueProfondeur)
                    .IsRequired()
                    .HasColumnName("Caracteristique_Profondeur");

                entity.Property(e => e.CodeTva).HasColumnName("CodeTVA");

                entity.Property(e => e.DesTva)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("DesTVA");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasColumnName("designation");

                entity.Property(e => e.DisponibiliteALaVente).HasColumnName("disponibilite_a_la_vente");

                entity.Property(e => e.FraisPortSupplimentaire).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.HauteurColis).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.LargeurDuColis)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Largeur_du_colis");

                entity.Property(e => e.Marge).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.MotsCles).IsRequired();

                entity.Property(e => e.PoidsColis).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PrixAchatHt)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("PrixAchatHT");

                entity.Property(e => e.PrixVenteHt)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("PrixVenteHT");

                entity.Property(e => e.PrixVenteTtc)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("PrixVenteTTC");

                entity.Property(e => e.ProfondeurColis).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference");

                entity.Property(e => e.Resume).IsRequired();

                entity.Property(e => e.RuptureAccepteCommande).HasColumnName("Rupture_AccepteCommande");

                entity.Property(e => e.RuptureAnnulerCommande).HasColumnName("Rupture_AnnulerCommande");

                entity.Property(e => e.RuptureDefaut).HasColumnName("Rupture_Defaut");

                entity.Property(e => e.Visibilite).HasColumnName("visibilite");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Promotion");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdProduit).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<ProprieteProduit>(entity =>
            {
                entity.ToTable("ProprieteProduit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Proprite>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ReductionGroupe>(entity =>
            {
                entity.HasKey(e => new { e.Idgroupe, e.Idcategorie });

                entity.ToTable("ReductionGroupe");

                entity.Property(e => e.Idgroupe).HasColumnName("IDGroupe");

                entity.Property(e => e.Idcategorie).HasColumnName("IDCategorie");

                entity.Property(e => e.Remise).HasColumnType("decimal(18, 3)");
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<StyleProduit>(entity =>
            {
                entity.ToTable("StyleProduit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Transporteur>(entity =>
            {
                entity.ToTable("Transporteur");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Adresse).IsRequired();

                entity.Property(e => e.Nom).IsRequired();

                entity.Property(e => e.Scredit).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Sdebit).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TelFax).IsRequired();

                entity.Property(e => e.TelFixe).IsRequired();

                entity.Property(e => e.TelGsm)
                    .IsRequired()
                    .HasColumnName("TelGSM");
            });
            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserType");

                entity.Property(e => e.Actif).HasColumnName("actif");

                entity.Property(e => e.Designation).IsRequired();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                // entity.HasNoKey();
                entity.HasKey(e => new { e.Login });

                entity.ToTable("User");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");

                entity.Property(e => e.Liaison)
                    .HasMaxLength(50)
                    .HasColumnName("liaison");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.UserCreation)
                    .IsRequired()
                    .HasMaxLength(50);
            });
            modelBuilder.Entity<Date>(entity =>
            {
                entity.HasKey(e => new { e.DateCreation });

                entity.ToTable("Date");

                entity.Property(e => e.DateCreation).HasColumnType("datetime");
  
            });

            modelBuilder.Entity<Valeur>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdAttribut });

                entity.ToTable("Valeur");

                entity.Property(e => e.Id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IdAttribut).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<ValeurProduit>(entity =>
            {
                entity.ToTable("ValeurProduit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Idattribut).HasColumnName("IDAttribut");
            });

            modelBuilder.Entity<Ville>(entity =>
            {
                entity.ToTable("Ville");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("ID");

                entity.Property(e => e.Cp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("CP");

                entity.Property(e => e.DesVille)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Idgouv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("IDGouv");
            });

            modelBuilder.Entity<VisibiliteProduit>(entity =>
            {
                entity.ToTable("VisibiliteProduit");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Designation).IsRequired();
            });

            modelBuilder.Entity<Visibility>(entity =>
            {
                entity.ToTable("Visibility");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
