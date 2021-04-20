using Microsoft.AspNetCore.Mvc;
using LibraryApp.Model;
using System.Data.SqlClient;
using System.Data;


namespace LibraryApp.Controllers
{
    
    [ApiController]
    public class LibraryController : ControllerBase
    {

        string strconnection = "Data Source=SKUY\\SQLEXPRESS;Initial Catalog=Library;User ID=sa;password=300396;";

        LibraryVM LibraryVM = new LibraryVM();
        LibraryModel model = new LibraryModel();
        DataTable dt = new DataTable();
        string Message = "";

        [HttpGet]
        [Route("api/Library/GetMasterBuku")]
        public JsonResult GetMasterBuku()
        {
             dt =  LibraryVM.GetMasterBuku();
            return new JsonResult(dt);
        }



        [HttpGet]
        [Route("api/Library/GetVisitor")]
        public JsonResult GetMasterVisitor()
        {
            dt = LibraryVM.GetMasterVisitor();
            return new JsonResult(dt);
        }

        [HttpGet]
        [Route("api/Library/GetTrxPinjam")]
        public JsonResult GetTrxPinjam()
        {

            dt = LibraryVM.GetTrxPinjam();
            return new JsonResult(dt);
        }

        [HttpGet]
        [Route("api/Library/GetTrxPinjamByID/{visitorID}")]
        public IActionResult GetTrxPinjamByID(int visitorID)
        {

            return Ok(LibraryVM.GetTrxPinjamByID(visitorID));
        }


        [HttpPost]
        [Route("api/Library/AddMasterBuku")]
        public IActionResult AddMasterBuku(LibraryModel.MasterBuku model)
        {
            
            Message = LibraryVM.AddMasterBuku(model);
            return new JsonResult(Message);

        }


        [HttpPost]
        [Route("api/Library/AddMasterVisitor")]
        public JsonResult AddMasterVisitor(LibraryModel.MasterVisitor model)
        {

            Message = LibraryVM.AddMasterVisitor(model);
            return new JsonResult(Message);
        }


        [HttpPost]
        [Route("api/Library/AddTrxPinjam")]
        public JsonResult AddTrxPinjam(LibraryModel.TrxPinjam model)
        {
            Message = LibraryVM.AddTrxPinjam(model);
            return new JsonResult(Message);
        }



        [HttpPost]
        [Route("api/Library/UpdateMasterVisitor")]
        public JsonResult UpdateMasterVisitor(LibraryModel.MasterVisitor model)
        {

            Message = LibraryVM.UpdateMasterVisitor(model);
            return new JsonResult(Message);
        }

        [HttpPost]
        [Route("api/Library/UpdateMasterbuku")]
        public JsonResult UpdateMasterbuku(LibraryModel.MasterBuku model)
        {

            Message = LibraryVM.UpdateMasterbuku(model);
            return new JsonResult(Message);
        }


        [HttpPost]
        [Route("api/Library/UpdateTrxPinjam")]
        public JsonResult UpdateTrxPinjam(LibraryModel.TrxPinjam model)
        {

            Message = LibraryVM.UpdateTrxPinjaman(model);
            return new JsonResult(Message);
        }

        [HttpPost]
        [Route("api/Library/DeleteMasterVisitor")]
        public JsonResult DeleteMasterVisitor(LibraryModel.MasterVisitor model)
        {

            Message = LibraryVM.DeleteMasterVisitor(model);
            return new JsonResult(Message);
        }

        [HttpPost]
        [Route("api/Library/DeleteMasterbuku")]
        public JsonResult DeleteMasterbuku(LibraryModel.MasterBuku model)
        {

            Message = LibraryVM.DeleteMasterBuku(model);
            return new JsonResult(Message);
        }

        [HttpPost]
        [Route("api/Library/DeleteTrxPinjam")]
        public JsonResult DeleteTrxPinjam(LibraryModel.TrxPinjam model)
        {

            Message = LibraryVM.DeleteTrxPinjam(model);
            return new JsonResult(Message);
        }





    }
}
