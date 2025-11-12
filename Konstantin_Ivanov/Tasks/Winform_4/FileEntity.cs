using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Winform_4
{
    [Table("files")]
    public class FileEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("file_name")]
        public string FileName { get; set; }

        [Column("total_bytes")]
        public long TotalBytes { get; set; }

        [Column("uploaded_bytes")]
        public long UploadedBytes { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }
}
