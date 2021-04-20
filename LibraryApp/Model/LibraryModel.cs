using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Model
{
    public class LibraryModel
    {
        //public MasterBuku masterBuku { get; set; }
        public MasterVisitor masterVisitor { get; set; }
        public TrxPinjam trxpinjam { get; set; }
        public List<MasterBuku> _listMasterBuku { get; set; }
        public List<MasterVisitor> _listMasterVisitor { get; set; }
        public List<TrxPinjam> _listTrxPinjam { get; set; }
        public class MasterVisitor
        {
            public int VisitorID { get; set; }
            public string NIK { get; set; }
            public string Nama { get; set; }
            public string NoTelepon { get; set; }
            public string Alamat { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class MasterBuku
        {
            public int BukuID { get; set; }
            public string Kategori { get; set; }
            public string JudulBuku { get; set; }
            public string Penerbit { get; set; }
            public string Penulis { get; set; }
            public int TahunTerbit { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class MasterKategori
        {
            public int KategoriID { get; set; }
            public string KategoriDesc { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class TrxPinjam
        {
            public int PinjamID { get; set; }
            public int VisitorID { get; set; }
            public int BukuID { get; set; }
            public string JudulBuku { get; set; }
            public DateTime TanggalPinjam { get; set; }
            public DateTime? TanggalPengembalian { get; set; }
            public DateTime BatasPinjaman { get; set; }
            public int Denda { get; set; }
            public bool IsDeleted { get; set; }

        }
    }
}
