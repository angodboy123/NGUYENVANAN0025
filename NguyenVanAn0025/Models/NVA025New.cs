using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NguyenVanAn0025.Models;


 public class NVA025New{
  [Key]
    public int? NewID {get;set;}
    public string? NewMa {get;set;}

    public string? TenSanPham {get;set;}
    [ForeignKey("TenSanPham")]

    public NVA025SanPham? NVA025SanPham {get;set;}

 }