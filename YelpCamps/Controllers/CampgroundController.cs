using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using YelpCamps.Models;
using YelpCamps.Repositories;
using YelpCamps.ViewModels;

namespace YelpCamp.Controllers
{
    public class CampgroundController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CampgroundController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var myId = User.Identity.GetUserId();
            var me = _unitOfWork.Users.Get(myId);

            if (!string.IsNullOrEmpty(Session["msg"] as string))
            {
                var msg = Session["msg"] as string;
                ViewBag.msg = msg += me.Name;
                Session["msg"] = null;
            }

            var camps = _unitOfWork.Campgrounds.GetAll();
            return View(camps);
        }

        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Session["msg"] = "You Need to Login To Create Campground";
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Create", "Campground") });
            }

            return View();
        }

        [HttpPost, Authorize]
        public ActionResult Create(CampgroundFormVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var myId = User.Identity.GetUserId();
            var me = _unitOfWork.Users.Get(myId);

            var camp = new Campground
            {
                Name = vm.Name,
                Image = vm.Image,
                Description = vm.Description,
                Author = me
            };

            _unitOfWork.Campgrounds.Add(camp);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var camp = _unitOfWork.Campgrounds.GetCampWithRelatedData(id);
            if (camp == null)
                return HttpNotFound("Campground Not Found !");

            var myId = User.Identity.GetUserId();

            var viewModel = new CampDetailVm
            {
                Campground = camp,
                ShowActions = User.Identity.IsAuthenticated,
                IsAuthorized = camp.Author.Id == myId
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var camp = _unitOfWork.Campgrounds.Get(id);
            if (camp == null)
                return HttpNotFound();

            var viewModel = new CampgroundFormVm
            {
                Name = camp.Name,
                Image = camp.Image,
                Description = camp.Description
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(CampgroundFormVm viewModel)
        {
            if (!ModelState.IsValid)
                return View("Edit", viewModel);

            var campInDb = _unitOfWork.Campgrounds.Get(viewModel.Id);
            if (campInDb == null)
                return HttpNotFound("Campground Not Found !");

            campInDb.Name = viewModel.Name;
            campInDb.Image = viewModel.Image;
            campInDb.Description = viewModel.Description;

            _unitOfWork.Complete();

            return RedirectToAction("Detail", "Campground", new { id = viewModel.Id });
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var camp = _unitOfWork.Campgrounds.Get(id);
            if (camp == null)
                return HttpNotFound("Campground Not Found !");

            _unitOfWork.Campgrounds.Remove(camp);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}