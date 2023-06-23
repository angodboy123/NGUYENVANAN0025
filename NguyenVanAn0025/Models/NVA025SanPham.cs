using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NguyenVanAn0025.Models;

 [Table("SanPham")]
 public class NVA025SanPham{
  [Key]
    public string? MaSanPham {get;set;}
    public string? TenSanPham {get;set;}
    public string? GiaSanPham {get;set;}




 }