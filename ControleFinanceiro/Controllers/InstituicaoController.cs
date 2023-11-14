using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Controllers
{
    public class InstituicaoController : Controller
    {   
        private readonly AcademicoContext _context;

        public InstituicaoController(AcademicoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Instituicoes.OrderBy(i => i.Nome).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost] /* formuláio */
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Nome", "Endereco")]Instituicao instituicao) /*sobrecarga */
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(instituicao);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível cadastrar a instituição.");
            }
            return View();
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
        public ActionResult Delete(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoId == id).First());
        }
        [HttpPost] /*formulário, vem de objeto */
        [ValidateAntiForgeryToken] /*todo site tem seu token, ele recebe esse token ele verifica se está correto*/
        public ActionResult Delete(Instituicao instituicao) /*sobrecarga */
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoId == instituicao.InstituicaoId).First());
            return RedirectToAction("Index");
        }
    }
}
