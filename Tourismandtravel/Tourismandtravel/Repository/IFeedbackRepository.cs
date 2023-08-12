using System;
using System.Collections.Generic;
using System.Linq;
using Tourismandtravel.Models;


namespace Tourismandtravel.Repositories
{
    public class FeedbackRepository
    {
        private readonly TourismdbContext _context;

        public FeedbackRepository(TourismdbContext context)
        {
            _context = context;
        }

        public IEnumerable<Feedback> GetAllFeedback()
        {
            return _context.Feedback.ToList();
        }

        public void AddFeedback(Feedback feedback)
        {
            feedback.CreatedAt = DateTime.Now;
            _context.Feedback.Add(feedback);
            _context.SaveChanges();
        }
    }
}
