using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.DataLayer.Context;
using RealEstate.Domain.Estate;
using RealEstate.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstate.DataLayer
{
   public class SeedDB
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<RealEstateDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();
            //if (!context.Users.Any())
            //{
            //    ApplicationUser user = new ApplicationUser()
            //    {
            //        Email = "ali@gmail.com",
            //        SecurityStamp = Guid.NewGuid().ToString(),
            //        UserName = "Ali"
            //    };
            //    userManager.CreateAsync(user, "Ali@123");
            //}
            if(!context.EstateStatuses.Any())
            {
                var estatestatuse = new List<EstateStatus>
                {
                    new EstateStatus
                    {
                    EstateStatusName = "Kiralik",
                    Created = DateTime.Now,
                    Enable = true,
                    Modified = DateTime.Now
                    },
                    new EstateStatus
                    {
                    EstateStatusName = "Satilik",
                    Created = DateTime.Now,
                    Enable = true,
                    Modified = DateTime.Now
                    }

                };
                context.AddRange(estatestatuse);
                context.SaveChanges();
            }
            if(!context.Estates.Any())
            {
                var estates = new List<Estates>()
                {
                   new Estates
                   {
                    Address= "Bahçekapı Etimesgut/Ankara 39.935646, 32.744088",
                    Area=130,
                    Baths=3,
                    Beds=2,
                    Garages =2,
                    Created =DateTime.Now,
                    Modified=DateTime.Now,
                    Enable=true,
                    EstateLogo="listing.jpg",
                    EstateStatusId=1,
                    Title="Daire1",
                    Price=600,
                    AboutText="Bölgenin en geniş ve en kullanışlı 3+1 idir.Havuza cephe,ebeveyn banyolu,yüzme havuzlu,güvenlik,görüntülü diafon,arıtma sistemi ve yaşam alanına sahip lüx sitede kaliteli malzemeler ile konforlu bir 3+1,sitenin peyzaj çalışması devam etmekte olup iskan aşamasına gelmek üzeredir,elektrik ve su aboneliği alınabilmektedir,dileyen direk oturmaya başlayabilir..."
                              +"İskan sonrasında bu fiyatlar yukarı yönlü revize edilecektir."
                              +"Daha detaylı bilgi için arayınız.."
                   },
                   new Estates
                   {
                    Address= "Kaletepe 06210 Yenimahalle/Ankara 39.982167, 32.792398",
                    Area=150,
                    Baths=2,
                    Beds=3,
                    Garages =2,
                    Created =DateTime.Now,
                    Modified=DateTime.Now,
                    Enable=true,
                    EstateLogo="listing_1.jpg",
                    EstateStatusId=1,
                    Title="Daire2",
                    Price=800,
                    AboutText="Bölgenin en geniş ve en kullanışlı 3+1 idir.Havuza cephe,ebeveyn banyolu,yüzme havuzlu,güvenlik,görüntülü diafon,arıtma sistemi ve yaşam alanına sahip lüx sitede kaliteli malzemeler ile konforlu bir 3+1,sitenin peyzaj çalışması devam etmekte olup iskan aşamasına gelmek üzeredir,elektrik ve su aboneliği alınabilmektedir,dileyen direk oturmaya başlayabilir..."
                              +"İskan sonrasında bu fiyatlar yukarı yönlü revize edilecektir."
                              +"Daha detaylı bilgi için arayınız.."
                   },
                   new Estates
                   {
                    Address= "Tarım Ve Köy İşleri Bakanlığı Gayret, 06170 Yenimahalle/Ankara 39.954258, 32.803444",
                    Area=170,
                    Baths=4,
                    Beds=2,
                    Garages =3,
                    Created =DateTime.Now,
                    Modified=DateTime.Now,
                    Enable=true,
                    EstateLogo="listing_2.jpg",
                    EstateStatusId=1,
                    Title="Daire3",
                    Price=500,
                    AboutText="Bölgenin en geniş ve en kullanışlı 3+1 idir.Havuza cephe,ebeveyn banyolu,yüzme havuzlu,güvenlik,görüntülü diafon,arıtma sistemi ve yaşam alanına sahip lüx sitede kaliteli malzemeler ile konforlu bir 3+1,sitenin peyzaj çalışması devam etmekte olup iskan aşamasına gelmek üzeredir,elektrik ve su aboneliği alınabilmektedir,dileyen direk oturmaya başlayabilir..."
                              +"İskan sonrasında bu fiyatlar yukarı yönlü revize edilecektir."
                              +"Daha detaylı bilgi için arayınız.."
                   },
                   new Estates
                   {
                    Address= "Çarşı 06170 Yenimahalle/Ankara 39.967749, 32.808542",
                    Area=130,
                    Baths=3,
                    Beds=4,
                    Garages =3,
                    Created =DateTime.Now,
                    Modified=DateTime.Now,
                    Enable=true,
                    EstateLogo="listing_3.jpg",
                    EstateStatusId=1,
                    Title="Daire4",
                    Price=900,
                    AboutText="Bölgenin en geniş ve en kullanışlı 3+1 idir.Havuza cephe,ebeveyn banyolu,yüzme havuzlu,güvenlik,görüntülü diafon,arıtma sistemi ve yaşam alanına sahip lüx sitede kaliteli malzemeler ile konforlu bir 3+1,sitenin peyzaj çalışması devam etmekte olup iskan aşamasına gelmek üzeredir,elektrik ve su aboneliği alınabilmektedir,dileyen direk oturmaya başlayabilir..."
                              +"İskan sonrasında bu fiyatlar yukarı yönlü revize edilecektir."
                              +"Daha detaylı bilgi için arayınız.."
                   },
                   new Estates
                   {
                    Address= "Ayvalı 06010 Keçiören/Ankara 39.971842, 32.825172",
                    Area=180,
                    Baths=3,
                    Beds=2,
                    Garages =2,
                    Created =DateTime.Now,
                    Modified=DateTime.Now,
                    Enable=true,
                    EstateLogo="listing_4.jpg",
                    EstateStatusId=2,
                    Title="Daire5",
                    Price=200000,
                    AboutText="Bölgenin en geniş ve en kullanışlı 3+1 idir.Havuza cephe,ebeveyn banyolu,yüzme havuzlu,güvenlik,görüntülü diafon,arıtma sistemi ve yaşam alanına sahip lüx sitede kaliteli malzemeler ile konforlu bir 3+1,sitenin peyzaj çalışması devam etmekte olup iskan aşamasına gelmek üzeredir,elektrik ve su aboneliği alınabilmektedir,dileyen direk oturmaya başlayabilir..."
                              +"İskan sonrasında bu fiyatlar yukarı yönlü revize edilecektir."
                              +"Daha detaylı bilgi için arayınız.."
                   },
                   new Estates
                   {
                    Address= "Etlik 06010 Keçiören/Ankara 39.981981, 32.821530 Aşağı Eğlence 06010 Keçiören/Ankara 39.969702, 32.838766",
                    Area=120,
                    Baths=3,
                    Beds=4,
                    Garages =1,
                    Created =DateTime.Now,
                    Modified=DateTime.Now,
                    Enable=true,
                    EstateLogo="listing_5.jpg",
                    EstateStatusId=2,
                    Title="Daire6",
                    Price=300000,
                    AboutText="Bölgenin en geniş ve en kullanışlı 3+1 idir.Havuza cephe,ebeveyn banyolu,yüzme havuzlu,güvenlik,görüntülü diafon,arıtma sistemi ve yaşam alanına sahip lüx sitede kaliteli malzemeler ile konforlu bir 3+1,sitenin peyzaj çalışması devam etmekte olup iskan aşamasına gelmek üzeredir,elektrik ve su aboneliği alınabilmektedir,dileyen direk oturmaya başlayabilir..."
                              +"İskan sonrasında bu fiyatlar yukarı yönlü revize edilecektir."
                              +"Daha detaylı bilgi için arayınız.."
                   },
                   new Estates
                   {
                    Address= "Yayla 06220 Keçiören/Ankara 39.989049, 32.819831",
                    Area=110,
                    Baths=3,
                    Beds=2,
                    Garages =2,
                    Created =DateTime.Now,
                    Modified=DateTime.Now,
                    Enable=true,
                    EstateLogo="listing_6.jpg",
                    EstateStatusId=1,
                    Title="Daire7",
                    Price=600,
                    AboutText="Bölgenin en geniş ve en kullanışlı 3+1 idir.Havuza cephe,ebeveyn banyolu,yüzme havuzlu,güvenlik,görüntülü diafon,arıtma sistemi ve yaşam alanına sahip lüx sitede kaliteli malzemeler ile konforlu bir 3+1,sitenin peyzaj çalışması devam etmekte olup iskan aşamasına gelmek üzeredir,elektrik ve su aboneliği alınabilmektedir,dileyen direk oturmaya başlayabilir..."
                              +"İskan sonrasında bu fiyatlar yukarı yönlü revize edilecektir."
                              +"Daha detaylı bilgi için arayınız.."
                   },
                   new Estates
                   {
                    Address= "Çiğdemtepe 06210 Yenimahalle/Ankara 39.992862, 32.795311",
                    Area=140,
                    Baths=2,
                    Beds=4,
                    Garages =2,
                    Created =DateTime.Now,
                    Modified=DateTime.Now,
                    Enable=true,
                    EstateLogo="listing_7.jpg",
                    EstateStatusId=2,
                    Title="Daire8",
                    Price=250000,
                    AboutText="Bölgenin en geniş ve en kullanışlı 3+1 idir.Havuza cephe,ebeveyn banyolu,yüzme havuzlu,güvenlik,görüntülü diafon,arıtma sistemi ve yaşam alanına sahip lüx sitede kaliteli malzemeler ile konforlu bir 3+1,sitenin peyzaj çalışması devam etmekte olup iskan aşamasına gelmek üzeredir,elektrik ve su aboneliği alınabilmektedir,dileyen direk oturmaya başlayabilir..."
                              +"İskan sonrasında bu fiyatlar yukarı yönlü revize edilecektir."
                              +"Daha detaylı bilgi için arayınız.."
                   },
                   new Estates
                   {
                    Address= "Yenimahalle Belediyesi Temizlik İşleri Müdürlüğü Varlık, 06170 Yenimahalle/Ankara 39.960678, 32.831241",
                    Area=145,
                    Baths=3,
                    Beds=3,
                    Garages =2,
                    Created =DateTime.Now,
                    Modified=DateTime.Now,
                    Enable=true,
                    EstateLogo="listing_8.jpg",
                    EstateStatusId=2,
                    Title="Daire9",
                    Price=350000,
                    AboutText="Bölgenin en geniş ve en kullanışlı 3+1 idir.Havuza cephe,ebeveyn banyolu,yüzme havuzlu,güvenlik,görüntülü diafon,arıtma sistemi ve yaşam alanına sahip lüx sitede kaliteli malzemeler ile konforlu bir 3+1,sitenin peyzaj çalışması devam etmekte olup iskan aşamasına gelmek üzeredir,elektrik ve su aboneliği alınabilmektedir,dileyen direk oturmaya başlayabilir..."
                              +"İskan sonrasında bu fiyatlar yukarı yönlü revize edilecektir."
                              +"Daha detaylı bilgi için arayınız.."
                   },
                   new Estates
                   {
                    Address= "Bahçekapı Etimesgut/Ankara 39.941975, 32.721875",
                    Area=90,
                    Baths=2,
                    Beds=2,
                    Garages =1,
                    Created =DateTime.Now,
                    Modified=DateTime.Now,
                    Enable=true,
                    EstateLogo="listing_9.jpg",
                    EstateStatusId=2,
                    Title="Daire10",
                    Price=230000,
                    AboutText="Bölgenin en geniş ve en kullanışlı 3+1 idir.Havuza cephe,ebeveyn banyolu,yüzme havuzlu,güvenlik,görüntülü diafon,arıtma sistemi ve yaşam alanına sahip lüx sitede kaliteli malzemeler ile konforlu bir 3+1,sitenin peyzaj çalışması devam etmekte olup iskan aşamasına gelmek üzeredir,elektrik ve su aboneliği alınabilmektedir,dileyen direk oturmaya başlayabilir..."
                              +"İskan sonrasında bu fiyatlar yukarı yönlü revize edilecektir."
                              +"Daha detaylı bilgi için arayınız.."
                   }
                };
                context.Estates.AddRange(estates);
                context.SaveChanges();
            }
        }
    }
}
