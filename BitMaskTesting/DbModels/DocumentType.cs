namespace BitMaskTesting.DbModels
{
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }
        public string Name { get; set; }
        public int DocumentCategoryId { get; set; }

        public byte[] FormMask { get; set; }

        public DocumentCategory DocumentCategory { get; set; }
    }
}
