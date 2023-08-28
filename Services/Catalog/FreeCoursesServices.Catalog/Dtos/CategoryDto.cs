using System;
namespace FreeCourse.Services.Catalog.Dtos
{
    public class CategoryDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
    }
}

//(Data Transfer Object) Entity sınıflarımızı apiler aracılığıyla dış dünyaya açmak bir güvenlik açığıdır.
//veritabanı varlıkları (entity) iş mantığı katmanına geçirilmez, bunun yerine DTO’lar kullanılır. Bu, katmanlar arasındaki sıkı bağımlılığı azaltır
//ve değişikliklerin daha kolay yönetilmesini sağlar.