using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Seeders
{
    public static class DatabaseSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed user
            _ = modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Email = "chihtt123@gmail.com",
                    UserName = "chi",
                    Password = "123",
                    Role = true
                }
            );

            // Seed products
            _ = modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Casio Classic", Name = "Casio F91W", Description = "Đồng hồ điện tử huyền thoại", Url = "casio-f91w", Gender = "Unisex", Price = 250000, ProductImageUrl = "/images/products/casio1.jpg" },
                new Product { Id = 2, Title = "Casio Vintage", Name = "Casio A168WA", Description = "Thiết kế cổ điển sang trọng", Url = "casio-a168wa", Gender = "Unisex", Price = 450000, ProductImageUrl = "/images/products/casio2.jpg" },
                new Product { Id = 3, Title = "Seiko Automatic", Name = "Seiko 5 SNK809", Description = "Automatic, dây vải", Url = "seiko-snk809", Gender = "Men", Price = 2200000, ProductImageUrl = "/images/products/seiko1.jpg" },
                new Product { Id = 4, Title = "Seiko Diver", Name = "Seiko SKX007", Description = "Dòng lặn nổi tiếng", Url = "seiko-skx007", Gender = "Men", Price = 5500000, ProductImageUrl = "/images/products/seiko2.jpg" },
                new Product { Id = 5, Title = "Orient Bambino", Name = "Orient FAC00009N0", Description = "Dresswatch thanh lịch", Url = "orient-bambino", Gender = "Men", Price = 3200000, ProductImageUrl = "/images/products/orient1.jpg" },
                new Product { Id = 6, Title = "Orient Mako II", Name = "Orient FAA02009D9", Description = "Diver giá rẻ", Url = "orient-mako2", Gender = "Men", Price = 3800000, ProductImageUrl = "/images/products/orient2.jpg" },
                new Product { Id = 7, Title = "Citizen Eco-Drive", Name = "Citizen BM8180", Description = "Năng lượng ánh sáng", Url = "citizen-bm8180", Gender = "Men", Price = 2900000, ProductImageUrl = "/images/products/citizen1.jpg" },
                new Product { Id = 8, Title = "Citizen Chronograph", Name = "Citizen AN8190", Description = "Chronograph thể thao", Url = "citizen-an8190", Gender = "Men", Price = 3500000, ProductImageUrl = "/images/products/citizen2.jpg" },
                new Product { Id = 9, Title = "Rolex Submariner", Name = "Rolex 116610LN", Description = "Huyền thoại xa xỉ", Url = "rolex-submariner", Gender = "Men", Price = 220000000, ProductImageUrl = "/images/products/rolex1.jpg" },
                new Product { Id = 10, Title = "Rolex Datejust", Name = "Rolex 126334", Description = "Đẳng cấp doanh nhân", Url = "rolex-datejust", Gender = "Men", Price = 180000000, ProductImageUrl = "/images/products/rolex2.jpg" },
                new Product { Id = 11, Title = "Omega Speedmaster", Name = "Omega Moonwatch", Description = "Đồng hồ Mặt Trăng", Url = "omega-speedmaster", Gender = "Men", Price = 150000000, ProductImageUrl = "/images/products/omega1.jpg" },
                new Product { Id = 12, Title = "Omega Seamaster", Name = "Omega Diver 300M", Description = "James Bond watch", Url = "omega-seamaster", Gender = "Men", Price = 120000000, ProductImageUrl = "/images/products/omega2.jpg" },
                new Product { Id = 13, Title = "Tissot Gentleman", Name = "Tissot Powermatic 80", Description = "Automatic 80 giờ trữ cót", Url = "tissot-gentleman", Gender = "Men", Price = 18000000, ProductImageUrl = "/images/products/tissot1.jpg" },
                new Product { Id = 14, Title = "Tissot PRX", Name = "Tissot PRX Quartz", Description = "Thiết kế retro", Url = "tissot-prx", Gender = "Unisex", Price = 9000000, ProductImageUrl = "/images/products/tissot2.jpg" },
                new Product { Id = 15, Title = "Daniel Wellington", Name = "DW Classic Petite", Description = "Thời trang tối giản", Url = "dw-petite", Gender = "Women", Price = 2800000, ProductImageUrl = "/images/products/dw1.jpg" },
                new Product { Id = 16, Title = "Daniel Wellington", Name = "DW Classic Black", Description = "Phong cách hiện đại", Url = "dw-black", Gender = "Unisex", Price = 3000000, ProductImageUrl = "/images/products/dw2.jpg" },
                new Product { Id = 17, Title = "Fossil Chronograph", Name = "Fossil FS4656", Description = "Thiết kế mạnh mẽ", Url = "fossil-fs4656", Gender = "Men", Price = 3500000, ProductImageUrl = "/images/products/fossil1.jpg" },
                new Product { Id = 18, Title = "Fossil Minimalist", Name = "Fossil FS5304", Description = "Phong cách thanh lịch", Url = "fossil-fs5304", Gender = "Men", Price = 3200000, ProductImageUrl = "/images/products/fossil2.jpg" },
                new Product { Id = 19, Title = "Longines HydroConquest", Name = "Longines L37814566", Description = "Diver Swiss Made", Url = "longines-hydro", Gender = "Men", Price = 42000000, ProductImageUrl = "/images/products/longines1.jpg" },
                new Product { Id = 20, Title = "Longines Master", Name = "Longines L26284783", Description = "Dresswatch cổ điển", Url = "longines-master", Gender = "Men", Price = 58000000, ProductImageUrl = "/images/products/longines2.jpg" },
                new Product { Id = 21, Title = "Hamilton Khaki Field", Name = "Hamilton H70455533", Description = "Đồng hồ quân đội", Url = "hamilton-khaki", Gender = "Men", Price = 15000000, ProductImageUrl = "/images/products/hamilton1.jpg" },
                new Product { Id = 22, Title = "Hamilton Jazzmaster", Name = "Hamilton H32515555", Description = "Thanh lịch, sang trọng", Url = "hamilton-jazz", Gender = "Men", Price = 19000000, ProductImageUrl = "/images/products/hamilton2.jpg" },
                new Product { Id = 23, Title = "Tag Heuer Carrera", Name = "Carrera Calibre 16", Description = "Chronograph Thụy Sĩ", Url = "tag-carrera", Gender = "Men", Price = 95000000, ProductImageUrl = "/images/products/tag1.jpg" },
                new Product { Id = 24, Title = "Tag Heuer Aquaracer", Name = "Aquaracer 300M", Description = "Thể thao chuyên nghiệp", Url = "tag-aquaracer", Gender = "Men", Price = 85000000, ProductImageUrl = "/images/products/tag2.jpg" },
                new Product { Id = 25, Title = "Swatch Originals", Name = "Swatch GN718", Description = "Giá rẻ, nhiều màu", Url = "swatch-gn718", Gender = "Unisex", Price = 1500000, ProductImageUrl = "/images/products/swatch1.jpg" },
                new Product { Id = 26, Title = "Swatch Big Bold", Name = "Swatch SO27B100", Description = "Thiết kế trẻ trung", Url = "swatch-bigbold", Gender = "Unisex", Price = 1800000, ProductImageUrl = "/images/products/swatch2.jpg" },
                new Product { Id = 27, Title = "Apple Watch SE", Name = "Apple Watch SE 44mm", Description = "Smartwatch giá rẻ", Url = "apple-watch-se", Gender = "Unisex", Price = 7500000, ProductImageUrl = "/images/products/apple1.jpg" },
                new Product { Id = 28, Title = "Apple Watch Ultra", Name = "Apple Watch Ultra 2", Description = "Siêu bền, cao cấp", Url = "apple-watch-ultra", Gender = "Unisex", Price = 22000000, ProductImageUrl = "/images/products/apple2.jpg" },
                new Product { Id = 29, Title = "Samsung Galaxy Watch", Name = "Galaxy Watch 6", Description = "Đồng hồ thông minh Android", Url = "galaxy-watch6", Gender = "Unisex", Price = 8500000, ProductImageUrl = "/images/products/samsung1.jpg" },
                new Product { Id = 30, Title = "Garmin Forerunner", Name = "Forerunner 265", Description = "Đồng hồ chạy bộ chuyên dụng", Url = "garmin-265", Gender = "Unisex", Price = 12000000, ProductImageUrl = "/images/products/garmin1.jpg" }
            );
        }
    }
}
