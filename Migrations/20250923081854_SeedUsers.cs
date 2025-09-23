using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "Gender", "Name", "Price", "ProductImageUrl", "Title", "Url" },
                values: new object[,]
                {
                    { 1, null, "Đồng hồ điện tử huyền thoại", "Unisex", "Casio F91W", 250000m, "/images/products/casio1.jpg", "Casio Classic", "casio-f91w" },
                    { 2, null, "Thiết kế cổ điển sang trọng", "Unisex", "Casio A168WA", 450000m, "/images/products/casio2.jpg", "Casio Vintage", "casio-a168wa" },
                    { 3, null, "Automatic, dây vải", "Men", "Seiko 5 SNK809", 2200000m, "/images/products/seiko1.jpg", "Seiko Automatic", "seiko-snk809" },
                    { 4, null, "Dòng lặn nổi tiếng", "Men", "Seiko SKX007", 5500000m, "/images/products/seiko2.jpg", "Seiko Diver", "seiko-skx007" },
                    { 5, null, "Dresswatch thanh lịch", "Men", "Orient FAC00009N0", 3200000m, "/images/products/orient1.jpg", "Orient Bambino", "orient-bambino" },
                    { 6, null, "Diver giá rẻ", "Men", "Orient FAA02009D9", 3800000m, "/images/products/orient2.jpg", "Orient Mako II", "orient-mako2" },
                    { 7, null, "Năng lượng ánh sáng", "Men", "Citizen BM8180", 2900000m, "/images/products/citizen1.jpg", "Citizen Eco-Drive", "citizen-bm8180" },
                    { 8, null, "Chronograph thể thao", "Men", "Citizen AN8190", 3500000m, "/images/products/citizen2.jpg", "Citizen Chronograph", "citizen-an8190" },
                    { 9, null, "Huyền thoại xa xỉ", "Men", "Rolex 116610LN", 220000000m, "/images/products/rolex1.jpg", "Rolex Submariner", "rolex-submariner" },
                    { 10, null, "Đẳng cấp doanh nhân", "Men", "Rolex 126334", 180000000m, "/images/products/rolex2.jpg", "Rolex Datejust", "rolex-datejust" },
                    { 11, null, "Đồng hồ Mặt Trăng", "Men", "Omega Moonwatch", 150000000m, "/images/products/omega1.jpg", "Omega Speedmaster", "omega-speedmaster" },
                    { 12, null, "James Bond watch", "Men", "Omega Diver 300M", 120000000m, "/images/products/omega2.jpg", "Omega Seamaster", "omega-seamaster" },
                    { 13, null, "Automatic 80 giờ trữ cót", "Men", "Tissot Powermatic 80", 18000000m, "/images/products/tissot1.jpg", "Tissot Gentleman", "tissot-gentleman" },
                    { 14, null, "Thiết kế retro", "Unisex", "Tissot PRX Quartz", 9000000m, "/images/products/tissot2.jpg", "Tissot PRX", "tissot-prx" },
                    { 15, null, "Thời trang tối giản", "Women", "DW Classic Petite", 2800000m, "/images/products/dw1.jpg", "Daniel Wellington", "dw-petite" },
                    { 16, null, "Phong cách hiện đại", "Unisex", "DW Classic Black", 3000000m, "/images/products/dw2.jpg", "Daniel Wellington", "dw-black" },
                    { 17, null, "Thiết kế mạnh mẽ", "Men", "Fossil FS4656", 3500000m, "/images/products/fossil1.jpg", "Fossil Chronograph", "fossil-fs4656" },
                    { 18, null, "Phong cách thanh lịch", "Men", "Fossil FS5304", 3200000m, "/images/products/fossil2.jpg", "Fossil Minimalist", "fossil-fs5304" },
                    { 19, null, "Diver Swiss Made", "Men", "Longines L37814566", 42000000m, "/images/products/longines1.jpg", "Longines HydroConquest", "longines-hydro" },
                    { 20, null, "Dresswatch cổ điển", "Men", "Longines L26284783", 58000000m, "/images/products/longines2.jpg", "Longines Master", "longines-master" },
                    { 21, null, "Đồng hồ quân đội", "Men", "Hamilton H70455533", 15000000m, "/images/products/hamilton1.jpg", "Hamilton Khaki Field", "hamilton-khaki" },
                    { 22, null, "Thanh lịch, sang trọng", "Men", "Hamilton H32515555", 19000000m, "/images/products/hamilton2.jpg", "Hamilton Jazzmaster", "hamilton-jazz" },
                    { 23, null, "Chronograph Thụy Sĩ", "Men", "Carrera Calibre 16", 95000000m, "/images/products/tag1.jpg", "Tag Heuer Carrera", "tag-carrera" },
                    { 24, null, "Thể thao chuyên nghiệp", "Men", "Aquaracer 300M", 85000000m, "/images/products/tag2.jpg", "Tag Heuer Aquaracer", "tag-aquaracer" },
                    { 25, null, "Giá rẻ, nhiều màu", "Unisex", "Swatch GN718", 1500000m, "/images/products/swatch1.jpg", "Swatch Originals", "swatch-gn718" },
                    { 26, null, "Thiết kế trẻ trung", "Unisex", "Swatch SO27B100", 1800000m, "/images/products/swatch2.jpg", "Swatch Big Bold", "swatch-bigbold" },
                    { 27, null, "Smartwatch giá rẻ", "Unisex", "Apple Watch SE 44mm", 7500000m, "/images/products/apple1.jpg", "Apple Watch SE", "apple-watch-se" },
                    { 28, null, "Siêu bền, cao cấp", "Unisex", "Apple Watch Ultra 2", 22000000m, "/images/products/apple2.jpg", "Apple Watch Ultra", "apple-watch-ultra" },
                    { 29, null, "Đồng hồ thông minh Android", "Unisex", "Galaxy Watch 6", 8500000m, "/images/products/samsung1.jpg", "Samsung Galaxy Watch", "galaxy-watch6" },
                    { 30, null, "Đồng hồ chạy bộ chuyên dụng", "Unisex", "Forerunner 265", 12000000m, "/images/products/garmin1.jpg", "Garmin Forerunner", "garmin-265" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 30);
        }
    }
}
