using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebStore.BusinessLogic.DTO.Product
{
    public class ProductFilterDTO
    {
        [DisplayName("Категория")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        public int CategoryId { get; set; }

        [DisplayName("Имя")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        [MaxLength(200, ErrorMessage = "Превышена ммаксимальная длина")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        [MaxLength(500, ErrorMessage = "Превышена ммаксимальная длина")]
        public string Description { get; set; }

        [DisplayName("Цена от")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        public double PriceMin { get; set; }

        [DisplayName("Цена до")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        public double PriceMax { get; set; }

        [DisplayName("Удален")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Поле обязательно для заполнения")]
        public bool IsDeleted { get; set; }

    }
}
