using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
 
using Tourismandtravel.Models;
using Tourismandtravel.Repository;

namespace Tourismandtravel.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly FeedbackRepository _feedbackRepository;

        public FeedbackController()
        {
            _feedbackRepository = new FeedbackRepository(new  TourismdbContext());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var feedbackList = _feedbackRepository.GetAllFeedback();
            return View(feedbackList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _feedbackRepository.AddFeedback(feedback);
                return RedirectToAction("Index");
            }

            return View(feedback);
        }
    }
}
