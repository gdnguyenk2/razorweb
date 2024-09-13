using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace razorweb.models{
    public class Article{
        [Key]
        public int Id{get;set;}
        [StringLength(255,MinimumLength =5,ErrorMessage ="{0} phải dài từ {1} đến {2}")]
        [Required(ErrorMessage ="{0} phải nhập")]
        [DisplayName("Tiêu đề")]
        [Column(TypeName ="nvarchar")]
        public string Title{get;set;}
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="{0} phải nhập")]
        [DisplayName("Ngày tạo")]
        public DateTime Created{get;set;}
        [Column(TypeName ="ntext")]
        [DisplayName("Nội dung")]
        public string? Content{get;set;}
    }
}