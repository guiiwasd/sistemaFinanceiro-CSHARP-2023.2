using ControleFinanceiro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    public class InstituicaoController : Controller
    {
        public static IList<Instituicao> instituicoes = new List<Instituicao>()
        {
            new Instituicao ()
            {
                InstituicaoId = 1,
                Nome = "Hogwarts",
                Endereco = "Escocia"
            },
            new Instituicao()
            {
                InstituicaoId = 2,
                Nome = "Mansão X",
                Endereco = "New York"
            }
        };
        public IActionResult Index()
        {
            return View(instituicoes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instituicao instituicao) /*sobrecarga */
        {
            instituicao.InstituicaoId = instituicoes.Select(i => i.InstituicaoId).Max() + 1;
            instituicoes.Add(instituicao);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoId == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Instituicao instituicao) /*sobrecarga */
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoId == instituicao.InstituicaoId).First());
            instituicoes.Add(instituicao);
            return RedirectToAction("Index");
        }
        public ActionResult Details(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoId == id).First());
        }
    }
}
