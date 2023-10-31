using ControleFinanceiro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    public class DepartamentoController : Controller
    {
        public static IList<Departamento> departamentos = new List<Departamento>()
        {
            new Departamento ()
            {
                DepartamentoId = 1,
                Nome = "Administrativo"
            },
            new Departamento()
            {
                DepartamentoId = 2,
                Nome = "Profissional"
            }
        };

        public IActionResult Index()
        {
            return View(departamentos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento departamento) /*sobrecarga */
        {
            departamento.DepartamentoId = departamentos.Select(i => i.DepartamentoId).Max() + 1;
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long id)
        {
            return View(departamentos.Where(i => i.DepartamentoId == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departamento departamento) /*sobrecarga */
        {
            departamentos.Remove(departamentos.Where(i => i.DepartamentoId == departamento.DepartamentoId).First());
            departamentos.Add(departamento);
            return RedirectToAction("Index");
        }
        public ActionResult Details(long id)
        {
            return View(departamentos.Where(i => i.DepartamentoId == id).First());
        }
        public ActionResult Delete(long id)
        {
            return View(departamentos.Where(i => i.DepartamentoId == id).First());
        }
        [HttpPost] /*formulário, vem de objeto */
        [ValidateAntiForgeryToken] /*todo site tem seu token, ele recebe esse token ele verifica se a página que tá enviando a informação tem esse token necessário */
        public ActionResult Delete(Departamento departamento) /*sobrecarga */
        {
            departamentos.Remove(departamentos.Where(i => i.DepartamentoId == departamento.DepartamentoId).First());
            return RedirectToAction("Index");
        }
    }
}
