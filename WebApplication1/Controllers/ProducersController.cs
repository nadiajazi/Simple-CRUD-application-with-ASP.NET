using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Cinema;

namespace WebApplication1.Controllers

{

    public class ProducersController : Controller
    {
        CinemaDbContext _context;

        public ProducersController(CinemaDbContext context)
        {
            _context = context;

        }




        // GET: ProducersController
        public ActionResult Index()
        {
            var producers = _context.Producers.ToList();
            return View(producers);
        }








        // GET: ProducersController/Create
        public ActionResult Create()
        {
            return View();
        }






        // POST: ProducersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producer producer)
        {
            try
            {

                _context.Producers.Add(producer);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index)); // Redirigez vers l'index après la création réussie

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Une erreur s'est produite lors de la création du producteur.");
            }

            return View(producer);
        }






        // GET: ProducersController/Edit/5
        public ActionResult Edit(int id)
        {
            var producer = _context.Producers.Find(id);
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        // POST: ProducersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Producer producer)
        {
            if (id != producer.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Producers.Update(producer);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(producer);
                }
            }

            // Retourne la vue avec le modèle en cas de ModelState invalide
            return View(producer);
        }


        // GET: ProducersController/Delete/5
        public ActionResult Delete(int id)
        {
            var producer = _context.Producers.Find(id);
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }
        // POST: ProducersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {

                var producer = _context.Producers.Find(id);

                if (producer == null)
                {
                    return NotFound();
                }


                _context.Producers.Remove(producer);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return RedirectToAction(nameof(Index));
            }


        }

        // GET: ProducersController/Details/5
        public ActionResult Details(int id)
        {
            var producer = _context.Producers.Find(id);
            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }


    }


}
