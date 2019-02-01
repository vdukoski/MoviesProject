using PrymApps.Business.DtoModel;
using PrymApps.Business.Service;
using System.Web.Mvc;
namespace PrymApp.WebDemo.Controllers
{
    public class MoviesController : Controller
    {
        MovieService _movieService;

        public MoviesController()
        {
            _movieService = new MovieService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var movieResult = _movieService.LoadAll();
            return View(movieResult.ListItems);
        }

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(DtoMovie movie)
        {
            ServiceResult<DtoMovie> result = _movieService.Add(movie);
            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.ErrorMessage;
                
                return View(movie);
            }
           return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id < 1)
                return RedirectToAction("Index");

            var serviceResult = _movieService.Load(new DtoMovie { Id = id });
            if (serviceResult == null)
                return RedirectToAction("Index");
            return View(serviceResult.Item);
        }

        [HttpPost]
        public ActionResult Edit(int id, DtoMovie item)
        {
            if (id > 0 && (item?.Id ?? 0) > 0 && id == item.Id)
            {
                var dbItem = _movieService.Edit(item);
                if (dbItem.Success)
                    return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var movieResult = _movieService.Load(new DtoMovie { Id = id });
            if (movieResult.Success)
                return View(movieResult.Item);
            else return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id, DtoMovie item)
        {
            if (id > 0 && (item?.Id ?? 0) > 0 && id == item.Id)
            {
                var dbItem = _movieService.Remove(item);
                if (dbItem.Success)
                    return RedirectToAction("Index");
            }
            return View(item);
        }

    }
    }
