using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Model
{
    public class LibraryVM
    {
        string strconnection = "Data Source=SKUY\\SQLEXPRESS;Initial Catalog=Library;User ID=sa;password=300396;";

        LibraryModel models = new LibraryModel();
        LibraryModel.MasterBuku masterBuku = new LibraryModel.MasterBuku();
        LibraryModel.MasterVisitor masterVisitor = new LibraryModel.MasterVisitor();
        DataTable dt = new DataTable();

        public DataTable GetMasterBuku()
        {
            using (SqlConnection con = new SqlConnection(strconnection))
            {

                SqlCommand cmd = new SqlCommand("Get_MasterBuku", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr); ;
                dr.Close();
                con.Close();
            }

            return dt;
        }

        public DataTable GetMasterVisitor()
        {
            using (SqlConnection con = new SqlConnection(strconnection))
            {

                SqlCommand cmd = new SqlCommand("Get_MasterVisitor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                dr.Close();
                con.Close();
            }

            return dt;
        }


        public DataTable GetTrxPinjam()
        {
            using (SqlConnection con = new SqlConnection(strconnection))
            {

                SqlCommand cmd = new SqlCommand("Get_TrxPinjam", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                dr.Close();
                con.Close();
            }

            return dt;
        }

        public IEnumerable<LibraryModel.TrxPinjam> GetTrxPinjamByID(int VisitorID)
        {
            List<LibraryModel.TrxPinjam> ListMaster = new List<LibraryModel.TrxPinjam>();

            try
            {
                using (SqlConnection con = new SqlConnection(strconnection))
                {
                    SqlCommand cmd = new SqlCommand("Get_TrxPinjamByID", con);
                    cmd.Parameters.AddWithValue("@VisitorID", VisitorID);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        LibraryModel.TrxPinjam trxPinjam = new LibraryModel.TrxPinjam();
                        trxPinjam.PinjamID = Convert.ToInt32(dr["PinjamID"]);
                        trxPinjam.VisitorID = Convert.ToInt32(dr["VisitorID"]);
                        trxPinjam.BukuID = Convert.ToInt32(dr["BukuID"]);
                        trxPinjam.JudulBuku = dr["JudulBuku"].ToString();
                        trxPinjam.TanggalPinjam = Convert.ToDateTime(dr["TanggalPinjam"]);
                        trxPinjam.TanggalPengembalian = dr["TanggalPengembalian"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["TanggalPengembalian"]);
                        trxPinjam.BatasPinjaman = Convert.ToDateTime(dr["BatasPinjaman"]);
                        trxPinjam.Denda = Convert.ToInt32(dr["Denda"]);
                        trxPinjam.IsDeleted = Convert.ToBoolean(dr["IsDeleted"]);

                        ListMaster.Add(trxPinjam);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }

            return ListMaster;
        }



        public string AddMasterBuku(LibraryModel.MasterBuku model)
        {

            string Message = "";
            try
            {
                using (SqlConnection con = new SqlConnection(strconnection))
                {
                    SqlCommand cmd = new SqlCommand("Add_MasterBuku", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@JudulBuku", model.JudulBuku);
                    cmd.Parameters.AddWithValue("@Kategori", model.Kategori);
                    cmd.Parameters.AddWithValue("@Penerbit", model.Penerbit);
                    cmd.Parameters.AddWithValue("@Penulis", model.Penulis);
                    cmd.Parameters.AddWithValue("@TahunTerbit", model.TahunTerbit);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            if (Message == "")
            {
                Message = "Berhasil Menyimpan";
            }

            return Message;

        }

        public string AddMasterVisitor(LibraryModel.MasterVisitor model)
        {
            string Message = "";
            try
            {
                using (SqlConnection con = new SqlConnection(strconnection))
                {
                    SqlCommand cmd = new SqlCommand("Add_Visitor", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NIK", model.NIK);
                    cmd.Parameters.AddWithValue("@Nama", model.Nama);
                    cmd.Parameters.AddWithValue("@NoTelepon", model.NoTelepon);
                    cmd.Parameters.AddWithValue("@Alamat", model.Alamat);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            if (Message == "")
            {
                Message = "Berhasil Menyimpan";
            }
            return Message;
        }

        public string AddTrxPinjam(LibraryModel.TrxPinjam model)
        {
            string Message = "";
            try
            {
                using (SqlConnection con = new SqlConnection(strconnection))
                {
                    SqlCommand cmd = new SqlCommand("Add_TrxPinjam", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@VisitorID", model.VisitorID);
                    cmd.Parameters.AddWithValue("@BukuID", model.BukuID);
                    cmd.Parameters.AddWithValue("@TanggalPinjam", model.TanggalPinjam);
                    cmd.Parameters.AddWithValue("@BatasPinjaman", model.BatasPinjaman);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            if (Message == "")
            {
                Message = "Berhasil Menyimpan";
            }

            return Message;
        }


        public string UpdateMasterVisitor(LibraryModel.MasterVisitor model)
        {
            string Message = "";
            try
            {
                using (SqlConnection con = new SqlConnection(strconnection))
                {
                    SqlCommand cmd = new SqlCommand("Update_MasterVisitor", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@VisitorID", model.VisitorID);
                    cmd.Parameters.AddWithValue("@NIK", model.NIK);
                    cmd.Parameters.AddWithValue("@Nama", model.Nama);
                    cmd.Parameters.AddWithValue("@NoTelepon", model.NoTelepon);
                    cmd.Parameters.AddWithValue("@Alamat", model.Alamat);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            if (Message == "")
            {
                Message = "Berhasil Menyimpan";
            }
            return Message;
        }

        public string UpdateMasterbuku(LibraryModel.MasterBuku model)
        {
            string Message = "";
            try
            {
                using (SqlConnection con = new SqlConnection(strconnection))
                {
                    SqlCommand cmd = new SqlCommand("Update_MasterBuku", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BukuID", model.BukuID);
                    cmd.Parameters.AddWithValue("@JudulBuku", model.JudulBuku);
                    cmd.Parameters.AddWithValue("@Kategori", model.Kategori);
                    cmd.Parameters.AddWithValue("@Penerbit", model.Penerbit);
                    cmd.Parameters.AddWithValue("@Penulis", model.Penulis);
                    cmd.Parameters.AddWithValue("@TahunTerbit", model.TahunTerbit);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            if (Message == "")
            {
                Message = "Berhasil Menyimpan";
            }
            return Message;
        }

        public string UpdateTrxPinjaman(LibraryModel.TrxPinjam model)
        {
            string Message = "";
            try
            {
                using (SqlConnection con = new SqlConnection(strconnection))
                {
                    SqlCommand cmd = new SqlCommand("Update_TrxPinjamPengembalian", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PinjamID", model.PinjamID);
                    cmd.Parameters.AddWithValue("@TanggalPengembalian", model.TanggalPengembalian);
                    cmd.Parameters.AddWithValue("@BatasPinjaman", model.BatasPinjaman);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            if (Message == "")
            {
                Message = "Berhasil Menyimpan";
            }
            return Message;
        }


        public string DeleteMasterVisitor(LibraryModel.MasterVisitor model)
        {
            string Message = "";
            try
            {
                using (SqlConnection con = new SqlConnection(strconnection))
                {
                    SqlCommand cmd = new SqlCommand("Delete_Visitor", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@VisitorID", model.VisitorID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            if (Message == "")
            {
                Message = "Berhasil dihapus";
            }
            return Message;
        }

        public string DeleteMasterBuku(LibraryModel.MasterBuku model)
        {
            string Message = "";
            try
            {
                using (SqlConnection con = new SqlConnection(strconnection))
                {
                    SqlCommand cmd = new SqlCommand("Delete_MasterBuku", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BukuID", model.BukuID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            if (Message == "")
            {
                Message = "Berhasil dihapus";
            }
            return Message;
        }


        public string DeleteTrxPinjam(LibraryModel.TrxPinjam model)
        {
            string Message = "";
            try
            {
                using (SqlConnection con = new SqlConnection(strconnection))
                {
                    SqlCommand cmd = new SqlCommand("Delete_TrxPinjam", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PinjamID", model.PinjamID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            if (Message == "")
            {
                Message = "Berhasil dihapus";
            }
            return Message;
        }
    }
}
