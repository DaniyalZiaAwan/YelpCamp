using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using YelpCamp.ViewModels;
using YelpCamps.Models;
using YelpCamps.Repositories;

namespace YelpCamp.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        public ActionResult Create(int campId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Session["msg"] = "You Need to Login To Comment";
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Create", "Campground") });
            }

            var camp = _unitOfWork.Campgrounds.Get(campId);
            if (camp == null)
                return HttpNotFound("CampGround Not Found !!");

            var vm = new CommentFormVm(camp.Id, camp.Name);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(CommentFormVm viewModel)
        {
            var myId = User.Identity.GetUserId();
            var me = _unitOfWork.Users.Get(myId);

            var comment = new Comment(me,
                                      viewModel.Text,
                                      viewModel.CampId);

            _unitOfWork.Comments.Add(comment);
            _unitOfWork.Complete();

            return RedirectToAction("Detail", "Campground", new { id = viewModel.CampId });
        }

        public ActionResult Edit(int id)
        {
            var comment = _unitOfWork.Comments.GetCommentWithRelatedData(id);
            if (comment == null)
                return HttpNotFound();

            var vm = new CommentFormVm
            {
                Text = comment.Text,
                CampName = comment.Campground.Name,
                CampId = comment.Campground.Id,
                CommentId = comment.Id
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(CommentFormVm viewModel)
        {
            if (!ModelState.IsValid)
                return View("Edit", viewModel);

            var comment = _unitOfWork.Comments.Get(viewModel.CommentId);
            if (comment == null)
                return HttpNotFound("comment Not Found !");

            comment.Text = viewModel.Text;

            _unitOfWork.Complete();

            return RedirectToAction("Detail", "Campground", new { id = viewModel.CampId });
        }

        public ActionResult Delete(int id)
        {
            var comment = _unitOfWork.Comments.Get(id);
            if (comment == null)
                return HttpNotFound("Campground Not Found !");

            var campId = comment.CampgroundId;

            _unitOfWork.Comments.Remove(comment);
            _unitOfWork.Complete();

            return RedirectToAction("Detail", "Campground", new { id = campId });
        }
    }
}