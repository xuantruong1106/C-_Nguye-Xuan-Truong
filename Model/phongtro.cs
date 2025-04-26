using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Phongtro{[Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Hinhthucthanhtoan")]
        public int id_hinh_thuc_thanh_toan { get; set; }

        public Hinhthucthanhtoan Hinhthucthanhtoan { get; set; } // Navigation property

        [Required]
        public string TenNguoiThue { get; set; }

        [Required]
        public string SDT { get; set; }

        public DateTime NgayThue { get; set; }  = DateTime.Now;
        public string GhiChu { get; set; }
}