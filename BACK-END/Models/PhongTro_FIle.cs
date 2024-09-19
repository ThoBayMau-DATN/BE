namespace BACK_END.Models
{
    public class PhongTro_FIle
    {
        public int Id { get; set; }
        public int PhongTroId { get; set; }
        public PhongTro? PhongTro { get; set; }
        public int FileId { get; set; }
        public File? File { get; set; }
    }
}
